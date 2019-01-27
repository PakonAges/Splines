using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiHUDView : UiView<DiUiHUDView>
    {
        internal override IDiViewModel IViewModel { get; set; }
        DiUiHUDViewModel _viewModel;
        public DiUiHUDViewModel ViewModel
        {
            get { return IViewModel as DiUiHUDViewModel; }
            set { _viewModel = value; }
        }

        string _realTimeData;

        [Binding]
        public string RealTimeData
        {
            get { return _realTimeData; }
            set
            {
                if (_realTimeData == value)
                {
                    return;
                }

                _realTimeData = value;
                OnPropertyChanged("RealTimeData");
            }

        }

        private string _eventData;

        [Binding]
        public string EventData
        {
            get { return _eventData; }
            set
            {
                if (_eventData == value)
                {
                    return;
                }

                _eventData = value;
                OnPropertyChanged("EventData");
            }
        }

        [Binding]
        public void OnControlCubeBtnClicked()
        {
            ViewModel.ControllCube();
        }

        [Binding]
        public void OnShowPopupBtnClick()
        {
            ViewModel.ShowPopup();
        }

        [Binding]
        public void OnShowHideousPopupBtnClick()
        {
            ViewModel.ShowHideousPopup();
        }

        public void UpdateRealTimeData(Vector3 position)
        {
            RealTimeData = "Cube Position (" + position.x + ";" + position.y + ";" + position.z + ")";
        }

        public void UpdateEventTimeData(MovementDirection direction)
        {
            EventData = "Move Direction: " + direction.ToString();
        }
    }
}