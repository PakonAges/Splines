namespace DiUi
{
    public interface IDiView
    {
        //void SetViewModel<T>(T ViewModel) where T : UiViewModel;
        void SetViewModel(IDiViewModel viewModel);
    }
}