using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiPopUpView : UiView<DiUiPopUpView>
    {
        DiUiPopUpViewModel _viewModel;
        public DiUiPopUpViewModel ViewModel
        {
            get { return IViewModel as DiUiPopUpViewModel; }
            set { _viewModel = value; }
        }

        [Binding]
        public void OnClose()
        {
            ViewModel.Close();
        }
    }
}