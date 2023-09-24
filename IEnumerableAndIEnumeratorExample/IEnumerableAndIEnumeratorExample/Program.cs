using System.Collections;
using System.Threading.Channels;

namespace IEnumerableAndIEnumeratorExample;

class Program
{
    static void Main(string[] args)
    {
        //List<string> Isimler = new List<string>();
        //Isimler.Add("Gençya");
        //Isimler.Add("Nurgül");
        //Isimler.Add("Ayşe");
        //Isimler.Add("Fatih");
        //Isimler.Add("Ilgaz");

        //foreach (var isim in Isimler)
        //{
        //    Console.WriteLine(isim);
        //}

        Personeller personeller = new Personeller();
        personeller.Add(new Personel { Id = 1, Adi = "Gençay", Soyadi = "Yıldız" });
        personeller.Add(new Personel { Id = 2, Adi = "Aslı", Soyadi = "Cambaz" });
        personeller.Add(new Personel { Id = 3, Adi = "Elif", Soyadi = "Gök" });
        personeller.Add(new Personel { Id = 4, Adi = "Aykız", Soyadi = "Yıldız" });
        personeller.Add(new Personel { Id = 5, Adi = "Erol", Soyadi = "Burçak" });

        foreach (Personel personel in personeller)
        {
            Console.WriteLine($"ID : {personel.Id}\nAdı : {personel.Adi}\nSoyadi : {personel.Soyadi}\n******");
        }

        Console.Read();
    }
}

class Personel
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}

//class Personeller
//{
//    List<Personel> PersonelListesi = new List<Personel>();

//    public void Add(Personel p)
//    {
//        PersonelListesi.Add(p);
//    }

//    public IEnumerator<Personel> GetEnumerator()
//    {
//        return PersonelListesi.GetEnumerator();
//    }
//}

class Personeller : IEnumerable<Personel>
{
    List<Personel> PersonelListesi = new List<Personel>();

    public void Add(Personel p)
    {
        PersonelListesi.Add(p);
    }

    public IEnumerator<Personel> GetEnumerator()
    {
        return new PersonelEnumerator(PersonelListesi);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new PersonelEnumerator(PersonelListesi);
    }
}

class PersonelEnumerator : IEnumerator<Personel>
{
    List<Personel> Kaynak;
    int currentIndex = -1;

    public PersonelEnumerator(List<Personel> Kaynak) => this.Kaynak = Kaynak;

    public Personel Current => Kaynak[currentIndex];

    object IEnumerator.Current => Kaynak[currentIndex];

    public void Dispose() => Console.WriteLine("İterasyon bitti");

    public bool MoveNext() => ++currentIndex < Kaynak.Count;

    public void Reset() => currentIndex = 0;
}

