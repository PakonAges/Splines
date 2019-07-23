/// <summary>
/// The "Builder" abstract class
/// </summary>
public abstract class VehicleBuilder
{
    protected Vehicle mVehicle;

    public Vehicle Vehicle
    {
        //get { return mVehicle; }
        get => mVehicle;
    }

    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();

}
