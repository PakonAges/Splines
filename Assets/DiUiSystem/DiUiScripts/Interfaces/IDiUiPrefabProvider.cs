using System.Threading.Tasks;
using UnityEngine;

namespace DiUi
{
    public interface IDiUiPrefabProvider
    {
        Task<GameObject> GetWindowPrefab<T>() where T : UiViewModel;
        //Task<GameObject> GetWindowPrefab(IDiViewModel ViewModel);
    }
}