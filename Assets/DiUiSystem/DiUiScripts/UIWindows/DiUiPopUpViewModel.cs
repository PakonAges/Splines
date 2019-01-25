using System.Threading.Tasks;
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

        public DiUiPopUpViewModel(IDiUiPrefabProvider prefabProvider) : base (prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public void CloseView()
        {
            GameObject.Destroy(View.gameObject);
        }
    }
}