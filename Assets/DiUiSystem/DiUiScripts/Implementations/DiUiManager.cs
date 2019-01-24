using System.Collections.Generic;
using UnityEngine;

namespace DiUi
{
    public class DiUiManager : IDiUiManager
    {
        readonly IDiUiPrefabProvider _uiPrefabProvider;
        readonly DiUiHUDModelView.Factory _HUDFactory;

        Dictionary<string, IDiViewModel> _VMCollection;

        public DiUiManager (IDiUiPrefabProvider prefabProvider,
                            DiUiHUDModelView.Factory factory)
        {
            _uiPrefabProvider = prefabProvider;
            _HUDFactory = factory;
        }

        public async void ShowWindow<T>() where T : IDiView
        {
            var Prefab = await _uiPrefabProvider.GetWindowPrefab<T>();

            //Create ModelView class from Fabric. Which Fabric?

            GameObject.Instantiate(Prefab);
        }
    }
}
