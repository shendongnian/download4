    static void Main(string[] args)
        {
            int DayHours = 0;
            int NightHours = 0;
            int dawn = 7;
            int dusk = 20;
            int start = 23;
            int end = 0;
            bool redEye = false;
            if (end < start) 
                redEye = true;
            for (int i = 0; i < 24; i++)
            {
                if (!redEye)
                {
                    if (i >= start && i < end)
                    {
                        if (i > 0 && i < dawn)
                            NightHours++;
                        else if (i >= dawn && i < dusk)
                            DayHours++;
                        else if (i >= dusk)
                            NightHours++;
                    }
                }
                else {
                    if (i < end || i >= start)
                    {
                        if (i < dawn)
                            NightHours++;
                        else if (i >= dawn && i < dusk)
                            DayHours++;
                        else if (i >= dusk)
                            NightHours++;
                    }
                }            
            }
            System.Console.WriteLine("Nighthours :" +NightHours.ToString() );
            System.Console.WriteLine("DayHoures :" + DayHours.ToString());
        }
