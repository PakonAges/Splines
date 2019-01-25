using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : UiViewModel<DiUiHUDViewModel>, IDiViewModel, ITickable, IInitializable, IDisposable
    {
        readonly SignalBus _signalBus;
        readonly ICubeDataProvider _dataProvider;
        readonly DiUiPopUpViewModel _popUpVM;

        internal override IDiView IView { get; set; }

        DiUiHUDView _view;
        public DiUiHUDView View
        {
            get { return IView as DiUiHUDView; }
            set { _view = value; }
        }

        public DiUiHUDViewModel(SignalBus signalBus,
                                IDiUiPrefabProvider prefabProvider,
                                ICubeDataProvider dataProvider,
                                DiUiPopUpViewModel popUp) : base (prefabProvider)
        {
            _signalBus = signalBus;
            _prefabProvider = prefabProvider;
            _dataProvider = dataProvider;
            _popUpVM = popUp;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<CubeMovementSignal>(UpdateEventData);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<CubeMovementSignal>(UpdateEventData);
        }

        public void ControllCube()
        {
            _dataProvider.MyCube.ControlTweener();
        }

        //Update real-time Data
        public void Tick()
        {
            if (IView != null)
            {
                UpdateRealTimeData();
            }
        }

        void UpdateRealTimeData()
        {
            View.UpdateRealTimeData(_dataProvider.CubePosition);
        }

        void UpdateEventData(CubeMovementSignal signal)
        {
            View.UpdateEventTimeData(signal.Direction);
        }

        public async void ShowPopup()
        {
            try
            {
                await _popUpVM.ShowViewAsync();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}