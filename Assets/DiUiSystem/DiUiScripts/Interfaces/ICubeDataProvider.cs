using UnityEngine;

namespace DiUi
{
    public interface ICubeDataProvider
    {
        DataCube MyCube { get; set; }
        Vector3 CubePosition { get; }
    }
}
