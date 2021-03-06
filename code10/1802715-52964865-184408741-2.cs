    using System;
    using System.Collections.Generic;
    
    using System.Text;
    
    namespace StackOverfloeProblem
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rnd = new Random();
                List<DataPair> origialList = new List<DataPair>();
                for (int indx = 0; indx < 10; indx++)
                    origialList.Add(new DataPair(rnd.Next(1, 100), rnd.Next(1, 100)));
    
                GetMaxPrice(origialList);
            }
            static double GetMaxPrice(List<DataPair> originalList)
            {
                double max = 0;
                //using a new list and copying using foreach does not change the behaviour
                List<DataPair> copy= new List<DataPair>();
                foreach (var item in originalList)
                {
                    DataPair a = (DataPair)item.Clone();
                   copy.Add(a);
                }
                //List<DataPair> copy = originalList.Select(elt => elt.Clone()).ToList();
      
                copy.Sort();
                if (copy.Count > 0)
                    max = copy[originalList.Count - 1].Price;
    
                foreach (DataPair item in copy)
                    item.Price = item.Volume = 0;
    
                return max;
            }
        }
    }
    
    public class DataPair : IComparable<DataPair>,ICloneable
    {
        double _price;
        double _volume;
        public DataPair(double price, double volume)
        {
            _price = price;
            _volume = volume;
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
        public int CompareTo(DataPair that)
        {
            if (this.Volume > that.Volume)
                return -1;
            if (this.Volume == that.Volume)
                return 0;
    
            return 1;
        }
    
    
        public object Clone()
        {
            return this.MemberwiseClone();  
        }
    }
