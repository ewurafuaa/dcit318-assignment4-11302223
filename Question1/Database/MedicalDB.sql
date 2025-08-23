-- Create DB --
CREATE DATABASE MedicalDB;
GO
USE MedicalDB;
GO

-- Tables --
CREATE TABLE Doctors(
  DoctorID INT IDENTITY PRIMARY KEY,
  FullName VARCHAR(100) NOT NULL,
  Specialty VARCHAR(100) NOT NULL,
  Availability BIT NOT NULL  -- 1 = available, 0 = unavailable
);

CREATE TABLE Patients(
  PatientID INT IDENTITY PRIMARY KEY,
  FullName VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL
);

CREATE TABLE Appointments(
  AppointmentID INT IDENTITY PRIMARY KEY,
  DoctorID INT NOT NULL,
  PatientID INT NOT NULL,
  AppointmentDate DATETIME NOT NULL,
  Notes VARCHAR(255) NULL,
  CONSTRAINT FK_Appointments_Doctors FOREIGN KEY(DoctorID) REFERENCES Doctors(DoctorID),
  CONSTRAINT FK_Appointments_Patients FOREIGN KEY(PatientID) REFERENCES Patients(PatientID)
);

-- Seed data --
INSERT INTO Doctors(FullName, Specialty, Availability) VALUES
('Dr. Ewurafua Quansah','Cardiology',1),
('Dr. Fidelis Quansah','Dermatology',1),
('Dr. Grace Sackey','Pediatrics',0)
('Dr. Jonathan McReynolds','Pediatrics',1);

INSERT INTO Patients(FullName, Email) VALUES
('Leslie Adottey Allotey','leslieadollo@gmail.com'),
('Emmanuella Kumah','ekemmanuella@gmail.com'),
('Jessica Gyimah','jessicagyimah@gmail.com'),
('Jennifer Agyapong','jenagya@gmail.com');
