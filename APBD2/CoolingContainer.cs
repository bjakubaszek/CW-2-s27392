namespace APBD2;

public class CoolingContainer : Container, IHazardNotifier
{
    public Cargo? Cargo { get; set; }
    public int Temperature { get; set; }
    public CoolingContainer(int height, int ownWeight, int maxCapacity, int temp) : base(height, ownWeight, maxCapacity)
    {
        Temperature = temp;
        SerialNumber = GenerateCode();
    }


    public override void LoadContainer(int toLoad, Cargo cargo)
    {
        if (Cargo == null || cargo.Name.Equals(Cargo.Name))
        {
            if (Temperature > cargo.SafeTemperature)
            {
                base.LoadContainer(toLoad, cargo);
                Cargo = cargo;
            }
            else
            {
                Notify(SerialNumber,$"Temperature of the Container cannot be lower than the needed for given product Cargo: {Temperature} Product: {cargo.SafeTemperature}");
            }

        }
        else
        {
            Notify(SerialNumber,"Cargo can only hold one type of a product");
        }
    }

    public void Notify(string serialNumber, string message)
    {
        Console.WriteLine($"Something dangerous happened to {serialNumber} due to: {message}");
    }

    public void PrintData()
    {
        base.PrintData();
        Console.Write($"Temperature: {Temperature} " +
                      $"Cargo: {Cargo?.Name} ");
        Console.WriteLine();
    }
}