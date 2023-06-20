using System;
using System.Globalization;
using UI.Common;
using UI.Panels.CurrencyExchanges;
using UI.Panels.Reserves;
using UI.Utils;
using VContainer;
using VContainer.Unity;

namespace UI.Windows
{
    public class MainMenuController : UiController<MainMenuView>, IInitializable, IDisposable
    {
        [Inject] private readonly CurrencyExchangeController _currencyExchangeController;
        [Inject] private readonly ReservesController _reservesController;

        private NumberFormatInfo _numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;

        public void Initialize()
        {
            _numberFormatInfo.NumberGroupSeparator = " ";

            RefreshUI();
            View.CurrencyPanelButton.onClick.AddListener(OpenCurrencyPanel);
            View.ReservesPanelButton.onClick.AddListener(OpenReservesPanel);
            GameModel.OperationComplete += OnOperationBuyComplete;
        }

        protected override void OnOpen()
        {
            RefreshUI();
        }

        private void OpenCurrencyPanel()
        {
            _currencyExchangeController.Open();
        }

        private void OpenReservesPanel()
        {
            _reservesController.Open();
        }

        private void OnOperationBuyComplete(GameModel.OperationResult result)
        {
            if (result.IsSuccess)
            {
                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            View.MedpackCountLabel.text = $"{GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack)}";
            View.ArmorPlateCountLabel.text = $"{GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate)}";

            View.CoinsCountLabel.text =
                string.Concat
                (
                    $"{TextUtils.SpriteWithInheritColor(Constants.UI.SpriteCoinName)}",
                    string.Format(GameModel.CoinCount.ToString("N0", _numberFormatInfo))
                );

            View.CreditsCountLabel.text =
                string.Concat
                (
                    $"{TextUtils.SpriteWithInheritColor(Constants.UI.SpriteCreditName)}",
                    string.Format(GameModel.CreditCount.ToString("N0", _numberFormatInfo))
                );

            View.TextsAutoSize.CheckMaxCountChar();
        }

        public void Dispose()
        {
            GameModel.OperationComplete -= OnOperationBuyComplete;
            View.CurrencyPanelButton.onClick.RemoveAllListeners();
            View.ReservesPanelButton.onClick.RemoveAllListeners();
        }
    }
}
