        private void ProportionateIt(List<double> input)
        {
            double sum = input.Sum(d => d);
            for (int i = 0; i < input.Count(); i++)
            {
                input[i] = input[i]/sum;
            }
        }
