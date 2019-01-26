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
        ICubeDataProvider _cubeData;
        DataCube.Factory _cubeFactory;

        [Inject]
        public void Construct(  IUIViewModelsStack viewsStack,
                                DiUiHUDViewModel HUD,
                                ICubeDataProvider cubeDataProvider,
                                DataCube.Factory cubeFactory)
        {
            _viewsStack = viewsStack;
            _HUD = HUD;
            _cubeData = cubeDataProvider;
            _cubeFactory = cubeFactory;
        }

        async Task Start()
        {
            try
            {
                await _HUD.ShowViewAsync();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

            _cubeData.MyCube = _cubeFactory.Create();
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