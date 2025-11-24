using MunthirsCargo.App;

namespace MunthirsCargo.Tests;

public class CargoTests
{
    [Fact]
    public void Cargo_Constructor_ValidParameters_CreatesInstance()
    {
        // Arrange & Act
        var cargo = new Cargo("C001", "Electronics", 25.5, "New York");

        // Assert
        Assert.Equal("C001", cargo.Id);
        Assert.Equal("Electronics", cargo.Description);
        Assert.Equal(25.5, cargo.Weight);
        Assert.Equal("New York", cargo.Destination);
    }

    [Fact]
    public void Cargo_Constructor_EmptyId_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Cargo("", "Electronics", 25.5, "New York"));
    }

    [Fact]
    public void Cargo_Constructor_EmptyDescription_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Cargo("C001", "", 25.5, "New York"));
    }

    [Fact]
    public void Cargo_Constructor_ZeroWeight_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Cargo("C001", "Electronics", 0, "New York"));
    }

    [Fact]
    public void Cargo_Constructor_NegativeWeight_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Cargo("C001", "Electronics", -5, "New York"));
    }

    [Fact]
    public void Cargo_Constructor_EmptyDestination_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Cargo("C001", "Electronics", 25.5, ""));
    }

    [Fact]
    public void Cargo_ToString_ReturnsFormattedString()
    {
        // Arrange
        var cargo = new Cargo("C001", "Electronics", 25.5, "New York");

        // Act
        var result = cargo.ToString();

        // Assert
        Assert.Contains("C001", result);
        Assert.Contains("Electronics", result);
        Assert.Contains("25.5", result);
        Assert.Contains("New York", result);
    }
}

