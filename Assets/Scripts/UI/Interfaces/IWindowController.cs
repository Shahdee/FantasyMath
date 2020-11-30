
namespace UI
{
    public interface IWindowController
    {
        void OpenWindowAndCloseOthers(EWindowType windowType);
        void OpenWindow(EWindowType windowType);
        void HideWindow(EWindowType windowType);
    }
}