namespace Cw2;

public class ContainerLiquid : Container, IHazardNotifier
{
    
    public ContainerLiquid(double maxLoadWeight, double height, double selfWeight, double depth, bool isHazard) 
        : base(maxLoadWeight, height, selfWeight, depth, ContainerType.L)
    {}

    public void Notify()
    {
        Console.WriteLine($"Unsafe operation was attempted with container {SerialNumber}");
    }

    public void LoadContainer(int id, double weight, bool isHazard)
    {
        if ((isHazard && weight + PayloadWeight > MaxLoadWeight * 0.5) || (!isHazard && weight + PayloadWeight > MaxLoadWeight * 0.9))
        {
            Notify();
        }
        else
        {
            base.LoadContainer(id, weight);   
        }
    }

    public void UnloadContainer(int id)
    {
       base.UnloadContainer(id); 
    }
} 