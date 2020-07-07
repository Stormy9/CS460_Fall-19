-- so i had to alter my data type, haha!
--    (from 'DateTime', b/c that gave you that blank/empty/uneeded Time part
--
ALTER TABLE Astronaut
ADD CONSTRAINT Birthday CHECK (Birthday < GetDate());
--
-- the constraint seems to have worked!  it shows in MSSQLSM for localDB
--    and in the Azure version, too -- it shows in there!
--       oh, and here too..... heh.
--
-- EXAMPLE:
-- ALTER TABLE yourTable
-- ADD CONSTRAINT yourDateTimeColumn CHECK (yourDateTimeColumn < GetDate() );
-- OR:
-- ALTER TABLE my_table ADD CONSTRAINT CHK_DATE CHECK (my_column <= GetDate());
--
-- GetDate() == "today"     [=
--   'GETDATE() is TSQL specific.'		<== per stack overflow
--
-- do this originally like:
-- [Birthday]	DATETIME	NOT NULL,
--		CHECK (Birthday < GetDate());		<== i think   [=

-- if you need to alter a column type:
-- ALTER COLUMN Birthday Date;
-- but can't do it if it's involved in other tables..... just stuck with it   [=