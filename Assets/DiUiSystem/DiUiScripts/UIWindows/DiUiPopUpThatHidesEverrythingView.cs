using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiPopUpThatHidesEverrythingView : UiView<DiUiPopUpThatHidesEverrythingView>
    {
        DiUiPopUpThatHidesEverrythingViewModel _viewModel;
        public DiUiPopUpThatHidesEverrythingViewModel ViewModel
        {
            get { return IViewModel as DiUiPopUpThatHidesEverrythingViewModel; }
            set { _viewModel = value; }
        }
        
        [Binding]
        public void OnCloseBtn()
        {
            ViewModel.Close();
        }

        [Binding]
        public async void OnShowInventoryBtn()
        {
            await ViewModel.OpenInventoryView();
        }
    }
}
