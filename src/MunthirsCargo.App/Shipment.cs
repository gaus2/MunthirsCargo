namespace MunthirsCargo.App;

/// <summary>
/// Represents a shipment containing multiple cargo items.
/// </summary>
public class Shipment
{
    public string ShipmentId { get; set; }
    public List<Cargo> CargoItems { get; private set; }
    public DateTime ShipmentDate { get; set; }
    public string Status { get; set; }

    public Shipment(string shipmentId)
    {
        if (string.IsNullOrWhiteSpace(shipmentId))
            throw new ArgumentException("Shipment ID cannot be empty", nameof(shipmentId));

        ShipmentId = shipmentId;
        CargoItems = new List<Cargo>();
        ShipmentDate = DateTime.Now;
        Status = "Pending";
    }

    public void AddCargo(Cargo cargo)
    {
        if (cargo == null)
            throw new ArgumentNullException(nameof(cargo));

        CargoItems.Add(cargo);
    }

    public bool RemoveCargo(string cargoId)
    {
        var cargo = CargoItems.FirstOrDefault(c => c.Id == cargoId);
        if (cargo != null)
        {
            CargoItems.Remove(cargo);
            return true;
        }
        return false;
    }

    public double GetTotalWeight()
    {
        return CargoItems.Sum(c => c.Weight);
    }

    public int GetCargoCount()
    {
        return CargoItems.Count;
    }

    public void UpdateStatus(string newStatus)
    {
        if (string.IsNullOrWhiteSpace(newStatus))
            throw new ArgumentException("Status cannot be empty", nameof(newStatus));
        
        Status = newStatus;
    }

    public override string ToString()
    {
        return $"Shipment {ShipmentId} - {Status} - {CargoItems.Count} items - {GetTotalWeight()}kg total";
    }
}
