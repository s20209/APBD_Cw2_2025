namespace Cw2;

public class Container
{
    public enum ContainerType
    {
        L,
        G,
        C
    }

    private static int _counter;
    private static readonly Dictionary<int, Container> Containers = new();
    private double _payloadWeight;
    private readonly double _maxLoadWeight;
    private double _height, _selfWeight, _depth;
    private string _serialNumber;
    private ContainerType _type;

    protected Container(double maxLoadWeight,
        double height, double selfWeight, double depth, ContainerType type)
    {
        this._maxLoadWeight = maxLoadWeight;
        this._height = height;
        this._selfWeight = selfWeight;
        this._depth = depth;
        this._type = type;
        var id = ++_counter;
        _serialNumber = GenerateSerialNumber(type, id);
        Containers.Add(id, this);
        _payloadWeight = 0;
    }

    public static Container getContainer(int id)
    {
        return Containers.ContainsKey(id) ? Containers[id] : null;
    }

    public double PayloadWeight => _payloadWeight;
    public double MaxLoadWeight => _maxLoadWeight;
    public double Height => _height;
    public double SelfWeight => _selfWeight;
    public double Depth => _depth;
    public string SerialNumber => _serialNumber;
    public ContainerType Type => _type;

    private static string GenerateSerialNumber(ContainerType type, int id) 
    {
        return "KON-" + type + "-" + id;
    }

    protected void LoadContainer(int id, double weight)
    {
        var container = getContainer(id);
        Console.WriteLine($"Container {container._serialNumber} loaded with {weight} kg.");
        container._payloadWeight += weight;
    }

    protected void UnloadContainer(int id)
    {
        var container = getContainer(id);
        container._payloadWeight = container._type == ContainerType.G ? container._payloadWeight * 0.05 : 0;
        Console.WriteLine($"Container {container._serialNumber} unloaded.");
    }

    public void PrintInformation()
    {
        Console.WriteLine($"Serial number: {SerialNumber}");
        Console.WriteLine($"Payload weight: {PayloadWeight} kg");
        Console.WriteLine($"Max load weight: {MaxLoadWeight} kg");
        Console.WriteLine($"Height: {Height} cm");
        Console.WriteLine($"Self weight: {SelfWeight} kg");
        Console.WriteLine($"Depth: {Depth} cm");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine();
    }

    protected Exception OverfillException()
    {
        return new Exception("Abort! This action would overload the container!");
    }
}