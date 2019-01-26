using System.Collections.Generic;

namespace DiUi
{
    public interface IUIViewModelsStack
    {
        Stack<UiViewModel> Stack { get; set; }
        void AddViewModel(UiViewModel ViewModel);
    }
}
