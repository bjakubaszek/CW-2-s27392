using System.Formats.Asn1;

namespace APBD2;

public class LiquidContainer : Container, IHazardNotifier
{
    


    public Cargo? Dangerous { get; set; }
    public Cargo? Safe { get; set; }


    public LiquidContainer(int height, int ownWeight, int maxCapacity, Cargo? dangerous, Cargo? safe) : base( height, ownWeight, maxCapacity)
    {
        Dangerous = dangerous;
        Safe = safe;
        SerialNumber = GenerateCode();
    }

    public override void LoadContainer(int toLoad, Cargo cargo)
    {

        if (!cargo.IsDangerous && Safe != null &&
            cargo.Name != Safe.Name)
        {
            Notify(SerialNumber,$"Emptying Safe Container and putting in new cargo which is {cargo.Name}");
            EmptyCargo();
        }
        else if (cargo.IsDangerous && Dangerous != null &&
                 cargo.Name != Dangerous.Name)
        {
            Notify(SerialNumber,$"Emptying Dangerous Container and putting in new cargo which is {cargo.Name}");
            EmptyCargo();
        }
        
        base.LoadContainer(toLoad, cargo);
        if (cargo.IsDangerous)
        {
            Dangerous = cargo;
        }
        else
        {
            Safe = cargo;
        }

        if (Dangerous == null)
        {
            if (LoadMass > MaxCapacity*9/10)
            {
                Notify(SerialNumber, $"Loaded more than recommended 90%. Currently {LoadMass} but has only {MaxCapacity}");
            }
        }
        else
        {
            if (LoadMass > MaxCapacity*5/10)
            {
                Notify(SerialNumber, $"Loaded more than recommended 50%. Currently {LoadMass} but has only {MaxCapacity}");

            }
        }

        
        if (cargo.IsDangerous) Dangerous = cargo;
        else Safe = cargo;
        
    }

    public void Notify(string serialNumber, string message)
    {
        Console.WriteLine($"Something dangerous happened to {serialNumber} due to: {message}");
    }
    
    public void EmptyCargo()
    {
        base.EmptyCargo();
        Safe = null;
        Dangerous = null;
    }
    
    public void PrintData()
    {
        base.PrintData();
        Console.Write($"Safe Container: {Safe?.Name}" +
                      $"Dangerous Container: {Dangerous?.Name} ");
        Console.WriteLine();
    }
    
}