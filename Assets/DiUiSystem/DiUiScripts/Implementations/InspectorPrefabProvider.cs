using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DiUi
{
    public class InspectorPrefabProvider : MonoBehaviour, IDiUiPrefabProvider
    {
        public List<GameObject> Views;

        public Task<GameObject> GetWindowPrefab<T>() where T : IDiView
        {
            throw new System.NotImplementedException();
        }

        //public Task<GameObject> GetWindowPrefab<T>() where T : IDiWindow
        //{
        //    return await GetPrefabFromInspector(typeof(T).Name.ToString());
        //}

        GameObject GetPrefabFromInspector(string Name)
        {
            for (int i = 0; i < Views.Count; i++)
            {
                if (Views[i].name == Name)
                {
                    return Views[i];
                }
            }

            Debug.LogErrorFormat("Can't Find View with name: {0}", Name);
            return null;
        }
    }
}
