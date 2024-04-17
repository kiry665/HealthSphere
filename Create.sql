CREATE TABLE Users(
    ID SERIAL PRIMARY KEY,
    Login TEXT,
    Password TEXT,
    Level INTEGER
);

CREATE TABLE Patients(
    ID SERIAL PRIMARY KEY,
    Fio TEXT,
    Sex TEXT,
    Date DATE,
    Policy_number INTEGER
);

CREATE TABLE Specializations(
    ID SERIAL PRIMARY KEY,
    Name_speciality TEXT
);

CREATE TABLE Shift(
    ID SERIAL PRIMARY KEY,
    Name TEXT
);

CREATE TABLE Times(
    ID SERIAL PRIMARY KEY,
    Time TIME,
    Shiftid INTEGER,
    FOREIGN KEY (Shiftid) REFERENCES Shift(ID)
);

CREATE TABLE Doctors(
    ID SERIAL PRIMARY KEY,
    Fio TEXT,
    Specializationid INTEGER,
    Userid INTEGER,
    Shiftid INTEGER,
    FOREIGN KEY (Specializationid) REFERENCES Specializations (ID),
    FOREIGN KEY (Userid) REFERENCES Users(ID),
    FOREIGN KEY (Shiftid) REFERENCES Shift(ID)
);


CREATE TABLE Records(
    ID SERIAL PRIMARY KEY,
    Patientid INTEGER,
    Doctorid INTEGER,
    Date DATE,
    Time TIME,
    Completed BOOLEAN DEFAULT False,
    FOREIGN KEY (Patientid) REFERENCES Patients(ID) ON DELETE CASCADE ,
    FOREIGN KEY (Doctorid) REFERENCES Doctors(ID) ON DELETE CASCADE
);

CREATE TABLE Mkb(
    ID SERIAL PRIMARY KEY,
    Code TEXT,
    Description TEXT
);

CREATE TABLE Appointments(
    ID SERIAL PRIMARY KEY,
    Recordid INTEGER,
    Mkbid INTEGER,
    Doctorid INTEGER,
    Patientid INTEGER,
    Result TEXT,
    FOREIGN KEY (Recordid) REFERENCES Records(ID),
    FOREIGN KEY (Mkbid) REFERENCES Mkb(ID),
    FOREIGN KEY (Doctorid) REFERENCES Doctors(ID),
    FOREIGN KEY (Patientid) REFERENCES Patients(ID)
);

