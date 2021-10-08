using System;

namespace SigmaHT_3
{
    class Flat
    {
        public int Number { get; set; }
        public string OwnerSurname { get; set; }
        public Flat(int number, string ownerSurname)
        {
            Number = number;
            OwnerSurname = ownerSurname;
        }

        public override string ToString()
        {
            return String.Format("{0,-10} {1,-20}",Number,OwnerSurname);
        }
    }
}
