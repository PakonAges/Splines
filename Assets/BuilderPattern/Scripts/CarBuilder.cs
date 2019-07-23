public class CarBuilder : VehicleBuilder
{
    public CarBuilder()
    {
        mVehicle = new Vehicle("Car");
    }

    public override void BuildFrame()
    {
        mVehicle["frame"] = "Car Frame";
    }

    public override void BuildEngine()
    {
        mVehicle["engine"] = "2500 cc";
    }

    public override void BuildWheels()
    {
        mVehicle["wheels"] = "4";
    }

    public override void BuildDoors()
    {
        mVehicle["doors"] = "3";
    }
}
