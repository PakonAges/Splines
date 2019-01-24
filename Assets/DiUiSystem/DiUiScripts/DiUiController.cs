using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiController : MonoBehaviour
    {
        public GameObject DataCube;
        public KeyCode CubeControllKey = KeyCode.G;

        IDiUiManager _uiManager;

        [Inject]
        public void Construct(IDiUiManager uiManager)
        {
            _uiManager = uiManager;
        }

        void Start()
        {
            //_uiManager.ShowWindow<DiUiHUDView>();
            Instantiate(DataCube);
        }

        void Update()
        {
            if (Input.GetKeyDown(CubeControllKey))
            {
                DataCube.GetComponent<DataCube>().ControlTweener();
            }
        }
    }
}