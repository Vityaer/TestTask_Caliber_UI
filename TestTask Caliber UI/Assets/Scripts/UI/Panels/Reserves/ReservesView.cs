using TMPro;
using Ui.Misc.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Reserves
{
    public class ReservesView : BasePanel
    {
        [field: SerializeField] public TMP_Text MainLabel { get; private set; }
        [field: SerializeField] public ReserveUiContainer MedpackUiContainer { get; private set; }
        [field: SerializeField] public ReserveUiContainer ArmorPlateUiContainer { get; private set; }

    }
}
