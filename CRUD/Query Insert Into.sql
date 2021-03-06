USE Crud;

INSERT INTO [dbo].[Order] (Product, Quantity, FirstName, LastName, PhoneNumber, OrderDate, OrderEndDate)
VALUES 
('telewizor', 2, 'Andrzej', 'Gajda', '986351839', '05.11.2019', '15.11.2019'),
('telewizor', 1, 'Angelika', 'Kociołek', '996712379', '23.10.2019', '01.11.2019'),
('komoda', 1, 'Ewa', 'Kościak', '335610883', '16.10.2019', '24.11.2019'),
('monitor', 5, 'Piotr', 'Zięba', '992465881', '10.09.2019', '11.09.2019'),
('drzwi', 6, 'Agnieszka', 'Wojewódzka', '070599331', '10.11.2019', '22.11.2019')


INSERT INTO [dbo].[Order] (Product, Quantity, FirstName, LastName, PhoneNumber, OrderDate)
VALUES 
('kanapa 5-os', 2, 'Andrzej', 'Gajda', '336842839', '20.12.2019'),
('lampa biurkowa', 3, 'Angelika', 'Kociołek', '466712389', '25.12.2019'),
('zestaw głośnomówiący', 1, 'Małgorzata', 'Nowak', '363289550', '10.12.2019'),
('grzejnik elektryczny', 2, 'Stanisław', 'Konieczny', '437893164', '30.11.2019')


UPDATE [dbo].[Order]
SET 
OrderEndDate = '08.12.2019' 
WHERE OrderId = 7