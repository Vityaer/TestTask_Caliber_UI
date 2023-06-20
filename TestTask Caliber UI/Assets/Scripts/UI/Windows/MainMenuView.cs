using TMPro;
using Ui.Misc.CustomComponents;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class MainMenuView : UiView
    {
        [field: SerializeField] public Button ReservesPanelButton { get; private set; }
        [field: SerializeField] public Button CurrencyPanelButton { get; private set; }
        [field: SerializeField] public TMP_Text CoinsCountLabel { get; private set; }
        [field: SerializeField] public TMP_Text CreditsCountLabel { get; private set; }
        [field: SerializeField] public TMP_Text ReservesLabel { get; private set; }
        [field: SerializeField] public TMP_Text MedpackCountLabel { get; private set; }
        [field: SerializeField] public TMP_Text ArmorPlateCountLabel { get; private set; }
        [field: SerializeField] public TextsAutoSize TextsAutoSize { get; private set; } 

    }
}
