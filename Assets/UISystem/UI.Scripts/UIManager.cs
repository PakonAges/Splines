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
        CanvasFacade<MenuView> _OverlayMenu;

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
                _OverlayMenu = await _canvasBuilder.BuildAsync<MenuView>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            _HUDView.CanvasMV.Initialize(this, _uITestDataClass);
            _OverlayMenu.CanvasMV.Initialize(this);
            _OverlayMenu.Enabled = false;

            _initCompleted = true;
        }

        public async Task ShowWindowAsync<T>() where T : GenericView
        {
           await _canvasBuilder.BuildAsync<T>();
            //HA! So I need to pass data/Initializable reffs in InitViewsAsync, so How can I use this method?
        }

        public void CloseWindow(GenericView view)
        {
            GameObject.Destroy(view.gameObject);
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