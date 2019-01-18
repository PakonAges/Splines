using UnityEngine;
using Zenject;

public class UITestDataClass : ITickable
{
    public int VeryImportantData { get; set; }

    public void Tick()
    {
        VeryImportantData = Random.Range(-100,100);
        Debug.Log(VeryImportantData);
    }
}
