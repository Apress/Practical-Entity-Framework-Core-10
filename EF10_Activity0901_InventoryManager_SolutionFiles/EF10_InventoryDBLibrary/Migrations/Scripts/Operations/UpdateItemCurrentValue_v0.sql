DECLARE @Min DECIMAL(18,4) = 00.01;
DECLARE @Max DECIMAL(18,4) = 199.99;

UPDATE Items
SET CurrentValue = @Min + 
                  (ABS(CHECKSUM(NEWID())) % 10000 / 10000.0) 
                  * (@Max - @Min);

Update Items
Set Quantity = CAST((ABS(CHECKSUM(NEWID())) % 10000 / 10000.0) 
                  * (10 - 1) as INT);