using UnityEngine;

namespace DiUi
{
    public interface ICubeDataProvider
    {
        DataCube MyCube { set; }
        Vector3 CubePosition { get; }

        //Get Cube Position = realtimeData
        //Get Cube Movement Direction = Event Update Data
        //Stop/Pause Cube Movement = Pass Commands from UI
    }
}
