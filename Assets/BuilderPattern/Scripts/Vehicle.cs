using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The "Product" class
/// </summary>
public class Vehicle
{
    private string mVehicleType;
    private Dictionary<string, string> mParts = new Dictionary<string, string>();

    public Vehicle(string vehicleType)
    {
        mVehicleType = vehicleType;
    }

    //Indexer
    public string this[string key]
    {
        get { return mParts[key]; }
        set { mParts[key] = value; }
    }

    public void Show()
    {
        Debug.Log("--------------------");
        Debug.LogFormat("Vehicle Type: {0}", mVehicleType);
        Debug.LogFormat("Frame: {0}", mParts["frame"]);
        Debug.LogFormat("Engine: {0}", mParts["engine"]);
        Debug.LogFormat("#Wheels: {0}", mParts["wheels"]);
        Debug.LogFormat("#Doors: {0}", mParts["doors"]);
    }
}