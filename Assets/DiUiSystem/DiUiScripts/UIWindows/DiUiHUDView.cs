using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiHUDView : UiView
    {
        private DiUiHUDViewModel _myModelView;

        [Binding]
        public int RealTimeDate { get; set; }

        [Binding]
        public int EventData { get; set; }

        [Binding]
        public void OnControlCubeBtnClicked()
        {
            _myModelView.ControllCube();
        }
    }
}