using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace myUi
{
    public class AdressablePrefabProvider : IUiPrefabProvider
    {
        public async Task<GameObject> GetPrefabAsync<T>() where T : GenericView
        {
            try
            {
                var window = await Addressables.LoadAsset<GameObject>(typeof(T).Name.ToString()) as GameObject;
                return window;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }

        }
    }
}