using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiConfirmExitView : UiView<DiUiConfirmExitView>
    {
        internal override IDiViewModel IViewModel { get; set; }
        DiUiConfirmExitViewModel _viewModel;
        public DiUiConfirmExitViewModel ViewModel
        {
            get { return IViewModel as DiUiConfirmExitViewModel; }
            set { _viewModel = value; }
        }

        [Binding]
        public void OnClose()
        {
            ViewModel.ExitGame();
        }

        [Binding]
        public void OnCancel()
        {
            ViewModel.CloseCommand();
        }
    }
}