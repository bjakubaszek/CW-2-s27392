namespace APBD2;

public class Ship(double speed,int maxOfContainers, int maxWeightofContainers) 
{
    public List<Container> Containers  { get;set; } = new List<Container>();
    public double Speed { get; set; } = speed;
    public int MaxOfContainers { get;set; } = maxOfContainers;
    public int MaxWeightofContainers { get;set; } = maxWeightofContainers;



    public void loadShip(Container container)
    {
        if (Containers.Count == MaxOfContainers) throw new Exception("Maximum number of containers exceeded");
        int currentWeight = 0;
        foreach (var currentContainer in Containers)
        {
            currentWeight += currentContainer.LoadMass + currentContainer.OwnWeight;
        }
        if (currentWeight + container.LoadMass + container.OwnWeight > MaxWeightofContainers) throw new Exception("Maximum weight of containers exceeded");
        Console.WriteLine($"Loading Ship with {container.SerialNumber} weight {container.LoadMass}");

        Containers.Add(container);
    }


    public void printData()
    {
        Console.WriteLine($"Ship Speed: {Speed} " +
                          $"Current number of Containers: {Containers.Count}" +
                          $" Max number of Containers: {MaxOfContainers}" +
                          $" Current weight of Containers: {Containers.Sum(e => e.LoadMass + e.OwnWeight)}" +
                          $" Max weight of Containers: {MaxWeightofContainers}" +
                          $" List of Containers: ");
        Containers.ForEach(e => e.PrintData());
        Console.WriteLine();

    }

    public void emptyShip()
    {
        Containers.Clear();
    }

    public void loadShip(List<Container> loadedContainers)
    {
        if (Containers.Count == MaxOfContainers) throw new Exception("Maximum number of containers exceeded");
        int currentWeight = 0;
        int currentWeightofLoadContainers = 0;
        foreach (var currentContainer in Containers)
        {
            currentWeight += currentContainer.LoadMass + currentContainer.OwnWeight;
        }

        string codes = "";
        foreach (var currentLoadContainers in loadedContainers)
        {
            currentWeightofLoadContainers += currentLoadContainers.LoadMass + currentLoadContainers.OwnWeight;
            codes += currentLoadContainers.SerialNumber + ",";
        }
        if (currentWeight + currentWeightofLoadContainers > MaxWeightofContainers) throw new Exception("Maximum weight of containers exceeded");
        
        Console.WriteLine($"Loading Ship with {codes} weight {currentWeightofLoadContainers}");

        Containers.AddRange(loadedContainers);
    }

    public void changeContainer(Container oldContainer, Container newContainer)
    {
        if (!Containers.Exists(e => e.SerialNumber == oldContainer.SerialNumber)) throw new Exception("Container not found");
        if (Containers.Exists(e => e.SerialNumber == newContainer.SerialNumber)) throw new Exception("Container already exists");
        
        removeContainer(oldContainer);
        loadShip(newContainer);
    }

    public void removeContainer(Container oldContainer)
    {
        Containers.Remove(oldContainer);
        Console.WriteLine($"Removed container with serial number {oldContainer.SerialNumber}");
    }

    public void transferContainer(Ship ship2, Container container)
    {
        try
        {
            ship2.loadShip(container);
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to Load, something went wrong: {e.Message}");
        }
        
        this.Containers.Remove(container);
    }
}