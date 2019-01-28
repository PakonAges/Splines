using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiPopUpThatHidesEverrythingView : UiView<DiUiPopUpThatHidesEverrythingView>
    {
        public DiUiPopUpThatHidesEverrythingViewModel ViewModel { get { return IViewModel as DiUiPopUpThatHidesEverrythingViewModel; }}
        
        [Binding]
        public void OnCloseBtn()
        {
            ViewModel.Close();
        }

        [Binding]
        public void OnShowInventoryBtn()
        {
            ViewModel.OpenInventoryView();
        }
    }
}
