using System;
using ECS.Entities;
using TMPro;
using UnityEngine;

namespace MVC
{
    public class WalletUIView : MonoBehaviour
    {
        #region serialize fields

        [SerializeField] private TextMeshProUGUI CoinsLabel;
        [SerializeField] private TextMeshProUGUI CrystalsLabel;

        #endregion

        #region fields

        private string _coinsLabelFormat;
        private string _crystalsLabelFormat;

        #endregion

        #region engine methods

        private void Awake()
        {
            _coinsLabelFormat = CoinsLabel.text;
            _crystalsLabelFormat = CrystalsLabel.text;
        }

        private void Start()
        {
            CurrencyWalletStorage.Instance.OnChangedValue += OnChangedValue;
            CurrencyWalletStorage.Instance.Init();
        }

        private void OnDestroy()
        {
            CurrencyWalletStorage.Instance.OnChangedValue -= OnChangedValue;
        }

        #endregion

        #region private methods

        private void OnChangedValue(CurrencyType type, int value)
        {
            switch (type)
            {
                case CurrencyType.Coins:
                    CoinsLabel.text = string.Format(_coinsLabelFormat, value);
                    break;
                case CurrencyType.Crystals:
                    CrystalsLabel.text = string.Format(_crystalsLabelFormat, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        #endregion
    }
}