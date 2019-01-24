using UnityEngine;

namespace DiUi
{
    public class DiUiController : MonoBehaviour
    {
        public GameObject DataCube;
        public KeyCode CubeControllKey = KeyCode.G;

        void Start()
        {
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