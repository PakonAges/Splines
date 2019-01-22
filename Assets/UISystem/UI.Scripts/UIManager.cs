using System;
using System.Threading.Tasks;
using UnityEngine;

namespace myUi
{
    /// <summary>
    /// Operates Global UI Logic
    /// </summary>
    public class UIManager : IUiManager
    { 
        readonly CanvasBuilder _canvasBuilder;

        //Data for HUDView Canvas
        readonly UITestDataClass _uITestDataClass;
        CanvasFacade<HUDView> _HUDView;

        bool _initCompleted = false;

        public UIManager(   CanvasBuilder canvasBuilder,
                            UITestDataClass uITestDataClass)
        {
            _canvasBuilder = canvasBuilder;
            _uITestDataClass = uITestDataClass;
        }

        public async Task InitViewsAsync()
        {
            try
            {
                _HUDView = await _canvasBuilder.BuildAsync<HUDView>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            _HUDView.CanvasMV.Initialize(this, _uITestDataClass);
            _initCompleted = true;
        }

        public async Task ShowWindowAsync<T>() where T : GenericView
        {
           await _canvasBuilder.BuildAsync<T>();
        }

        //Pass update call to all views. Updates Data that needs to Update by frame/time
        public void UpdateViews(float iDeltaTime)
        {
            if (_initCompleted)
            {
                _HUDView.Update(iDeltaTime);
            }
        }
    }
}