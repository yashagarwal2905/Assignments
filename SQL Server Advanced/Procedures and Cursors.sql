CREATE PROCEDURE A1
AS
BEGIN
    DECLARE @grand DECIMAL;
    SET @grand = 0;

 

    DECLARE C__ursor CURSOR FOR
        SELECT ProductName, UnitsOnOrder, UnitPrice FROM Products;

 

    OPEN C__ursor;

 

    DECLARE @Unitsonorder smallint, @Unitprice MONEY, @Totalamount DECIMAL, @Productname NVARCHAR(40);

 

    FETCH NEXT FROM C__ursor INTO @Productname, @Unitsonorder, @Unitprice;

 

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF (@Unitsonorder > 100)
        BEGIN
            SELECT @Totalamount = ((@Unitsonorder * @Unitprice) - ((@Unitsonorder * @Unitprice) * 0.1));
        END
        ELSE IF (@Unitsonorder > 50)
        BEGIN
            SELECT @Totalamount = ((@Unitsonorder * @Unitprice) - ((@Unitsonorder * @Unitprice) * 0.05));
        END
        ELSE 
        BEGIN
            SELECT @Totalamount = (@Unitsonorder * @Unitprice);
        END

 

        PRINT @Productname + ' - ' + FORMAT(@Totalamount,'N2');
        SET @grand = @grand + @Totalamount;

        FETCH NEXT FROM C__ursor INTO @Productname, @Unitsonorder, @Unitprice;
    END;

 

    CLOSE C__ursor;
    DEALLOCATE C__ursor;

    -- Print the grand total
    PRINT 'GRAND TOTAL : ' + CAST(@grand AS VARCHAR(10))
END;

 

EXEC A1
