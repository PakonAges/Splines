using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiPopUpView : UiView<DiUiPopUpView>
    {
        public DiUiPopUpViewModel ViewModel {get { return IViewModel as DiUiPopUpViewModel; }}

        [Binding]
        public void OnClose()
        {
            ViewModel.Close();
        }
    }
}