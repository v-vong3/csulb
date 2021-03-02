using System;
using System.Collections.Generic;
using System.Text;

namespace Company.DataStore
{
    public sealed class InMemoryDataStore
    {
        // Lecture: Normally you won't have access to the source code
        // of your data store to understand the inter-workings of it.
        // But it can dramatically assist in providing insight into how
        // to best utilize the technology.  Also, this is a naive example
        // and should NOT be used in production at all mainly since it is
        // NOT a thread-safe approach to storing and manipulating data.
        private static readonly IDictionary<string, ICollection<object>> _data;
        private static readonly StringBuilder _internalLog;
        private readonly string _accessBy;

        public InMemoryDataStore(string accessBy)
        {
            _accessBy = accessBy;
        }

        static InMemoryDataStore()
        {
            _data = new Dictionary<string, ICollection<object>>();
            _internalLog = new StringBuilder();
        }

        private static void VerifyTableExists(string tableName)
        {
            if (!_data.ContainsKey(tableName))
            {
                throw new ArgumentException($"Table {tableName} does not exist.");
            }
        }


        public bool CreateTable(string tableName)
        {
            if (_data.ContainsKey(tableName))
            {
                _internalLog.AppendLine($"{_accessBy} unable to create table {tableName}");
                return false;
            }


            _data.Add(tableName, new HashSet<object>());
            _internalLog.AppendLine($"{_accessBy} created table {tableName}");

            return true;
        }

        public IEnumerable<object> GetRows(string tableName)
        {
            VerifyTableExists(tableName);

            _internalLog.AppendLine($"{_accessBy} retrieved rows from {tableName}");

            return _data[tableName];
        }

        public bool AddOrUpdate(string tableName, object row)
        {
            DeleteRow(tableName, row);

            _data[tableName].Add(row);
            _internalLog.AppendLine($"{_accessBy} upsert {row} into {tableName}");

            return true;
        }

        public bool DeleteTable(string tableName)
        {
            VerifyTableExists(tableName);

            _data.Remove(tableName);
            _internalLog.AppendLine($"{_accessBy} remove table {tableName}");

            return true;
        }

        public bool DeleteRow(string tableName, object row)
        {
            VerifyTableExists(tableName);

            if (_data[tableName].Contains(row))
            {
                _data[tableName].Remove(row);
                _internalLog.AppendLine($"{_accessBy} remove {row} from {tableName}");

                return true;
            }

            _internalLog.AppendLine($"{_accessBy} remove {row} from {tableName}");

            return false;
        }

    }
}
