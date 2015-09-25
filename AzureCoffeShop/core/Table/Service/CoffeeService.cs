using core.Table.Entry;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;

namespace core.Table.Service
{
    public class CoffeeService : TableServiceBase
    {
        protected override string TableName
        {
            get { return "Coffees"; }
        }

        public void Initialize()
        {
            InitializeBase(new Coffee());
        }

        public List<Coffee> GetAll()
        {
            var query = new TableQuery<Coffee>();
            return Table.ExecuteQuery(query).ToList()
                .OrderBy(i => i.Title).ToList();
        }

        public List<Coffee> GetByCategoryId(string categoryId,
            bool? isApprover = null)
        {
            string filter;
            if (isApprover.HasValue)
            {
                filter = TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(
                        "PartitionKey",
                        QueryComparisons.Equal,
                        categoryId),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForBool(
                        "IsApproved",
                        QueryComparisons.Equal,
                        isApprover.Value)
                    );
            }
            else
            {
                filter = TableQuery.GenerateFilterCondition(
                    "PartitionKey",
                    QueryComparisons.Equal,
                    categoryId);
            }

            var query = new TableQuery<Coffee>()
                .Where(filter);
            return Table.ExecuteQuery(query).ToList()
                .OrderBy(i => i.Title).ToList();
        }

        public Coffee GetById(string categoryId, string CoffeeId)
        {
            return (Coffee)GetByIdBase<Coffee>(categoryId, CoffeeId);
        }

        public Coffee GetById(string CoffeeId)
        {
            var query = new TableQuery<Coffee>()
                .Where(
                    TableQuery.GenerateFilterCondition(
                        "RowKey",
                        QueryComparisons.Equal,
                        CoffeeId));
            return Table.ExecuteQuery(query).FirstOrDefault();
        }

        public void DeleteById(string CoffeeId)
        {
            var Coffee = GetById(CoffeeId);
            Table.Execute(TableOperation.Delete(Coffee));
        }
    }
}
