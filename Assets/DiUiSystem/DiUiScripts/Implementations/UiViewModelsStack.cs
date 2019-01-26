using System.Collections.Generic;

namespace DiUi
{
    public class UIViewModelsStack : IUIViewModelsStack
    {
        public Stack<UiViewModel> Stack { get; set; }

        public UIViewModelsStack()
        {
            Stack = new Stack<UiViewModel>();
        }

        public void AddViewModel(UiViewModel ViewModel)
        {
            if (Stack.Count > 0)
            {
                //De-activate prev. Menu
                //If bool -> foreach . Canvas disable

                //Setup Canvas Sorting Order
                var TopCanvas = ViewModel.Canvas;
                var PreviousCanvas = Stack.Peek().Canvas;
                TopCanvas.sortingOrder = PreviousCanvas.sortingOrder + 1;
            }

            Stack.Push(ViewModel);
        }
    }
}