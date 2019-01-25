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
        internal abstract IDiViewModel IViewModel { get; set; }
        //internal UiViewModel _myViewModel;
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void OnBackPressed();

        public virtual void SetViewModel<T>(T ViewModel) where T : UiViewModel
        {
            _myViewModel = ViewModel;
        }
    }
}