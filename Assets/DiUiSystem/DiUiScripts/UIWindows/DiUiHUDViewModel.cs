using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : IDiViewModel, ITickable
    {
        readonly IDiUiPrefabProvider _prefabProvider;
        UiView _myView;

        public DiUiHUDViewModel(IDiUiPrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
            //Data class
        }

        public void ControllCube()
        {
            //pass command from View
        }

        public void Tick()
        {
            _myView.UpdateRealTimeDate();
        }

        public async Task ShowViewAsync()
        {
            var Prefab = await _prefabProvider.GetWindowPrefab(this);
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<UiView>();
            //show Data
        }
    }
}