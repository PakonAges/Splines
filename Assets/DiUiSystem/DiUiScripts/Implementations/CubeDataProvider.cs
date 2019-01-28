using UnityEngine;

namespace DiUi
{
    public class CubeDataProvider : ICubeDataProvider
    {
        public DataCube MyCube { get; set; }
        public Vector3 CubePosition
        {
            get
            {
                if (MyCube != null)
                {
                    return MyCube.transform.position;
                }
                else
                {
                    return Vector3.zero;
                }

            }
        }
    }
}