using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    public class Database
    {
        public string Name { get; set; }
        public Dictionary<string,Table> Tables { get; set; }
        public Database()
        {
            Tables = new Dictionary<string, Table>();
        }
    }

    public class Table
    {
        public string Name { get; set; }
        public long Count { get; set; }
        public TableProcessingTypes Status { get; set; }
        public List<List<string>> StartExampleDatas { get; set; }

        public List<List<string>> EndExampleDatas { get; set; }

        public int ExampleDataMaxCount { get; set; }
        public int DirectDumpAllDataCount { get; set; }
        public bool CanDirectDumpAll
        {
            get
            {
                return Count <= DirectDumpAllDataCount;
            }
        }
        public List<string> SortedColumnNames
        {
            get
            {
                var orderdColumns = Columns.Keys.ToList();
                orderdColumns.Sort();
                return orderdColumns;
            }
        }

    public Dictionary<string,Column> Columns { get; set; }

        public string GetSqlExampleDataStart(string dbName)
        {
            var sql = $"select {string.Join(",", SortedColumnNames)} from {dbName}.{Name} order by {SortedColumnNames[0]} asc limit {ExampleDataMaxCount};";
            return sql;
        }

        public string GetSqlExampleDataEnd(string dbName)
        {
            var sql = $"select {string.Join(",", SortedColumnNames)} from {dbName}.{Name} order by {SortedColumnNames[0]} desc limit {ExampleDataMaxCount};";
            return sql;
        }


        public Table()
        {
            Columns = new Dictionary<string, Column>();
            StartExampleDatas = new List<List<string>>() ;
            EndExampleDatas = new List<List<string>>();
            ExampleDataMaxCount = 10;
            DirectDumpAllDataCount = 1000000;
            Status = TableProcessingTypes.Waiting;
        }
    }

    public class Column
    {
        public string FieldName { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
    }

    public class TargetInfo
    {
        public bool IsSuccess { get; set; }
        public string Url { get; set; }
        public string Query { get; set; }
        public object Data { get; set; }

        public Dictionary<string, Database> Databases { get; set; }

        public TargetInfo()
        {
            Databases = new Dictionary<string, Database>();
        }

    }
}
