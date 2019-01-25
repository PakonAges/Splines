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
            var Prefab = await _prefabProvider.GetWindowPrefab<T>();
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<UiView>();
            _myView.SetViewModel(this);
        }
    }

    public abstract class UiViewModel
    {
        internal IDiUiPrefabProvider _prefabProvider;
        internal UiView _myView;
    }
}