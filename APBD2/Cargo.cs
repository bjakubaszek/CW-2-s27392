namespace APBD2;

public class Cargo(string name, bool isDangerous, double safeTemperature)
{
    public string Name { get; set; } = name;
    public bool IsDangerous { get; set; } = isDangerous;
    public double SafeTemperature { get; set; } = safeTemperature;
}