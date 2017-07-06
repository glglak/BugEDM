using LinqToQuerystring;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace EDMOpenDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1 (not Working)
            //var uri = HttpUtility.UrlDecode("?$top=2&$filter=index1+eq+1");
            //Example 2(Working)
            var uri = HttpUtility.UrlDecode("?$top=2&$filter=([index1]+eq+1)");

            //more advanced scenarios 
            //Example 3 (Working)
            // var uri = HttpUtility.UrlDecode("?$top=2&$filter=([index1]+eq+1+and+[index2]+eq+%272%27)");
            //Example 4 (not Working)
            //var uri = HttpUtility.UrlDecode("?$top=2&$filter=(index1+eq+1+and+index2+eq+%272%27)");



            Console.WriteLine(uri);//press enter
            #region Defining List of Dictionaries
            var listofDictionary = new List<Dictionary<string, object>>();
            Dictionary<string, object> test1 = new Dictionary<string, object>()
            {
                {"index1",1 },
                {"index2","2" } 
               

            };
            Dictionary<string, object> test2 = new Dictionary<string, object>()
            {
                {"index1",3 },
                {"index2","4" }

            };
            Dictionary<string, object> test3 = new Dictionary<string, object>()
            {
                {"index1",1 },
                {"index2","4" }

            };
          
            listofDictionary.Add(test1);
            listofDictionary.Add(test2);
            listofDictionary.Add(test3);
            #endregion

            var d = listofDictionary.AsQueryable();
            var ordered = d.LinqToQuerystring(uri) ; 

           
            //return JSON
            var j = new JObject();
            j["odata.count"] = ordered.Count();
            j["value"] = JToken.FromObject(ordered);


            Console.WriteLine(j.ToString());
            Console.ReadKey();
        }


    }
}
