using VContainer;

namespace UI.Common
{
    public abstract class UiController<T> : IUiController
        where T : UiView
    {
        [Inject] protected readonly T View;

        public void Close()
        {
            View.OnHide();
            OnClose();
        }

        public void Open()
        {
            View.transform.SetAsLastSibling();
            View.OnShow();
            OnOpen();

        }

        protected virtual void OnOpen()
        {
        }

        protected virtual void OnClose()
        {
        }
    }
}
