
namespace oop
{
    class Smartphone
    {
        public int id;
        public string name;
        public string brand;
        public string color;
        public int price;

        public Smartphone()//consruct
        {
            Console.WriteLine("Membuat sebuah object");
        }
        public void doit()//menampilkan value dari atribut smartphone
        {
            Console.WriteLine("|{0,10}|", "SMARTPHONE");
            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", "ID", "NAME", "BRAND", "COLOR","PRICE");
            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|", id, name, brand, color,"Rp. "+price);
        }
    }

}
