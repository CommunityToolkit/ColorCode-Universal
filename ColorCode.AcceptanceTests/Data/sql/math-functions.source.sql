SELECT ABS(-1.0), ABS(0.0), ABS(1.0)

SET NOCOUNT OFF;
DECLARE @angle float;
SET @angle = -1.0;
SELECT 'The ACOS of the angle is: ' + CONVERT(varchar, ACOS(@angle));

/* The first value will be -1.01. This fails because the value is 
outside the range.*/
DECLARE @angle float
SET @angle = -1.01
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO

-- The next value is -1.00.
DECLARE @angle float
SET @angle = -1.00
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO

-- The next value is 0.1472738.
DECLARE @angle float
SET @angle = 0.1472738
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO

SELECT 'The ATAN of -45.01 is: ' + CONVERT(varchar, ATAN(-45.01))
SELECT 'The ATAN of -181.01 is: ' + CONVERT(varchar, ATAN(-181.01))
SELECT 'The ATAN of 0 is: ' + CONVERT(varchar, ATAN(0))
SELECT 'The ATAN of 0.1472738 is: ' + CONVERT(varchar, ATAN(0.1472738))
SELECT 'The ATAN of 197.1099392 is: ' + CONVERT(varchar, ATAN(197.1099392))
GO

DECLARE @x float
DECLARE @y float
SET @x = 35.175643
SET @y = 129.44
SELECT 'The ATN2 of the angle is: ' + CONVERT(varchar,ATN2(@x,@y ))
GO

SELECT CEILING($123.45), CEILING($-123.45), CEILING($0.0)
GO

DECLARE @angle float
SET @angle = 14.78
SELECT 'The COS of the angle is: ' + CONVERT(varchar,COS(@angle))
GO

DECLARE @angle float
SET @angle = 124.1332
SELECT 'The COT of the angle is: ' + CONVERT(varchar,COT(@angle))
GO

SELECT 'The number of degrees in PI/2 radians is: ' + 
CONVERT(varchar, DEGREES((PI()/2)));
GO

DECLARE @var float
SET @var = 10
SELECT 'The EXP of the variable is: ' + CONVERT(varchar,EXP(@var))
GO

SELECT FLOOR(123.45), FLOOR(-123.45), FLOOR($123.45)

DECLARE @var float
SET @var = 10
SELECT 'The LOG of the variable is: ' + CONVERT(varchar, LOG(@var))
GO

DECLARE @var float
SET @var = 145.175643
SELECT 'The LOG10 of the variable is: ' + CONVERT(varchar,LOG10(@var))
GO

SELECT PI()
GO

SELECT POWER(2.0, -100.0)
GO

SELECT RADIANS(1e-307)
GO

DECLARE @counter smallint
SET @counter = 1
WHILE @counter < 5
    BEGIN
        SELECT RAND() Random_Number
        SET @counter = @counter + 1
    END
GO

SELECT ROUND(123.9994, 3), ROUND(123.9995, 3)
GO

DECLARE @value real
SET @value = -1
WHILE @value < 2
    BEGIN
        SELECT SIGN(@value)
        SET NOCOUNT ON
        SELECT @value = @value + 1
        SET NOCOUNT OFF
    END
SET NOCOUNT OFF
GO

DECLARE @angle float
SET @angle = 45.175643
SELECT 'The SIN of the angle is: ' + CONVERT(varchar,SIN(@angle))
GO

DECLARE @myvalue float;
SET @myvalue = 1.00;
WHILE @myvalue < 10.00
    BEGIN
        SELECT SQRT(@myvalue);
        SET @myvalue = @myvalue + 1
    END;
GO

SELECT TAN(PI()/2);