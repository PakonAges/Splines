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
    }
}