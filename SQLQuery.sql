create database DbCarRental

use DbCarRental
go

create table Car
(
	CarId int primary key identity(1, 1),
	Manufacturer nvarchar(50),
	Model nvarchar(50),
	LicensePlate nvarchar(50),
	Year int,
	Available bit
)

create table Customer
(
	CustomerId int primary key identity(1, 1),
	Name nvarchar(50),
	DriverLicNo int,
)

create table Rental
(
	RentalId int primary key identity(1, 1),
	CustomerId int foreign key references Customer(CustomerId),
	CarId int foreign key references Car(CarId),
	DateRented datetime,
	DateReturned datetime
)

