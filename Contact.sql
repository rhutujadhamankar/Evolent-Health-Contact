create table tblContactDetails (
  Personid int IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(255),
  LastName varchar(255),
  Email varchar(255),
  PhoneNumber varchar(255),
  IsActive  BIT NOT NULL DEFAULT 0
  )

  select * from tblContactDetails
