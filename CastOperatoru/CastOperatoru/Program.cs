#region cast Operatörü
// genellikle tür dönüşümlerinde kullanılan bir operatördür.
// 1. Boxing -> Unboxing
object x = 123;
int x2 = (int)x;

// 2. bilinçli tür dönüşümü
int a = 5;
short b = (short)a;

// 3. Char -> int | int -> Char (ASCII)
int ascii = 93;
char c = (char)ascii;
#endregion