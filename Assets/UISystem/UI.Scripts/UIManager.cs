using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace myUi
{
    public class UIManager : IUiManager
    { 
        readonly CanvasBuilder _canvasBuilder;
        readonly UITestDataClass _uITestDataClass;
        CanvasFacade<HUDView> _HUDView;

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

            _HUDView.CanvasMV.Initialize(_uITestDataClass);
        }

        public async Task ShowWindowAsync<T>() where T : GenericView
        {
           await _canvasBuilder.BuildAsync<T>();
        }

        public void UpdateViews(float iDeltaTime)
        {
            _HUDView.Update(iDeltaTime);
        }

        //public async Task ShowWindowAsync(ViewType type)
        //{
        //    try
        //    {
        //        var Window = await getWindowPrefabAsync(type);
        //        GameObject.Instantiate(Window);
        //        _HUDViewModel._HUDView = (HUDView)Window.GetComponent<GenericView>();
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.LogError(e);
        //    }
        //}
    }
}