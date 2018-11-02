using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacerLibary
{
    /// <summary>
    /// Построение проставки.
    /// </summary>
    public class Builder
    {
        private KompasConnector _kompasConnector;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="kompasConnector"></param>
        public Builder(KompasConnector kompasConnector)
        {
            _kompasConnector = kompasConnector;
        }

        /// <summary>
        /// Построение проставки.
        /// </summary>
        /// <param name="parameters"></param>
        public void CreateDetail(Parametrs parametrs)
        {
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

            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch); 

            var sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition(); 

            var plane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ); 

            sketchDefinition.SetPlane(plane);   
            entitySketch.Create(); 

            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();

            sketchEdit.ksCircle(0, 0, outerDiametr, 0);

            sketchDefinition.EndEdit();

        }
    }
}
