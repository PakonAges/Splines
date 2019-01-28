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
            inventoryItems = ViewModel.InventoryList;
        }

        private ObservableList<DiUiInventoryItemViewModel> inventoryItems = new ObservableList<DiUiInventoryItemViewModel>();

        [Binding]
        public ObservableList<DiUiInventoryItemViewModel> InventoryItems
        {
            get { return inventoryItems; }
        }
    }
}