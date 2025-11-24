using MunthirsCargo.App;

Console.WriteLine("=== MunthirsCargo - Shipment Management System ===");
Console.WriteLine();

var shipments = new List<Shipment>();
var running = true;

while (running)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Create new shipment");
    Console.WriteLine("2. Add cargo to shipment");
    Console.WriteLine("3. View all shipments");
    Console.WriteLine("4. View shipment details");
    Console.WriteLine("5. Update shipment status");
    Console.WriteLine("6. Remove cargo from shipment");
    Console.WriteLine("7. Exit");
    Console.Write("\nSelect an option: ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                CreateShipment(shipments);
                break;
            case "2":
                AddCargoToShipment(shipments);
                break;
            case "3":
                ViewAllShipments(shipments);
                break;
            case "4":
                ViewShipmentDetails(shipments);
                break;
            case "5":
                UpdateShipmentStatus(shipments);
                break;
            case "6":
                RemoveCargoFromShipment(shipments);
                break;
            case "7":
                running = false;
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void CreateShipment(List<Shipment> shipments)
{
    Console.Write("Enter shipment ID: ");
    var shipmentId = Console.ReadLine() ?? "";

    var shipment = new Shipment(shipmentId);
    shipments.Add(shipment);
    Console.WriteLine($"Shipment {shipmentId} created successfully!");
}

static void AddCargoToShipment(List<Shipment> shipments)
{
    if (shipments.Count == 0)
    {
        Console.WriteLine("No shipments available. Create a shipment first.");
        return;
    }

    Console.Write("Enter shipment ID: ");
    var shipmentId = Console.ReadLine();
    var shipment = shipments.FirstOrDefault(s => s.ShipmentId == shipmentId);

    if (shipment == null)
    {
        Console.WriteLine("Shipment not found.");
        return;
    }

    Console.Write("Enter cargo ID: ");
    var cargoId = Console.ReadLine() ?? "";
    Console.Write("Enter description: ");
    var description = Console.ReadLine() ?? "";
    Console.Write("Enter weight (kg): ");
    var weightStr = Console.ReadLine();
    Console.Write("Enter destination: ");
    var destination = Console.ReadLine() ?? "";

    if (double.TryParse(weightStr, out var weight))
    {
        var cargo = new Cargo(cargoId, description, weight, destination);
        shipment.AddCargo(cargo);
        Console.WriteLine("Cargo added successfully!");
    }
    else
    {
        Console.WriteLine("Invalid weight value.");
    }
}

static void ViewAllShipments(List<Shipment> shipments)
{
    if (shipments.Count == 0)
    {
        Console.WriteLine("No shipments available.");
        return;
    }

    Console.WriteLine("\nAll Shipments:");
    foreach (var shipment in shipments)
    {
        Console.WriteLine(shipment);
    }
}

static void ViewShipmentDetails(List<Shipment> shipments)
{
    if (shipments.Count == 0)
    {
        Console.WriteLine("No shipments available.");
        return;
    }

    Console.Write("Enter shipment ID: ");
    var shipmentId = Console.ReadLine();
    var shipment = shipments.FirstOrDefault(s => s.ShipmentId == shipmentId);

    if (shipment == null)
    {
        Console.WriteLine("Shipment not found.");
        return;
    }

    Console.WriteLine($"\nShipment Details:");
    Console.WriteLine($"ID: {shipment.ShipmentId}");
    Console.WriteLine($"Date: {shipment.ShipmentDate}");
    Console.WriteLine($"Status: {shipment.Status}");
    Console.WriteLine($"Total Weight: {shipment.GetTotalWeight()}kg");
    Console.WriteLine($"Cargo Count: {shipment.GetCargoCount()}");
    Console.WriteLine("\nCargo Items:");
    foreach (var cargo in shipment.CargoItems)
    {
        Console.WriteLine($"  {cargo}");
    }
}

static void UpdateShipmentStatus(List<Shipment> shipments)
{
    if (shipments.Count == 0)
    {
        Console.WriteLine("No shipments available.");
        return;
    }

    Console.Write("Enter shipment ID: ");
    var shipmentId = Console.ReadLine();
    var shipment = shipments.FirstOrDefault(s => s.ShipmentId == shipmentId);

    if (shipment == null)
    {
        Console.WriteLine("Shipment not found.");
        return;
    }

    Console.Write("Enter new status: ");
    var status = Console.ReadLine() ?? "";
    shipment.UpdateStatus(status);
    Console.WriteLine("Status updated successfully!");
}

static void RemoveCargoFromShipment(List<Shipment> shipments)
{
    if (shipments.Count == 0)
    {
        Console.WriteLine("No shipments available.");
        return;
    }

    Console.Write("Enter shipment ID: ");
    var shipmentId = Console.ReadLine();
    var shipment = shipments.FirstOrDefault(s => s.ShipmentId == shipmentId);

    if (shipment == null)
    {
        Console.WriteLine("Shipment not found.");
        return;
    }

    Console.Write("Enter cargo ID to remove: ");
    var cargoId = Console.ReadLine() ?? "";
    
    if (shipment.RemoveCargo(cargoId))
    {
        Console.WriteLine("Cargo removed successfully!");
    }
    else
    {
        Console.WriteLine("Cargo not found in this shipment.");
    }
}
