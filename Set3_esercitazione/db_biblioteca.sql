CREATE TABLE Utenti(
utenteID INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(250) NOT NULL,
cognome VARCHAR(250) NOT NULL,
email VARCHAR(250) NOT NULL UNIQUE,
);

CREATE TABLE Libri(
libroID INT PRIMARY KEY IDENTITY(1,1),
titolo VARCHAR(250) NOT NULL,
anno_pubblicazione INT NOT NULL CHECK (anno_pubblicazione BETWEEN 1455 AND 2024),
disponibilita BIT NOT NULL
);

CREATE TABLE Prestiti(
prestitoID INT PRIMARY KEY IDENTITY(1,1),
data_prestito DATE NOT NULL,
data_ritorno DATE NOT NULL,
utenteRIF INT NOT NULL,
libroRIF INT NOT NULL,
FOREIGN KEY (utenteRIF) REFERENCES Utenti(utenteID) ON DELETE CASCADE,
FOREIGN KEY (libroRIF) REFERENCES Libri(libroID) ON DELETE CASCADE,
);

ALTER TABLE Prestiti ADD CONSTRAINT CHK_date CHECK (data_ritorno > data_prestito); 

INSERT INTO Utenti (nome, cognome, email) VALUES
('Mario', 'Rossi', 'mario.rossi@example.com'),
('Giulia', 'Bianchi', 'giulia.bianchi@example.com'),
('Luca', 'Verdi', 'luca.verdi@example.com'),
('Sara', 'Neri', 'sara.neri@example.com'),
('Federico', 'Ferrari', 'federico.ferrari@example.com'),
('Elena', 'Conti', 'elena.conti@example.com'),
('Giorgio', 'Gallo', 'giorgio.gallo@example.com'),
('Alessia', 'Marini', 'alessia.marini@example.com'),
('Simone', 'Fontana', 'simone.fontana@example.com'),
('Martina', 'Ricci', 'martina.ricci@example.com'),
('Davide', 'Sartori', 'davide.sartori@example.com'),
('Laura', 'Gentile', 'laura.gentile@example.com');

INSERT INTO Libri (titolo, anno_pubblicazione, disponibilita) VALUES
('Il Signore degli Anelli', 1954, 1),
('1984', 1949, 1),
('Orgoglio e Pregiudizio', 1813, 1),
('Il Nome della Rosa', 1980, 1),
('Moby Dick', 1851, 1),
('Cime Tempestose', 1847, 1),
('Guerra e Pace', 1869, 1),
('La Divina Commedia', 1520, 1),
('Il Gattopardo', 1958, 1),
('I Promessi Sposi', 1842, 1),
('Dracula', 1897, 1),
('Il Piccolo Principe', 1943, 1),
('Il Grande Gatsby', 1925, 1),
('Il Processo', 1925, 1),
('La Metamorfosi', 1915, 1),
('Ulisse', 1922, 1),
('Fahrenheit 451', 1953, 1),
('Don Chisciotte', 1605, 1),
('I Miserabili', 1862, 1),
('Frankenstein', 1818, 1),
('Anna Karenina', 1877, 1),
('Le Avventure di Sherlock Holmes', 1892, 1),
('Il Lamento di Portnoy', 1969, 1),
('Madame Bovary', 1857, 1),
('Il Maestro e Margherita', 1967, 1),
('Il Deserto dei Tartari', 1940, 1),
('La Coscienza di Zeno', 1923, 1),
('Lolita', 1955, 1),
('La Montagna Incantata', 1924, 1),
('L’Idiota', 1869, 1);

INSERT INTO Prestiti (data_prestito, data_ritorno, utenteRIF, libroRIF) VALUES
('2024-01-15', '2024-02-15', 1, 1),
('2024-01-18', '2024-02-18', 2, 2),
('2024-02-01', '2024-03-01', 3, 3),
('2024-02-10', '2024-03-10', 4, 4),
('2024-02-14', '2024-03-14', 5, 5),
('2024-03-01', '2024-03-31', 6, 6),
('2024-03-02', '2024-04-02', 7, 7),
('2024-03-10', '2024-04-10', 8, 8),
('2024-03-15', '2024-04-15', 9, 9),
('2024-04-01', '2024-05-01', 10, 10),
('2024-04-05', '2024-05-05', 11, 11),
('2024-04-10', '2024-05-10', 12, 12),
('2024-04-15', '2024-05-15', 1, 13),
('2024-04-20', '2024-05-20', 2, 14),
('2024-05-01', '2024-06-01', 3, 15),
('2024-05-05', '2024-06-05', 4, 16),
('2024-05-10', '2024-06-10', 5, 17),
('2024-06-01', '2024-07-01', 6, 18),
('2024-06-02', '2024-07-02', 7, 19),
('2024-06-10', '2024-07-10', 8, 20),
('2024-06-15', '2024-07-15', 9, 21),
('2024-07-01', '2024-08-01', 10, 22),
('2024-07-05', '2024-08-05', 11, 23),
('2024-07-10', '2024-08-10', 12, 24);

SELECT * FROM Utenti;

SELECT * FROM Libri;

SELECT * FROM Prestiti;