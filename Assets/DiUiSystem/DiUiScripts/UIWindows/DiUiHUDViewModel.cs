using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : IDiViewModel, ITickable, IInitializable, IDisposable
    {
        readonly SignalBus _signalBus;
        readonly IDiUiPrefabProvider _prefabProvider;
        readonly ICubeDataProvider _dataProvider;
        readonly DiUiPopUpViewModel _popUpVM;

        DiUiHUDView _myView;

        public DiUiHUDViewModel(SignalBus signalBus,
                                IDiUiPrefabProvider prefabProvider,
                                ICubeDataProvider dataProvider,
                                DiUiPopUpViewModel popUp)
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
            if (_myView != null)
            {
                UpdateRealTimeData();
            }
        }

        void UpdateRealTimeData()
        {
            _myView.UpdateRealTimeData(_dataProvider.CubePosition);
        }

        void UpdateEventData(CubeMovementSignal signal)
        {
            _myView.UpdateEventTimeData(signal.Direction);
        }

        public async void ShowPopup()
        {
            await _popUpVM.ShowViewAsync();
        }

        public async Task ShowViewAsync()
        {
            var Prefab = await _prefabProvider.GetWindowPrefab(this);
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<DiUiHUDView>();
            _myView.ViewModel = this;
        }

    }
}