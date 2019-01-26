using UnityEngine;

namespace DiUi
{
    public class DiUiPopUpViewModel : UiViewModel<DiUiPopUpViewModel>, IDiViewModel
    {
        internal override IDiView IView { get; set; }
        DiUiPopUpView _view;
        public DiUiPopUpView View
        {
            get { return IView as DiUiPopUpView; }
            set { _view = value; }
        }

        public DiUiPopUpViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base (prefabProvider, uIViewModelsStack)
        {
            _prefabProvider = prefabProvider;
        }

        public override void Close()
        {
            GameObject.Destroy(View.gameObject);
            //Remove from stack? but it assumes that Im at the top. which is can  be untrue
        }
    }
}