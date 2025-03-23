// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using APBD2;


List<Cargo> listCargo = new List<Cargo>();

listCargo.Add(new Cargo("Milk",false,15.3));
listCargo.Add(new Cargo("Tea",false,-12.3));
listCargo.Add(new Cargo("Butter",false,21.2));
listCargo.Add(new Cargo("Oil",true,20));
listCargo.Add(new Cargo("C4",true,-30));
listCargo.Add(new Cargo("Gas",true,-0));



Dictionary<string, Cargo> cargoMap = listCargo.ToDictionary(c => c.Name);
LiquidContainer liquidContainer1 = new LiquidContainer( 300, 1000, 3000, null, null);

liquidContainer1.LoadContainer(1000,cargoMap["Milk"]);
liquidContainer1.LoadContainer(1000,cargoMap["Milk"]);
liquidContainer1.LoadContainer(1000,cargoMap["Milk"]);
liquidContainer1.LoadContainer(2000,cargoMap["Tea"]);
try
{
    liquidContainer1.LoadContainer(5000, cargoMap["Tea"]);
}
catch (OverfillException ex)
{
    Console.WriteLine(ex.Message);
}
liquidContainer1.LoadContainer(1000,cargoMap["Tea"]);

Console.WriteLine();
liquidContainer1.EmptyCargo();
liquidContainer1.LoadContainer(1000,cargoMap["C4"]);
liquidContainer1.LoadContainer(1000,cargoMap["Milk"]);
Console.WriteLine();

liquidContainer1.EmptyCargo();
liquidContainer1.LoadContainer(1000,cargoMap["Milk"]);
liquidContainer1.LoadContainer(1000,cargoMap["C4"]);
liquidContainer1.PrintData();
Console.WriteLine();


GasContainer gasContainer1 = new GasContainer( 250, 1000, 6000, 13);

gasContainer1.LoadContainer(1000,cargoMap["Gas"]);
gasContainer1.LoadContainer(5000,cargoMap["Gas"]);
gasContainer1.PrintData();
Console.WriteLine();
try
{
    gasContainer1.LoadContainer(1000,cargoMap["Gas"]);
}
catch (OverfillException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine();

gasContainer1.EmptyCargo();
Console.WriteLine($"{gasContainer1.LoadMass} Gas"); // teoretycznie wg zadania nie trzeba przetrzymywac co trzyma gasContainer :shrug: wiec uznaje ze po prostu gaz

Console.WriteLine();

CoolingContainer coolingContainer1 = new CoolingContainer( 250, 1000, 4000, 13);
coolingContainer1.LoadContainer(1000,cargoMap["Butter"]);
coolingContainer1.LoadContainer(1000,cargoMap["Tea"]);
coolingContainer1.LoadContainer(3000,cargoMap["Tea"]);
coolingContainer1.PrintData();
try
{
    coolingContainer1.LoadContainer(1000,cargoMap["Tea"]);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine();
Console.WriteLine("END OF PER CONTAINER TESTS, NOW TIME FOR THE SHIP TO SAIL THROUGH SUEZ AND AVOID THE SOMALI PIRATES");
Console.WriteLine();

Ship ship1 = new Ship(3,10,10000);
ship1.loadShip(coolingContainer1);
ship1.loadShip(gasContainer1);
ship1.loadShip(liquidContainer1);

ship1.printData();
try
{
    ship1.loadShip(coolingContainer1);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine();

Ship ship2 = new Ship(3,1,10000);
GasContainer gasContainer2 = new GasContainer( 250, 1000, 6000, 10);
GasContainer gasContainer3 = new GasContainer( 250, 1000, 6000, 10);
gasContainer2.LoadContainer(1000,cargoMap["Gas"]);
gasContainer3.LoadContainer(1000,cargoMap["Gas"]);
ship2.loadShip(gasContainer2);
try
{
    ship2.loadShip(gasContainer3);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

List<Container> gasContainers = new List<Container>();
gasContainers.Add(gasContainer1); 
gasContainers.Add(gasContainer2);
gasContainers.Add(gasContainer3);

Console.WriteLine("");


ship1.emptyShip();
ship1.printData();
double totalWeight = gasContainers.Sum(gas => gas.OwnWeight + gas.LoadMass);
Console.WriteLine($"Total weight: {totalWeight}");
ship1.loadShip(gasContainers);
ship1.printData(); // bedzue 5300
//teraz ship1 ma kon-g-2 kon-g-4 kon-g-5
Console.WriteLine();

ship1.changeContainer(gasContainer2, liquidContainer1);
ship1.printData(); // ma l1 nie ma g4
Console.WriteLine();


Ship ship3 = new Ship(3,2,10000);
ship3.loadShip(coolingContainer1);
ship3.printData(); 
Console.WriteLine();

ship1.transferContainer(ship3, liquidContainer1); // oddaje l1


Console.WriteLine();

ship1.printData();
ship3.printData();
// ship 3 ma 2 kontenery bo dostal
// ship 1 ma 2 kontenery bo oddal

Console.WriteLine();

ship1.removeContainer(gasContainer1);
ship1.printData();










