namespace CodeWars2;
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(Solution_1(-10));
        //Console.WriteLine(IsValidIp("a.1.1.1"));
        //Console.WriteLine(Chatgpt_IsValidIP("a.1.1.1"));
        var input = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine(FoldArray(input, 2).ToString());

        Console.ReadKey();
    }

    // https://www.codewars.com/kata/514b92a657cdc65150000006
    public static int Solution_1(int value)
    {
        List<int> toplam = new List<int>();

        for (int i = 0; i < value; i++)
        {
            if (i % 3 == 0)
            {
                toplam.Add(i);
            }

            if (i % 5 == 0 && !(i % 3 == 0))
            {
                toplam.Add(i);
            }
        }

        int toplamInt = 0;
        foreach (int i in toplam)
        {
            toplamInt += i;
        }

        return toplamInt;
    }

    // https://www.codewars.com/kata/515decfd9dcfc23bb6000006/train/csharp
    public static bool IsValidIp(string ipAddres)
    {
        string[] ipSplit = ipAddres.Split(".");
        int trueCount = 0;

        if (ipSplit.Length == 4)
        {
            foreach (string ip in ipSplit)
            {
                foreach (char chr in ip)
                {
                    if (!Char.IsDigit(chr))
                        return false;
                }

                int numericValue;
                bool isNumber = int.TryParse(ip, out numericValue);

                if (isNumber)
                {
                    if (numericValue <= 255 && numericValue >= 0)
                    {
                        string firstZeroControl = ip.Substring(0, 1);
                        if (firstZeroControl != "0" || (firstZeroControl == "0" && ip.Length == 1))
                            trueCount++;
                    }
                }
            }
        }

        if (trueCount == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // CHATGPT
    public static bool Chatgpt_IsValidIP(string ipAddress)
    {
        // IP adresini noktalar veya iki nokta üst üste kullanarak bölün
        string[] ipParts = ipAddress.Split('.', ':');

        // IPv4 adresi mi kontrol et
        if (ipParts.Length == 4)
        {
            byte tempForParsing;

            // IP adresinin her bölümünü 0-255 arasında olup olmadığını kontrol edin
            foreach (string part in ipParts)
            {
                if (!byte.TryParse(part, out tempForParsing))
                {
                    return false;
                }
            }

            return true;
        }

        // IPv6 adresi mi kontrol et
        else if (ipParts.Length == 8)
        {
            ushort tempForParsing;

            // IP adresinin her bölümünü 0-FFFF arasında olup olmadığını kontrol edin
            foreach (string part in ipParts)
            {
                if (!ushort.TryParse(part, System.Globalization.NumberStyles.HexNumber, null, out tempForParsing))
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    // https://www.codewars.com/kata/57ea70aa5500adfe8a000110/train/csharp
    public static int[] FoldArray(int[] array, int runs)
    {
        List<int> arr = array.ToList();
        for (int c = 0; c < runs; c++)
        {
            int cou = arr.Count;
            for (int i = 0; i < (cou / 2); i++)
            {
                arr[i] = arr[i] + arr[cou - i - 1];

                arr.RemoveAt(cou - i - 1);
            }
        }
        return arr.ToArray();
    }
}