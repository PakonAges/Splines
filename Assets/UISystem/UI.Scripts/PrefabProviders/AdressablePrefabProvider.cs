using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AdressablePrefabProvider : IUiPrefabProvider
{
    public async Task<GameObject> GetPrefabAsync(ViewType type)
    {
        if (type == ViewType.Invalid)
        {
            Debug.LogError("Trying to get Invalid UI Prefab");
            return null;
        }
        else
        {
            var window = await Addressables.LoadAsset<GameObject>(type.ToString()) as GameObject;
            return window;
        }

        throw new System.NotImplementedException();
    }
}
