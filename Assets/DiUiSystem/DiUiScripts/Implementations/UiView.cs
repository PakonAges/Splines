using System.ComponentModel;
using UnityEngine;

namespace DiUi
{
    public abstract class UiView<T> : UiView where T : UiView<T>
    {
        public override void OnBackPressed()
        {
            Debug.Log("Back pressed?");
            //default implementation -> destroy?
        }
    }

    public abstract class UiView : MonoBehaviour, IDiView, INotifyPropertyChanged
    {
        //public bool ShowTranslucentBg = true;
        public bool CacheOnClosed = false;
        public bool HideSubordinates = false;

        internal abstract IDiViewModel IViewModel { get; set; }
        public bool HideOnClose { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void OnBackPressed();

        public virtual void SetViewModel(IDiViewModel viewModel)
        {
            IViewModel = viewModel;
            HideOnClose = CacheOnClosed;
        }
    }
}