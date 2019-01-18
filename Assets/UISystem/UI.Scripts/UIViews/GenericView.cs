using System.ComponentModel;
using UnityEngine;

public abstract class GenericView : MonoBehaviour, IWindow, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    internal void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
