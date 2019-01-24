namespace DiUi
{
    public interface IDiUiManager 
    {
        void ShowWindow<T>() where T : IDiView;
    }
}
