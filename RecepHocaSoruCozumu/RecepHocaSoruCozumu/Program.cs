using System.Data;

namespace RecepHocaSoruCozumu;
class Program
{
    static void Main(string[] args)
    {
        int[,] a = new int[3, 3] {
           {7, 1, 2} ,   // row 0
           {4, 7, 6} ,   // row 1
           {8, 9, 7}     // row 2
        };

        int[,] b = new int[3, 2];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == j)
                {
                    return;
                }
                else
                {
                    b[i-1,j] = a[i,j];
                }
            }
        }
    }
}