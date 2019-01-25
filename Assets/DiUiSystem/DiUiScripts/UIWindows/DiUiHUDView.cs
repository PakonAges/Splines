
using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiHUDView : UiView
    {
        //private DiUiHUDViewModel _myModelView;

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

        [Binding]
        public int EventData { get; set; }

        [Binding]
        public void OnControlCubeBtnClicked()
        {
            //_myModelView.ControllCube();
        }

        public void UpdateRealTimeData(Vector3 position)
        {
            RealTimeData = "Cube Position (" + position.x + ";" + position.y + ";" + position.z + ")";
        }
    }
}