INSERT INTO Book (Title, ISBN, PublicationYear, AvailableCopies)
VALUES ('To Kill a Mockingbird', '9780060935467', 1960, 3),
       ('1984', '9780451524935', 1949, 2),
       ('The Catcher in the Rye', '9780316769174', 1951, 4);

INSERT INTO Member (FirstName, LastName, Address, PhoneNumber, Email, RegistrationDate)
VALUES ('John', 'Doe', '123 Main St', '555-1234', 'john.doe@example.com', '2020-01-01'),
       ('Jane', 'Smith', '456 Elm St', '555-5678', 'jane.smith@example.com', '2021-05-15');

INSERT INTO Loan (BookId, MemberId, LoanDate, DueDate)
VALUES (1, 1, '2022-01-05', '2022-01-19'),
       (2, 2, '2022-02-10', '2022-02-24'),
       (3, 1, '2022-03-01', '2022-03-15');
