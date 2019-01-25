
using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiHUDView : UiView
    {
        public DiUiHUDViewModel ViewModel { private get; set; }

        //public override void InitializeView(DiUiViewModel ViewModel)
        //{
        //    _myModelView = ViewModel;
        //}

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