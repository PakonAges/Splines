using System;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : UiViewModel<DiUiHUDViewModel>, IDiViewModel, ITickable
    {
        readonly SignalBus _signalBus;
        readonly ICubeDataProvider _dataProvider;
        readonly DiUiPopUpViewModel _popUpVM;
        readonly DiUiConfirmExitViewModel _confirmExit;

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
                                IUIViewModelsStack uIViewModelsStack,
                                DiUiPopUpViewModel popUp,
                                DiUiConfirmExitViewModel diUiConfirmExit) : base (prefabProvider, uIViewModelsStack)
        {
            _signalBus = signalBus;
            _prefabProvider = prefabProvider;
            _dataProvider = dataProvider;
            _popUpVM = popUp;
            _confirmExit = diUiConfirmExit;
        }

        public override void Initialize()
        {
            _signalBus.Subscribe<CubeMovementSignal>(UpdateEventData);
        }

        public override void Dispose()
        {
            _signalBus.Unsubscribe<CubeMovementSignal>(UpdateEventData);
            base.Dispose();
        }

        //Update real-time Data
        public void Tick()
        {
            if (IView != null)
            {
                UpdateRealTimeData();
            }
        }

        public async override void ShowConfirmToClose()
        {
            try
            {
                await _confirmExit.ShowViewAsync();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
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

        public void ControllCube()
        {
            _dataProvider.MyCube.ControlTweener();
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