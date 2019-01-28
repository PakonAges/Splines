using System.Threading.Tasks;
using UnityWeld.Binding;

namespace DiUi
{
    public class DiUiInventoryViewModel : UiViewModel<DiUiInventoryViewModel>
    {
        readonly IInventoryData _inventoryData;
        readonly IInventoryItemSprites _icons;

        DiUiInventoryView _view;
        public DiUiInventoryView View
        {
            get { return IView as DiUiInventoryView; }
            set { _view = value; }
        }

        public DiUiInventoryViewModel(  IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack,
                                        IInventoryData inventoryData,
                                        IInventoryItemSprites icons) : base(prefabProvider, uIViewModelsStack)
        {
            _inventoryData = inventoryData;
            _icons = icons;
        }

        public ObservableList<DiUiInventoryItemViewModel> InventoryList = new ObservableList<DiUiInventoryItemViewModel>();

        public override void Initialize()
        {
            foreach (var item in _inventoryData.MyInventory)
            {
                DiUiInventoryItemViewModel newItem = new DiUiInventoryItemViewModel(_icons.GetIcon(item.Key), item.Value);
                InventoryList.Add(newItem);
            }
        }
    }
}
