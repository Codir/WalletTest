using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace MVC.Saves
{
    public class FileController : ISavesController
    {
        #region fields

        private const string FILE_NAME = "save.json";

        #endregion

        #region public methods

        public async void Load(Action<string> callback)
        {
            try
            {
                var json = await LoadDataAsync(FILE_NAME);
                Debug.Log("Save successful loaded");
                callback?.Invoke(json);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Save loaded with error: {ex.Message}");
            }
        }

        public async void Save(string json)
        {
            try
            {
                await SaveDataAsync(FILE_NAME, json);
                Debug.Log("SaveDataAsync was successful");
            }
            catch (Exception ex)
            {
                Debug.LogError($"SaveDataAsync was fail: {ex.Message}");
            }
        }

        #endregion

        #region private methods

        private async Task SaveDataAsync(string filename, string json)
        {
            using (var writer = new StreamWriter(filename))
            {
                await writer.WriteLineAsync(json);
            }
        }

        private async Task<string> LoadDataAsync(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("Save file not found", filename);
            }

            using (var reader = new StreamReader(filename))
            {
                var json = await reader.ReadLineAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    throw new FormatException("Save load: parsing error");
                }

                return json;
            }
        }

        #endregion
    }
}