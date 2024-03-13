using System;
using UnityEngine;
using Utils;

namespace MVC.Saves
{
    public class PlayerPrefsController : ISavesController
    {
        #region fields

        private const string KEY = "PlayerPrefsSaves";

        #endregion

        #region public methods

        public void Load(Action<string> callback)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                if (!PlayerPrefs.HasKey(KEY)) return;

                var data = PlayerPrefs.GetString(KEY);

                callback?.Invoke(data);
            });
        }

        public void Save(string json)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                PlayerPrefs.SetString(KEY, json);
                PlayerPrefs.Save();
            });
        }

        #endregion
    }
}