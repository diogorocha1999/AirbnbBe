-- Inserir utilizadores
INSERT INTO Users (Name, Email, Password)
VALUES 
('João Silva', 'joao.silva@example.com', 'hashedpassword1'),
('Maria Santos', 'maria.santos@example.com', 'hashedpassword2'),
('Carlos Oliveira', 'carlos.oliveira@example.com', 'hashedpassword3'),
('Ana Costa', 'ana.costa@example.com', 'hashedpassword4');

-- Inserir propriedades
INSERT INTO Properties (Name, Location, PricePerNight)
VALUES 
('Apartamento no Centro', 'Lisboa, Portugal', 120.00),
('Casa de Campo', 'Alentejo, Portugal', 180.00),
('Villa com Piscina', 'Algarve, Portugal', 350.00),
('Quinta Rústica', 'Douro, Portugal', 250.00);

-- Inserir reservas
INSERT INTO Bookings (UserId, PropertyId, CheckInDate, CheckOutDate)
VALUES 
(1, 1, '2025-05-01', '2025-05-05'),  -- João Silva reservou o Apartamento no Centro
(2, 3, '2025-06-10', '2025-06-15'), -- Maria Santos reservou a Villa com Piscina
(3, 2, '2025-07-01', '2025-07-07'), -- Carlos Oliveira reservou a Casa de Campo
(4, 4, '2025-08-15', '2025-08-20'); -- Ana Costa reservou a Quinta Rústica