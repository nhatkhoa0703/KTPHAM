
-- TABLE: Customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- TABLE: Tables
CREATE TABLE Tables (
    TableID INT PRIMARY KEY IDENTITY(1,1),
    TableNumber INT NOT NULL UNIQUE,
    Capacity INT NOT NULL,
    IsAvailable BIT DEFAULT 1
);

-- TABLE: Reservations
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    TableID INT NOT NULL,
    ReservationTime DATETIME NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled')),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (TableID) REFERENCES Tables(TableID)
);

-- TABLE: MenuItems
CREATE TABLE MenuItems (
    MenuItemID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    IsAvailable BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- TABLE: Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    TableID INT NOT NULL,
    CustomerID INT,
    OrderTime DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'In Progress', 'Completed', 'Cancelled')),
    FOREIGN KEY (TableID) REFERENCES Tables(TableID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- TABLE: OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    MenuItemID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID)
);

-- TABLE: Payments
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    PaymentMethod NVARCHAR(50) CHECK (PaymentMethod IN ('Cash', 'Credit Card', 'Online')),
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- TABLE: KitchenNotifications
CREATE TABLE KitchenNotifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    NotificationTime DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Not Started', 'In Progress', 'Completed')),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- TABLE: Statistics
CREATE TABLE MenuStatistics (
    StatisticID INT PRIMARY KEY IDENTITY(1,1),
    MenuItemID INT NOT NULL,
    TotalOrders INT DEFAULT 0,
    LastOrdered DATETIME,
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID)
);

-- TABLE: Users (for staff management)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Staff')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

SELECT TABLE_NAME AS TableName
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

INSERT INTO Customers (FullName, PhoneNumber, Email)
VALUES 
('Nguyen Van A', '0123456789', 'nguyenvana@example.com'),
('Tran Thi B', '0987654321', 'tranthib@example.com'),
('Le Van C', '0345678901', 'levanc@example.com');

INSERT INTO Tables (TableNumber, Capacity, IsAvailable)
VALUES 
(1, 4, 1),
(2, 6, 1),
(3, 2, 1),
(4, 8, 0),
(5, 4, 1);

INSERT INTO Reservations (CustomerID, TableID, ReservationTime, Status)
VALUES 
(1, 1, '2024-06-12 18:00:00', 'Confirmed'),
(2, 3, '2024-06-13 19:00:00', 'Pending'),
(3, 2, '2024-06-14 20:00:00', 'Cancelled');

INSERT INTO MenuItems (Name, Description, Price, IsAvailable)
VALUES 
('Hamburger', 'Delicious beef burger with lettuce and cheese', 5.99, 1),
('Lobster', 'Fresh grilled lobster with butter sauce', 24.99, 1),
('Fried Chicken', 'Crispy fried chicken with special spices', 8.99, 1),
('Pasta', 'Creamy alfredo pasta with chicken', 7.49, 1),
('Salad', 'Fresh green salad with olive oil dressing', 4.99, 1);

INSERT INTO MenuItems (Name, Description, Price, IsAvailable)
VALUES 
-- Vietnamese dishes
('Pho', 'Traditional Vietnamese beef noodle soup', 7.99, 1),
('Banh Mi', 'Crispy baguette with pork, pate, and vegetables', 4.49, 1),
('Spring Rolls', 'Fresh rice paper rolls with shrimp and herbs', 5.49, 1),
('Vietnamese Pancake', 'Crispy pancake with shrimp, pork, and bean sprouts', 6.99, 1),
('Grilled Pork Vermicelli', 'Vermicelli with grilled pork and fresh herbs', 7.49, 1),

-- Korean dishes
('Kimchi Stew', 'Spicy stew with kimchi, tofu, and pork', 8.99, 1),
('Bulgogi', 'Marinated beef stir-fried with onions', 9.49, 1),
('Tteokbokki', 'Spicy rice cakes with fish cakes and vegetables', 6.99, 1),
('Bibimbap', 'Mixed rice bowl with vegetables and beef', 8.49, 1),
('Korean Fried Chicken', 'Crispy fried chicken with sweet and spicy sauce', 9.99, 1);
INSERT INTO Orders (TableID, CustomerID, Status)
VALUES 
(1, 1, 'In Progress'),
(2, 2, 'Pending'),
(3, 3, 'Completed');

INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity, Price)
VALUES 
(1, 1, 2, 11.98),
(1, 4, 1, 7.49),
(2, 3, 3, 26.97),
(2, 5, 1, 4.99),
(3, 2, 2, 49.98);

INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid)
VALUES 
(1, 'Cash', 19.47),
(2, 'Credit Card', 31.96),
(3, 'Online', 49.98);

INSERT INTO KitchenNotifications (OrderID, Status)
VALUES 
(1, 'In Progress'),
(2, 'Not Started'),
(3, 'Completed');

INSERT INTO MenuStatistics (MenuItemID, TotalOrders, LastOrdered)
VALUES 
(1, 10, '2024-06-11 12:00:00'),
(2, 5, '2024-06-10 14:00:00'),
(3, 8, '2024-06-12 15:30:00'),
(4, 6, '2024-06-11 17:00:00'),
(5, 7, '2024-06-13 18:00:00');

INSERT INTO Users (Username, PasswordHash, Role)
VALUES 
('admin', 'hashed_password_12345', 'Admin'),
('staff1', 'hashed_password_67890', 'Staff'),
('staff2', 'hashed_password_abcde', 'Staff');

SELECT * FROM Customers;
SELECT * FROM Tables;
SELECT * FROM Reservations;
SELECT * FROM MenuItems;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM Payments;
SELECT * FROM KitchenNotifications;
SELECT * FROM MenuStatistics;
SELECT * FROM Users;

ALTER TABLE MenuItems ADD Category NVARCHAR(50);
UPDATE MenuItems SET Category = 'American' WHERE Name = 'Hamburger';
UPDATE MenuItems SET Category = 'American' WHERE Name = 'Fried Chicken';
UPDATE MenuItems SET Category = 'Italian' WHERE Name = 'Pasta';
UPDATE MenuItems SET Category = 'Healthy' WHERE Name = 'Salad';
UPDATE MenuItems SET Category = 'Luxury' WHERE Name = 'Lobster';

SELECT * FROM MenuItems;

INSERT INTO Customers (FullName, PhoneNumber, Email)
VALUES 
('Pham Thi D', '0912345678', 'phamthid@example.com'),
('Nguyen Van E', '0923456789', 'nguyenvane@example.com'),
('Tran Van F', '0934567890', 'tranvanf@example.com'),
('Le Thi G', '0945678901', 'lethig@example.com'),
('Bui Van H', '0956789012', 'buivanh@example.com'),
('Pham Van I', '0967890123', 'phamvani@example.com'),
('Do Thi J', '0978901234', 'dothij@example.com'),
('Ngo Van K', '0989012345', 'ngovank@example.com'),
('Hoang Thi L', '0990123456', 'hoangthil@example.com'),
('Vu Van M', '0901234567', 'vuvan@example.com');

-- Hiển thị danh sách tất cả khách hàng
SELECT * FROM Customers;
DELETE  FROM Customers;

INSERT INTO Orders (TableID, CustomerID, Status)
VALUES 
(4, 4, 'Pending'),
(5, 5, 'In Progress'),
(1, 6, 'Completed'),
(2, 7, 'Pending'),
(3, 8, 'In Progress'),
(4, 9, 'Completed'),
(5, 10, 'Pending'),
(1, 11, 'Completed'),
(2, 12, 'In Progress');

INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid)
VALUES 
(4, 'Cash', 50.00),
(5, 'Credit Card', 75.00),
(6, 'Online', 100.00),
(7, 'Cash', 40.00),
(8, 'Credit Card', 60.00),
(9, 'Online', 80.00),
(10, 'Cash', 45.00),
(11, 'Credit Card', 55.00),
(12, 'Online', 90.00);

INSERT INTO Reservations (CustomerID, TableID, ReservationTime, Status)
VALUES 
(4, 1, '2024-06-14 18:00:00', 'Confirmed'),
(5, 2, '2024-06-15 19:00:00', 'Pending'),
(6, 3, '2024-06-16 20:00:00', 'Cancelled'),
(7, 4, '2024-06-17 18:30:00', 'Confirmed'),
(8, 5, '2024-06-18 19:30:00', 'Pending'),
(9, 1, '2024-06-19 20:30:00', 'Cancelled'),
(10, 2, '2024-06-20 18:15:00', 'Confirmed'),
(11, 3, '2024-06-21 19:15:00', 'Pending'),
(12, 4, '2024-06-22 20:15:00', 'Cancelled');

INSERT INTO Users (Username, PasswordHash, Role)
VALUES 
('khoa', '0703', 'admin');