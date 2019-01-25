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

        [Inject]
        public void Construct(  DiUiHUDViewModel HUD,
                                ICubeDataProvider cubeDataProvider)
        {
            _HUD = HUD;
            _cubeData = cubeDataProvider;
        }

        async Task Start()
        {
            await _HUD.ShowViewAsync();
            _cubeData.MyCube = Instantiate(DataCube).GetComponent<DataCube>();
        }

        void Update()
        {
            if (Input.GetKeyDown(CubeControllKey))
            {
                DataCube.GetComponent<DataCube>().ControlTweener();
                Debug.Log("Cube control Commad pass");
            }
        }
    }
}