using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiController : MonoBehaviour
    {
        public GameObject DataCube;
        public KeyCode CubeControllKey = KeyCode.G;

        DiUiHUDViewModel _HUD;
        ICubeDataProvider _cubeData;
        DataCube.Factory _cubeFactory;

        [Inject]
        public void Construct(  DiUiHUDViewModel HUD,
                                ICubeDataProvider cubeDataProvider,
                                DataCube.Factory cubeFactory)
        {
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
                Debug.Log("Cube control Commad pass");
            }
        }
    }
}