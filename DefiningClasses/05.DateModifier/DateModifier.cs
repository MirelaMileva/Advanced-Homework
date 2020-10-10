using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int GetDaysDifference(string startDateAsString, string endDateAsString)
        {
            DateTime startDate = DateTime.Parse(startDateAsString);

            DateTime endDate = DateTime.Parse(endDateAsString);

            var totalDays = (int)Math.Abs((startDate - endDate).TotalDays);

            return totalDays;
        }
    }
}
