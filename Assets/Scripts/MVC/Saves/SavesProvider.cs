using System;
using System.Collections.Generic;

namespace MVC.Saves
{
    public class SavesProvider
    {
        #region fields

        private List<ISavesController> _controllers;

        #endregion

        #region constructor

        public SavesProvider()
        {
            _controllers = new List<ISavesController>
            {
                new PlayerPrefsController()
            };
        }

        #endregion

        #region public methods

        public void Load(Action<string> callback)
        {
            foreach (var controllers in _controllers)
            {
                controllers.Load(callback);
            }
        }

        public void Save(string json)
        {
            foreach (var controllers in _controllers)
            {
                controllers.Save(json);
            }
        }

        #endregion
    }
}