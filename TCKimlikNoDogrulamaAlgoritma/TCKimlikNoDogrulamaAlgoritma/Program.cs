//TC Kimlik numaraları 11 basamaktan oluşmaktadır. İlk 9 basamak arasında kurulan bir algoritma bize 10. basamağı, ilk 10 basamak arasında kurulan algoritma ise bize 11. basamağı verir.
//* 11 hanelidir.
//* Her hanesi rakamsal değer içerir.
//* İlk hane 0 olamaz.
//* 1. 3. 5. 7. ve 9. hanelerin toplamının 7 katından, 2. 4. 6. ve 8. hanelerin toplamı çıkartıldığında, elde edilen sonucun 10’a bölümünden kalan, yani Mod 10’u bize 10. haneyi verir.
//* 1. 2. 3. 4. 5. 6. 7. 8. 9. ve 10. hanelerin toplamından elde edilen sonucun 10’a bölümünden kalan, yani Mod10’u bize 11. haneyi verir.

Console.Write("tc kimlik noyu giriniz: ");
string tcNoInput = Console.ReadLine();

FirstMethod(tcNoInput);
Console.WriteLine("********************");
SecondMethod(tcNoInput);


void FirstMethod(string tcno)
{
    int toplam = 0; int toplam2 = 0; int toplam3 = 0;
    if (tcno.Length == 11)
    {
        if (Convert.ToInt32(tcno[0].ToString()) != 0)
        {
            for (int i = 0; i < 10; i++)
            {
                toplam = toplam + Convert.ToInt32(tcno[i].ToString());
                if (i % 2 == 0)
                {
                    if (i != 10)
                    {
                        toplam2 = toplam2 + Convert.ToInt32(tcno[i].ToString());
                    }
                }
                else
                {
                    if (i != 9)
                    {
                        toplam3 = toplam3 + Convert.ToInt32(tcno[i].ToString());
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("tc kimlik numaranızın ilk hanesi 0 olamaz");
        }
    }
    else
    {
        Console.WriteLine("tc kimlik numaranız 11 haneli olmak zorunda. eksik ya da fazla değer girdiniz");
    }
    if (((toplam2 * 7) - toplam3) % 10 == Convert.ToInt32(tcno[9].ToString()) && toplam % 10 == Convert.ToInt32(tcno[10].ToString()))
    {
        Console.WriteLine("tc kimlik numarası doğru");
    }
    else
    {
        Console.WriteLine("tc kimlik numarası yanlış");
    }
}


void SecondMethod(string tcno)
{
    bool returnValue = false;
    if (tcno.Length == 11)
    {
        Int64 ATCNO, BTCNO, TcNo;
        long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

        TcNo = Int64.Parse(tcno);

        ATCNO = TcNo / 100;
        BTCNO = TcNo / 100;

        C1 = ATCNO % 10; ATCNO = ATCNO / 10;
        C2 = ATCNO % 10; ATCNO = ATCNO / 10;
        C3 = ATCNO % 10; ATCNO = ATCNO / 10;
        C4 = ATCNO % 10; ATCNO = ATCNO / 10;
        C5 = ATCNO % 10; ATCNO = ATCNO / 10;
        C6 = ATCNO % 10; ATCNO = ATCNO / 10;
        C7 = ATCNO % 10; ATCNO = ATCNO / 10;
        C8 = ATCNO % 10; ATCNO = ATCNO / 10;
        C9 = ATCNO % 10; ATCNO = ATCNO / 10;
        Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
        Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

        returnValue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
    }

    if (returnValue)
        Console.WriteLine("doğru");
    else
        Console.WriteLine("yanlış");
}