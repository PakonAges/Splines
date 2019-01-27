namespace DiUi
{
    public class DiUiPopUpThatHidesEverrythingViewModel : UiViewModel<DiUiPopUpThatHidesEverrythingViewModel>
    {
        internal override IDiView IView { get; set; }
        DiUiPopUpThatHidesEverrythingView _view;
        public DiUiPopUpThatHidesEverrythingView View
        {
            get { return IView as DiUiPopUpThatHidesEverrythingView; }
            set { _view = value; }
        }

        public DiUiPopUpThatHidesEverrythingViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack)
        {
            _prefabProvider = prefabProvider;
        }
    }
}
