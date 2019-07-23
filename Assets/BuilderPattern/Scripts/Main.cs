using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        VehicleBuilder _VehicleBuilder;

        Shop _shop = new Shop();

        _VehicleBuilder = new ScooterBuilder();
        _shop.Construct(_VehicleBuilder);
        _VehicleBuilder.Vehicle.Show();

        _VehicleBuilder = new MotorCycleBuilder();
        _shop.Construct(_VehicleBuilder);
        _VehicleBuilder.Vehicle.Show();

        _VehicleBuilder = new CarBuilder();
        _shop.Construct(_VehicleBuilder);
        _VehicleBuilder.Vehicle.Show();
    }
}