using System.Threading.Tasks;
using UnityEngine;

namespace DiUi
{
    public abstract class UiViewModel<T> : UiViewModel where T : UiViewModel<T>
    {
        public UiViewModel(IDiUiPrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public virtual async Task ShowViewAsync()
        {
            try
            {
                var Prefab = await _prefabProvider.GetWindowPrefab<T>();
                var ViewGo = GameObject.Instantiate(Prefab);
                IView = ViewGo.GetComponent<IDiView>();
                IView.SetViewModel(this);
            }
            catch (System.Exception  e)
            {
                Debug.LogError(e);
            }
        }
    }

    public abstract class UiViewModel : IDiViewModel
    {
        internal IDiUiPrefabProvider _prefabProvider;
        internal abstract IDiView IView { get; set; }
    }
}