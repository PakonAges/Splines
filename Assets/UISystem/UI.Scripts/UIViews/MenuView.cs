using UnityWeld.Binding;

namespace myUi
{
    [Binding]
    public class MenuView : GenericView
    {
        public override void ViewUpdate(float iDeltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void Initialize(IUiManager uiManager)
        { 
            _uiManager = uiManager;
        }

        [Binding]
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}