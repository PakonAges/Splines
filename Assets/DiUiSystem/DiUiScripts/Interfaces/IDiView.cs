namespace DiUi
{
    public interface IDiView
    {
        bool HideOnClose { get; }
        void SetViewModel(IDiViewModel viewModel);
    }
}