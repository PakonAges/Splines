using Zenject;

namespace DiUi
{
    public class DiUiHUDModelView : IDiViewModel, ITickable
    {
        readonly UiView _myView;

        public DiUiHUDModelView(UiView diView)
        {
            _myView = diView;
            //Data class
        }

        public void ControllCube()
        {
            //pass command from View
        }

        public void Tick()
        {
            _myView.UpdateRealTimeDate();
        }

        public class Factory : PlaceholderFactory<DiUiHUDModelView> { }
    }
}