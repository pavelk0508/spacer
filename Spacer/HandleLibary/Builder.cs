using Kompas6API5;
using Kompas6Constants3D;
using System;
using HandleLibary;

namespace SpacerLibary
{
    /// <summary>
    /// Построение проставки.
    /// </summary>
    public class Builder
    {

        /// <summary>
        /// Ссылка на объект, содержащий ссылку на Компас-3Д.
        /// </summary>
        private KompasConnector _kompasConnector;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="kompasConnector">Ссылка на объект подключения к компасу.</param>
        public Builder(KompasConnector kompasConnector)
        {
            if (kompasConnector != null)
            {
                _kompasConnector = kompasConnector;
            }
            else
            {
                throw new ArgumentException("Аргумент конструктора имеет значение NULL.");
            }
        }

        /// <summary>
        /// Построение основного тела объекта.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="innerDiametr">Внутренний диаметр.</param>
        /// <param name="outerDiametr">Внешний диаметр.</param>
        /// <param name="width">Толщина проставки.</param>
        /// <returns>Ссылка на результат.</returns>
        public ksEntity MakeMainObject(ksPart part, float innerDiametr, float outerDiametr, float width)
        {
            var sketch = MakeSketch(part, 0);

            var sketchDefinition = sketch.KsSketchDefinition;

            var entitySketch = sketch.KsEntity;

            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();

            sketchEdit.ksCircle(0, 0, outerDiametr / 2, 1);
            sketchEdit.ksCircle(0, 0, innerDiametr / 2, 1);

            sketchDefinition.EndEdit();

            var solidObject = MakeExtrude(width, part, entitySketch);

            return solidObject;
        }

        /// <summary>
        /// Создание отверстий.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="distanceBetweenHoles">Расстояние между точками.</param>
        /// <param name="width">Толщина проставки.</param>
        /// <param name="countHoles">Количество отверстий</param>
        public void MakeHoles(ksPart part, float distanceBetweenHoles, float width, int countHoles)
        {
            var smallHoles = MakeBaseCircle(part, 12.2f, distanceBetweenHoles / 2);

            var extrudedSmallHole = ExtrusionEntity(part, width, smallHoles);

            var smallCircularHoles = CircularEntity(part, countHoles * 2, extrudedSmallHole);

            var bigCirclesFromOtherSide = MakeBaseCircle(part, 20, -distanceBetweenHoles / 2, 5f);

            if (countHoles % 2 == 0)
            {
                var sin = (float)(-distanceBetweenHoles / 2 * Math.Sin(Math.PI / countHoles));
                var cos = (float)(-distanceBetweenHoles / 2 * Math.Cos(Math.PI / countHoles));
                bigCirclesFromOtherSide = MakeBaseCircle(part, 20, cos, 5f, sin);
            }

            var extrudedBigHoleFromOtherSide = ExtrusionEntity
                (part, width - 5f, bigCirclesFromOtherSide, false);

            var bigCircularHolesFromOtherSide = CircularEntity
                (part, countHoles, extrudedBigHoleFromOtherSide);

            var bigCircles = MakeBaseCircle(part, 20, distanceBetweenHoles / 2);

            var extrudedBigHole = ExtrusionEntity(part, width - 5f, bigCircles);

            var bigCircularHoles = CircularEntity(part, countHoles, extrudedBigHole);

        }

        /// <summary>
        /// Создание центрального отверстия.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="innerDiametr">Внутренний диаметр.</param>
        public void MakeMiddleHole(ksPart part, float innerDiametr)
        {
            var middleCircle = MakeMiddleCircle(part, innerDiametr, 0, 0, -5f);

            var extrudedMiddleCircle = MakeExtrude(5, part, middleCircle, true);

            var champfer = Champfer(part);
        }

        /// <summary>
        /// Построение проставки.
        /// </summary>
        /// <param name="parameters">Параметры проставки.</param>
        public void CreateDetail(Parametrs parametrs)
        {
            if (parametrs == null)
            {
                throw new ArgumentException("Параметры имеют значение NULL.");
            }
            var kompas = _kompasConnector.KompasObject;
            if (kompas != null)
            {
                var document3D = (ksDocument3D)kompas.Document3D();
                document3D.Create(false, true);
            }
            else
            {
                throw new ArgumentException("Компас 3д не запущен!");
            }

            //Параметры модели.
            var innerDiametr = parametrs.InnerDiametr;
            var outerDiametr = parametrs.OuterDiametr;
            var countHoles = parametrs.CountHoles;
            var distanceBetweenHoles = parametrs.Distance;
            var width = parametrs.Width;

            var doc3D = (ksDocument3D)kompas.ActiveDocument3D();

            var part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

            MakeMainObject(part, innerDiametr, outerDiametr, width);

            MakeHoles(part, distanceBetweenHoles, width, countHoles);

            MakeMiddleHole(part, innerDiametr);
        }

        /// <summary>
        /// Создание скетча.
        /// </summary>
        /// <param name="part">Деталь.</param>
        /// <param name="offset">Смещение.</param>
        /// <returns>Ссылка на скетч.</returns>
        public SketchParametrs MakeSketch(ksPart part, float offset)
        {
            var entityPlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = offset;
            planeOffsetDefinition.SetPlane(entityPlane);
            entityOffsetPlane.Create();

            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();

            sketchDefinition.SetPlane(planeOffsetDefinition);
            entitySketch.Create();

            var sketchParametrs = new SketchParametrs(entitySketch, sketchDefinition);

            return sketchParametrs;
        }

        /// <summary>
        /// Создание базового круга определенного диаметра и создание соответствующего эскиза.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="diametr">Диаметр окружности.</param>
        /// <param name="distance">Расстояние от точки 0,0.</param>
        /// <returns>Ссылка на эскиз.</returns>
        public ksEntity MakeBaseCircle(ksPart part, float diametr, float distance, float offset = 0f, float y = 0f)
        {
            var sketch = MakeSketch(part, offset);

            var sketchDefinition = sketch.KsSketchDefinition;

            var entitySketch = sketch.KsEntity;

            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();

            sketchEdit.ksCircle(distance, y, diametr / 2, 1);

            sketchDefinition.EndEdit();
            return entitySketch;
        }

        /// <summary>
        /// Создание эскиза центрального выступа.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="diametr">Диаметр окружности.</param>
        /// <param name="distance">Расстояние от точки 0,0.</param>
        /// <returns>Ссылка на эскиз.</returns>
        public ksEntity MakeMiddleCircle(ksPart part, float diametr, float x, float y, float offset = 0f)
        {
            var sketch = MakeSketch(part, offset);

            var sketchDefinition = sketch.KsSketchDefinition;

            var entitySketch = sketch.KsEntity;

            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();

            sketchEdit.ksCircle(x, y, diametr / 2, 1);
            sketchEdit.ksCircle(x, y, diametr / 2 + 2.5f, 1);

            sketchDefinition.EndEdit();
            return entitySketch;
        }

        /// <summary>
        /// Круговое копирование.
        /// </summary>
        /// <param name="part">Ссылка на объект.</param>
        /// <param name="count">Количество отверстий.</param>
        /// <param name="entityForExtrusion">Эскиз для операции.</param>
        /// <returns>Ссылка на эскиз.</returns>
        public ksEntity CircularEntity(ksPart part, int count, object entityForExtrusion)
        {
            var entityArray = (ksEntity)part.NewEntity((short)Obj3dType.o3d_circularCopy);
            var circularCopy = (ksCircularCopyDefinition)entityArray.GetDefinition();
            var baseAxisOZ =
                (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_axisOZ);
            circularCopy.count1 = 1;
            circularCopy.SetAxis(baseAxisOZ);
            circularCopy.SetCopyParamAlongDir(count, 360 / count, false, false);
            var collection = (ksEntityCollection)circularCopy.GetOperationArray();
            collection.Clear();
            collection.Add(entityForExtrusion);
            entityArray.Create();
            return entityArray;
        }

        /// <summary>
        /// Выдавливание с вырезанием.
        /// </summary>
        /// <param name="part">Ссылка на объект.</param>
        /// <param name="width">Глубина.</param>
        /// <param name="entityForExtrusion">Объект для операции.</param>
        /// <returns>Ссылка на выдавливание.</returns>
        public ksEntity ExtrusionEntity(ksPart part, float width, object entityForExtrusion, bool side = false)
        {
            var entityCutExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            cutExtrusionDefinition.cut = true;
            cutExtrusionDefinition.SetSideParam(side, 0, width, 0, false);
            cutExtrusionDefinition.SetSketch(entityForExtrusion);
            entityCutExtrusion.Create();
            return entityCutExtrusion;
        }

        /// <summary>
        /// Создание выдавливания.
        /// </summary>
        /// <param name="width">Высота.</param>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="entitySketch">Ссылка на скетч.</param>
        /// <param name="toForward">Направление выдавливания.</param>
        /// <returns>Ссылка на результат выдавливания.</returns>
        private ksEntity MakeExtrude(float width, ksPart part, ksEntity entitySketch, bool toForward = true)
        {
            var entityExtrude = (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var entityExtrudeDefinition = (ksBaseExtrusionDefinition)entityExtrude.GetDefinition();
            entityExtrudeDefinition.SetSideParam(toForward, 0, width, 0, true);
            entityExtrudeDefinition.SetSketch(entitySketch);
            entityExtrude.Create();
            return entityExtrude;
        }

        /// <summary>
        /// Фаска.
        /// </summary>
        /// <param name="part">Ссылка на деталь.</param>
        /// <param name="width">Толщина фаски.</param>
        /// <returns>Ссылка на результат операции.</returns>
        private ksEntity Champfer(ksPart part, float width = 1f)
        {
            var entityChamfer = (ksEntity)part.NewEntity((short)Obj3dType.o3d_chamfer);
            var chamferDefinition = (ksChamferDefinition)entityChamfer.GetDefinition();
            chamferDefinition.tangent = false;
            chamferDefinition.SetChamferParam(true, width, width);

            var entityCollectionPart = (ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_face);
            var entityCollectionChamfer = (ksEntityCollection)chamferDefinition.array();

            entityCollectionChamfer.Clear();
            entityCollectionChamfer.Add(entityCollectionPart.GetByIndex(entityCollectionPart.GetCount() - 2));
            entityChamfer.Create();
            return entityChamfer;
        }
    }
}
