    public double GPA
    {
        get
        {
            if (Gpa <= 0)
            {
                return 0;
            }
            else if (Gpa >= 4)
            {
                return 4;
            }
            else
            {
                return Gpa;
            }
        }
    }
