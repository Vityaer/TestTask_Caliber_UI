using System;
using System.Globalization;
using UI.Common;
using UI.Panels.WaitPanel;
using UI.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Utils;
using DG.Tweening;

namespace UI.Panels.CurrencyExchanges
{
    public class CurrencyExchangeController : UiController<CurrencyExchangeView>, IInitializable, IDisposable
    {
        private const float AnimationTime = 0.3f;

        [Inject] private readonly WaitPanelController _waitPanelController;

        private Guid _currentOperationGuid;
        private NumberFormatInfo _numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
        private int _previousResultCredit;
        private Tween _tween;

        public void Initialize()
        {
            _numberFormatInfo.NumberGroupSeparator = " ";

            View.DimedButton.onClick.AddListener(Close);
            View.CancelButton.onClick.AddListener(Close);
            View.ExchangeButton.onClick.AddListener(StartCurrencyExchange);
            View.CoinInputField.onValueChanged.AddListener(OnEditInputFieldCoins);

            View.Rate.text = string.Concat
                (
                    $"{TextUtils.SpriteWithColor(Constants.UI.SpriteCoinName, Constants.Color.Orange)}",
                    " 1 = ",
                    $"{TextUtils.SpriteWithColor(Constants.UI.SpriteCreditName, Constants.Color.Blue)}",
                    " ",
                    $"{GameModel.CoinToCreditRate}"
                );

            RefreshUI();
        }

        protected override void OnOpen()
        {
            GameModel.OperationComplete += OnExchangeComplete;
            RefreshUI();
        }

        protected override void OnClose()
        {
            GameModel.OperationComplete -= OnExchangeComplete;
        }

        private void OnEditInputFieldCoins(string text)
        {
            if (int.TryParse(View.CoinInputField.text, out int currentInputedCoinCount))
            {
                if(currentInputedCoinCount < 0)
                {
                    currentInputedCoinCount = Mathf.Abs(currentInputedCoinCount);
                    View.CoinInputField.text = $"{currentInputedCoinCount}";
                }

                var calculateCredit = currentInputedCoinCount * GameModel.CoinToCreditRate;

                SetCreditResult(calculateCredit);
                var checkCoins = (currentInputedCoinCount > 0 && currentInputedCoinCount <= GameModel.CoinCount);
                View.ExchangeButton.interactable = checkCoins;
            }
            else
            {
                View.ExchangeButton.interactable = false;
                SetCreditResult(0);
            }
        }

        private void StartCurrencyExchange()
        {
            View.ExchangeButton.interactable = false;
            if (int.TryParse(View.CoinInputField.text, out int currentInputedCoinCount))
            {
                if (currentInputedCoinCount <= 0)
                    return;

                _currentOperationGuid = GameModel.ConvertCoinToCredit(currentInputedCoinCount);
                _waitPanelController.Open();
            }

        }

        private void OnExchangeComplete(GameModel.OperationResult result)
        {
            if (_currentOperationGuid == result.Guid)
            {
                if (!result.IsSuccess)
                {
                    Debug.LogError(result.ErrorDescription);
                    return;
                }

                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            SetCreditResult(0);
            View.CoinInputField.text = string.Empty;
            View.StorageCoinCount.text = $"{TextUtils.SpriteWithInheritColor(Constants.UI.SpriteCoinName)} {string.Format(GameModel.CoinCount.ToString("N0", _numberFormatInfo))}";
            View.StorageCreditCount.text = $"{TextUtils.SpriteWithInheritColor(Constants.UI.SpriteCreditName)} {string.Format(GameModel.CreditCount.ToString("N0", _numberFormatInfo))}";
            View.ExchangeButton.interactable = false;
        }

        private void SetCreditResult(int count)
        {
            var prefix = string.Concat
                (
                    " = ",
                    $"{TextUtils.SpriteWithColor(Constants.UI.SpriteCreditName, Constants.Color.Blue)}"
                );

            _tween.Kill();
            _tween = View.CreditResult.DOCounter(_previousResultCredit, count, AnimationTime, prefix, _numberFormatInfo);
            //View.CreditResult.text = string.Concat
            //    (
            //        " = ",
            //        $"{TextUtils.SpriteWithColor(Constants.UI.SpriteCreditName, Constants.Color.Blue)}",
            //        string.Format(count.ToString("N0", _numberFormatInfo))
            //    );
        }

        public void Dispose()
        {
            _tween.Kill();
            GameModel.OperationComplete -= OnExchangeComplete;
            View.DimedButton.onClick.RemoveAllListeners();
            View.ExchangeButton.onClick.RemoveAllListeners();
            View.CancelButton.onClick.RemoveAllListeners();
            View.CoinInputField.onEndEdit.RemoveAllListeners();
        }
    }
}
