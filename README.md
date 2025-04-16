# Customer Management Module

A comprehensive customer management module built with Blazor Server, featuring a clean architecture design and modern UI components.

## Features

- 📋 Customer List with search and filtering
- ➕ Create new customers with detailed information
- 📝 Edit existing customer details
- 👁️ View detailed customer profiles
- 🗑️ Soft delete customers
- 📍 Manage billing and shipping addresses
- 💳 Track credit limits
- 📸 Support for customer profile photos
- 🔍 Advanced search functionality
- 🎨 Modern, responsive UI with Tailwind CSS

## Technology Stack

- **Frontend**: Blazor Server
- **UI Framework**: Tailwind CSS
- **Icons**: Font Awesome
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Architecture**: Clean Architecture

## Project Structure

```
CustomerModule/
├── Core/                 # Business logic and interfaces
│   ├── Entities/        # Domain entities
│   ├── Interfaces/      # Core interfaces
│   └── Services/        # Business logic services
├── Infrastructure/      # Data access and external services
│   ├── Data/           # Database context and migrations
│   └── Repositories/   # Data access implementations
├── Shared/             # Shared DTOs and utilities
│   ├── DTOs/           # Data transfer objects
│   ├── Models/         # Shared models
│   └── Mapping/        # Object mapping extensions
└── Web/                # Blazor Server web application
    ├── Components/     # Blazor components
    │   ├── Layout/     # Layout components
    │   ├── Pages/      # Page components
    │   └── Shared/     # Shared components
    └── Services/       # Web-specific services
```

## Setup Instructions

1. **Database Setup**:
   ```sql
   -- Run the migration script
   CustomerModule.Infrastructure/Data/Migrations/InitialCreate.sql
   ```

2. **Configuration**:
   - Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CustomerModule;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Run the Application**:
   ```bash
   dotnet run --project CustomerModule.Web
   ```

## Key Components

### Shared Components

- **Toast Notifications**: Provides feedback for user actions
- **Loading Spinner**: Indicates loading states
- **Confirmation Dialog**: Confirms destructive actions
- **Error Handling**: Centralized error handling and display

### Features

1. **Customer List**
   - Responsive table layout
   - Quick search functionality
   - Sorting and filtering
   - Bulk actions

2. **Customer Forms**
   - Validation
   - Address management
   - Image upload support
   - Same-as-billing address option

3. **Customer Details**
   - Comprehensive customer information
   - Address display
   - Activity history
   - Quick actions

## Architecture Highlights

- **Clean Architecture**: Separation of concerns with clear boundaries
- **Repository Pattern**: Abstracted data access
- **CQRS-inspired**: Separate models for reading and writing
- **Service Layer**: Business logic encapsulation
- **DTOs**: Clean data transfer between layers

## Best Practices

- Comprehensive error handling
- Loading state management
- Responsive design
- Form validation
- Soft delete implementation
- Audit trails (CreatedAt, UpdatedAt)
- Toast notifications for user feedback

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

MIT License - feel free to use this code in your own projects.
