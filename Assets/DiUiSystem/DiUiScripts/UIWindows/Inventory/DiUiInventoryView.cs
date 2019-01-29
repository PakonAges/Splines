using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiInventoryView : UiView<DiUiInventoryView>
    {
        public DiUiInventoryViewModel ViewModel { get { return IViewModel as DiUiInventoryViewModel; } }

        [Binding]
        public void OnClose()
        {
            ViewModel.Close();
        }

        [Binding]
        public void OnUpdateClick()
        {
            foreach (var item in ViewModel.InventoryList)
            {
                InventoryItems.Add(item);
            }
            
        }

        [Binding]
        public ObservableList<DiUiInventoryItemViewModel> InventoryItems { get; } = new ObservableList<DiUiInventoryItemViewModel>();
    }
}