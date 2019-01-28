﻿using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiInventoryView : UiView<DiUiInventoryView>
    {
        internal override IDiViewModel IViewModel { get; set; }
        DiUiInventoryViewModel _viewModel;
        public DiUiInventoryViewModel ViewModel
        {
            get { return IViewModel as DiUiInventoryViewModel; }
            set { _viewModel = value; }
        }

        [Binding]
        public void OnClose()
        {
            ViewModel.Close();
        }
    }
}