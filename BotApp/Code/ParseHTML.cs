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
            html = html.Replace("</p>", ", ");
            html = html.Replace("</li>", "\n\n");
            html = html.Replace("<a href=\"#l\" title=\"", " (").Replace("\" class=\"diet diet-l\">l", ")").ToLower();
            html = html.Replace("<a href=\"#g\" title=\"", " (").Replace("\" class=\"diet diet-g\">g", ")").ToLower();
            html = html.Replace("<a href=\"#m\" title=\"", " (").Replace("\" class=\"diet diet-m\">m", ")").ToLower();
            html = html.Replace("<a href=\"#vl\" title=\"", " (").Replace("\" class=\"diet diet-vl\">vl", ")").ToLower();
            html = Regex.Replace(html, "<.*?>", String.Empty).Replace(">", String.Empty);

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
