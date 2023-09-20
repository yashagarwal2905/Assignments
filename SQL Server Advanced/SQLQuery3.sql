SELECT * FROM Student

CREATE NONCLUSTERED INDEX contact_filter_index
ON Student(ContactNumber)

CREATE INDEX Student_Course_Index  on Student (StudentName ASC, CourseName ASC);

DROP INDEX  contact_filter_index  on Student

CREATE NONCLUSTERED INDEX contact_filter_index
ON Student(ContactNumber)

EXEC sp_rename 'Student.contact_filter_index','contact_filters_index'

ALTER INDEX contact_filters_index on Student DISABLE	

ALTER INDEX contact_filters_index on Student REBUILD

CREATE VIEW [Products Above Average] AS
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);	

SELECT * FROM [Products Above Average]

EXEC sp_rename '[Products Above Average]', 'Low Cost Products';

SELECT * FROM [Low Cost Products]


DROP VIEW [Low Cost Products]




