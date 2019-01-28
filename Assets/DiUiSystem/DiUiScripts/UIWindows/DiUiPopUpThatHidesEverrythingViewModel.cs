using System.Threading.Tasks;
using Zenject;

namespace DiUi
{
    public class DiUiPopUpThatHidesEverrythingViewModel : UiViewModel<DiUiPopUpThatHidesEverrythingViewModel>
    {
        [Inject] DiUiInventoryViewModel _Inventory = null;

        internal override IDiView IView { get; set; }
        DiUiPopUpThatHidesEverrythingView _view;
        public DiUiPopUpThatHidesEverrythingView View
        {
            get { return IView as DiUiPopUpThatHidesEverrythingView; }
            set { _view = value; }
        }

        public DiUiPopUpThatHidesEverrythingViewModel(IDiUiPrefabProvider prefabProvider, IUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack)
        {

        }

        public async Task OpenInventoryView()
        {
            await _Inventory.Open();
        }
    }
}
