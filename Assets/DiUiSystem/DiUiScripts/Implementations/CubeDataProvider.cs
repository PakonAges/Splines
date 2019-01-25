using UnityEngine;

namespace DiUi
{
    public class CubeDataProvider : ICubeDataProvider
    {
        public DataCube MyCube { get; set; }
        public Vector3 CubePosition{ get { return MyCube.transform.position; } }
    }
}