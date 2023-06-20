using UnityEngine;
using VContainer.Unity;
using VContainer;
using UI.Panels.Reserves;
using UI.Panels.CurrencyExchanges;
using Assets.Scripts.UI.Extensions;
using UI.Windows;
using Initializable;
using UI.Panels.WaitPanel;

namespace Installers
{
    public class MenuUiScope : LifetimeScope
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ReservesView _reservesView;
        [SerializeField] private CurrencyExchangeView _currencyExchangeView;
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private WaitPanelView _waitPanelView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            var canvas = Instantiate(_canvas);
            builder.RegisterUiView<ReservesController, ReservesView>(_reservesView, canvas.transform);
            builder.RegisterUiView<CurrencyExchangeController, CurrencyExchangeView>(_currencyExchangeView, canvas.transform);
            builder.RegisterUiView<MainMenuController, MainMenuView>(_mainMenuView, canvas.transform);
            builder.RegisterUiView<WaitPanelController, WaitPanelView>(_waitPanelView, canvas.transform);

            builder.RegisterEntryPoint<MenuInitialize>();
        }
    }
}
