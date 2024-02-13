CREATE TABLE books (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    author VARCHAR(MAX),
    launch_date DATETIME NOT NULL,
    price DECIMAL(38,2) NOT NULL,
    title VARCHAR(MAX)
);
