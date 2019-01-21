using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public abstract class GenericView : MonoBehaviour, IWindow, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    internal void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual void OnWrapped()
    {
        //Something like Awake / Start
    }
}
