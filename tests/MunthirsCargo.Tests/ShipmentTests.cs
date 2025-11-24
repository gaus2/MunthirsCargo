using MunthirsCargo.App;

namespace MunthirsCargo.Tests;

public class ShipmentTests
{
    [Fact]
    public void Shipment_Constructor_ValidId_CreatesInstance()
    {
        // Arrange & Act
        var shipment = new Shipment("S001");

        // Assert
        Assert.Equal("S001", shipment.ShipmentId);
        Assert.Equal("Pending", shipment.Status);
        Assert.Empty(shipment.CargoItems);
        Assert.NotEqual(default(DateTime), shipment.ShipmentDate);
    }

    [Fact]
    public void Shipment_Constructor_EmptyId_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Shipment(""));
    }

    [Fact]
    public void Shipment_AddCargo_ValidCargo_AddsToList()
    {
        // Arrange
        var shipment = new Shipment("S001");
        var cargo = new Cargo("C001", "Electronics", 25.5, "New York");

        // Act
        shipment.AddCargo(cargo);

        // Assert
        Assert.Single(shipment.CargoItems);
        Assert.Contains(cargo, shipment.CargoItems);
    }

    [Fact]
    public void Shipment_AddCargo_NullCargo_ThrowsArgumentNullException()
    {
        // Arrange
        var shipment = new Shipment("S001");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => shipment.AddCargo(null!));
    }

    [Fact]
    public void Shipment_RemoveCargo_ExistingCargo_ReturnsTrue()
    {
        // Arrange
        var shipment = new Shipment("S001");
        var cargo = new Cargo("C001", "Electronics", 25.5, "New York");
        shipment.AddCargo(cargo);

        // Act
        var result = shipment.RemoveCargo("C001");

        // Assert
        Assert.True(result);
        Assert.Empty(shipment.CargoItems);
    }

    [Fact]
    public void Shipment_RemoveCargo_NonExistingCargo_ReturnsFalse()
    {
        // Arrange
        var shipment = new Shipment("S001");
        var cargo = new Cargo("C001", "Electronics", 25.5, "New York");
        shipment.AddCargo(cargo);

        // Act
        var result = shipment.RemoveCargo("C999");

        // Assert
        Assert.False(result);
        Assert.Single(shipment.CargoItems);
    }

    [Fact]
    public void Shipment_GetTotalWeight_MultipleCargo_ReturnsSum()
    {
        // Arrange
        var shipment = new Shipment("S001");
        shipment.AddCargo(new Cargo("C001", "Electronics", 25.5, "New York"));
        shipment.AddCargo(new Cargo("C002", "Furniture", 150.0, "Los Angeles"));
        shipment.AddCargo(new Cargo("C003", "Books", 10.5, "Chicago"));

        // Act
        var totalWeight = shipment.GetTotalWeight();

        // Assert
        Assert.Equal(186.0, totalWeight);
    }

    [Fact]
    public void Shipment_GetCargoCount_ReturnsCorrectCount()
    {
        // Arrange
        var shipment = new Shipment("S001");
        shipment.AddCargo(new Cargo("C001", "Electronics", 25.5, "New York"));
        shipment.AddCargo(new Cargo("C002", "Furniture", 150.0, "Los Angeles"));

        // Act
        var count = shipment.GetCargoCount();

        // Assert
        Assert.Equal(2, count);
    }

    [Fact]
    public void Shipment_UpdateStatus_ValidStatus_UpdatesStatus()
    {
        // Arrange
        var shipment = new Shipment("S001");

        // Act
        shipment.UpdateStatus("In Transit");

        // Assert
        Assert.Equal("In Transit", shipment.Status);
    }

    [Fact]
    public void Shipment_UpdateStatus_EmptyStatus_ThrowsArgumentException()
    {
        // Arrange
        var shipment = new Shipment("S001");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => shipment.UpdateStatus(""));
    }

    [Fact]
    public void Shipment_ToString_ReturnsFormattedString()
    {
        // Arrange
        var shipment = new Shipment("S001");
        shipment.AddCargo(new Cargo("C001", "Electronics", 25.5, "New York"));

        // Act
        var result = shipment.ToString();

        // Assert
        Assert.Contains("S001", result);
        Assert.Contains("Pending", result);
        Assert.Contains("1 items", result);
    }
}
