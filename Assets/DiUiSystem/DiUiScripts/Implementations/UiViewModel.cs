namespace DiUi
{
    public abstract class UiViewModel<T> : UiViewModel where T : UiViewModel<T>
    {
        internal IDiUiPrefabProvider _prefabProvider;

        public UiViewModel(IDiUiPrefabProvider prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }
    }

    public abstract class UiViewModel
    {

    }
}