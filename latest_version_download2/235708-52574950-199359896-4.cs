    int days = (int)(End - Start).TotalDays + 1;
            int holidays = days / 7 * 2;
            int remain = days % 7;
            DateTime dt = End.AddDays(-remain);
            while (dt.Date <= End.Date)
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    holidays++;
                dt = dt.AddDays(1);
            }
            int year = Start.Year;
            do
            {
                dt = new DateTime(year, 12, 25); //is chritsmass right?
                if (dt >= Start && dt <= End && dt.DayOfWeek!=DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) holidays++;
                dt = new DateTime(year, 7, 4); // 4th of july
                if (dt >= Start && dt <= End && dt.DayOfWeek!=DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) holidays++;
                dt = new DateTime(year, 10, 31); // holoween
                if (dt >= Start && dt <= End && dt.DayOfWeek!=DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) holidays++;
                year++;
            } while (year <= End.Year);
            int businessDays = days - holidays;
