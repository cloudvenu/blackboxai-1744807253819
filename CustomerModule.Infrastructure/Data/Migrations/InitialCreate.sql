-- Create Customers table
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    CompanyName NVARCHAR(100),
    PhotoUrl NVARCHAR(MAX),
    CreditLimit DECIMAL(18,2) NOT NULL DEFAULT 0,
    Notes NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsActive BIT NOT NULL DEFAULT 1,
    
    -- Billing Address
    BillingStreet NVARCHAR(100),
    BillingCity NVARCHAR(50),
    BillingState NVARCHAR(50),
    BillingPostalCode NVARCHAR(20),
    BillingCountry NVARCHAR(50),
    
    -- Shipping Address
    ShippingStreet NVARCHAR(100),
    ShippingCity NVARCHAR(50),
    ShippingState NVARCHAR(50),
    ShippingPostalCode NVARCHAR(20),
    ShippingCountry NVARCHAR(50)
);

-- Create unique index on Email
CREATE UNIQUE NONCLUSTERED INDEX IX_Customers_Email 
ON Customers(Email) 
WHERE IsActive = 1;

-- Create indexes for common search fields
CREATE INDEX IX_Customers_Names 
ON Customers(FirstName, LastName);

CREATE INDEX IX_Customers_CompanyName 
ON Customers(CompanyName);

-- Insert sample data
INSERT INTO Customers (
    FirstName, LastName, Email, Phone, CompanyName,
    CreditLimit, Notes,
    BillingStreet, BillingCity, BillingState, BillingPostalCode, BillingCountry,
    ShippingStreet, ShippingCity, ShippingState, ShippingPostalCode, ShippingCountry
)
VALUES
(
    'John', 'Doe', 'john.doe@example.com', '555-0100', 'Acme Corp',
    10000.00, 'VIP Customer',
    '123 Main St', 'New York', 'NY', '10001', 'USA',
    '123 Main St', 'New York', 'NY', '10001', 'USA'
),
(
    'Jane', 'Smith', 'jane.smith@example.com', '555-0200', 'Tech Solutions',
    5000.00, 'New customer - 2023',
    '456 Park Ave', 'Los Angeles', 'CA', '90001', 'USA',
    '789 Ship St', 'Los Angeles', 'CA', '90002', 'USA'
),
(
    'Robert', 'Johnson', 'robert.j@example.com', '555-0300', 'Global Industries',
    15000.00, 'Long-term customer',
    '789 Business Rd', 'Chicago', 'IL', '60601', 'USA',
    '789 Business Rd', 'Chicago', 'IL', '60601', 'USA'
);

-- Create a view for active customers
CREATE VIEW vw_ActiveCustomers AS
SELECT 
    Id,
    FirstName,
    LastName,
    Email,
    Phone,
    CompanyName,
    PhotoUrl,
    CreditLimit,
    Notes,
    CreatedAt,
    UpdatedAt,
    BillingStreet,
    BillingCity,
    BillingState,
    BillingPostalCode,
    BillingCountry,
    ShippingStreet,
    ShippingCity,
    ShippingState,
    ShippingPostalCode,
    ShippingCountry
FROM 
    Customers
WHERE 
    IsActive = 1;
