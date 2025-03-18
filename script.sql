-- Create the Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Primary key with auto-increment
    Name NVARCHAR(255) NOT NULL, -- User's name
    Email NVARCHAR(255) NOT NULL UNIQUE, -- User's email (must be unique)
    Password NVARCHAR(255) NOT NULL -- Hashed password
);

-- Create the Properties table
CREATE TABLE Properties (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Primary key with auto-increment
    Name NVARCHAR(255) NOT NULL, -- Property name
    Location NVARCHAR(255) NOT NULL, -- Property location
    PricePerNight DECIMAL(18, 2) NOT NULL -- Price per night
);

-- Create the Bookings table
CREATE TABLE Bookings (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Primary key with auto-increment
    UserId INT NOT NULL, -- Foreign key to Users table
    PropertyId INT NOT NULL, -- Foreign key to Properties table
    StartDate DATE NOT NULL, -- Booking start date
    EndDate DATE NOT NULL, -- Booking end date
    TotalPrice DECIMAL(18, 2) NOT NULL, -- Total price for the booking
    CONSTRAINT FK_Bookings_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Bookings_Properties FOREIGN KEY (PropertyId) REFERENCES Properties(Id) ON DELETE CASCADE
);

-- Optional: Insert sample data for testing
INSERT INTO Users (Name, Email, Password)
VALUES 
('John Doe', 'john.doe@example.com', 'hashedpassword1'),
('Jane Smith', 'jane.smith@example.com', 'hashedpassword2');

INSERT INTO Properties (Name, Location, PricePerNight)
VALUES 
('Beach House', 'Miami, FL', 250.00),
('Mountain Cabin', 'Aspen, CO', 300.00);

INSERT INTO Bookings (UserId, PropertyId, StartDate, EndDate, TotalPrice)
VALUES 
(1, 1, '2025-03-20', '2025-03-25', 1250.00),
(2, 2, '2025-04-01', '2025-04-05', 1200.00);