using System.Threading.Tasks;
using UnityEngine;

namespace DiUi
{
    public class DiUiPopUpViewModel : IDiViewModel
    {
        readonly IDiUiPrefabProvider _prefabProvider; //Same member in all ViewModels!
        DiUiPopUpView _myView;                          //Same member in all ViewModels but type if sub-type

        public DiUiPopUpViewModel(IDiUiPrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public async Task ShowViewAsync() //Same member in all ViewModels!
        {
            var Prefab = await _prefabProvider.GetWindowPrefab(this);
            var ViewGo = GameObject.Instantiate(Prefab);
            _myView = ViewGo.GetComponent<DiUiPopUpView>();
            _myView.ViewModel = this;
        }

        public void CloseView()
        {
            GameObject.Destroy(_myView.gameObject);
        }

    }
}