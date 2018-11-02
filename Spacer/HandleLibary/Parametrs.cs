using System;

namespace SpacerLibary
{
    /// <summary>
    /// Параметры построения.
    /// </summary>
    public class Parametrs
    {
        private float _width;
        private float _innerDiametr;
        private float _outerDiametr;
        private int _countHoles;
        private float _distance;
        
        /// <summary>
        /// Создание параметров.
        /// </summary>
        /// <param name="width">Толщина.</param>
        /// <param name="innerDiametr">Внутренний диаметр.</param>
        /// <param name="outerDiametr">Внешний диаметр.</param>
        /// <param name="countHoles">Количество отверстий.</param>
        /// <param name="distance">Расстояние между отверстиями.</param>
        public Parametrs(float width, float innerDiametr, float outerDiametr, int countHoles, float distance)
        {
            Width = width;
            SetDiametrs(innerDiametr, outerDiametr);
            CountHoles = countHoles;
            Distance = distance;
        }

        /// <summary>
        /// Толщина проставки.
        /// </summary>
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                if(value >= 10 && value <= 100)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException("Диапазон толщины проставки должен находиться в диапазон [10,100]");
                }
            }
        }

        /// <summary>
        /// Задать диаметры.
        /// </summary>
        /// <param name="innerDiametr">Внутренний.</param>
        /// <param name="outerDiametr">Внешний.</param>
        public void SetDiametrs(float innerDiametr, float outerDiametr)
        {
            if(outerDiametr - innerDiametr >= 80 && 
               innerDiametr > 0)
            {
                _innerDiametr = innerDiametr;
                _outerDiametr = outerDiametr;
            }
            else
            {
                throw new ArgumentException("Диаметры должны быть положительными числами и разница между ними должнать буть не менее 80.");
            }
        }

        /// <summary>
        /// Внутренний диаметр.
        /// </summary>
        public float InnerDiametr
        {
            get
            {
                return _innerDiametr;
            }
        }

        /// <summary>
        /// Внешний диаметр.
        /// </summary>
        public float OuterDiametr
        {
            get
            {
                return _outerDiametr;
            }
        }

        /// <summary>
        /// Количество отверстий.
        /// </summary>
        public int CountHoles
        {
            get
            {
                return _countHoles;
            }
            set
            {
                if (value >= 4 && value <= 6)
                {
                    _countHoles = value;
                }
                else
                {
                    throw new ArgumentException("Количество отверстий должно находиться в диапазоне от 4 до 6.");
                }
            }
        }

        /// <summary>
        /// Расстояние между отверстиями.
        /// </summary>
        public float Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if(value >= _innerDiametr+10 && value <= _outerDiametr-10)
                {
                    _distance = value;
                }
                else
                {
                    throw new ArgumentException($"Дистанция между отверстиями должна быть больше {_innerDiametr+10} и меньше, чем {_outerDiametr-10}.");
                }
            }
        }
    }
}
