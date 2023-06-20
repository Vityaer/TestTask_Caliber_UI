using DG.Tweening;
using UnityEngine;

namespace UI.Common
{
    public abstract class UiView : MonoBehaviour
    {
        public virtual void OnShow()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnHide()
        {
            gameObject.SetActive(false);
        }
    }
}
