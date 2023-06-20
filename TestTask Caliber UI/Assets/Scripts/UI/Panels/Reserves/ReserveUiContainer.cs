using TMPro;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Reserves
{
    public class ReserveUiContainer : UiView
    {
        [field: SerializeField] public TMP_Text MainLable { get; private set; }
        [field: SerializeField] public Image MainImage { get; private set; }
        [field: SerializeField] public TMP_Text Count { get; private set; }
        [field: SerializeField] public TMP_Text Decription { get; private set; }
        [field: SerializeField] public Button BuyReserveButton { get; private set; }
        [field: SerializeField] public TMP_Text BuyReserveButtonText { get; private set; }

    }
}
