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
		
		static void Main (string[] args)
			{
			App app = new App();
			app.RunApp();
			Console.ReadKey();
		}
	}
}