namespace Szija_Website_Printer
{
    internal class DateFormatter
    {
        static public string Format(string inputDate, string locale)
        {
            string[] monthsHu = { "jan", "febr", "márc", "ápr", "máj", "jún", "júl", "aug", "szept", "okt", "nov", "dec" };
            string[] monthsEn = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            string[] dateSplit = inputDate.Split('-');
            string year = dateSplit[0];
            int month = Int32.Parse(dateSplit[1]) - 1;

            if (locale == "en") return $"{monthsEn[month]} {year}";
            return $"{year}. {monthsHu[month]}.";
        }
    }
}
