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
        public bool CacheOnClosed = false;
        public bool HideSubordinates = false;
        public bool NeedConfirmBeforeClosing = false;

        internal virtual IDiViewModel IViewModel { get; set; }
        public bool HideOnClose { get; private set; }
        public bool NeedConfirmToClose { get; private set; }
        public bool HideAllOtherViews { get; private set; }

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
            NeedConfirmToClose = NeedConfirmBeforeClosing;
            HideAllOtherViews = HideSubordinates;
        }
    }
}