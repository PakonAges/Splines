public class ScooterBuilder : VehicleBuilder
{
    public ScooterBuilder()
    {
        mVehicle = new Vehicle("Scooter");
    }

    public override void BuildFrame()
    {
        mVehicle["frame"] = "Scooter Frame";
    }

    public override void BuildEngine()
    {
        mVehicle["engine"] = "100 cc";
    }

    public override void BuildWheels()
    {
        mVehicle["wheels"] = "2";
    }

    public override void BuildDoors()
    {
        mVehicle["doors"] = "0";
    }

}
