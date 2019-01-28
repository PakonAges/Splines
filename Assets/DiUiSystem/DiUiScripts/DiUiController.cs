using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiController : MonoBehaviour
    {
        IUIViewModelsStack _viewsStack;
        public GameObject DataCube;
        public KeyCode CubeControllKey = KeyCode.G;
        public KeyCode BackBtn = KeyCode.Escape;

        DiUiHUDViewModel _HUD;
        DiUiPopUpViewModel _popUp;
        DiUiPopUpThatHidesEverrythingViewModel _hiddeousPopUp;
        ICubeDataProvider _cubeData;
        DataCube.Factory _cubeFactory;

        [Inject]
        public void Construct(  IUIViewModelsStack viewsStack,
                                ICubeDataProvider cubeDataProvider,
                                DiUiHUDViewModel HUD,
                                DiUiPopUpViewModel PopUp,
                                DiUiPopUpThatHidesEverrythingViewModel HideousPopup,
                                DataCube.Factory cubeFactory)
        {
            _viewsStack = viewsStack;
            _cubeData = cubeDataProvider;
            _cubeFactory = cubeFactory;

            _HUD = HUD;
            _popUp = PopUp;
            _hiddeousPopUp = HideousPopup;
        }

        async Task Start()
        {
            try
            {
                await _HUD.Open();
                //await _popUp.Open();
                //await _hiddeousPopUp.Open();
                _cubeData.MyCube = _cubeFactory.Create();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

        }

        void Update()
        {
            if (Input.GetKeyDown(CubeControllKey))
            {
                _cubeData.MyCube.ControlTweener();
            } else if (Input.GetKeyDown(BackBtn) && _viewsStack.Stack.Count > 0)
            {
                _viewsStack.CloseTopView();
            }
        }
    }
}