using System.Threading.Tasks;
using UnityEngine;

public interface IUiPrefabProvider
{
    //TO DO: make normal method and do adapter/decorator to implement async if needed
    Task<GameObject> GetPrefabAsync(ViewType view);
    Task<GameObject> GetPrefabAsync<T>() where T : GenericView;
}
