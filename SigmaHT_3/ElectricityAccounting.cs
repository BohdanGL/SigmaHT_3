using System;

namespace SigmaHT_3
{
    enum Quarter { First, Second, Third, Fourth };
 
    class ElectricityAccounting
    {
        public int FlatCount { get; set; }
        public Quarter Quarter { get; set; }
        
        private Flat[] flats;
        private (long, long)[,] counters;

        public ElectricityAccounting(Flat[] flats, Quarter quarter, int flatCount, (long, long)[,] counters)
        {
            this.flats = flats;
            Quarter = quarter;
            FlatCount = flatCount;
            this.counters = counters;
        }

        public string GetReport()
        {
            string output = $"Number of flats = {FlatCount}\tQuarter - {Quarter}\n";
            output += String.Format("{0,-10} {1,-20}", "Number", "Owner");
            
            switch (Quarter)
            {
                case Quarter.First:
                    output += String.Format("{0,-15} {1,-15} {2}", "January", "February", "March");
                    break;
                case Quarter.Second:
                    output += String.Format("{0,-15} {1,-15} {2}", "April", "May", "June");
                    break;
                case Quarter.Third:
                    output += String.Format("{0,-15} {1,-15} {2}","July","August","Septemer");
                    break;
                case Quarter.Fourth:
                    output += String.Format("{0,-15} {1,-15} {2}", "October", "November", "December");
                    break;
            }

            for (int i = 0; i < counters.GetLength(0); i++)
            {
                output += String.Format("\n{0}{1,-15} {2,-15} {3}\n",
                        flats[i],
                        counters[i, 0].Item2 - counters[i, 0].Item1,
                        counters[i, 1].Item2 - counters[i, 1].Item1,
                        counters[i, 2].Item2 - counters[i, 2].Item1);
            }

            return output;
        }

        public string GetReportByNumber(int number)
        {
            int index = 0;
            for (int i = 0; i < flats.Length; i++)
            {
                if (flats[i].Number == number)
                {
                    index = i;
                    break;
                }
                
            }
            string output = String.Format("{0,-10} {1,-20}", "Number", "Owner");

            switch (Quarter)
            {
                case Quarter.First:
                    output += String.Format("{0,-15} {1,-15} {2}", "January", "February", "March");
                    break;
                case Quarter.Second:
                    output += String.Format("{0,-15} {1,-15} {2}", "April", "May", "June");
                    break;
                case Quarter.Third:
                    output += String.Format("{0,-15} {1,-15} {2}", "July", "August", "Septemer");
                    break;
                case Quarter.Fourth:
                    output += String.Format("{0,-15} {1,-15} {2}", "October", "November", "December");
                    break;
            }

            output += String.Format("\n{0}{1,-15} {2,-15} {3}\n",
                        flats[index],
                        counters[index, 0].Item2 - counters[index, 0].Item1,
                        counters[index, 1].Item2 - counters[index, 1].Item1,
                        counters[index, 2].Item2 - counters[index, 2].Item1);

            return output;
        }
         
        public string GetTheMosetDebtedOwner()
        {
            int index = 0;
            long maxDebt = counters[0, 2].Item2 - counters[0, 0].Item1;

            for (int i = 0; i < flats.Length-1; i++)
            {
                if((counters[i, 2].Item2 - counters[i, 0].Item1) >maxDebt)
                {
                    maxDebt = counters[i, 2].Item2 - counters[i, 0].Item1;
                    index = i;
                }
                
            }

            return flats[index].OwnerSurname;
        }

        public int GetFlatNumberWithNoConsumption()
        {
            for (int i = 0; i < flats.Length; i++)
            {
                if(counters[i,0].Item1 == counters[i,2].Item2)
                {
                    return flats[i].Number;
                }
            }

            return -1;
        }

    }
}
