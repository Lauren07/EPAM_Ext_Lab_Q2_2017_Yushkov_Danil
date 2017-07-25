-- 13.1 Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год. В результатах не может быть несколько заказов одного продавца, должен быть только один и самый крупный. 
-- В результатах запроса должны быть выведены следующие колонки: колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость. В запросе надо учитывать Discount при продаже товаров. 
-- Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей. Результаты запроса должны быть упорядочены по убыванию суммы заказа. Процедура должна быть реализована с использованием оператора SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно GreatestOrders.
IF (SELECT object_id('Northwind.GreatestOrders')) IS NOT NULL
    DROP PROCEDURE Northwind.GreatestOrders
GO
CREATE PROCEDURE Northwind.GreatestOrders
    @RequiredYear DATE
    ,@CountOrders INT 
AS
    SELECT TOP(@CountOrders) 
          employees.FirstName + ' ' + employees.LastName  AS 'Name'

          ,(SELECT TOP(1) orders.OrderID
            FROM Northwind.Orders orders
            JOIN Northwind.[Order Details] orderDetails
                 ON orders.OrderID = orderDetails.OrderID
            WHERE orders.EmployeeID = employees.EmployeeID
                  AND YEAR(@RequiredYear) = YEAR(orders.OrderDate)
            ORDER BY ((UnitPrice - (UnitPrice/100*Discount)) * orderDetails.Quantity) DESC) 
              AS 'Order ID'

           ,(SELECT TOP(1) ((UnitPrice - (UnitPrice/100*Discount)) * orderDetails.Quantity) AS Price
            FROM Northwind.Orders orders
            JOIN Northwind.[Order Details] orderDetails
                 ON orders.OrderID = orderDetails.OrderID
            WHERE orders.EmployeeID = employees.EmployeeID
                 AND YEAR(@RequiredYear) = YEAR(orders.OrderDate)
            ORDER BY Price DESC) 
              AS 'Price'

    FROM Northwind.Employees employees
    ORDER BY Price DESC
GO


-- 13.2 Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях (разница между OrderDate и ShippedDate). В результатах должны быть возвращены заказы, срок которых превышает переданное значение или еще недоставленные заказы. 
-- Значению по умолчанию для передаваемого срока 35 дней. Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки: OrderID, OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и OrderDate), SpecifiedDelay (переданное в процедуру значение).
IF (SELECT object_id('Northwind.ShippedOrdersDiff')) IS NOT NULL
    DROP PROCEDURE Northwind.ShippedOrdersDiff
GO
CREATE PROCEDURE Northwind.ShippedOrdersDiff
    @SpecifiedDelay INT = 35
AS
  SELECT  orders.OrderID
          ,orders.OrderDate
          ,orders.ShippedDate
          ,DAY(orders.ShippedDate - orders.OrderDate) AS ShippedDelay
          ,@SpecifiedDelay AS SpecifiedDelay
  FROM  Northwind.Orders orders
  WHERE DAY(orders.ShippedDate - orders.OrderDate) > @SpecifiedDelay
        OR DAY(orders.ShippedDate - orders.OrderDate) IS NULL
  ORDER BY orders.OrderDate
GO


-- 13.3 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и подчиненных его подчиненных. В качестве входного параметра функции используется EmployeeID. 
-- Необходимо распечатать имена подчиненных и выровнять их в тексте (использовать оператор PRINT) согласно иерархии подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен. Название процедуры SubordinationInfo.
IF (SELECT object_id('Northwind.SubordinationInfo')) IS NOT NULL
    DROP PROCEDURE Northwind.SubordinationInfo
GO
CREATE PROCEDURE Northwind.SubordinationInfo
    @EmployeeID INT
AS
DECLARE @Result NVARCHAR(MAX),
        @EmployeeIDStr NVARCHAR(MAX)
SET @EmployeeIDStr = CAST(@EmployeeID AS VARCHAR(MAX));
SET @Result = char(13);

  WITH tree AS 
    (
    SELECT  EmployeeID, LastName
            ,0 AS Level
            ,CAST(EmployeeID AS VARCHAR(255)) AS Path
    FROM Northwind.Employees
    WHERE ReportsTo IS NULL

    UNION ALL

    SELECT  empl.EmployeeID, empl.LastName
            ,Level + 1
            ,CAST(Path + '.' + CAST(empl.EmployeeID AS VARCHAR(255)) AS VARCHAR(255))
    FROM  Northwind.Employees empl
    JOIN tree tree2 
      ON tree2.EmployeeID = empl.ReportsTo
    )
SELECT @Result = @Result + space(tree.Level*2 ) + tree.LastName + char(13)
FROM tree 
WHERE tree.Path LIKE ('%.' + @EmployeeIDStr + '.%')
      OR tree.Path LIKE (@EmployeeIDStr + '.%')
      OR tree.Path LIKE ('%.' + @EmployeeIDStr)
      OR tree.Path = @EmployeeIDStr
ORDER BY Path

PRINT @Result
GO


-- 13.4 Написать функцию, которая определяет, есть ли у продавца подчиненные. Возвращает тип данных BIT.
-- В качестве входного параметра функции используется EmployeeID. Название функции IsBoss.
IF (SELECT object_id('Northwind.IsBoss')) IS NOT NULL
    DROP FUNCTION Northwind.IsBoss
GO
CREATE FUNCTION Northwind.IsBoss (@EmployeeID INT)
RETURNS BIT
AS
  BEGIN
  IF EXISTS (SELECT employees.EmployeeID
             FROM Northwind.Employees employees
             WHERE employees.ReportsTo = @EmployeeID)
    RETURN 1;
  RETURN 0;
  END;
GO