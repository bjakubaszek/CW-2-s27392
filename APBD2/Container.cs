namespace APBD2;

public abstract class Container
{
    public static int CodeNumber { get; private set; } = 1;  

    public int LoadMass { get; set; }
    public int Height { get; set; }
    public int OwnWeight { get; set; }
    public int MaxCapacity { get; set; }
    public string SerialNumber { get; protected set; }  

    public Container (int height, int ownWeight, int maxCapacity)
    {
        LoadMass = 0;
        Height = height;
        OwnWeight = ownWeight;
        MaxCapacity = maxCapacity;
    }

    public virtual void EmptyCargo()
    {
        LoadMass = 0;
    }

    public virtual void LoadContainer(int toLoad, Cargo cargo)
    {
        if (toLoad + LoadMass > MaxCapacity)
        {
            throw new OverfillException($"ERROR Container too full to hold {toLoad + LoadMass} out of {MaxCapacity}");
        }
        LoadMass += toLoad;
        Console.WriteLine($"Loaded {SerialNumber} with {cargo.Name} of weight {toLoad}");

    }

    public string GenerateCode()
    {
        string code = "";
        switch (GetType().Name)
        {
            case "LiquidContainer": code =  "L";
                break;
            case "GasContainer": code =  "G";
                break;
            case "CoolingContainer": code =  "C";
                break;
        }
        return $"KON-{code}-{CodeNumber++}";
    }

    public void PrintData()
    {
        Console.Write(
            $"{LoadMass} <- mass "
            + $"{Height} <- height "
            + $"{OwnWeight} <- own weight "
            + $"{MaxCapacity} <- capacity "
            + $"{SerialNumber} | ");
    }



}
