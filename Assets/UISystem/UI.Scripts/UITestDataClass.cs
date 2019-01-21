using UnityEngine;
using Zenject;

public class UITestDataClass : ITickable
{
    public int VeryImportantData { get; set; }

    readonly HUDViewModel _HUDViewModel;

    public UITestDataClass(HUDViewModel hUDViewModel)
    {
        _HUDViewModel = hUDViewModel;
    }

    public void Tick()
    {
        VeryImportantData = Random.Range(-100,100);
        UpdateViewModel();
        Debug.Log(VeryImportantData);
    }

    void UpdateViewModel()
    {
        _HUDViewModel.UpdateData(VeryImportantData);
    }
}
