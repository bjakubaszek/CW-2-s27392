using System.Formats.Asn1;

namespace APBD2;

public class GasContainer : Container, IHazardNotifier
{
    


    public double Atmosphere { get; set; }

    public GasContainer( int height, int ownWeight, int maxCapacity, double atmosphere ) : base( height, ownWeight, maxCapacity)
    {
        Atmosphere = atmosphere;
        SerialNumber = GenerateCode();
    }

    public override void LoadContainer(int toLoad, Cargo cargo)
    {
        base.LoadContainer(toLoad, cargo);
    }

    public override void EmptyCargo()
    {
        LoadMass = LoadMass/100*5;
    }

    public void Notify(string serialNumber, string message)
    {
        Console.WriteLine($"Something dangerous happened to {serialNumber} due to: {message}");
    }
    
    public void PrintData()
    {
        base.PrintData();
        Console.Write($"Atmosphere: {Atmosphere} ");
        Console.WriteLine();
    }
}