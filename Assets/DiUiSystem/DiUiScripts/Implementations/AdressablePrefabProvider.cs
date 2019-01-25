using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DiUi
{
    public class AdressablePrefabProvider : IDiUiPrefabProvider
    {
        public async Task<GameObject> GetWindowPrefab<T>() where T : UiViewModel
        {
            try
            {
                var AssetName = ConvertGenericName(typeof(T).Name.ToString());
                var window = await Addressables.LoadAsset<GameObject>(AssetName) as GameObject;
                return window;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }

        }

        string ConvertGenericName(string ViewModelName)
        {
            int index = ViewModelName.Length - 5;
            return ViewModelName.Substring(0, index);
        }
    }
}
