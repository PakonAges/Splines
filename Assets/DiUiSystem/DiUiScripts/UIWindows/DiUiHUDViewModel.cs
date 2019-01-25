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
        DiUiHUDView _myView;

        public DiUiHUDViewModel(SignalBus signalBus,
                                IDiUiPrefabProvider prefabProvider,
                                ICubeDataProvider dataProvider)
        {
            _signalBus = signalBus;
            _prefabProvider = prefabProvider;
            _dataProvider = dataProvider;
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
            //pass command from View
        }

        public void Tick()
        {
            if (_myView != null)
            {
                _myView.UpdateRealTimeData(_dataProvider.CubePosition);
            }
        }

        void UpdateEventData(CubeMovementSignal signal)
        {
            _myView.UpdateEventTimeData(signal.Direction);
        }

        public async Task ShowViewAsync()
        {
            var Prefab = await _prefabProvider.GetWindowPrefab(this);
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<DiUiHUDView>();
        }


    }
}