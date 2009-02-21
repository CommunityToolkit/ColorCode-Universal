using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlKeywordTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleKnownKeywords()
            {
                string sourceText =
@"ADA
ADD
AFTER
ALL
ALTER
AND
ANY
AS
ASC
ASCII
AT
AUTHORIZATION
AUTO
AVG
BACKUP
BEGIN
BETWEEN
BINARY
BIT
BIT_LENGTH
BREAK
BROWSE
BULK
BY
CASCADE
CASE
CAST
CHAR
CHARACTER
CHARACTER_LENGTH
CHARINDEX
CHAR_LENGTH
CHECK
CHECKPOINT
CLOSE
CLUSTERED
COALESCE
COLLATE
COLUMN
COMMIT
COMPUTE
CONNECT
CONNECTION
CONSTRAINT
CONTAINS
CONTAINSTABLE
CONTINUE
CONVERT
COUNT
CREATE
CROSS
CUBE
CURRENT
CURRENT_DATE
CURRENT_TIME
CURRENT_TIMESTAMP
CURRENT_USER
CURSOR
CURSOR_STATUS
DATABASE
DATALENGTH
DATE
DATETIME
DAY
DB_NAME
DB_ID
DBCC
DEALLOCATE
DEC
DECIMAL
DECLARE
DEFAULT
DEFERRED
DELETE
DENY
DESC
DIFFERENCE
DISK
DISTINCT
DISTRIBUTED
DOUBLE
DROP
DUMMY
DUMP
ELSE
ENCRYPTION
END
END-EXEC
ERRLVL
ESCAPE
EXCEPT
EXEC
EXECUTE
EXISTS
EXIT
EXTERNAL
EXTRACT
FALSE
FETCH
FILE
FILLFACTOR
FIRST
FLOAT
FOR
FOREIGN
FORTRAN
FREE
FREETEXT
FREETEXTTABLE
FROM
FULL
FUNCTION
GLOBAL
GOTO
GRANT
GROUP
GROUPING
HAVING
HOLDLOCK
HOUR
IDENTITY
IDENTITYCOL
IDENTITY_INSERT
IF
IGNORE
IMAGE
IMMEDIATE
IN
INCLUDE
INDEX
INNER
INSENSITIVE
INSERT
INSTEAD
INT
INTEGER
INTERSECT
INTO
IS
ISOLATION
JOIN
KEY
KILL
LANGUAGE
LAST
LEFT
LEN
LEVEL
LIKE
LINENO
LOAD
LOCAL
LOWER
LTRIM
MAX
MIN
MINUTE
MODIFY
MONEY
MONTH
NAME
NATIONAL
NCHAR
NEXT
NOCHECK
NOCOUNT
NONCLUSTERED
NONE
NOT
NULL
NULLIF
NUMERIC
NVARCHAR
OCTET_LENGTH
OF
OFF
OFFSETS
ON
ONLY
OPEN
OPENDATASOURCE
OPENQUERY
OPENROWSET
OPENXML
OPTION
OR
ORDER
OUTER
OUTPUT
OVER
OVERLAPS
PARTIAL
PASCAL
PATINDEX
PERCENT
PLAN
POSITION
PRECISION
PREPARE
PRIMARY
PRINT
PRIOR
PRIVILEGES
PROC
PROCEDURE
PUBLIC
QUOTENAME
RAISERROR
READ
READTEXT
REAL
RECONFIGURE
REFERENCES
REPLACE
REPLICATE
REPLICATION
RESTORE
RESTRICT
RETURN
RETURNS
REVERSE
REVERT
REVOKE
RIGHT
ROLLBACK
ROLLUP
ROWCOUNT
ROWGUIDCOL
ROWS
RTRIM
RULE
SAVE
SCHEMA
SCROLL
SECOND
SECTION
SELECT
SEQUENCE
SESSION_USER
SET
SETUSER
SHUTDOWN
SIZE
SMALLINT
SMALLMONEY
SOME
SOUNDEX
SPACE
SQLCA
SQLERROR
STATISTICS
STR
STUFF
SUBSTRING
SUM
SYSTEM_USER
TABLE
TEMPORARY
TEXT
TEXTSIZE
THEN
TIME
TIMESTAMP
TO
TOP
TRAN
TRANSACTION
TRANSLATION
TRIGGER
TRUE
TRUNCATE
TSEQUAL
UNICODE
UNION
UNIQUE
UPDATE
UPDATETEXT
UPPER
USE
USER
VALUES
VARCHAR
VARYING
VIEW
WAITFOR
WHEN
WHERE
WHILE
WITH
WORK
WRITETEXT
YEAR
BIGINT
TINYINT
SMALLDATETIME
NTEXT
SQL_VARIANT
XML
VAR
TYPE";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">ADA</span>
<span style=""color:Blue;"">ADD</span>
<span style=""color:Blue;"">AFTER</span>
<span style=""color:Blue;"">ALL</span>
<span style=""color:Blue;"">ALTER</span>
<span style=""color:Blue;"">AND</span>
<span style=""color:Blue;"">ANY</span>
<span style=""color:Blue;"">AS</span>
<span style=""color:Blue;"">ASC</span>
<span style=""color:Blue;"">ASCII</span>
<span style=""color:Blue;"">AT</span>
<span style=""color:Blue;"">AUTHORIZATION</span>
<span style=""color:Blue;"">AUTO</span>
<span style=""color:Blue;"">AVG</span>
<span style=""color:Blue;"">BACKUP</span>
<span style=""color:Blue;"">BEGIN</span>
<span style=""color:Blue;"">BETWEEN</span>
<span style=""color:Blue;"">BINARY</span>
<span style=""color:Blue;"">BIT</span>
<span style=""color:Blue;"">BIT_LENGTH</span>
<span style=""color:Blue;"">BREAK</span>
<span style=""color:Blue;"">BROWSE</span>
<span style=""color:Blue;"">BULK</span>
<span style=""color:Blue;"">BY</span>
<span style=""color:Blue;"">CASCADE</span>
<span style=""color:Blue;"">CASE</span>
<span style=""color:Blue;"">CAST</span>
<span style=""color:Blue;"">CHAR</span>
<span style=""color:Blue;"">CHARACTER</span>
<span style=""color:Blue;"">CHARACTER_LENGTH</span>
<span style=""color:Blue;"">CHARINDEX</span>
<span style=""color:Blue;"">CHAR_LENGTH</span>
<span style=""color:Blue;"">CHECK</span>
<span style=""color:Blue;"">CHECKPOINT</span>
<span style=""color:Blue;"">CLOSE</span>
<span style=""color:Blue;"">CLUSTERED</span>
<span style=""color:Blue;"">COALESCE</span>
<span style=""color:Blue;"">COLLATE</span>
<span style=""color:Blue;"">COLUMN</span>
<span style=""color:Blue;"">COMMIT</span>
<span style=""color:Blue;"">COMPUTE</span>
<span style=""color:Blue;"">CONNECT</span>
<span style=""color:Blue;"">CONNECTION</span>
<span style=""color:Blue;"">CONSTRAINT</span>
<span style=""color:Blue;"">CONTAINS</span>
<span style=""color:Blue;"">CONTAINSTABLE</span>
<span style=""color:Blue;"">CONTINUE</span>
<span style=""color:Blue;"">CONVERT</span>
<span style=""color:Blue;"">COUNT</span>
<span style=""color:Blue;"">CREATE</span>
<span style=""color:Blue;"">CROSS</span>
<span style=""color:Blue;"">CUBE</span>
<span style=""color:Blue;"">CURRENT</span>
<span style=""color:Blue;"">CURRENT_DATE</span>
<span style=""color:Blue;"">CURRENT_TIME</span>
<span style=""color:Blue;"">CURRENT_TIMESTAMP</span>
<span style=""color:Blue;"">CURRENT_USER</span>
<span style=""color:Blue;"">CURSOR</span>
<span style=""color:Blue;"">CURSOR_STATUS</span>
<span style=""color:Blue;"">DATABASE</span>
<span style=""color:Blue;"">DATALENGTH</span>
<span style=""color:Blue;"">DATE</span>
<span style=""color:Blue;"">DATETIME</span>
<span style=""color:Blue;"">DAY</span>
<span style=""color:Blue;"">DB_NAME</span>
<span style=""color:Blue;"">DB_ID</span>
<span style=""color:Blue;"">DBCC</span>
<span style=""color:Blue;"">DEALLOCATE</span>
<span style=""color:Blue;"">DEC</span>
<span style=""color:Blue;"">DECIMAL</span>
<span style=""color:Blue;"">DECLARE</span>
<span style=""color:Blue;"">DEFAULT</span>
<span style=""color:Blue;"">DEFERRED</span>
<span style=""color:Blue;"">DELETE</span>
<span style=""color:Blue;"">DENY</span>
<span style=""color:Blue;"">DESC</span>
<span style=""color:Blue;"">DIFFERENCE</span>
<span style=""color:Blue;"">DISK</span>
<span style=""color:Blue;"">DISTINCT</span>
<span style=""color:Blue;"">DISTRIBUTED</span>
<span style=""color:Blue;"">DOUBLE</span>
<span style=""color:Blue;"">DROP</span>
<span style=""color:Blue;"">DUMMY</span>
<span style=""color:Blue;"">DUMP</span>
<span style=""color:Blue;"">ELSE</span>
<span style=""color:Blue;"">ENCRYPTION</span>
<span style=""color:Blue;"">END</span>
<span style=""color:Blue;"">END-EXEC</span>
<span style=""color:Blue;"">ERRLVL</span>
<span style=""color:Blue;"">ESCAPE</span>
<span style=""color:Blue;"">EXCEPT</span>
<span style=""color:Blue;"">EXEC</span>
<span style=""color:Blue;"">EXECUTE</span>
<span style=""color:Blue;"">EXISTS</span>
<span style=""color:Blue;"">EXIT</span>
<span style=""color:Blue;"">EXTERNAL</span>
<span style=""color:Blue;"">EXTRACT</span>
<span style=""color:Blue;"">FALSE</span>
<span style=""color:Blue;"">FETCH</span>
<span style=""color:Blue;"">FILE</span>
<span style=""color:Blue;"">FILLFACTOR</span>
<span style=""color:Blue;"">FIRST</span>
<span style=""color:Blue;"">FLOAT</span>
<span style=""color:Blue;"">FOR</span>
<span style=""color:Blue;"">FOREIGN</span>
<span style=""color:Blue;"">FORTRAN</span>
<span style=""color:Blue;"">FREE</span>
<span style=""color:Blue;"">FREETEXT</span>
<span style=""color:Blue;"">FREETEXTTABLE</span>
<span style=""color:Blue;"">FROM</span>
<span style=""color:Blue;"">FULL</span>
<span style=""color:Blue;"">FUNCTION</span>
<span style=""color:Blue;"">GLOBAL</span>
<span style=""color:Blue;"">GOTO</span>
<span style=""color:Blue;"">GRANT</span>
<span style=""color:Blue;"">GROUP</span>
<span style=""color:Blue;"">GROUPING</span>
<span style=""color:Blue;"">HAVING</span>
<span style=""color:Blue;"">HOLDLOCK</span>
<span style=""color:Blue;"">HOUR</span>
<span style=""color:Blue;"">IDENTITY</span>
<span style=""color:Blue;"">IDENTITYCOL</span>
<span style=""color:Blue;"">IDENTITY_INSERT</span>
<span style=""color:Blue;"">IF</span>
<span style=""color:Blue;"">IGNORE</span>
<span style=""color:Blue;"">IMAGE</span>
<span style=""color:Blue;"">IMMEDIATE</span>
<span style=""color:Blue;"">IN</span>
<span style=""color:Blue;"">INCLUDE</span>
<span style=""color:Blue;"">INDEX</span>
<span style=""color:Blue;"">INNER</span>
<span style=""color:Blue;"">INSENSITIVE</span>
<span style=""color:Blue;"">INSERT</span>
<span style=""color:Blue;"">INSTEAD</span>
<span style=""color:Blue;"">INT</span>
<span style=""color:Blue;"">INTEGER</span>
<span style=""color:Blue;"">INTERSECT</span>
<span style=""color:Blue;"">INTO</span>
<span style=""color:Blue;"">IS</span>
<span style=""color:Blue;"">ISOLATION</span>
<span style=""color:Blue;"">JOIN</span>
<span style=""color:Blue;"">KEY</span>
<span style=""color:Blue;"">KILL</span>
<span style=""color:Blue;"">LANGUAGE</span>
<span style=""color:Blue;"">LAST</span>
<span style=""color:Blue;"">LEFT</span>
<span style=""color:Blue;"">LEN</span>
<span style=""color:Blue;"">LEVEL</span>
<span style=""color:Blue;"">LIKE</span>
<span style=""color:Blue;"">LINENO</span>
<span style=""color:Blue;"">LOAD</span>
<span style=""color:Blue;"">LOCAL</span>
<span style=""color:Blue;"">LOWER</span>
<span style=""color:Blue;"">LTRIM</span>
<span style=""color:Blue;"">MAX</span>
<span style=""color:Blue;"">MIN</span>
<span style=""color:Blue;"">MINUTE</span>
<span style=""color:Blue;"">MODIFY</span>
<span style=""color:Blue;"">MONEY</span>
<span style=""color:Blue;"">MONTH</span>
<span style=""color:Blue;"">NAME</span>
<span style=""color:Blue;"">NATIONAL</span>
<span style=""color:Blue;"">NCHAR</span>
<span style=""color:Blue;"">NEXT</span>
<span style=""color:Blue;"">NOCHECK</span>
<span style=""color:Blue;"">NOCOUNT</span>
<span style=""color:Blue;"">NONCLUSTERED</span>
<span style=""color:Blue;"">NONE</span>
<span style=""color:Blue;"">NOT</span>
<span style=""color:Blue;"">NULL</span>
<span style=""color:Blue;"">NULLIF</span>
<span style=""color:Blue;"">NUMERIC</span>
<span style=""color:Blue;"">NVARCHAR</span>
<span style=""color:Blue;"">OCTET_LENGTH</span>
<span style=""color:Blue;"">OF</span>
<span style=""color:Blue;"">OFF</span>
<span style=""color:Blue;"">OFFSETS</span>
<span style=""color:Blue;"">ON</span>
<span style=""color:Blue;"">ONLY</span>
<span style=""color:Blue;"">OPEN</span>
<span style=""color:Blue;"">OPENDATASOURCE</span>
<span style=""color:Blue;"">OPENQUERY</span>
<span style=""color:Blue;"">OPENROWSET</span>
<span style=""color:Blue;"">OPENXML</span>
<span style=""color:Blue;"">OPTION</span>
<span style=""color:Blue;"">OR</span>
<span style=""color:Blue;"">ORDER</span>
<span style=""color:Blue;"">OUTER</span>
<span style=""color:Blue;"">OUTPUT</span>
<span style=""color:Blue;"">OVER</span>
<span style=""color:Blue;"">OVERLAPS</span>
<span style=""color:Blue;"">PARTIAL</span>
<span style=""color:Blue;"">PASCAL</span>
<span style=""color:Blue;"">PATINDEX</span>
<span style=""color:Blue;"">PERCENT</span>
<span style=""color:Blue;"">PLAN</span>
<span style=""color:Blue;"">POSITION</span>
<span style=""color:Blue;"">PRECISION</span>
<span style=""color:Blue;"">PREPARE</span>
<span style=""color:Blue;"">PRIMARY</span>
<span style=""color:Blue;"">PRINT</span>
<span style=""color:Blue;"">PRIOR</span>
<span style=""color:Blue;"">PRIVILEGES</span>
<span style=""color:Blue;"">PROC</span>
<span style=""color:Blue;"">PROCEDURE</span>
<span style=""color:Blue;"">PUBLIC</span>
<span style=""color:Blue;"">QUOTENAME</span>
<span style=""color:Blue;"">RAISERROR</span>
<span style=""color:Blue;"">READ</span>
<span style=""color:Blue;"">READTEXT</span>
<span style=""color:Blue;"">REAL</span>
<span style=""color:Blue;"">RECONFIGURE</span>
<span style=""color:Blue;"">REFERENCES</span>
<span style=""color:Blue;"">REPLACE</span>
<span style=""color:Blue;"">REPLICATE</span>
<span style=""color:Blue;"">REPLICATION</span>
<span style=""color:Blue;"">RESTORE</span>
<span style=""color:Blue;"">RESTRICT</span>
<span style=""color:Blue;"">RETURN</span>
<span style=""color:Blue;"">RETURNS</span>
<span style=""color:Blue;"">REVERSE</span>
<span style=""color:Blue;"">REVERT</span>
<span style=""color:Blue;"">REVOKE</span>
<span style=""color:Blue;"">RIGHT</span>
<span style=""color:Blue;"">ROLLBACK</span>
<span style=""color:Blue;"">ROLLUP</span>
<span style=""color:Blue;"">ROWCOUNT</span>
<span style=""color:Blue;"">ROWGUIDCOL</span>
<span style=""color:Blue;"">ROWS</span>
<span style=""color:Blue;"">RTRIM</span>
<span style=""color:Blue;"">RULE</span>
<span style=""color:Blue;"">SAVE</span>
<span style=""color:Blue;"">SCHEMA</span>
<span style=""color:Blue;"">SCROLL</span>
<span style=""color:Blue;"">SECOND</span>
<span style=""color:Blue;"">SECTION</span>
<span style=""color:Blue;"">SELECT</span>
<span style=""color:Blue;"">SEQUENCE</span>
<span style=""color:Blue;"">SESSION_USER</span>
<span style=""color:Blue;"">SET</span>
<span style=""color:Blue;"">SETUSER</span>
<span style=""color:Blue;"">SHUTDOWN</span>
<span style=""color:Blue;"">SIZE</span>
<span style=""color:Blue;"">SMALLINT</span>
<span style=""color:Blue;"">SMALLMONEY</span>
<span style=""color:Blue;"">SOME</span>
<span style=""color:Blue;"">SOUNDEX</span>
<span style=""color:Blue;"">SPACE</span>
<span style=""color:Blue;"">SQLCA</span>
<span style=""color:Blue;"">SQLERROR</span>
<span style=""color:Blue;"">STATISTICS</span>
<span style=""color:Blue;"">STR</span>
<span style=""color:Blue;"">STUFF</span>
<span style=""color:Blue;"">SUBSTRING</span>
<span style=""color:Blue;"">SUM</span>
<span style=""color:Blue;"">SYSTEM_USER</span>
<span style=""color:Blue;"">TABLE</span>
<span style=""color:Blue;"">TEMPORARY</span>
<span style=""color:Blue;"">TEXT</span>
<span style=""color:Blue;"">TEXTSIZE</span>
<span style=""color:Blue;"">THEN</span>
<span style=""color:Blue;"">TIME</span>
<span style=""color:Blue;"">TIMESTAMP</span>
<span style=""color:Blue;"">TO</span>
<span style=""color:Blue;"">TOP</span>
<span style=""color:Blue;"">TRAN</span>
<span style=""color:Blue;"">TRANSACTION</span>
<span style=""color:Blue;"">TRANSLATION</span>
<span style=""color:Blue;"">TRIGGER</span>
<span style=""color:Blue;"">TRUE</span>
<span style=""color:Blue;"">TRUNCATE</span>
<span style=""color:Blue;"">TSEQUAL</span>
<span style=""color:Blue;"">UNICODE</span>
<span style=""color:Blue;"">UNION</span>
<span style=""color:Blue;"">UNIQUE</span>
<span style=""color:Blue;"">UPDATE</span>
<span style=""color:Blue;"">UPDATETEXT</span>
<span style=""color:Blue;"">UPPER</span>
<span style=""color:Blue;"">USE</span>
<span style=""color:Blue;"">USER</span>
<span style=""color:Blue;"">VALUES</span>
<span style=""color:Blue;"">VARCHAR</span>
<span style=""color:Blue;"">VARYING</span>
<span style=""color:Blue;"">VIEW</span>
<span style=""color:Blue;"">WAITFOR</span>
<span style=""color:Blue;"">WHEN</span>
<span style=""color:Blue;"">WHERE</span>
<span style=""color:Blue;"">WHILE</span>
<span style=""color:Blue;"">WITH</span>
<span style=""color:Blue;"">WORK</span>
<span style=""color:Blue;"">WRITETEXT</span>
<span style=""color:Blue;"">YEAR</span>
<span style=""color:Blue;"">BIGINT</span>
<span style=""color:Blue;"">TINYINT</span>
<span style=""color:Blue;"">SMALLDATETIME</span>
<span style=""color:Blue;"">NTEXT</span>
<span style=""color:Blue;"">SQL_VARIANT</span>
<span style=""color:Blue;"">XML</span>
VAR
TYPE
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}
