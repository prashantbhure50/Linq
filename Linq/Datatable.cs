using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Datatable
    {
        DataTable table = new DataTable();
        public void AddDataTabe(List<ProductReview> productReviews)
        {
            table.Columns.Add("productId", typeof(int));
            table.Columns.Add("userId", typeof(int));
            table.Columns.Add("rating", typeof(double));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("isLike", typeof(string));
            foreach (var records in productReviews)
            {
                table.Rows.Add(records.productId, records.userId, records.rating, records.Review, records.isLike);
            }
        }

        //UC9
        public void DisplayIsLike()
        {
            var data = from record in table.AsEnumerable()
                             where record.Field<string>("isLike") =="Yes"
                             select new
                             {
                                 product = record.Field<int>("productId")
                             };
            Console.WriteLine("IsLike : ");
            foreach(var ProductName in data)
            {
                Console.WriteLine(ProductName);
            }
        }

        //UC11
        public void DisplayAllRecordsContainsNice()
        {
            var data = from record in table.AsEnumerable()
                             where record.Field<string>("Review").Contains("Nice")
                             select new
                             {
                                 product = record.Field<int>("productId")
                             };
            foreach (var productid in data)
            {
                Console.WriteLine(productid);
            }
        }

        //UC12
        public void DisplayAllRecordsWhereUserID10()
        {
            var data = from record in table.AsEnumerable()
                             where record.Field<int>("Product Id") == 10
                             orderby record.Field<double>("Rating") descending
                             select new
                             {
                                 product = record.Field<int>("Product Id"),
                                 rating = record.Field<double>("Rating")
                             };
            foreach (var record in data)
            {
                Console.WriteLine(record.product + "  " + record.rating);
            }
        }


    }
}
