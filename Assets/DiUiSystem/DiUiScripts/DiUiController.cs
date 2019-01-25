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

        [Inject]
        public void Construct(DiUiHUDViewModel HUD)
        {
            _HUD = HUD;
        }

        async Task Start()
        {
            await _HUD.ShowViewAsync();
            Instantiate(DataCube);
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