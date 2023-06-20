using TMPro;
using Ui.Misc.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.CurrencyExchanges
{
    public class CurrencyExchangeView : BasePanel
    {
        [field: SerializeField] public TMP_Text MainLabel { get; private set; }
        [field: SerializeField] public TMP_Text Rate { get; private set; }
        [field: SerializeField] public TMP_Text StorageCoinCount { get; private set; }
        [field: SerializeField] public TMP_Text StorageCreditCount { get; private set; }
        [field: SerializeField] public TMP_Text CreditResult { get; private set; }
        [field: SerializeField] public TMP_InputField CoinInputField { get; private set; }
        [field: SerializeField] public TMP_Text CointPlaceholder { get; private set; }
        [field: SerializeField] public Button ExchangeButton { get; private set; }
        [field: SerializeField] public TMP_Text ExchangeButtonText { get; private set; }
        [field: SerializeField] public Button CancelButton { get; private set; }
        [field: SerializeField] public TMP_Text CancelButtonText { get; private set; }
    }
}
