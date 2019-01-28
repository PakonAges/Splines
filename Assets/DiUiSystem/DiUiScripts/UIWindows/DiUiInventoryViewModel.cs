namespace DiUi
{
    public class DiUiInventoryViewModel : UiViewModel<DiUiInventoryViewModel>
    {
        internal override IDiView IView { get; set; }
        DiUiInventoryView _view;
        public DiUiInventoryView View
        {
            get { return IView as DiUiInventoryView; }
            set { _view = value; }
        }

        public DiUiInventoryViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
    }
}
