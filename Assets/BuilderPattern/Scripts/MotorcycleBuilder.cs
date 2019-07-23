public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder()
    {
        mVehicle = new Vehicle("MotorCycle");
    }

    public override void BuildFrame()
    {
        mVehicle["frame"] = "MotorCycle Frame";
    }

    public override void BuildEngine()
    {
        mVehicle["engine"] = "500 cc";
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
