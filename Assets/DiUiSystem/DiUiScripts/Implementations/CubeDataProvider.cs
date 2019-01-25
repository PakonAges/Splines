using UnityEngine;

namespace DiUi
{
    public class CubeDataProvider : ICubeDataProvider
    {
        public DataCube MyCube { private get; set; }
        public Vector3 CubePosition{ get { return MyCube.transform.position; } }
    }
}