CREATE DATABASE digify;

USE digify;

CREATE TABLE CompanyRegistration (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CompanyName NVARCHAR(255) NOT NULL,
    NPWP NVARCHAR(50) NOT NULL,
    DirectorName NVARCHAR(255) NOT NULL,
    PICName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(50) NOT NULL,
    NPWPFilePath NVARCHAR(500) NULL,
    PowerOfAttorneyFilePath NVARCHAR(500) NULL,
    IsInvitationAccessAllowed BIT NOT NULL
);
