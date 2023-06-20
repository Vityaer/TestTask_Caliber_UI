using System;
using UI.Common;
using UI.Panels.WaitPanel;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI.Panels.Reserves
{
    public class ReservesController : UiController<ReservesView>, IInitializable, IDisposable
    {
        [Inject] private readonly WaitPanelController _waitPanelController;

        private Guid _currentOperationGuid;

        public void Initialize()
        {
            View.CloseButton.onClick.AddListener(Close);
            View.DimedButton.onClick.AddListener(Close);
            View.MedpackUiContainer.BuyReserveButton.onClick.AddListener(StartBuyMedpack);
            View.ArmorPlateUiContainer.BuyReserveButton.onClick.AddListener(StartBuyArmorPlate);
            GameModel.OperationComplete += OnOperationBuyComplete;

            View.MedpackUiContainer.BuyReserveButtonText.text = $"<sprite tint=1 name={Constants.UI.SpriteCoinName}>{GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack].CoinPrice}";
            View.ArmorPlateUiContainer.BuyReserveButtonText.text = $"<sprite tint=1 name={Constants.UI.SpriteCreditName}>{GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate].CreditPrice}";

            RefreshUI();
        }

        protected override void OnOpen()
        {
            GameModel.OperationComplete += OnOperationBuyComplete;
            RefreshUI();
        }

        protected override void OnClose()
        {
            GameModel.OperationComplete -= OnOperationBuyComplete;
        }

        private void StartBuyMedpack()
        {
            
            _currentOperationGuid = GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
            _waitPanelController.Open();

        }

        private void StartBuyArmorPlate()
        {
            _currentOperationGuid = GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
            _waitPanelController.Open();
        }

        private void OnOperationBuyComplete(GameModel.OperationResult result)
        {
            if (_currentOperationGuid == result.Guid)
            {
                if (!result.IsSuccess)
                {
                    Debug.LogError(result.ErrorDescription);
                    return;
                }
            }

            RefreshUI();
        }

        private void RefreshUI()
        {
            View.MedpackUiContainer.BuyReserveButton.interactable = GameModel.CoinCount >= GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack].CoinPrice;
            View.ArmorPlateUiContainer.BuyReserveButton.interactable = GameModel.CreditCount >= GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate].CreditPrice;
        }

        public void Dispose()
        {
            View.DimedButton.onClick.RemoveAllListeners();
            View.CloseButton.onClick.RemoveAllListeners();
            View.MedpackUiContainer.BuyReserveButton.onClick.RemoveAllListeners();
            View.ArmorPlateUiContainer.BuyReserveButton.onClick.RemoveAllListeners();
        }
    }
}
