using System.ComponentModel;
using UnityEngine;

namespace DiUi
{
    public abstract class UiView<T> : UiView where T : UiView<T>
    {
        public override void OnBackPressed()
        {
            //default implementation -> destroy?
        }
    }

    public abstract class UiView : MonoBehaviour, IDiView, INotifyPropertyChanged
    {
        //public virtual void InitializeView(DiUiHUDViewModel ViewModel)
        //{
        //    //Do Initialization here
        //}

        public abstract void OnBackPressed();

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
