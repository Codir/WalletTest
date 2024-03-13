using System;

namespace MVC.Saves
{
    public interface ISavesController
    {
        void Load(Action<string> callback);
        void Save(string json);
    }
}