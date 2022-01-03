A stored function is a special kind stored program that returns a single value. Typically, you use stored functions to encapsulate common formulas or business rules that are reusable among SQL statements or stored programs.

To create a new stored function:

```sql
DELIMITER $$

CREATE FUNCTION Customer_Level(
    credit DECIMAL(10,2)
) 
RETURNS VARCHAR(20)
DETERMINISTIC
BEGIN
    DECLARE customerLevel VARCHAR(20);

    IF credit > 50000 THEN
		    SET customerLevel = 'PLATINUM';
    ELSEIF (credit >= 50000 AND credit <= 10000) THEN
        SET customerLevel = 'GOLD';
    ELSEIF credit < 10000 THEN
        SET customerLevel = 'SILVER';
    END IF;

	-- return the customer level
	RETURN (customerLevel);
END$$
DELIMITER ;
```


To use this function:

```sql
SELECT c.id, Customer_Level(c.credit) FROM Customers c GROUP BY c.id;
```
