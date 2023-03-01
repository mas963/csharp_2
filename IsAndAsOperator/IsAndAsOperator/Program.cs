#region Is Operatörü
// Boxing'e tabi tutulmuş bir değerin öz türünü öğrenebilmek/check edebilmek/kontrol edebilmek için kullanılan bir operatördür.
// is operatörü denetleme neticesinde durumu bool yani true ya da false olarak döndürecektir.

object x = true; // boxing
Console.WriteLine(x is bool);
Console.WriteLine(x is int);
Console.WriteLine(x is Program);

// if yapılanmasında vs. çok tercih ettiğimiz bir operatördür.
// oop yapılanmasında polimorfizm is operatörüyle kalıtımsal durumlardaki neslerin türlerinide öğrenebiliriz
#endregion

#region is null Operatörü
// bir değişkenin değerinin null olup olmamasını kontrol eden ve sonuç olarak geriye bool türde değer döndüren operatördür.
string a = null;
Console.WriteLine(a is null);

// is null operatörü sadece null olabilen türlerde kullanabilmektedir.
int b = 123;
Console.WriteLine(b is null);
#endregion

#region is not null Operatörü
// elimizde değerin null olup olmamasıyla ilgilenmekte ve geriye bool sonuç döndürmektedir.
string c = null;
Console.WriteLine(c is not null);

// sadece null alabilen türlerde kullanılabilir.
#endregion

#region as Operatörü
// cast operatörünün UnBoxing işlemine alternatif olarak üretilmiş bir operatördür.
#region cast örneklendirmesi
object x = "Ahmet";
string x2 = (string)x;
Console.WriteLine(x2);
#endregion

object y = "Ahmet";
int y2 = y as int;
Console.WriteLine(y2);
#endregion