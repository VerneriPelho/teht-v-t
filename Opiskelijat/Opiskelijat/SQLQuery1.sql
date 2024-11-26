CREATE TABLE opiskelija (
    id INT IDENTITY PRIMARY KEY,
    etunimi VARCHAR(50) NOT NULL,
    sukunimi VARCHAR(50) NOT NULL,
    ryhma_id INT
);

CREATE TABLE opiskelijaryhma (
    id INT IDENTITY PRIMARY KEY,
    ryhmannimi VARCHAR(50) NOT NULL
);

INSERT INTO opiskelijaryhma (ryhmannimi)
VALUES ('Ryhmä A'), ('Ryhmä B'), ('Ryhmä C');

INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id)
VALUES 
('Anna', 'Virtanen', 1),
('Pekka', 'Korhonen', 2),
('Liisa', 'Mäkinen', 1),
('Matti', 'Niemi', 3),
('Kaisa', 'Heikkinen', 2),
('Juhani', 'Lehtonen', 3),
('Eeva', 'Laaksonen', 1),
('Kalle', 'Hakala', 2),
('Tiina', 'Karjalainen', 3),
('Antti', 'Salminen', 1);

