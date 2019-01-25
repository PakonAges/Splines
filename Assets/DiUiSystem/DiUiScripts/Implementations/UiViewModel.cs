namespace DiUi
{
    public abstract class UiViewModel
    {
        internal IDiUiPrefabProvider _prefabProvider;

        public UiViewModel(IDiUiPrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }
    }
}