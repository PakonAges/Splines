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

        public void Initialize(UITestDataClass DataClass)
        {
            _UITestDataClass = DataClass;
            ViewUpdate(0f);
        }

        public override void ViewUpdate(float iDeltaTime)
        {
            DataText = _UITestDataClass.VeryImportantData.ToString();
        }

        //We need to inject Data Source to change the Text!

        //SO! Do I need to Reffenerce Data Class here? HUD in Data Class
        //1. Data class doesn't need to Know anything about HUD
        //2. Something has to inform that Data has changed! and -> Change property here
        //3. So "Something" needs to know what is DataClass data and if that is changed -> give a command to HUD (change it's property).


        //OnMenu1 open
        //OnMenu2 Open
        //OnBackPressed -> Exit it log
    }
}