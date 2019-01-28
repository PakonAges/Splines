namespace DiUi
{
    public class DiUiPopUpViewModel : UiViewModel<DiUiPopUpViewModel>
    {
        DiUiPopUpView _view;
        public DiUiPopUpView View
        {
            get { return IView as DiUiPopUpView; }
            set { _view = value; }
        }

        public DiUiPopUpViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base (prefabProvider, uIViewModelsStack) { }

    }
}