using UnityWeld.Binding;

namespace myUi
{
    [Binding]
    public class HUDView : GenericView
    {
        private UITestDataClass _UITestDataClass;
        string _dataText;

        [Binding]
        public string DataText
        {
            get { return _dataText; }
            set
            {
                if (_dataText == value)
                {
                    return;
                }

                _dataText = value;
                OnPropertyChanged("DataText");
            }

        }

        [Binding]
        public void OnShowMenuHideOthersBtnClicked()
        {
            _uiManager.ShowWindowAsync<MenuView>();
        }

        [Binding]
        public void OnShowMenuOverOthersBtnClicked()
        {
            _uiManager.ShowWindowAsync<MenuView>();
        }

        public void Initialize( IUiManager uiManager,
                                UITestDataClass DataClass)
        {
            _uiManager = uiManager;
            _UITestDataClass = DataClass;
        }

        public override void ViewUpdate(float iDeltaTime)
        {
            DataText = _UITestDataClass.VeryImportantData.ToString();
        }

        //OnMenu1 open
        //OnMenu2 Open
        //OnBackPressed -> Exit it log
    }
}