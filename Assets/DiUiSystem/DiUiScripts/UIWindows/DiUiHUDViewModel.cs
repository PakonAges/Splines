using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiHUDViewModel : IDiViewModel, ITickable
    {
        readonly IDiUiPrefabProvider _prefabProvider;
        readonly ICubeDataProvider _dataProvider;
        DiUiHUDView _myView;

        public DiUiHUDViewModel(IDiUiPrefabProvider prefabProvider,
                                ICubeDataProvider dataProvider)
        {
            _prefabProvider = prefabProvider;
            _dataProvider = dataProvider;
        }

        public void ControllCube()
        {
            //pass command from View
        }

        public void Tick()
        {
            if (_myView != null)
            {
                _myView.UpdateRealTimeData(_dataProvider.CubePosition);
            }
        }

        public async Task ShowViewAsync()
        {
            var Prefab = await _prefabProvider.GetWindowPrefab(this);
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<DiUiHUDView>();
            //show Data
        }
    }
}