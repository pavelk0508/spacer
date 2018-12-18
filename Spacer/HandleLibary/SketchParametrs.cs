using Kompas6API5;

namespace HandleLibary
{
    /// <summary>
    /// Структура для возвращения результата работы.
    /// </summary>
    public class SketchParametrs
    {
        /// <summary>
        /// Ссылка на поверхность.
        /// </summary>
        private ksSketchDefinition _definition;

        /// <summary>
        /// Ссылка на часть детали.
        /// </summary>
        private ksEntity _entity;

        /// <summary>
        /// Конструктор класса выходных параметров.
        /// </summary>
        /// <param name="entity">Ссылка на часть детали.</param>
        /// <param name="sketchDefinition">Ссылка на поверхность.</param>
        public SketchParametrs(ksEntity entity, ksSketchDefinition sketchDefinition)
        {
            _entity = entity;
            _definition = sketchDefinition;
        }

        /// <summary>
        /// Ссылка на поверхность.
        /// </summary>
        public ksSketchDefinition KsSketchDefinition => _definition;

        /// <summary>
        /// Ссылка на часть детали.
        /// </summary>
        public ksEntity KsEntity => _entity;
    }
}
