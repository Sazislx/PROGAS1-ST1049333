--CREATE TABLE FOR ORGANISER
CREATE TABLE Organiser (
    OrganiserID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Organisation VARCHAR(100) NULL
);

--TABLE FOR PARTICIPANT
CREATE TABLE Participant (
    ParticipantID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    DOB DATE NOT NULL
);

--TABLE FOR EVENT
CREATE TABLE Event (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    Location VARCHAR(100) NOT NULL,
    OrganiserID INT NOT NULL,
    CONSTRAINT FK_Event_Organiser FOREIGN KEY (OrganiserID) REFERENCES Organiser(OrganiserID)
);
 
 --TABLE FOR CATAGORY
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    DistanceKm DECIMAL(5,2) NOT NULL,
    EventID INT NOT NULL,
    CONSTRAINT FK_Category_Event FOREIGN KEY (EventID) REFERENCES Event(EventID)
);

--TABLE FOR ENTRY
CREATE TABLE Entry (
    EntryID INT IDENTITY(1,1) PRIMARY KEY,
    ParticipantID INT NOT NULL,
    CategoryID INT NOT NULL,
    BibNumber INT NOT NULL,
    RegistrationDate DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Entry_Participant FOREIGN KEY (ParticipantID) REFERENCES Participant(ParticipantID),
    CONSTRAINT FK_Entry_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);
 
 --TABLE FOR DATA
CREATE TABLE Result (
    ResultID INT IDENTITY(1,1) PRIMARY KEY,
    EntryID INT NOT NULL UNIQUE,
    FinishTime TIME NOT NULL,
    Position INT NOT NULL,
    CONSTRAINT FK_Result_Entry FOREIGN KEY (EntryID) REFERENCES Entry(EntryID)
);


INSERT INTO Organiser (Name, Email, Organisation) VALUES
('Lindiwe Khumalo', 'lindiwe@comrades.co.za', 'Comrades Marathon Association'),
('Pieter van Wyk', 'pieter@capetowncycle.co.za', 'Cape Town Cycle Tour');
 
INSERT INTO Participant (Name, Email, DOB) VALUES
('Thabo Mokoena', 'thabo.m@gmail.com', '1995-03-14'),
('Sarah Johnson', 'sarah.j@gmail.com', '1990-07-22');
 
INSERT INTO Event (EventName, EventDate, Location, OrganiserID) VALUES
('Comrades Marathon', '2027-06-13', 'Pietermaritzburg', 1),
('Cape Town Cycle Tour', '2027-03-08', 'Cape Town', 2),
('Soweto Marathon', '2027-11-07', 'Soweto', 1);
 
INSERT INTO Category (CategoryName, DistanceKm, EventID) VALUES
('Full Marathon', 89.00, 1),
('Ultra Marathon', 56.00, 1),
('Cycle Race', 109.00, 2),
('Half Marathon', 21.10, 3),
('10km Fun Run', 10.00, 3);
 
INSERT INTO Entry (ParticipantID, CategoryID, BibNumber) VALUES
(1, 1, 1001),
(2, 3, 2001),
(1, 5, 3001);