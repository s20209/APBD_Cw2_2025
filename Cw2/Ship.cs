namespace Cw2;

public class Ship
{
   public string Name;
   public List<Container> Containers;
   public double maxSpeed;
   public int containerLimit;
   public double weightLimit;
   public double cargoWeight;
   
   public Ship(string name, double maxSpeed, int containerLimit, double weightLimit)
   {
      Name = name;
      Containers = new List<Container>();
      this.maxSpeed = maxSpeed;
      this.containerLimit = containerLimit;
      this.weightLimit = weightLimit;
      cargoWeight = 0;
   }
   
   public void AddContainer(Container container)
   {
      if (Containers.Count >= containerLimit || container.PayloadWeight + cargoWeight < weightLimit*1000)
      {
         Console.WriteLine("Cannot add container to ship. Ship is full or exceeds weight limit.");
         return;
      }
      Containers.Add(container);
      cargoWeight += container.PayloadWeight;
      Console.WriteLine($"Added container {container.SerialNumber} to ship.");
   }
   public void AddContainers(List<Container> containers)
   {
      if (Containers.Count + containers.Count > containerLimit || containers.Sum(c => c.PayloadWeight) + cargoWeight > weightLimit*1000)
      {
         Console.WriteLine($"Cannot add containers to ship {Name}. Ship is full or exceeds weight limit.");
         return;
      }
      Containers.AddRange(containers);
      cargoWeight += containers.Sum(c => c.PayloadWeight);
      Console.WriteLine($"Added {containers.Count} containers to ship {Name}.");
   }
   
   public void RemoveContainer(Container container)
   {
      Containers.Remove(container);
      cargoWeight -= container.PayloadWeight;
      Console.WriteLine($"Removed container {container.SerialNumber} from ship {Name}.");
   }

   public void RemoveAllContainers()
   {
      Containers.Clear();
      cargoWeight = 0;
      Console.WriteLine($"Removed all containers from ship {Name}.");
   }

   public void PrintInformation()
   {
      Console.WriteLine($"Ship: {Name}");
      Console.WriteLine($"Max speed: {maxSpeed} kn");
      Console.WriteLine($"Container limit: {containerLimit}");
      Console.WriteLine($"Weight limit: {weightLimit} t");
      Console.WriteLine($"Cargo weight: {cargoWeight} kg");
      Console.WriteLine("Cargo:");
      foreach (var container in Containers)
      {
         Console.WriteLine($"- Container: {container.SerialNumber}, Type: {container.Type}, Weight: {container.PayloadWeight} kg");
      }
   }
}