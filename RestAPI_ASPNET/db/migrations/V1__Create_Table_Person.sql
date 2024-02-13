 CREATE TABLE [dbo].[person](
        [id] BIGINT IDENTITY(1,1) NOT NULL,
        [address] VARCHAR(100) NOT NULL,
        [first_name] VARCHAR(80) NOT NULL,
        [gender] VARCHAR(15) NOT NULL,
        [last_name] VARCHAR(80) NOT NULL,
        PRIMARY KEY CLUSTERED ([id] ASC)
    );