using System.Collections.Generic;
using UnityEngine;

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

        public void CloseTopView()
        {
            var TopView = Stack.Pop();
            TopView.Close();
        }

        //Assumes that I want to close only top view? is it correct?
        public void Close(UiViewModel ViewModel)
        {
            if (Stack.Count == 0)
            {
                Debug.LogErrorFormat("Trying to close Viev: {0}, But Stack is empty", ViewModel);
                return;
            }

            if (Stack.Peek() != ViewModel)
            {
                Debug.LogErrorFormat("Trying to close View ({0}), but it isn't at the top of the Stack", ViewModel);
                return;
            }

            CloseTopView();
        }
    }
}