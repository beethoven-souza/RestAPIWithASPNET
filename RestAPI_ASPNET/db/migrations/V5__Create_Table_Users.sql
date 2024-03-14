CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_name VARCHAR(50) NOT NULL DEFAULT '0',
    password VARCHAR(130) NOT NULL DEFAULT '0',
    full_name VARCHAR(120) NOT NULL,
    refresh_token VARCHAR(500) NOT NULL DEFAULT '0',
    refresh_token_expiry_time DATETIME NULL
);

CREATE UNIQUE INDEX idx_unique_user_name ON users(user_name);