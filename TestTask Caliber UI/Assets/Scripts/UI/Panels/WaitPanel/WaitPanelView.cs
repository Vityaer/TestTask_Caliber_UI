using UI.Common;
using UnityEngine;

namespace UI.Panels.WaitPanel
{
    public class WaitPanelView : UiView
    {
        [field: SerializeField] public RectTransform LoadingCircle { get; private set; }
    }
}
