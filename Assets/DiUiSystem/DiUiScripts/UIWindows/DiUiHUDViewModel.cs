using System;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : UiViewModel<DiUiHUDViewModel>, ITickable
    {
        readonly SignalBus _signalBus;
        readonly ICubeDataProvider _dataProvider;

        [Inject] readonly DiUiPopUpViewModel _popUpVM = null;
        [Inject] readonly DiUiConfirmExitViewModel _confirmExit = null;
        [Inject] readonly DiUiPopUpThatHidesEverrythingViewModel _hideousPopUp = null;

        DiUiHUDView _view;
        public DiUiHUDView View
        {
            get { return IView as DiUiHUDView; }
            set { _view = value; }
        }


        public DiUiHUDViewModel(SignalBus signalBus,
                                IDiUiPrefabProvider prefabProvider,
                                ICubeDataProvider dataProvider,
                                IUIViewModelsStack uIViewModelsStack) : base (prefabProvider, uIViewModelsStack)
        {
            _signalBus = signalBus;
            _dataProvider = dataProvider;
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
                await _confirmExit.Open();
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
                await _popUpVM.Open();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public async void ShowHideousPopup()
        {
            try
            {
                await _hideousPopUp.Open();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}