A stored procedure is a segment of declarative SQL statements stored inside the MySQL Server.

To create a new stored procedure:

```sql
DELIMITER $$

CREATE PROCEDURE Get_Order_Status (
    IN  orderStatus VARCHAR(25)
)
BEGIN
    SELECT o.orderNumber
    FROM orders o
    WHERE status = orderStatus;
END$$

DELIMITER ;
```


To use this stored procedure:

```sql
CALL Get_Order_Status('complete');
```