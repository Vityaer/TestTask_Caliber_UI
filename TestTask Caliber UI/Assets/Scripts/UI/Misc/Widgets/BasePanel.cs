using DG.Tweening;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Misc.Widgets
{
    public class BasePanel : UiView
    {
        private const float STRETCH_TIME = 0.1f;
        private const float STRETCH_DEFAULT_TIME = 0.1f;
        private const float SQUEEZE_TIME = 0.1f;
        private const float STRETCH_P0WER = 1.1f;

        public Button CloseButton;
        public Button DimedButton;

        private Sequence _tweenSequence;

        public override void OnShow()
        {
            base.OnShow();
            _tweenSequence.Kill();
            _tweenSequence = DOTween.Sequence()
                                .Append(transform.DOScale(Vector3.one * STRETCH_P0WER, STRETCH_TIME))
                                .Append(transform.DOScale(Vector3.one, STRETCH_DEFAULT_TIME));
        }

        public override void OnHide()
        {
            _tweenSequence.Kill();
            _tweenSequence = DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one * STRETCH_P0WER, STRETCH_TIME))
                .Append(transform.DOScale(Vector3.zero, SQUEEZE_TIME)).OnComplete(() => base.OnHide());
        }
    }
}