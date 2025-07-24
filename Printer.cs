using System.Globalization;
using System.Text.RegularExpressions;

namespace Szija_Website_Printer
{
    internal class Printer
    {
        private string Locale;
        private string LocaleLong;
        private string OtherLocale;
        private RootStrings Strings;

        public Printer(string locale, RootStrings strings)
        {
            Locale = locale;
            Strings = strings;

            if (locale == "hu")
            {
                LocaleLong = "hu-HU";
                OtherLocale = "en";
            }
            else
            {
                LocaleLong = "en-GB";
                OtherLocale = "hu";
            }
        }

        private string PrintHeader(int pageIndex)
        {
            string header = $"<!doctype html>\r\n<html lang=\"{Locale}\">\r\n\r\n<head>\r\n\t<meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n\t<link rel=\"stylesheet\" href=\"../style.css\">\r\n\t<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n\t<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n\t<link href=\"https://fonts.googleapis.com/css2?family=Atkinson+Hyperlegible:ital,wght@0,400;0,700;1,400;1,700&display=swap\" rel=\"stylesheet\">\r\n\t<title>szija</title>\r\n\t<link rel=\"icon\" type=\"image/x-icon\" href=\"../images/favicon.ico\">\r\n</head>\r\n\r\n<body>\r\n\t<div id=\"wrapper\">\r\n\t\t<header>\r\n\t\t\t<h1>{Strings.header_text.name.text.Get(Locale)}</h1>\r\n\t\t\t<p id=\"bio\">{Strings.header_text.bio.text.Get(Locale)}</p>\r\n\t\t\t\r\n\t\t\t<nav>\r\n\t\t\t\t";

            if (pageIndex == 0) header += $"<p id=\"nav\"><span class=\"nav-active hor-list\">▶ <b>{Strings.header_text.project_listing.text.Get(Locale)}</b></span> <span class=\"hor-list\">▶ <a href=\"links.html\"><b>{Strings.header_text.links.text.Get(Locale)}</b></a></span><span class=\"langselect\">▶ <a href=\"../{OtherLocale}/index.html\"><b>{Strings.header_text.other_lang.text.Get(Locale)}</b></a></span>";
            else header += $"<p id=\"nav\"><span class=\"hor-list\">▶ <a href=\"index.html\"><b>{Strings.header_text.project_listing.text.Get(Locale)}</b></a></span> <span class=\"nav-active hor-list\">▶ <b>{Strings.header_text.links.text.Get(Locale)}</b></span><span class=\"langselect\">▶ <a href=\"../{OtherLocale}/links.html\"><b>{Strings.header_text.other_lang.text.Get(Locale)}</b></a></span>";

            header += $"</p>\r\n\t\t\t<nav>\r\n\t\t</header>\r\n\t\t\r\n\t\t";

            return header;
        }

        private string PrintFooter()
        {
            string date = DateTime.Now.ToString("D", CultureInfo.CreateSpecificCulture(LocaleLong));

            return $"<footer>\r\n\t\t\t<p id=\"footer\">{Strings.footer_gag.text.Get(Locale)}<br>\r\n\t\t\t{Strings.last_updated.text.Get(Locale)}{date}</p>\r\n\t\t</footer>\r\n\t<div>\r\n</body>\r\n\r\n\r\n</html>";
        }

        private string PrintProjectsListingMain()
        {
            string main = $"<main>\r\n\t\t\t<p>{Strings.project_listing_text.top_text.text.Get(Locale)}</p>\r\n\t\t\t<div>\r\n\t\t\t\t<!-- Filters list -->\r\n\t\t\t\t<b class=\"hor-list\">{Strings.project_listing_text.filter.text.Get(Locale)}</b>";

            for (int i = 0; i < Strings.project_types.Count; i++)
            {
                main += $"<input type=\"checkbox\" id=\"filter-{Strings.project_types[i].code_name}\" checked />\r\n\t\t\t\t<label for=\"filter-{Strings.project_types[i].code_name}\" class=\"hor-list\">{Strings.project_types[i].filter_name.text.Get(Locale)}</label>\n";
            }

            main += $"\r\n\t\t\t\t\r\n\t\t\t\t<!-- Projects list -->\r\n\t\t\t\t";

            for (int i = 0; i < Strings.project_entries.Count; i++)
            {
                main += $"<div class=\"proj proj-{Strings.project_entries[i].type}\">\r\n\t\t\t\t\t<div class=\"proj-header\">\r\n\t\t\t\t\t\t<aside>{Strings.GetInlineName(Strings.project_entries[i].type, Locale)}, <time datetime=\"{Strings.project_entries[i].start_date}\">{DateFormatter.Format(Strings.project_entries[i].start_date, Locale)}</time>";

                //‘end_date == null’ means ongoing, ‘end_date == ""’ means one-time.
                if (Strings.project_entries[i].end_date == null) main += "–";
                else if (Strings.project_entries[i].end_date != "") main += $"–<time datetime=\\\"{Strings.project_entries[i].end_date}\\\">{DateFormatter.Format(Strings.project_entries[i].end_date, Locale)}</time>";

                main += $"</aside><span class=\\\"proj-title\\\">{Strings.project_entries[i].name.text.Get(Locale)}</span> <span class=\\\"proj-id\\\">SZLP-{(Strings.project_entries[i].id + 100).ToString("0000")}</span>\\r\\n\\t\\t\\t\\t\\t</div>\\r\\n\\t\\t\\t\\t\\t<div class=\\\"proj-body\\\">\\r\\n\\t\\t\\t\\t\\t\\t<aside><a href=\\\"../{Strings.project_entries[i].imageFull}\\\" target=\\\"_blank\\\"><img class=\\\"proj-img\\\" src=\\\"../{Strings.project_entries[i].image}\\\" alt=\\\"\\\"></a></aside>\\r\\n\\t\\t\\t\\t\\t\\t<p class=\\\"body-text\\\">{Strings.project_entries[i].body_text.text.Get(Locale)}</p>";

                for (int j = 0; j < Strings.project_entries[i].buttons.Count; j++)
                {
                    main += $"<a href=\"{Strings.project_entries[i].buttons[j].url}\" target=\"_blank\" class=\"button";

                    if (Strings.project_entries[i].buttons[j].emphasis) main += " button-emph";

                    main += $"\">▶ {Strings.project_entries[i].buttons[j].label.text.Get(Locale)}</a>";

                    if (j < Strings.project_entries[i].buttons.Count - 1) main += "&ZeroWidthSpace;";
                }

                main += "\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t\r\n\t\t\t\t";
            }

            main += $"<div class=\"nofilters\">\r\n\t\t\t\t\t<p>{Strings.project_listing_text.no_filter.text.Get(Locale)}</p>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</main>\r\n\t\t\r\n\t\t";

            return main;
        }

        private string PrintLinksMain()
        {
            string main = $"<main>\r\n\t\t\t<p>{Strings.links_text.top_text.text.Get(Locale)}</p>\r\n\t\t\t<!-- 88x31 -->\r\n\t\t\t<h2>{Strings.links_text.title1.text.Get(Locale)}</h2>\r\n\t\t\t<p>{Strings.links_text.text1.text.Get(Locale)}</p>\r\n\t\t\t";

            for (int i = 0; i < Strings.links_8831.Count; i++)
            {
                main += $"<a href=\"{Strings.links_8831[i].url}\" target=\"_blank\"><img class=\"yes8831\" src=\"../images/links/{Strings.links_8831[i].img_url}\" title=\"{Strings.links_8831[i].alt_text.text.Get(Locale)}\"></a>\r\n\t\t\t";
            }

            main += $"\r\n\t\t\t<!-- Non-88x31 -->\r\n\t\t\t<h2>{Strings.links_text.title2.text.Get(Locale)}</h2>\r\n\t\t\t";

            for (int i = 0; i < Strings.links_no_8831.Count; i++)
            {
                main += $"<p class=\"no8831\"><a href=\"{Strings.links_no_8831[i].url}\" target=\"_blank\">{Strings.links_no_8831[i].text.Get(Locale)}</a></p>\r\n\t\t\t";
            }

            main += $"\r\n\t\t\t<!-- Own -->\r\n\t\t\t<h2>{Strings.links_text.title3.text.Get(Locale)}</h2>\r\n\t\t\t<aside><img class=\"yes8831\" src=\"../images/links/own/ico_szija.gif\" alt=\"{Strings.links_text.button_alt_text.text.Get(Locale)}\"></aside>\r\n\t\t\t<p>{Strings.links_text.text3.text.Get(Locale)}</p>\r\n\t\t\t\r\n\t\t\t<!-- Internetometer -->\r\n\t\t\t<h2>{Strings.links_text.title4.text.Get(Locale)}</h2>\r\n\t\t\t<a href='http://internetometer.com/give/45353'><img src='http://internetometer.com/image/45353.png'/></a>\r\n\t\t</main>\r\n\t\t\r\n\t\t";

            return main;
        }

        public void PrintAll(string outputPath)
        {
            DirectoryInfo outputDirectory = Directory.CreateDirectory($"{outputPath}{Locale}/");

            using (StreamWriter outputIndex = new StreamWriter($"{outputPath}{Locale}/index.html"))
            {
                outputIndex.WriteLine(Regex.Unescape(PrintHeader(0) + PrintProjectsListingMain() + PrintFooter()));
            }

            using (StreamWriter outputLinks = new StreamWriter($"{outputPath}{Locale}/links.html"))
            {
                outputLinks.WriteLine(Regex.Unescape(PrintHeader(1) + PrintLinksMain() + PrintFooter()));
            }
        }
    }
}
