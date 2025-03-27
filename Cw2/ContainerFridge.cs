namespace Cw2;

public class ContainerFridge : Container
{
    private readonly Dictionary<string, double> products2temperature= new Dictionary<string, double>()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen Pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    private string? _productType;
    private double? _temperature;
    public ContainerFridge(double maxLoadWeight, double height, double selfWeight, double depth) 
        : base(maxLoadWeight, height, selfWeight, depth, ContainerType.C)
    {}

    public void LoadContainer(int id, string product, double weight)
    {
        if (_productType != null && _productType != product)
        {
            Console.WriteLine("Cannot load different product types into the same container.");
            return;
        }

        if (!products2temperature.ContainsKey(product))
        {
            Console.WriteLine("Invalid product type.");
            return;
        }
        
        if (weight + PayloadWeight > MaxLoadWeight)
            throw OverfillException();

        base.LoadContainer(id, weight);
        _productType = product;
        _temperature = products2temperature[product];
    }

    public void UnloadContainer(int id)
    {
        base.UnloadContainer(id);
        _productType = null;
        _temperature = null;
    }
}