using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

namespace myUi
{
    [Binding]
    public abstract class GenericView : MonoBehaviour, IWindow, INotifyPropertyChanged
    {
        internal IUiManager _uiManager;
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void ViewUpdate(float iDeltaTime);

        public virtual void OnWrapped()
        {
            //Something like Awake / Start
        }

        [Binding]
        public virtual void OnBackPressed()
        {
            //Pass command to close this window / or show (override) other
            //UIManager needs to know that this one is closing, so he can show underneath's window if there is anything
            //So this View -> UIManager.CLoseMe -> Destroy/Hide (depends on my settings) & show underwear 
            
            //But who is me? Canvas FACADE or Generic VIew? Or IWindow?
            
            _uiManager.CloseWindow(this);
        }
    }
}