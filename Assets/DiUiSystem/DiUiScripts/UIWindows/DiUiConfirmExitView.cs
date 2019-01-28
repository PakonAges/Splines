using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiConfirmExitView : UiView<DiUiConfirmExitView>
    {
        public DiUiConfirmExitViewModel ViewModel { get { return IViewModel as DiUiConfirmExitViewModel; }}

        [Binding]
        public void OnExitGameBtn()
        {
            ViewModel.ExitGame();
        }

        [Binding]
        public void OnCancel()
        {
            ViewModel.Close();
        }
    }
}