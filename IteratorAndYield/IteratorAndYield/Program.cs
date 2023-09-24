namespace IteratorAndYield;

class Program
{
    static void Main(string[] args)
    {
        foreach (var Gun in VerileriGetir())
            Console.WriteLine(Gun);

        Console.WriteLine("***************");

        foreach (var Gun in VerileriGetir2())
            Console.WriteLine(Gun);

        Console.WriteLine("***************");

        foreach (var Gun in VerileriGetir3())
            Console.WriteLine(Gun);
    }

    static public IEnumerable<string> VerileriGetir()
    {
        string[] Gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cume", "Cumartesi", "Pazar" };
        List<string> gunler = new List<string>();
        foreach (var Gun in Gunler)
            gunler.Add(Gun);

        return gunler;
    }

    static public IEnumerable<string> VerileriGetir2()
    {
        string[] Gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cume", "Cumartesi", "Pazar" };
        foreach (var Gun in Gunler)
            yield return Gun;
    }

    static public IEnumerable<string> VerileriGetir3()
    {
        yield return "Pazartesi";
        yield return "Salı";
        yield return "Çarşamba";
        yield return "Perşembe";
        yield return "Cuma";
        yield return "Cumartesi";
        yield return "Pazar";
    }

    // yield break kullanımı
    //static public IEnumerable<string> VerileriGetir()
    //{
    //    yield return "Pazartesi";
    //    yield return "Salı";
    //    yield return "Çarşamba";
    //    yield return "Perşembe";
    //    yield return "Cuma";
    //    yield return "Cumartesi";
    //    yield break;
    //    yield return "Pazar";
    //}
}