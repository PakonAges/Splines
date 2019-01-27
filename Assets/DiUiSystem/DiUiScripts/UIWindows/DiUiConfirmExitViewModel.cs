namespace DiUi
{
    public class DiUiConfirmExitViewModel : UiViewModel<DiUiConfirmExitViewModel>
    {
        internal override IDiView IView { get; set; }
        DiUiConfirmExitView _view;
        public DiUiConfirmExitView View
        {
            get { return IView as DiUiConfirmExitView; }
            set { _view = value; }
        }

        public DiUiConfirmExitViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack)
        {
            _prefabProvider = prefabProvider;
        }

        public void ExitGame()
        {
            // save any game data here
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}