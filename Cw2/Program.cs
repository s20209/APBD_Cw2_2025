// See https://aka.ms/new-console-template for more information


using Cw2;

var liquidContainer = new ContainerLiquid(1000, 250, 300, 40, false);
var fridgeContainer = new ContainerFridge(1500, 280, 350, 350);
var gasContainer = new ContainerGas(800, 230, 280, 4);
var gasContainer2 = new ContainerGas(800, 230, 280, 4);
var gasContainer3 = new ContainerGas(800, 230, 280, 4);
var gasContainer4 = new ContainerGas(800, 230, 280, 4);
var gasContainer5 = new ContainerGas(800, 230, 280, 4);
var hazardLiquidContainer = new ContainerLiquid(800, 220, 250, 380, true);

var ship1 = new Ship("Sea Voyager", 50, 5, 5000);
var ship2 = new Ship("Ocean Explorer", 45, 30, 3000);

fridgeContainer.LoadContainer(1, "Bananas", 500);
liquidContainer.LoadContainer(2, 400, false);
gasContainer.LoadContainer(3, 200);
gasContainer.LoadContainer(4, 200);
gasContainer.LoadContainer(5, 200);
gasContainer.LoadContainer(6, 200);
gasContainer.LoadContainer(7, 200);
hazardLiquidContainer.LoadContainer(8, 200, true);

ship1.AddContainer(fridgeContainer);
ship1.AddContainer(liquidContainer);
ship2.AddContainer(gasContainer);
ship1.AddContainer(gasContainer2);
ship2.AddContainers(new List<Container>{ gasContainer3, gasContainer4, gasContainer5 });
ship2.AddContainer(hazardLiquidContainer);

ReplaceContainer(ship1, liquidContainer, gasContainer);

MoveContainer(ship1, ship2, gasContainer);

liquidContainer.PrintInformation();
fridgeContainer.PrintInformation();
gasContainer.PrintInformation();
hazardLiquidContainer.PrintInformation();

ship1.RemoveAllContainers();

ship1.PrintInformation();
ship2.PrintInformation();

void MoveContainer(Ship sourceShip, Ship targetShip, Container container)
{
    sourceShip.RemoveContainer(container);
    targetShip.AddContainer(container);
    Console.WriteLine($"Moved container {container.SerialNumber} from {sourceShip.Name} to {targetShip.Name}.");
}

void ReplaceContainer(Ship ship, Container oldContainer, Container newContainer)
{
    ship.RemoveContainer(oldContainer);
    ship.AddContainer(newContainer);
    Console.WriteLine($"Replaced container {oldContainer.SerialNumber} with {newContainer.SerialNumber} on ship {ship.Name}.");
}