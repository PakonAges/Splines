namespace DiUi
{
    public interface IDiView
    {
        bool HideOnClose { get; }
        bool NeedConfirmToClose { get; }
        bool HideAllOtherViews { get; }
        void SetViewModel(IDiViewModel viewModel);
    }
}