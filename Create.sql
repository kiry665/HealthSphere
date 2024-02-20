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

INSERT INTO Specializations(Name_speciality)
VALUES
    ('Терапевт'),
    ('Офтальмолог'),
    ('Хирург'),
    ('Дерматолог'),
    ('Ортопед'),
    ('Невролог'),
    ('Отоларинголог'),
    ('Кардиолог'),
    ('Фтизиатр'),
    ('Аллерголог');

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



INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Фролов', 'Елисей', 'Николаевич', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Грибов', 'Платон', 'Кириллович', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Попов', 'Максим', 'Андреевич', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Морозов', 'Вячеслав', 'Олегович', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Зверев', 'Фёдор', 'Георгиевич', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Русанов', 'Даниил', 'Михайлович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Филатов', 'Александр', 'Ярославович', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Сычев', 'Марат', 'Михайлович', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Молчанов', 'Даниил', 'Ярославович', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Морозов', 'Григорий', 'Михайлович', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Макеев', 'Никита', 'Егорович', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Симонов', 'Максим', 'Константинович', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Свешников', 'Анатолий', 'Богданович', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Леонтьев', 'Даниил', 'Фёдорович', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Павлов', 'Демид', 'Артёмович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Некрасов', 'Иван', 'Романович', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Казаков', 'Артём', 'Артёмович', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Фролов', 'Матвей', 'Богданович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Кузнецов', 'Тимур', 'Фёдорович', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Павлов', 'Артём', 'Михайлович', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Кондратьев', 'Леонид', 'Александрович', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Орлов', 'Фёдор', 'Михайлович', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Матвеев', 'Марк', 'Богданович', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Попов', 'Максим', 'Никитич', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Макеев', 'Константин', 'Иванович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Панов', 'Матвей', 'Александрович', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Новиков', 'Алексей', 'Петрович', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Петров', 'Леонид', 'Артёмович', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Романов', 'Олег', 'Александрович', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Попов', 'Ярослав', 'Лукич', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Аксенов', 'Леонид', 'Максимович', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Лапин', 'Георгий', 'Тимурович', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Максимов', 'Фёдор', 'Егорович', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Владимиров', 'Лев', 'Романович', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Афанасьев', 'Леонид', 'Григорьевич', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Майоров', 'Даниэль', 'Егорович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Логинов', 'Артём', 'Фёдорович', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Ермолаев', 'Тимофей', 'Тимурович', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Лебедев', 'Билал', 'Олегович', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Иванов', 'Дмитрий', 'Михайлович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Лыков', 'Максим', 'Иванович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Борисов', 'Даниэль', 'Матвеевич', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Захаров', 'Кирилл', 'Егорович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Иванов', 'Тимофей', 'Данилович', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Симонов', 'Михаил', 'Михайлович', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Никитин', 'Савва', 'Никитич', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Покровский', 'Платон', 'Александрович', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Климов', 'Станислав', 'Арсентьевич', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Зимин', 'Илья', 'Олегович', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Романов', 'Арсений', 'Артёмович', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Рыбакова', 'Сафия', 'Эмировна', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Кудрявцева', 'Виктория', 'Максимовна', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Носова', 'Вероника', 'Дмитриевна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Федотова', 'Виктория', 'Андреевна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Александрова', 'Елизавета', 'Даниэльевна', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Сазонова', 'Виктория', 'Билаловна', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Егорова', 'Агата', 'Ильинична', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Матвеева', 'Ксения', 'Павловна', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Мартынова', 'Карина', 'Михайловна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Горбунова', 'Элина', 'Романовна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Савельева', 'Карина', 'Михайловна', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Морозова', 'Анастасия', 'Платоновна', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Яковлева', 'Дарья', 'Давидовна', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Богданова', 'Амира', 'Тимуровна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Богданова', 'Айлин', 'Даниэльевна', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Иванова', 'Вероника', 'Георгиевна', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Иванова', 'Мария', 'Дмитриевна', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Киселева', 'Зоя', 'Алексеевна', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Смирнова', 'Ульяна', 'Глебовна', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Шмелева', 'София', 'Глебовна', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Мальцева', 'София', 'Всеволодовна', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Филимонова', 'Василиса', 'Максимовна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Михайлова', 'Виктория', 'Алексеевна', '4');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Зайцева', 'Мария', 'Романовна', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Петрова', 'Маргарита', 'Кирилловна', '5');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Алешина', 'Эмма', 'Егоровна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Петрова', 'Арина', 'Артёмовна', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Петрова', 'Вероника', 'Мирославовна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Яковлева', 'Анна', 'Никитична', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Егорова', 'Кристина', 'Фёдоровна', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Серова', 'Виктория', 'Ярославовна', '8');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Панова', 'Арина', 'Алексеевна', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Грибова', 'Василиса', 'Николаевна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Кузнецова', 'Виктория', 'Вячеславовна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Миронова', 'Анастасия', 'Игоревна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Левина', 'Варвара', 'Ильинична', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Зорина', 'Алиса', 'Мироновна', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Балашова', 'Валерия', 'Павловна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Павлова', 'Сафия', 'Петровна', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Владимирова', 'Ева', 'Кирилловна', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Егорова', 'София', 'Романовна', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Блинова', 'Александра', 'Павловна', '3');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Ерофеева', 'Ксения', 'Тимуровна', '10');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Антипова', 'Кристина', 'Артёмовна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Булатова', 'Александра', 'Георгиевна', '1');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Федорова', 'Валерия', 'Денисовна', '6');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Богданова', 'Полина', 'Константиновна', '9');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Иванова', 'Елизавета', 'Данииловна', '7');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Черных', 'Аделина', 'Егоровна', '2');
INSERT INTO doctors (Last_name, First_name, Patronymic, Specializationid) VALUES ('Сорокина', 'Алиса', 'Егоровна', '8');





