using Kompas6API5;
using System;

namespace SpacerLibary
{
    /// <summary>
    /// Работа с компасом.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Ссылка на окно Kompas-3D.
        /// </summary>
        private KompasObject _kompasObject;

        /// <summary>
        /// Объект компаса.
        /// </summary>
        public KompasObject KompasObject
        {
            get
            {
                return _kompasObject;
            }
            set
            {
                _kompasObject = value;
            }
        }

        /// <summary>
        /// Запуск компаса.
        /// </summary>
        public void StartKompas()
        {
            if (_kompasObject == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(type);
            }

            if (_kompasObject != null)
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Закрытие компаса.
        /// </summary>
        public void CloseKompas()
        {
            try
            {
                _kompasObject.Quit();
                _kompasObject = null;
            }
            catch
            {
                _kompasObject = null;
            }

        }

    }
}
