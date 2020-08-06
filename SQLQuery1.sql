IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HospitalDatabase')
CREATE DATABASE HospitalDatabase

if exists (SELECT name FROM sys.sysobjects WHERE name = 'Patient')
drop table Patient
if exists (SELECT name FROM sys.sysobjects WHERE name = 'Doctor')
drop table Doctor
if exists (SELECT name FROM sys.sysobjects WHERE name = 'SickLeave')
drop table SickLeave

create table Doctor
(
DoctorID int primary key identity(1,1),
FirstName nvarchar(35),
LastName nvarchar(20),
JMBG nvarchar(13),
BankAccountNumber nvarchar(20),
Username nvarchar(20),
Password nvarchar (20),
)

create table Patient
(
PatientID int primary key identity(1,1),
FirstName nvarchar(35),
LastName nvarchar(20),
JMBG nvarchar(13),
HealthInsuranceCardNumber nvarchar(20),
Username nvarchar(20),
Password nvarchar (20),
DoctorID int FOREIGN KEY REFERENCES Doctor(DoctorID),
)

create table SickLeave
(
SickLeaveID int primary key identity(1,1),
DateOfRequest nvarchar(35),
Reason nvarchar(20),
PlaceOfWork nvarchar(13),
Urgent bit,
PatientID int FOREIGN KEY REFERENCES Patient(PatientID),
DoctorID int FOREIGN KEY REFERENCES Doctor(DoctorID)
)
