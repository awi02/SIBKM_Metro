namespace oop
{
    internal class Tablet:Smartphone//merupakan child dari Smartphone
    {
        public int screen;
        public Tablet()//consruct
        {
        }
        public void doit()//menampilkan value dari atribut tablet
        {
            Console.WriteLine("|{0,10}|", "TABLET");
            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|", "ID", "NAME","SCREEN", "BRAND", "COLOR", "PRICE");
            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|", id, name,screen+"Inch", brand, color, "Rp. " + price);
        }
    }
}
