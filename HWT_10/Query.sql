--1.1 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при любых региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements” в Books Online раздел “Accessing and Changing Relational Data Overview”. 
--Этот метод использовать далее для всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia. 
--Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate.
DECLARE @date NVARCHAR(8)
SET  @date = '19980506'
SELECT  OrderID
        ,ShippedDate
        ,ShipVia
FROM  Northwind.Northwind.Orders
WHERE ShippedDate >= CONVERT(DATETIME, @date,101)
      AND ShipVia >= 2
-- Ответ: в результат не попали заказы с NULL-ом, т.к. сравнение любого значения с NULL выдаст результат UNKNOWN (а не TRUE).


-- 1.2 Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
-- В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен высвечивать только колонки OrderID и ShippedDate.
SELECT  OrderID
        ,CASE
          WHEN ShippedDate IS NULL
          THEN  'Not Shipped'
        END AS 'Shipped Date'
FROM  Northwind.Orders
WHERE ShippedDate IS NULL


-- 1.3 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только колонки OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date). 
-- В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, для остальных значений высвечивать дату в формате по умолчанию.
DECLARE @minDate NVARCHAR(8)
SET  @minDate = '19980506'
SELECT  OrderID AS 'Order Number'
        ,CASE
          WHEN ShippedDate IS NULL
          THEN  'Not Shipped'
          ELSE  CONVERT(VARCHAR,ShippedDate,20)
         END AS 'Shipped Date'
FROM  Northwind.Orders
WHERE ShippedDate > CONVERT(DATETIME, @minDate,101)
      OR ShippedDate IS NULL


-- 2.1 Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. Запрос сделать с только помощью оператора IN. 
-- Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту проживания.
SELECT  ContactName
        ,Country
FROM Northwind.Northwind.Customers
WHERE Country IN ('USA','Canada')
ORDER BY ContactName, Country


-- 2.2 Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. Запрос сделать с помощью оператора IN. 
-- Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков.
SELECT  ContactName
        ,Country
FROM Northwind.Northwind.Customers
WHERE Country NOT IN ('USA','Canada')
ORDER BY ContactName


-- 2.3 Выбрать из таблицы Customers все страны, в которых проживают заказчики. Страна должна быть упомянута только один раз и список отсортирован по убыванию. 
-- Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса.
SELECT DISTINCT Country
FROM  Northwind.Northwind.Customers
ORDER BY Country DESC


-- 3.1 Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details. 
-- Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.
DECLARE @minQuantity SMALLINT
        ,@maxQuantity SMALLINT
SET @minQuantity = 3
SET @maxQuantity = 10
SELECT  OrderID
FROM  Northwind.[Order Details]
WHERE Quantity BETWEEN @minQuantity AND @maxQuantity


-- 3.2 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g. Использовать оператор BETWEEN. 
-- Проверить, что в результаты запроса попадает Germany. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
DECLARE @firstLetter CHAR
        ,@lastLetter CHAR
SET @firstLetter = 'b'
SET @lastLetter = 'g'
SELECT  CustomerID
        ,Country
FROM Northwind.Customers
WHERE LEFT(Country, 1) BETWEEN @firstLetter AND @lastLetter
ORDER BY Country


-- 3.3 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g, не используя оператор BETWEEN. 
-- С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3 – для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов, результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам дать ответ на вопрос – по какому параметру было проведено сравнение. 
-- Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
DECLARE @firstLet CHAR
        ,@lastLet CHAR
SET @firstLet = 'b'
SET @lastLet = 'g'
SELECT  CustomerID
        ,Country
FROM Northwind.Customers
WHERE LEFT(Country, 1) >= @firstLet AND LEFT(Country, 1) <= @lastLet
ORDER BY Country
-- С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3
-- Результат Execution Plan: http://imgur.com/OVigVV6
-- Исходя из результатов, оба варианты оказались одинаковы по производительности (я так понимаю БД сама оптимизирует второй запрос), но с точки зрения читабельности, 3.2 естественно лучше.


-- 4.1 В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. 
-- Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты, которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.
SELECT ProductName
FROM Northwind.Products
WHERE ProductName LIKE '%cho_olade%'


-- 5.1 Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money. 
-- Скидка (колонка Discount) составляет процент из стоимости для данного товара. Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.
SELECT  CONVERT (MONEY, ROUND(SUM( (UnitPrice - Discount) * Quantity), 2), 1) AS 'Totals'
FROM  Northwind.[Order Details] 


-- 5.2 По таблице Orders найти количество заказов, которые еще не были доставлены (т.е. в колонке ShippedDate нет значения даты доставки).
-- Использовать при этом запросе только оператор COUNT. Не использовать предложения WHERE и GROUP.
SELECT  COUNT(ShippedDate) AS 'Count not shipped orders'
FROM  Northwind.Orders


-- 5.3 По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
SELECT COUNT(DISTINCT CustomerID) AS 'Count customers'
FROM Northwind.Orders


-- 6.1 По таблице Orders найти количество заказов с группировкой по годам. В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
SELECT YEAR(OrderDate) AS Year
       ,COUNT(YEAR(OrderDate)) AS Total
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)
-- Написать проверочный запрос, который вычисляет количество всех заказов.
SELECT COUNT(OrderID) AS TotalOrders
FROM Northwind.Orders


-- 6.2 По таблице Orders найти количество заказов, cделанных каждым продавцом. Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного продавца. 
-- В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName. Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. 
-- Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть упорядочены по убыванию количества заказов.
SELECT (SELECT employees.LastName
               + ' '
               + employees.FirstName
        FROM Northwind.Employees employees
        WHERE orders.EmployeeID = employees.EmployeeID) AS Seller
        ,COUNT(orders.EmployeeID) AS Amount
FROM  Northwind.Orders orders
GROUP BY  orders.EmployeeID
ORDER BY  COUNT(orders.EmployeeID) DESC


-- 6.3 По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. Необходимо определить это только для заказов сделанных в 1998 году. 
-- В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), колонку с именем покупателя (название колонки ‘Customer’) и колонку c количеством заказов высвечивать с названием 'Amount'. 
-- В запросе необходимо использовать специальный оператор языка T-SQL для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса). Группировки должны быть сделаны по ID продавца и покупателя.
-- Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж. В результатах должна быть сводная информация по продажам.
SELECT CASE WHEN GROUPING(orders.EmployeeID) = 1
                 THEN 'All'
            ELSE (SELECT employees.LastName
                  + ' '
                  + employees.FirstName
                  FROM Northwind.Employees employees
                  WHERE orders.EmployeeID = employees.EmployeeID)
       END AS Seller
       ,CASE WHEN GROUPING(orders.CustomerID) = 1
                 THEN 'All'
             ELSE (SELECT customers.ContactName
                   FROM Northwind.Customers customers
                   WHERE orders.CustomerID = customers.CustomerID) 
        END AS Customer
        ,COUNT(orders.EmployeeID) AS Amount
FROM  Northwind.Orders orders
GROUP BY CUBE (orders.EmployeeID,orders.CustomerID)
ORDER BY orders.EmployeeID
         ,orders.CustomerID
         ,COUNT(orders.EmployeeID) DESC


-- 6.4 Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один или несколько продавцов или только один или несколько покупателей, то информация о таких покупателя и продавцах не должна попадать в результирующий набор.
-- Не использовать конструкцию JOIN. В результатах запроса необходимо вывести следующие заголовки для результатов запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или ‘Seller’ в завимости от типа записи), ‘City’. 
-- Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
SELECT customers.ContactName AS Person
       ,customers.City
       ,'Customer' AS Type
FROM  Northwind.Customers customers
WHERE customers.City IN (SELECT employees.City
                         FROM Northwind.Employees employees)
UNION
SELECT employees.LastName + ' ' + employees.FirstName AS Person
       ,employees.City
       ,'Seller' AS Type
FROM  Northwind.Employees employees
WHERE employees.City IN (SELECT customers.City
                         FROM Northwind.Customers customers)
ORDER BY City,Person


-- 6.5 Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы Customers c собой - самосоединение. 
-- Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи.
SELECT  customers.CustomerID
        ,customers.City
FROM  Northwind.Customers customers
      ,Northwind.Customers customers2
WHERE customers.City = customers2.City
      AND customers.CustomerID != customers2.CustomerID
GROUP BY customers.CustomerID, customers.City
-- Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers. Это позволит проверить правильность запроса.
SELECT City
FROM Northwind.Customers
GROUP BY City
HAVING COUNT(City) > 1


-- 6.6 По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. Высветить колонки с именами 'User Name' (LastName) и 'Boss'. В колонках должны быть высвечены имена из колонки LastName. 
-- Высвечены ли все продавцы в этом запросе?
SELECT  employees1.LastName AS 'User Name'
        ,employees2.LastName AS 'Boss'
FROM  Northwind.Employees employees1
      ,Northwind.Employees employees2
WHERE employees1.ReportsTo = employees2.EmployeeID
-- Ответ: в запросе высвечены не все продавцы, т.к. у одного из них нет руководителя - значение атрибута равно NULL, соответственно условие в секции WHERE никогда не выполнится.


-- 7.1 Определить продавцов, которые обслуживают регион 'Western' (таблица Region). 
-- Результаты запроса должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN в предложении FROM. 
DECLARE @requiredRegion NVARCHAR(20)
SET @requiredRegion = 'Western'
SELECT employees.LastName AS Name
       ,region.RegionDescription AS Region
FROM Northwind.Employees employees
JOIN  Northwind.EmployeeTerritories emplTerritories
      ON emplTerritories.EmployeeID = employees.EmployeeID
JOIN  Northwind.Territories territories
      ON emplTerritories.TerritoryID = territories.TerritoryID
JOIN  Northwind.Region region
      ON territories.RegionID = region.RegionID
GROUP BY  employees.LastName
          ,region.RegionDescription
HAVING region.RegionDescription =  @requiredRegion


--8.1 Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders. 
-- Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. Упорядочить результаты запроса по возрастанию количества заказов.
SELECT customers.ContactName
       ,COUNT(orders.OrderID)
FROM Northwind.Customers customers
LEFT OUTER JOIN Northwind.Orders orders
           ON  customers.CustomerID = orders.CustomerID
GROUP BY  customers.ContactName
ORDER BY  COUNT(orders.OrderID) 


-- 9.1 Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный SELECT для этого запроса с использованием оператора IN.
SELECT suppliers.CompanyName
FROM Northwind.Suppliers suppliers
WHERE suppliers.SupplierID IN (SELECT products.SupplierID
                               FROM Northwind.Products products
                               WHERE products.UnitsInStock = 0)
-- Можно ли использовать вместо оператора IN оператор '=' ?
-- Ответ: В данном случае нет, т.к. нам заранее не известна результирующая выборка, но в данном случае так же можно использовать конструкцию JOIN вместо подзапроса.


-- 10.1 Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
DECLARE @minCountOrders INT
SET @minCountOrders = 150
SELECT  employees.LastName AS Name
FROM Northwind.Employees employees
WHERE (SELECT COUNT(orders.EmployeeID)
       FROM Northwind.Orders orders
       WHERE employees.EmployeeID = orders.EmployeeID) > @minCountOrders


-- 11.1 Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.
SELECT  customers.ContactName
FROM  Northwind.Customers customers
WHERE  NOT EXISTS (SELECT orders.CustomerID
                   FROM Northwind.Orders orders
                   WHERE orders.CustomerID = customers.CustomerID)


-- 12.1 Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. 
-- Алфавитный список должен быть отсортирован по возрастанию.
SELECT LEFT(employees.LastName, 1)
FROM Northwind.Employees employees
GROUP BY LEFT(employees.LastName, 1)


-- 13.1 Пример вызова процедуры 'GreatestOrders' - показывает самые крупные заказы продавцов за определенный год.
EXEC Northwind.GreatestOrders @RequiredYear = '1998', @CountOrders = 9;
-- Также помимо демонстрации вызовов процедур надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос для тестирования правильности работы процедуры GreatestOrders. 
-- Проверочный запрос должен выводить в удобном для сравнения с результатами работы процедур виде для определенного продавца для всех его заказов за определенный указанный год в результатах следующие колонки: имя продавца, номер заказа, сумму заказа. 
DECLARE @requiredIdEmployer INT
        ,@requiredYear NVARCHAR(10)
SET  @requiredIdEmployer = 6 
SET  @requiredYear = '1998'
SELECT  employees.LastName AS Name
        ,orderDetails.OrderID AS OrderID
        ,((orderDetails.UnitPrice - orderDetails.Discount) * orderDetails.Quantity) AS Price
FROM Northwind.Employees employees
JOIN Northwind.Orders orders
  ON  orders.EmployeeID = employees.EmployeeID
      AND YEAR(@requiredYear) = YEAR(orders.OrderDate)
JOIN Northwind.[Order Details] orderDetails
  ON orderDetails.OrderID = orders.OrderID
WHERE  employees.EmployeeID = @requiredIdEmployer
ORDER BY  Price DESC


-- 13.2 Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях.
EXEC Northwind.ShippedOrdersDiff @SpecifiedDelay = 15;


-- 13.3 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и подчиненных его подчиненных.
EXEC Northwind.SubordinationInfo @EmployeeID = 4;


-- 13.4 Продемонстрировать использование функции IsBoss для всех продавцов из таблицы Employees.
SELECT  employees.EmployeeID
        ,employees.ReportsTo
        ,Northwind.IsBoss(employees.EmployeeID) AS IsBoss
FROM Northwind.Employees AS employees;