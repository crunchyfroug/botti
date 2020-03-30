using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace BotApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string data;
            string urlAddress = "https://www.lounaat.info";
            using (WebClient client = new WebClient())
                {
                client.UseDefaultCredentials = true;
                client.Headers.Add("User-Agent: Other");
                data = client.DownloadString(urlAddress);
                    }
            string pattern = "<div.*?>(.*?)<\\/div>";
            MatchCollection matches = Regex.Matches(data, pattern);
            Console.WriteLine("Matches found: {0}", matches.Count);
            if (matches.Count > 0)
                {
                foreach (Match m in matches)
                Console.WriteLine("{0}", m.Groups[1]);
                
            Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
