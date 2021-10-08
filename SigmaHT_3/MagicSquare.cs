using System;

namespace SigmaHT_3
{
    class MagicSquare
    {
        private int[,] magicSquare;

        private int size;
        public int Size
        {
            get { return size; }
            set 
            {
                if (value % 2 == 0)
                    throw new ArgumentException("Size must be odd");
                size = value;
                magicSquare = new int[size, size];

                for (int i = 0, N = 1; i < magicSquare.GetLength(0); i++)
                {
                    for (int j = 0; j < magicSquare.GetLength(1); j++, N++)
                    {
                        magicSquare[i, j] = N;

                    }
                }
            }
        }

        public MagicSquare(int size = 0)
        {
            if (size <=0) 
                throw new ArgumentException("Size must be > 0");

            try
            {
                Size = size;
            }
            catch (ArgumentException)
            {
                throw;
            }

        }

        public override string ToString()
        {
            if (size == 0)
                return String.Empty;
            string output = String.Empty;

            for (int i = 0; i < magicSquare.GetLength(0); i++)
            {
                for (int j = 0; j < magicSquare.GetLength(1); j++)
                {
                    output += String.Format($"{magicSquare[i, j],5}");
                }
                output += "\n";
            }

            return output;
        }
        public bool GenerateMagicSquare()
        {
            if (size <= 0)
            {
                return false;
            }
            for (int i = 0; i < magicSquare.GetLength(0); i++)
                for (int j = 0; j < magicSquare.GetLength(1); j++) magicSquare[i, j] = 0;
            magicSquare[0, magicSquare.GetLength(1) / 2] = 1;
            for (int i = 0, j = magicSquare.GetLength(1) / 2, process = 2; process <= size * size; process++)
            {
                if ((i - 1) > 0 && j + 1 < magicSquare.GetLength(1) && magicSquare[i - 1, j + 1] == 0)
                {
                    i = i - 1; j = j + 1;
                    magicSquare[i, j] = process;
                }
                else if ((i - 1) > 0 && j + 1 < magicSquare.GetLength(1) && magicSquare[i - 1, j + 1] != 0)
                {
                    i = i + 1;
                    magicSquare[i, j] = process;
                }
                else if (i == 0 && j == size - 1)
                {
                    i = 1; j = size - 1;
                    magicSquare[i, j] = process;
                }
                else
                {
                    if ((i - 1) < 0 && j + 1 < magicSquare.GetLength(1))
                    {
                        i = size - 1; j = j + 1;
                        magicSquare[i, j] = process;
                    }
                    else if ((j + 1) == magicSquare.GetLength(1) && (i - 1) > 0 && (i - 1) < magicSquare.GetLength(0))
                    {
                        i = i - 1; j = 0;
                        magicSquare[i, j] = process;
                    }
                    else if ((j + 1) == magicSquare.GetLength(1) && (i - 1) == 0)
                    {
                        i = 0; j = 0;
                        magicSquare[i, j] = process;
                    }
                    else if ((j + 1) == magicSquare.GetLength(1) && (i - 1) < 0)
                    {
                        i = i - 1; j = 0;
                        magicSquare[i, j] = process;
                    }
                    else if (i - 1 < magicSquare.GetLength(0) && j + 1 < magicSquare.GetLength(1) && magicSquare[i - 1, j + 1] != 0)
                    {
                        i = i + 1; magicSquare[i, j] = process;
                    }
                    else if ((i - 1) == 0 && j + 1 < magicSquare.GetLength(1) && magicSquare[i - 1, j + 1] == 0)
                    {
                        i = i - 1; j = j + 1;
                        magicSquare[i, j] = process;
                    }
                }
            }

            return true;
        }
    }
}
