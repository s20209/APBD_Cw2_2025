namespace Cw2;

public class Container
{
    private double payloadWeight, maxLoadWeight, height, selfWeight, depth;
    private ContainerType type;
    private static int counter = 0;
    private int id = 0;
    private string serialNumber;

    public Container(double payloadWeight, double maxLoadWeight, 
        double height, double selfWeight, double depth)
    {
        this.payloadWeight = payloadWeight;
        this.maxLoadWeight = maxLoadWeight;
        this.height = height;
        this.selfWeight = selfWeight;
        this.depth = depth;
        id = ++counter;
    }

    public enum ContainerType
    {
        L,
        G,
        C
    }
}