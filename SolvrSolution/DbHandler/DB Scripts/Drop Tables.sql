use SolvrDB

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
--EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"

DROP TABLE taglists;
DROP TABLE reports;
DROP TABLE votes;
DROP TABLE comments;
DROP TABLE posts;
DROP TABLE tags;
DROP TABLE categories;
DROP TABLE users;