namespace Cw2;

public class ContainerGas : Container, IHazardNotifier
{
    public ContainerGas(double maxLoadWeight, double height, double selfWeight, double depth) 
        : base(maxLoadWeight, height, selfWeight, depth, ContainerType.G)
    {
    }

    public void Notify()
    {
        Console.WriteLine($"Hazard! Container {SerialNumber}");
    }

    public void LoadContainer(int id, double weight)
    {
        if (weight + PayloadWeight > MaxLoadWeight)
           throw OverfillException();
        
        base.LoadContainer(id, weight);
    }

    public void UnloadContainer(int id)
    {
        base.UnloadContainer(id);
    }
}