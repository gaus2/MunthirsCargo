# MunthirsCargo

A cargo shipment management system for managing shipments and cargo items.

## Features

- Create and manage shipments
- Add cargo items to shipments
- Track cargo weight and destinations
- Update shipment status
- View shipment details
- Remove cargo from shipments

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later

### Building the Application

```bash
dotnet build
```

### Running the Application

```bash
dotnet run --project src/MunthirsCargo.App/MunthirsCargo.App.csproj
```

### Running Tests

```bash
dotnet test
```

## Usage

The application provides an interactive console menu with the following options:

1. **Create new shipment** - Create a new shipment with a unique ID
2. **Add cargo to shipment** - Add cargo items to an existing shipment
3. **View all shipments** - List all shipments with summary information
4. **View shipment details** - View detailed information about a specific shipment
5. **Update shipment status** - Change the status of a shipment (e.g., "Pending", "In Transit", "Delivered")
6. **Remove cargo from shipment** - Remove a cargo item from a shipment
7. **Exit** - Close the application

## Project Structure

```
MunthirsCargo/
├── src/
│   └── MunthirsCargo.App/      # Main console application
│       ├── Cargo.cs             # Cargo class definition
│       ├── Shipment.cs          # Shipment class definition
│       └── Program.cs           # Main program entry point
└── tests/
    └── MunthirsCargo.Tests/    # Unit tests
        ├── CargoTests.cs        # Tests for Cargo class
        └── ShipmentTests.cs     # Tests for Shipment class
```

## Example

```
=== MunthirsCargo - Shipment Management System ===

Menu:
1. Create new shipment
2. Add cargo to shipment
3. View all shipments
4. View shipment details
5. Update shipment status
6. Remove cargo from shipment
7. Exit

Select an option: 1
Enter shipment ID: S001
Shipment S001 created successfully!
```

