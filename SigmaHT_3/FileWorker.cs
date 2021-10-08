using System;
using System.IO;

namespace SigmaHT_3
{
    class FileWorker
    {
        public string Text { get; set; }

        public FileWorker(string filePath)
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                Text = reader.ReadToEnd();
            }
        }

        public ElectricityAccounting GetElectricityAccounting()
        {
            string[] InputData = Text.Replace("\r\n\r\n", " ").Replace("\r\n"," ").Split(' ');

            int flatCount, quarterNum;

            int.TryParse(InputData[0], out flatCount);
            int.TryParse(InputData[1], out quarterNum);

            Quarter quarter = Quarter.First;

            switch (quarterNum)
            {
                case 1:quarter = Quarter.First;break;
                case 2:quarter = Quarter.Second;break;
                case 3:quarter = Quarter.Third;break;
                case 4:quarter = Quarter.Fourth;break;
            }

            Flat[] flats = new Flat[flatCount];

            int flatNumber;
            string surname;
            long[] counter = new long[6];
            (long, long)[,] counters;

            counters = new (long, long)[flatCount, 3];

            for (int i = 0,m=0; i < 8*flats.Length; i+=8,m++)
            {
                if (!int.TryParse(InputData[2 + i], out flatNumber))
                    throw new ArgumentException("Bad input in number of flats");

                surname = InputData[3 + i];
                
                for (int j = 0; j < 6; j++)
                {
                    if (!long.TryParse(InputData[4 + i + j], out counter[j]))
                        throw new ArgumentException("Bad input in counters");
                }

                for (int k = 0,n=0; k < counters.GetLength(1); k++,n++)
                {
                    counters[m, k].Item1 = counter[n];
                    counters[m, k].Item2 = counter[++n];
                }

                

                Flat flat = new Flat(flatNumber, surname);
                flats[m] = flat;
            }

            return new ElectricityAccounting(flats, quarter, flatCount, counters);
        }
    }
}
