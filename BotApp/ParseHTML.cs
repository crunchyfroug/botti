using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotApp
    {
    public class ParseHTML
        {
        public string MenuItem (string html)
            {
            string pattern = "<li [^>]*class=\"menu-ite.*?\"(.*?)</div>";
            Match match = Regex.Match(html, pattern);
            html = match.Value;
            html = html.Replace("<p class=\"dish\">", "\n");
            html = Regex.Replace(html, "<.*?>", "");
            html = html.Replace("l ", " Laktoositon, ")
            .Replace("g ", "Gluteeniton, ").Replace("m ", "Maidoton, ");
            return html;
            }

        public string Address (string html)
            {
            string pattern = "<p[^>] *class=\"dist.*?\"(.*?)>";
            Match match = Regex.Match(html, pattern);

            html = match.Value;
            html = Regex.Replace(html, "<p class=\"dist\" title=\"", String.Empty);
            html = Regex.Replace(html, "\">", String.Empty);
            return html;
            }
        public string Name (string html)
            {
            string pattern = "<h3.*?>(.*?)<\\/h3>";
            Match match = Regex.Match(html, pattern);
            html = match.Value;
            html = Regex.Replace(html, "<.*?>", String.Empty);
            return html;

            }
        }
    }
