-- для решения этой задачи обычно используется третья таблица
-- например ProductCategories  гда будет id из первой таблицы 
-- и из второй

SELECT P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID
