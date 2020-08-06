IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HospitalDatabase')
CREATE DATABASE HospitalDatabase

if exists (SELECT name FROM sys.sysobjects WHERE name = 'SickLeave')
drop table SickLeave
if exists (SELECT name FROM sys.sysobjects WHERE name = 'Patient')
drop table Patient
if exists (SELECT name FROM sys.sysobjects WHERE name = 'Doctor')
drop table Doctor

use HospitalDatabase
GO

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

use HospitalDatabase
GO

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

use HospitalDatabase
GO

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

INSERT INTO Doctor(FirstName, LastName, JMBG, BankAccountNumber, Username,Password) VALUES ('DoctorName1','DoctorSurname1','1231231231231','123123','doctor1','doctor1');
INSERT INTO Doctor(FirstName, LastName, JMBG, BankAccountNumber, Username,Password) VALUES ('DoctorName2','DoctorSurname2','1234567890123','456789','doctor2','doctor2');
INSERT INTO Doctor(FirstName, LastName, JMBG, BankAccountNumber, Username,Password) VALUES ('DoctorName3','DoctorSurname3','3210987654321','987654','doctor3','doctor3');

INSERT INTO Patient(FirstName, LastName, JMBG, HealthInsuranceCardNumber, Username,Password,DoctorID) VALUES ('PatientName1','PatientSurname1','1111111111111','111111','patient1','patient1',1);
INSERT INTO Patient(FirstName, LastName, JMBG, HealthInsuranceCardNumber, Username,Password,DoctorID) VALUES ('PatientName2','PatientSurname2','2222222222222','222222','patient2','patient2',2);
INSERT INTO Patient(FirstName, LastName, JMBG, HealthInsuranceCardNumber, Username,Password,DoctorID) VALUES ('PatientName3','PatientSurname2','3333333333333','333333','patient3','patient3',2);

INSERT INTO SickLeave(DateOfRequest, Reason, PlaceOfWork, Urgent, PatientID, DoctorID) VALUES ('20.03.2020','Pneumonia','Company1',1,1,2);
INSERT INTO SickLeave(DateOfRequest, Reason, PlaceOfWork, Urgent, PatientID, DoctorID) VALUES ('22.05.2020','Concussion','Company2',0,2,2);
INSERT INTO SickLeave(DateOfRequest, Reason, PlaceOfWork, Urgent, PatientID, DoctorID) VALUES ('13.02.2020','Burnout','Company3',1,3,3);

