using System.Globalization;

namespace MærkeDageCalender.Data
{
    public class Month
    {
        public string getMonthName = "";
        public string monthName = "";
        public DateTime monthEnd;
        public int monthsAway = 0;
        public int numDummyColumn = 0;
        public int year = DateTime.Now.Year;
        public int currentMonth = 0;

        public void CreateMonth()
        {
            var tempDate = DateTime.Now.AddMonths(monthsAway);
            currentMonth = tempDate.Month;
            year = tempDate.Year;

            DateTime monthStart = new DateTime(year, currentMonth, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            getMonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            monthName = $"{getMonthName[0].ToString().ToUpper()}{getMonthName.Substring(1)}";

            numDummyColumn = (int)monthStart.DayOfWeek;
        }
    }
}
