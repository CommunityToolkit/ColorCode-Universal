// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Sql : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Sql; }
        }

        public string Name
        {
            get { return "SQL"; }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"(?s)/\*.*?\*/",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(--.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"'(?>[^\']*)'",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String },
                                       }),
                               new LanguageRule(
                                   @"""(?>[^\""]*)""",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String },
                                       }),
                               new LanguageRule(
                                   @"\[(?>[^\]]*)]",
                                   new Dictionary<int, string>
                                       {
                                           { 0, null },
                                       }),
                               new LanguageRule(
                                   @"(?i)\b(?<![.@""])(ABS|ACOS|ADA|ADD|AFTER|ALL|ALTER|AND|ANY|AS|ASC|ASCII|ASIN|AT|ATAN|ATN2|AUTHORIZATION|AUTO|AVG|BACKUP|BEGIN|BETWEEN|BINARY|BINARY_CHECKSUM|BIT|BIT_LENGTH|BREAK|BROWSE|BULK|BY|CASCADE|CASE|CAST|CEILING|CHAR|CHARACTER|CHARACTER_LENGTH|CHARINDEX|CHAR_LENGTH|CHECK|CHECKPOINT|CHECKSUM|CHECKSUM_AGG|CLOSE|CLUSTERED|COALESCE|COLLATE|COL_LENGTH|COL_NAME|COLUMN|COLUMNPROPERTY|COMMIT|COMPUTE|CONNECT|CONNECTION|CONSTRAINT|CONTAINS|CONTAINSTABLE|CONTINUE|CONVERT|COS|COT|COUNT|COUNT_BIG|CREATE|CROSS|CUBE|CURRENT|CURRENT_DATE|CURRENT_TIME|CURRENT_TIMESTAMP|CURRENT_USER|CURSOR|CURSOR_STATUS|DATABASE|DATABASEPROPERTY|DATALENGTH|DATE|DATETIME|DAY|DB_ID|DB_NAME|DBCC|DEALLOCATE|DEC|DECIMAL|DECLARE|DEFAULT|DEFERRED|DEGREES|DELETE|DENY|DESC|DIFFERENCE|DISK|DISTINCT|DISTRIBUTED|DOUBLE|DROP|DUMMY|DUMP|ELSE|ENCRYPTION|END-EXEC|END|ERRLVL|ESCAPE|EXCEPT|EXEC|EXECUTE|EXISTS|EXIT|EXP|EXTERNAL|EXTRACT|FALSE|FETCH|FILE|FILE_ID|FILE_NAME|FILEGROUP_ID|FILEGROUP_NAME|FILEGROUPPROPERTY|FILEPROPERTY|FILLFACTOR|FIRST|FLOAT|FLOOR|FOR|FOREIGN|FORTRAN|FREE|FREETEXT|FREETEXTTABLE|FROM|FULL|FULLTEXTCATALOGPROPERTY|FULLTEXTSERVICEPROPERTY|FUNCTION|GLOBAL|GOTO|GRANT|GROUP|GROUPING|HAVING|HOLDLOCK|HOUR|IDENTITY|IDENTITYCOL|IDENTITY_INSERT|IF|IGNORE|IMAGE|IMMEDIATE|IN|INCLUDE|INDEX|INDEX_COL|INDEXKEY_PROPERTY|INDEXPROPERTY|INNER|INSENSITIVE|INSERT|INSTEAD|INT|INTEGER|INTERSECT|INTO|IS|ISOLATION|JOIN|KEY|KILL|LANGUAGE|LAST|LEFT|LEN|LEVEL|LIKE|LINENO|LOAD|LOCAL|LOG|LOG10|LOWER|LTRIM|MAX|MIN|MINUTE|MODIFY|MONEY|MONTH|NAME|NATIONAL|NCHAR|NEXT|NOCHECK|NONCLUSTERED|NOCOUNT|NONE|NOT|NULL|NULLIF|NUMERIC|NVARCHAR|OBJECT_ID|OBJECT_NAME|OBJECTPROPERTY|OCTET_LENGTH|OF|OFF|OFFSETS|ON|ONLY|OPEN|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|OPTION|OR|ORDER|OUTER|OUTPUT|OVER|OVERLAPS|PARTIAL|PASCAL|PATINDEX|PERCENT|PI|PLAN|POSITION|POWER|PRECISION|PREPARE|PRIMARY|PRINT|PRIOR|PRIVILEGES|PROC|PROCEDURE|PUBLIC|QUOTENAME|RADIANS|RAISERROR|RAND|READ|READTEXT|REAL|RECONFIGURE|REFERENCES|REPLACE|REPLICATE|REPLICATION|RESTORE|RESTRICT|RETURN|RETURNS|REVERSE|REVERT|REVOKE|RIGHT|ROLLBACK|ROLLUP|ROUND|ROWCOUNT|ROWGUIDCOL|ROWS|RULE|RTRIM|SAVE|SCHEMA|SCROLL|SECOND|SECTION|SELECT|SEQUENCE|SESSION_USER|SET|SETUSER|SHUTDOWN|SIGN|SIN|SIZE|SMALLINT|SMALLMONEY|SOME|SOUNDEX|SPACE|SQL_VARIANT_PROPERTY|SQLCA|SQLERROR|SQRT|SQUARE|STATISTICS|STDEV|STDEVP|STR|STUFF|SUBSTRING|SUM|SYSTEM_USER|TABLE|TAN|TEMPORARY|TEXT|TEXTPTR|TEXTSIZE|TEXTVALID|THEN|TIME|TIMESTAMP|TO|TOP|TRAN|TRANSACTION|TRANSLATION|TRIGGER|TRUE|TRUNCATE|TSEQUAL|TYPEPROPERTY|UNICODE|UNION|UNIQUE|UPDATE|UPDATETEXT|UPPER|USE|USER|VALUES|VARCHAR|VARP|VARYING|VIEW|WAITFOR|WHEN|WHERE|WHILE|WITH|WORK|WRITETEXT|YEAR|GETDATE|IS_MEMBER|IS_SRVROLEMEMBER|NEWID|PERMISSIONS|SUSER_NAME|SUSER_SID|SUSER_SNAME|SYSNAME|UNIQUEIDENTIFIER|USER_ID|USER_NAME|VARBINARY|ABSOLUTE|DATEPART|DATEDIFF|WEEK|WEEKDAY|MILLISECOND|GETUTCDATE|DATENAME|DATEADD|BIGINT|TINYINT|SMALLDATETIME|NTEXT|SQL_VARIANT|XML|ASSEMBLY|AGGREGATE)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword },
                                       }),
                           };
            }
        }
    }
}