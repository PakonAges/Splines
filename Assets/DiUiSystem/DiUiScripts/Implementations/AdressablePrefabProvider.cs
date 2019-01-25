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

        //public async Task<GameObject> GetWindowPrefab(IDiViewModel ViewModel)
        //{
        //    try
        //    {
        //        var AssetName = ConvertInterfaceName(ViewModel.GetType().Name.ToString());
        //        var window = await Addressables.LoadAsset<GameObject>(AssetName) as GameObject;
        //        return window;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.LogError(e);
        //        return null;
        //    }
        //}

        //string ConvertInterfaceName(string ViewModelName)
        //{
        //    int index = ViewModelName.Length - 5;
        //    return ViewModelName.Substring(0, index);
        //}

        string ConvertGenericName(string ViewModelName)
        {
            int index = ViewModelName.Length - 5;
            return ViewModelName.Substring(0, index);
        }
    }
}
