using UI.Windows;
using VContainer;
using VContainer.Unity;

namespace Initializable
{
    public class MenuInitialize : IInitializable
    {
        [Inject] private readonly MainMenuController _mainMenuController;

        public void Initialize()
        {
            _mainMenuController.Open();
        }
    }
}
