namespace DiUi
{
    public interface IDiView
    {
        bool HideOnClose { get; }
        bool NeedConfirmToClose { get; }
        void SetViewModel(IDiViewModel viewModel);
    }
}