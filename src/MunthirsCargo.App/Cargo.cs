namespace MunthirsCargo.App;

/// <summary>
/// Represents a cargo item with description, weight, and destination.
/// </summary>
public class Cargo
{
    public string Id { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public string Destination { get; set; }

    public Cargo(string id, string description, double weight, string destination)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Cargo ID cannot be empty", nameof(id));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
        if (weight <= 0)
            throw new ArgumentException("Weight must be greater than zero", nameof(weight));
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("Destination cannot be empty", nameof(destination));

        Id = id;
        Description = description;
        Weight = weight;
        Destination = destination;
    }

    public override string ToString()
    {
        return $"[{Id}] {Description} - {Weight}kg to {Destination}";
    }
}
