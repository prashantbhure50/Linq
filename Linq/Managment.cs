using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Managment
    {
        ArrayList outputList = new ArrayList();
        public void RetriveTopThreeRecord(List<ProductReview> productReviewsList)
        {
            var highestRatedRows = (from rec in productReviewsList
                                    orderby rec.rating descending
                                    select rec).Take(3);
            foreach (var row in highestRatedRows)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

        }
        public void RetriveAllRecordRatingGreaterThanThree(List<ProductReview> productReviewsList)
        {
            var data = (from rec in productReviewsList
                        where rec.rating > 3 && (rec.productId == 1 || rec.productId == 3 || rec.productId == 9)
                        select rec);
            foreach (var row in data)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
        }
        public void RetriveCounOfReviewForProductId(List<ProductReview> productReviewsList)
        {
            var records = (from rec in productReviewsList
                           group rec by rec.productId into g
                           select new
                           {
                               productId2 = g.Key,
                               ReviewCount = g.Count()
                           });
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
        }
        public void RetriveOnlyProductIdAndRating(List<ProductReview> productReviewsList)
        {
            var element = productReviewsList.GroupBy(x => x.productId).Select(x => new { productId = x.Key, Count = x.Count() });
            foreach (var row in element)
            {
                Console.WriteLine(row.productId + "  " + row.Count);
            }
        }
        public void SkipTopFiveRecord(List<ProductReview> productReviewsList)
        {
            var highestRatedRows = (from rec in productReviewsList
                                    orderby rec.rating descending
                                    select rec);
            foreach (var row in highestRatedRows.Skip(5))
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
        }
    }
}
