using System.ComponentModel;
using UnityEngine;

namespace DiUi
{
    public abstract class UiView : MonoBehaviour, IDiView, INotifyPropertyChanged
    {
        //public virtual void InitializeView(DiUiHUDViewModel ViewModel)
        //{
        //    //Do Initialization here
        //}

        public virtual void OnBackPressed()
        {
            //Close Window by default
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
