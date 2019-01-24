using System.ComponentModel;
using UnityEngine;

namespace DiUi
{
    public class UiView : MonoBehaviour, IDiView, INotifyPropertyChanged
    {
        public virtual void InitializeView()
        {
            //Do Initialization here
        }

        public virtual void UpdateRealTimeDate()
        {

        }

        public virtual void UpdateEventData()
        {

        }

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
