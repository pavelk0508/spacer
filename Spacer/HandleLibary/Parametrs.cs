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
            if (width != float.NaN && !float.IsInfinity(width))
            {
                Width = width;
            }
            else
            {
                throw new ArgumentException("Некорректное значение толщины.");
            }

            if (innerDiametr == float.NaN && !float.IsInfinity(innerDiametr))
            {
                throw new ArgumentException("Некорректное значение внутреннего диаметра.");
            }

            if (outerDiametr == float.NaN && !float.IsInfinity(outerDiametr))
            {
                throw new ArgumentException("Некорректное значение внешнего диаметра.");
            }

            SetDiametrs(innerDiametr, outerDiametr);
            CountHoles = countHoles;

            if (distance != float.NaN && !float.IsInfinity(distance))
            {
                Distance = distance;
            }
            else
            {
                throw new ArgumentException("Некорректное значение дистанции.");
            }
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
            private set
            {
                if (value >= 10 && value <= 100 )
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
        private void SetDiametrs(float innerDiametr, float outerDiametr)
        {
            if (outerDiametr - innerDiametr >= 80 && 
               innerDiametr >= 0)
            {
                _innerDiametr = innerDiametr;
                _outerDiametr = outerDiametr;
            }
            else
            {
                throw new ArgumentException("Диаметры должны быть положительными числами " +
                                            "и разница между ними должнать быть не менее 80.");
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
            private set
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
            private set
            {
                if (value >= _innerDiametr + 30 && value <= _outerDiametr - 30)
                {
                    _distance = value;
                }
                else
                {
                    throw new ArgumentException($"Дистанция между отверстиями должна быть больше " +
                                                $"{_innerDiametr + 30} и меньше, чем {_outerDiametr - 30}.");
                }
            }
        }
    }
}
