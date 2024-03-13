using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECS.Entities;
using MVC.Saves;
using UnityEngine;
using Utils;

namespace MVC
{
    public sealed class CurrencyWalletStorage
    {
        #region fields

        public event Action<CurrencyType, int> OnChangedValue;
        public static CurrencyWalletStorage Instance => _instance ??= new CurrencyWalletStorage();

        private readonly Dictionary<CurrencyType, int> _currencies;
        private static CurrencyWalletStorage _instance;
        private readonly SavesProvider _savesProvider;

        #endregion

        #region constructor

        private CurrencyWalletStorage()
        {
            _currencies = new Dictionary<CurrencyType, int>();
            _savesProvider = new SavesProvider();
        }

        #endregion

        #region public methods

        public void Init()
        {
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            {
                Set(type, 0);
            }

            Load();
        }

        public void Increment(CurrencyType type, int value)
        {
            if (!_currencies.ContainsKey(type))
            {
                _currencies.Add(type, 0);
            }

            _currencies[type] += value;

            ChangedValue(type);
        }

        public void Decrement(CurrencyType type, int value)
        {
            if (!_currencies.ContainsKey(type))
                return;

            _currencies[type] -= value;

            ChangedValue(type);
        }

        public void Clear(CurrencyType type)
        {
            if (!_currencies.ContainsKey(type))
                return;

            _currencies[type] = 0;

            ChangedValue(type);
        }

        #endregion

        #region private methods

        private void Set(CurrencyType type, int value)
        {
            if (!_currencies.ContainsKey(type))
            {
                _currencies.Add(type, 0);
            }

            _currencies[type] = value;

            ChangedValue(type);
        }

        private async void ChangedValue(CurrencyType type)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() => { OnChangedValue.SafeInvoke(type, _currencies[type]); });
            await Save();
        }

        private void Load()
        {
            _savesProvider.Load(OnLoaded);
        }

        private void OnLoaded(string json)
        {
            var loadedData = JsonUtility.FromJson<Dictionary<CurrencyType, int>>(json);

            if (loadedData == null || loadedData.Keys.Count <= 0) return;

            foreach (var (key, value) in loadedData)
            {
                if (!_currencies.ContainsKey(key))
                {
                    _currencies.Add(key, 0);
                }

                _currencies[key] = value;
                OnChangedValue.SafeInvoke(key, _currencies[key]);
            }
        }

        private async Task Save()
        {
            await Task.Run(() =>
            {
                var json = JsonUtility.ToJson(_currencies);

                _savesProvider.Save(json);
            });
        }

        #endregion
    }
}