-- Question 5 (SQL)
-- A. Return the names of all salespeople that have an order with George

SELECT DISTINCT sp.Name from Salesperson sp
	INNER JOIN Orders o
		ON sp.SalespersonID = o.SalespersonID
	INNER JOIN Customer c
	    ON o.CustomerID = c.CustomerID
	WHERE c.Name = 'George'

------------------------------------------------------------------------------------------------
-- B. Return the names of all salespeople that do not have any order with George

SELECT DISTINCT sp.Name from Salesperson sp
	INNER JOIN Orders o
		ON sp.SalespersonID = o.SalespersonID
	INNER JOIN Customer c
	    ON o.CustomerID = c.CustomerID
	WHERE c.Name <> 'George'

------------------------------------------------------------------------------------------------
-- C. Return the names of salespeople that have 2 or more orders.

SELECT sp.Name FROM Salesperson sp
	INNER JOIN (SELECT COUNT(*) AS cnt, SalespersonID FROM Orders o GROUP BY o.SalespersonID) AS os
		ON os.SalespersonID = sp.SalespersonID
		AND os.cnt >= 2


------------------------------------------------------------------------------------------------
-- Question 6 (SQL)
-- A. Return the name of the salesperson with the 3rd highest salary.

SELECT sp.Name FROM Salesperson sp
	INNER JOIN ( SELECT sp_slr.Salary, ROW_NUMBER() OVER(ORDER BY sp_slr.Salary DESC) As RowNum 
						FROM (SELECT DISTINCT TOP 3 sp_sld.salary
							FROM Salesperson sp_sld 
							ORDER BY sp_sld.salary DESC) as sp_slr) as sp_sl
		ON sp.Salary = sp_sl.Salary
		AND sp_sl.RowNum = 3

------------------------------------------------------------------------------------------------
-- B. Create a new roll­up table BigOrders(where columns are CustomerID, TotalOrderValue), 
-- and insert into that table customers whose total Amount across all orders is greater than 1000

CREATE TABLE [dbo].[BigOrders](
	[CustomerID] [int] NOT NULL,
	[TotalOrderValue] [int] NOT NULL,
	FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
);

INSERT INTO [dbo].[BigOrders]
SELECT o.CustomerID, SUM(o.NumberOfUnits*o.CostOfUnit) as TotalOrderValue FROM Orders o
	GROUP BY o.CustomerID
	HAVING SUM(o.NumberOfUnits*o.CostOfUnit) > 1000

------------------------------------------------------------------------------------------------
-- C. Return the total Amount of orders for each month, ordered by year, then month (both in descending order)

SELECT SUM(o.NumberOfUnits*o.CostOfUnit) as TotalAmt, YEAR(o.OrderDate) as OrderYear,Month(o.OrderDate) as OrderMonth FROM Orders o
GROUP BY YEAR(o.OrderDate),Month(o.OrderDate)
ORDER BY YEAR(o.OrderDate) DESC,Month(o.OrderDate) DESC

------------------------------------------------------------------------------------------------