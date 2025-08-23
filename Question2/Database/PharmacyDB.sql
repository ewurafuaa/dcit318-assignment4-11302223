-- === Create DB ===
CREATE DATABASE PharmacyDB;
GO
USE PharmacyDB;
GO

-- === Tables ===
CREATE TABLE Medicines(
  MedicineID INT IDENTITY PRIMARY KEY,
  Name       VARCHAR(100) NOT NULL,
  Category   VARCHAR(100) NOT NULL,
  Price      DECIMAL(18,2) NOT NULL CHECK (Price >= 0),
  Quantity   INT NOT NULL CHECK (Quantity >= 0)
);

CREATE TABLE Sales(
  SaleID        INT IDENTITY PRIMARY KEY,
  MedicineID    INT NOT NULL,
  QuantitySold  INT NOT NULL CHECK (QuantitySold > 0),
  SaleDate      DATETIME NOT NULL DEFAULT(GETDATE()),
  CONSTRAINT FK_Sales_Medicines FOREIGN KEY (MedicineID) REFERENCES Medicines(MedicineID)
);
GO

-- === Stored Procedures ===

-- AddMedicine: inserts and returns new ID via OUTPUT param
CREATE OR ALTER PROCEDURE AddMedicine
  @Name VARCHAR(100),
  @Category VARCHAR(100),
  @Price DECIMAL(18,2),
  @Quantity INT,
  @NewMedicineID INT OUTPUT
AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO Medicines(Name, Category, Price, Quantity)
  VALUES (@Name, @Category, @Price, @Quantity);
  SET @NewMedicineID = SCOPE_IDENTITY();
END
GO

-- SearchMedicine: matches name OR category
CREATE OR ALTER PROCEDURE SearchMedicine
  @SearchTerm VARCHAR(100)
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @term VARCHAR(110) = '%' + ISNULL(@SearchTerm,'') + '%';
  SELECT MedicineID, Name, Category, Price, Quantity
  FROM Medicines
  WHERE Name LIKE @term OR Category LIKE @term
  ORDER BY Name;
END
GO

-- UpdateStock: sets Quantity to a specific value (absolute set)
CREATE OR ALTER PROCEDURE UpdateStock
  @MedicineID INT,
  @Quantity INT
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE Medicines SET Quantity = @Quantity WHERE MedicineID = @MedicineID;
END
GO

-- RecordSale: checks stock, inserts sale, decrements stock (transaction)
CREATE OR ALTER PROCEDURE RecordSale
  @MedicineID INT,
  @QuantitySold INT
AS
BEGIN
  SET NOCOUNT ON;
  BEGIN TRY
    BEGIN TRAN;

    DECLARE @available INT;
    SELECT @available = Quantity FROM Medicines WITH (UPDLOCK, ROWLOCK) WHERE MedicineID = @MedicineID;

    IF @available IS NULL
      THROW 50001, 'Medicine not found.', 1;

    IF @available < @QuantitySold
      THROW 50002, 'Insufficient stock.', 1;

    INSERT INTO Sales(MedicineID, QuantitySold) VALUES(@MedicineID, @QuantitySold);
    UPDATE Medicines SET Quantity = Quantity - @QuantitySold WHERE MedicineID = @MedicineID;

    COMMIT TRAN;
  END TRY
  BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
    THROW;
  END CATCH
END
GO

-- GetAllMedicines: list for grid
CREATE OR ALTER PROCEDURE GetAllMedicines
AS
BEGIN
  SET NOCOUNT ON;
  SELECT MedicineID, Name, Category, Price, Quantity
  FROM Medicines
  ORDER BY Name;
END
GO

-- (Optional) Seed a bit of data to test quickly:
DECLARE @id INT;
EXEC AddMedicine 'Paracetamol', 'Pain Relief', 8.50, 100, @NewMedicineID=@id OUTPUT;
EXEC AddMedicine 'Amoxicillin', 'Antibiotic', 75.00, 50, @NewMedicineID=@id OUTPUT;
EXEC AddMedicine 'Cetirizine', 'Allergy', 13.00, 80, @NewMedicineID=@id OUTPUT;
EXEC AddMedicine 'Viscof S', 'Coughing Fits', 80.00, 80, @NewMedicineID=@id OUTPUT;
EXEC AddMedicine 'Symbicot', 'Asthma Attacks', 360.00, 80, @NewMedicineID=@id OUTPUT;
