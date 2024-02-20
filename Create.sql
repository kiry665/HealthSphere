CREATE TABLE Users(
    ID SERIAL PRIMARY KEY,
    Login TEXT,
    Password TEXT
);

INSERT INTO Users(Login, Password)
VALUES
    ('kiry665', '111');

CREATE TABLE Patients(
    ID SERIAL PRIMARY KEY,
    Last_name TEXT,
    First_name TEXT,
    Patronymic TEXT,
    Sex TEXT,
    Date DATE
);

INSERT INTO Patients(Last_name, First_name, Patronymic, Sex, Date)
VALUES
    ('Новокшонов', 'Кирилл', 'Евгеньвич', 'М', '23.07.2003');

CREATE TABLE Specializations(
    ID SERIAL PRIMARY KEY,
    Name_speciality TEXT
);

INSERT INTO Specializations(ID, Name_speciality)
VALUES
    (1, 'Терапевт');

CREATE TABLE Doctors(
    ID SERIAL PRIMARY KEY,
    Last_name TEXT,
    First_name TEXT,
    Patronymic TEXT,
    Specializationid INTEGER,
    FOREIGN KEY (Specializationid) REFERENCES Specializations (ID)
);

INSERT INTO Doctors(Last_name, First_name, Patronymic, Specializationid)
VALUES
    ('Семенов', 'Анатолий', 'Павлович', 1);

SELECT Doctors.ID, Doctors.Last_name, Doctors.First_name, Doctors.Patronymic, Specializations.Name_speciality
FROM Doctors
INNER JOIN Specializations ON Doctors.Specializationid = Specializations.ID;

CREATE TABLE Schedule(
    ID INTEGER PRIMARY KEY,
    Time TIME
);

INSERT INTO Schedule(ID, Time)
VALUES
    (1, '9:00'),
    (2, '10:00'),
    (3, '11:00');

CREATE TABLE Records(
    ID SERIAL PRIMARY KEY,
    Patientid INTEGER,
    Date DATE,
    Scheduleid INTEGER,
    Doctorid INTEGER,
    FOREIGN KEY (Patientid) REFERENCES Patients (ID) ON DELETE CASCADE,
    FOREIGN KEY (Scheduleid) REFERENCES Schedule(ID) ON DELETE CASCADE ,
    FOREIGN KEY (Doctorid) REFERENCES Doctors(ID) ON DELETE CASCADE
);

INSERT INTO Records(Patientid, Date, Scheduleid, Doctorid)
VALUES
    (1, '23.02.2024', 1, 1);

SELECT Records.ID, Patients.Last_name, Patients.First_name, Patients.Patronymic, Records.Date, Schedule.Time, Doctors.Last_name, Doctors.First_name, Doctors.Patronymic FROM Records
INNER JOIN Patients ON Records.Patientid = Patients.ID
INNER JOIN Schedule ON Records.Scheduleid = Schedule.ID
INNER JOIN Doctors ON Records.Doctorid = Doctors.ID;

INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Алексеев', 'Егор', 'Артёмович', 'М', '1978-10-11 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Павлов', 'Максим', 'Русланович', 'М', '1989-07-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Гончаров', 'Марк', 'Григорьевич', 'М', '1974-10-23 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Голубев', 'Кирилл', 'Иванович', 'М', '1950-06-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Сомов', 'Дамир', 'Александрович', 'М', '1967-11-04 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Зайцев', 'Ярослав', 'Александрович', 'М', '2005-04-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Кузнецов', 'Максим', 'Алексеевич', 'М', '1999-01-24 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Серов', 'Антон', 'Артёмович', 'М', '1979-07-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Харитонов', 'Руслан', 'Владимирович', 'М', '1995-05-08 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Балашов', 'Илья', 'Артёмович', 'М', '1956-10-24 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Григорьев', 'Матвей', 'Романович', 'М', '1981-04-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Иванов', 'Михаил', 'Игоревич', 'М', '1980-11-15 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Назаров', 'Иван', 'Тимофеевич', 'М', '1965-01-27 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Дементьев', 'Михаил', 'Матвеевич', 'М', '1972-09-26 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Петров', 'Артём', 'Глебович', 'М', '1962-12-19 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Винокуров', 'Евгений', 'Александрович', 'М', '1963-12-04 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Борисов', 'Игорь', 'Тимурович', 'М', '1987-06-15 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Широков', 'Дамир', 'Арсенович', 'М', '1997-09-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Васильев', 'Андрей', 'Михайлович', 'М', '1984-10-25 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Хомяков', 'Александр', 'Русланович', 'М', '1952-12-04 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Фролов', 'Иван', 'Фёдорович', 'М', '1979-10-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Сергеев', 'Михаил', 'Иванович', 'М', '1999-07-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Левин', 'Александр', 'Данилович', 'М', '1971-06-04 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Румянцев', 'Андрей', 'Артёмович', 'М', '1965-12-15 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Николаев', 'Яков', 'Миронович', 'М', '1956-08-22 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Волков', 'Филипп', 'Михайлович', 'М', '1991-01-17 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Ульянов', 'Артём', 'Артёмович', 'М', '1976-08-21 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Синицын', 'Михаил', 'Маркович', 'М', '1958-03-23 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Родионов', 'Максим', 'Иванович', 'М', '1974-01-25 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Харитонов', 'Ярослав', 'Захарович', 'М', '1987-05-20 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Фомин', 'Елисей', 'Сергеевич', 'М', '1977-08-17 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Овчинников', 'Степан', 'Данилович', 'М', '1958-02-02 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Широков', 'Никита', 'Александрович', 'М', '1995-02-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Болдырев', 'Ярослав', 'Александрович', 'М', '1955-09-12 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Антонов', 'Илья', 'Иванович', 'М', '1956-04-15 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Наумов', 'Егор', 'Маркович', 'М', '2000-01-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Иванов', 'Максим', 'Степанович', 'М', '1997-05-16 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Воронин', 'Михаил', 'Ярославович', 'М', '1996-11-02 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Иванов', 'Степан', 'Георгиевич', 'М', '1998-04-04 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Жуков', 'Роман', 'Николаевич', 'М', '1970-05-20 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Данилов', 'Дмитрий', 'Владимирович', 'М', '1976-07-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Филиппов', 'Артём', 'Даниилович', 'М', '1988-09-09 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Жуков', 'Владимир', 'Германович', 'М', '1991-07-18 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Фокин', 'Михаил', 'Григорьевич', 'М', '1957-05-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Щукин', 'Максим', 'Давидович', 'М', '1989-08-14 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Голубев', 'Денис', 'Ильич', 'М', '1973-08-08 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Ушаков', 'Алексей', 'Романович', 'М', '1967-03-24 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Щербаков', 'Максим', 'Григорьевич', 'М', '1992-01-27 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Гусев', 'Савелий', 'Ярославович', 'М', '1965-11-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Лебедев', 'Георгий', 'Святославович', 'М', '1962-05-16 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Зубова', 'Дарья', 'Романовна', 'Ж', '1956-06-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Макарова', 'София', 'Николаевна', 'Ж', '1951-10-21 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Овчинникова', 'Сафия', 'Михайловна', 'Ж', '1974-08-23 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Молчанова', 'Марина', 'Максимовна', 'Ж', '1987-05-15 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Киселева', 'Варвара', 'Семёновна', 'Ж', '1983-09-24 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Симонова', 'Екатерина', 'Константиновна', 'Ж', '2002-04-17 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Карпова', 'Кристина', 'Львовна', 'Ж', '1997-04-19 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Быкова', 'Мария', 'Матвеевна', 'Ж', '1970-10-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Иванова', 'Мария', 'Григорьевна', 'Ж', '1999-05-16 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Беляева', 'Кристина', 'Антоновна', 'Ж', '1970-02-28 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Маркина', 'Стефания', 'Владимировна', 'Ж', '1973-09-22 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Давыдова', 'Майя', 'Ильинична', 'Ж', '1985-06-08 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Николаева', 'Ульяна', 'Дмитриевна', 'Ж', '1962-01-26 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Соболева', 'Полина', 'Артемьевна', 'Ж', '1964-02-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Кузнецова', 'Дарья', 'Егоровна', 'Ж', '1987-03-25 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Егорова', 'Милана', 'Ярославовна', 'Ж', '2005-01-19 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Потапова', 'Алёна', 'Константиновна', 'Ж', '1969-12-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Кузина', 'Анастасия', 'Арсентьевна', 'Ж', '1965-04-09 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Карташова', 'Дарина', 'Тимофеевна', 'Ж', '1991-08-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Афанасьева', 'Арина', 'Захаровна', 'Ж', '1987-10-28 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Петрова', 'София', 'Михайловна', 'Ж', '1992-11-20 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Зайцева', 'Элина', 'Романовна', 'Ж', '1972-03-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Дмитриева', 'Ксения', 'Данииловна', 'Ж', '1953-10-24 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Колесникова', 'Аглая', 'Данииловна', 'Ж', '2003-01-28 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Григорьева', 'Вероника', 'Владимировна', 'Ж', '1953-03-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Смирнова', 'Стефания', 'Кирилловна', 'Ж', '1962-03-17 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Зотова', 'Евгения', 'Марковна', 'Ж', '1958-03-03 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Денисова', 'Валерия', 'Назаровна', 'Ж', '1953-11-23 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Ильина', 'Анна', 'Романовна', 'Ж', '1963-03-26 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Цветкова', 'Злата', 'Ильинична', 'Ж', '1961-03-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Грекова', 'Алиса', 'Леонидовна', 'Ж', '1964-01-21 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Зуева', 'Вера', 'Тимуровна', 'Ж', '1973-09-01 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Демина', 'Елизавета', 'Никитична', 'Ж', '1994-05-28 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Гусева', 'Теона', 'Ильинична', 'Ж', '1978-03-01 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Скворцова', 'Владислава', 'Ивановна', 'Ж', '2003-06-06 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Баранова', 'Ева', 'Арсентьевна', 'Ж', '1969-09-28 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Большакова', 'Амина', 'Николаевна', 'Ж', '2001-08-19 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Журавлева', 'Ксения', 'Матвеевна', 'Ж', '2002-02-16 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Кузнецова', 'Екатерина', 'Михайловна', 'Ж', '1988-03-22 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Захарова', 'Мадина', 'Антоновна', 'Ж', '1995-08-20 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Федорова', 'Марта', 'Ивановна', 'Ж', '1958-11-19 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Архипова', 'Ева', 'Матвеевна', 'Ж', '1955-07-22 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Кузнецова', 'Ариана', 'Максимовна', 'Ж', '1997-08-11 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Михайлова', 'Полина', 'Фёдоровна', 'Ж', '1976-09-12 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Токарева', 'Виктория', 'Максимовна', 'Ж', '1996-07-07 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Новикова', 'Виктория', 'Давидовна', 'Ж', '1972-04-11 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Овчинникова', 'Софья', 'Никитична', 'Ж', '1992-10-10 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Герасимова', 'Олеся', 'Владимировна', 'Ж', '2001-07-05 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Белова', 'Ольга', 'Матвеевна', 'Ж', '1982-08-17 00:00:00');
INSERT INTO patients (Last_name, First_name, Patronymic, Sex, Date) VALUES ('Гордеева', 'Светлана', 'Романовна', 'Ж', '1995-08-07 00:00:00');






