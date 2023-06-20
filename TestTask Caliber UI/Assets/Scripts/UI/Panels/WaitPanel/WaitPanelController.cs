using DG.Tweening;
using System;
using UI.Common;
using UnityEngine;

namespace UI.Panels.WaitPanel
{
    public class WaitPanelController : UiController<WaitPanelView>, IDisposable
    {
        private Tween _tween;

        protected override void OnOpen()
        {
            GameModel.OperationComplete += OnExchangeComplete;
            _tween.Kill();
            _tween = View.LoadingCircle.DOLocalRotate(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }

        private void OnExchangeComplete(GameModel.OperationResult obj)
        {
            GameModel.OperationComplete -= OnExchangeComplete;
            _tween.Kill();
            Close();
        }

        public void Dispose()
        {
            _tween.Kill();
        }
    }
}
