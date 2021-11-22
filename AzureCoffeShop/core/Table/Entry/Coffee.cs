using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace core.Table.Entry
{
    public class Coffee : TableEntity
    {
        public Coffee() : this(Guid.NewGuid().ToString())
        {
        }

        public Coffee(string goodId)
        {
            PartitionKey = "";
            RowKey = goodId;
        }

        public string Title { get; set; }
    }
}
