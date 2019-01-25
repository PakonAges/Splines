using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiPopUpView : UiView
    {
        public DiUiPopUpViewModel ViewModel { private get; set; }

        [Binding]
        public void OnClose()
        {
            ViewModel.CloseView();
        }
    }
}