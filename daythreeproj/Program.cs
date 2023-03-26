using daythreeproj;
using oop;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

public class mainprogram
{
    //Method Non voidyang dimiliki oleh main yang berfunsi sebagai pengambilan keputusan iya atau tidak
    public static int LoopBack(string x, string y, string z)
    {
        int answer=0;
        bool loop=true;
        while (loop == true) {//While loop
            Console.WriteLine(x);
            string no = Console.ReadLine();
            if (no.ToUpper() == z)
            {
                answer = 1;
                loop = false;
         
            }
            else if (no.ToUpper() == y)
            {
                answer = 0;
                loop = false;
            }
            else
            {
                Console.WriteLine("Please answer"+ y+ "/" +z);
                loop = true;
            }

        }
        return answer;


    } 

    public static int Menu()//method non-void yang digunakan untuk menampilkan menu dan mengambil keputusan untuk pilihan menu tersebut
    {
        IDictionary<int, string> menus = new Dictionary<int, string>();//Dictionary array
        menus.Add(1, "Add");
        menus.Add(2, "View");
        menus.Add(3, "Edit");
        int x = 0;
        foreach (KeyValuePair<int, string> select in menus)//foreach loop
        {
            Console.WriteLine("Type {0} to {1}",
                select.Key, select.Value);
            x++;
        }
        Console.WriteLine("Type the answer here");
        int menucount = x;
        Console.WriteLine();
        int usr_select = 0;
        bool stoped = false;
        while (stoped == false && menucount >= 0)
        {
            try//Error Handling jika user mengetik selain angka maka akan muncul pesan seperti berikut
            {
                usr_select = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You're not typing a number dumbass");
            }
            if (usr_select != 0 && usr_select <= menucount)
            {
                stoped = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("your selection is not available");
            }
        }
        return usr_select;//nilai dikembalikan
    }
 


    public static void Main()
    {
        List<Smartphone> list = new List<Smartphone>();//dua list yang akan dimemasukan beberapa objet smartphone & tablet 
        List<Tablet> Tlist = new List<Tablet>();
        Variantselect user = new Variantselect();
        while (true)//looping ini berfungsi untuk mengulang" program ini akan bisa kembali ke menu utama
        {
            int menu = Menu();//Memanggil method menu
            if (menu == 1)//jika user memilih 1 akan user akan meng-input object smartphone
            {
                bool y = true;
                while (y == true)//User input yang akan mengungang pada sampai nilai y adalah false 
                {
                    Console.Write("id  : ");
                    int n_id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Name  : ");
                    string n_name = Console.ReadLine();
                    user.show();//ini adalah method dari objek variant yang berguna untuk menampilkan sekaligus memilih warna dan brand
                    string n_brand = user.usr_selecty;
                    string n_color = user.usr_selectx;
                    Console.Write("Price  : ");
                    int n_price = Convert.ToInt32(Console.ReadLine());
                    int b = LoopBack("Type?(A= Smartphone / B= Tablet)", "A", "B");//menggunakan loopback untuk memilih 2 tipe
                    if (b == 0)//jika user memilih A akan diproses sebagai berikut
                    {
                        list.Add(new Smartphone { id = n_id, name = n_name, brand = n_brand, color = n_color, price = n_price });
                        //User input yang sudah dimasukan tadi akan dunasukan kepada value pada atribut lalu sekaligus memasukan kedalam list tadi
                        int a = LoopBack("Apakah anda ingin berhenti?(Y= Yes/N= No)", "Y", "N");
                        //disini ada pilihan untuk melanjutkan menginput atau tidak jika tidak nilai y adalah false lalu looping pun berhenti
                        if (a == 0)
                        {
                            y = false;
                            Console.Clear();//dan menghapus tampilan yg akan kembali ke menu
                            break;
                        }
                        else if (a == 1) { y = true; n_id++; }//jika ingin melanjutkan looping akan terus berlanjut
                    }
                    else if (b == 1)//jika user memilih B akan diproses sebagai berikut
                    {
                        Console.Write("Screen  : ");//akan ada tambahan input yaitu layar karena biasanya ukuran layar tablet jauh lebih besar
                        int n_screen = Convert.ToInt32(Console.ReadLine());
                        Tlist.Add(new Tablet { id = n_id, name = n_name,screen=n_screen, brand = n_brand, color = n_color, price = n_price });
                        //untuk tahap selanjutnya sama dengan smartphone diatas
                        int a = LoopBack("Apakah anda ingin berhenti?(Y= Yes/N= No)", "Y", "N");
                        if (a == 0)
                        {
                            y = false;
                            Console.Clear();
                            break;
                        }
                        else if (a == 1) { y = true; n_id++; }
                    }

                }
            }
            else if (menu == 2)//dari menu 2 adalah menampilkan apa saja smartphone/tablet yg ada di list
            {
                foreach (Smartphone phone in list)
                {
                    phone.doit();//method ini diambil dari object smartphone yang dimana berfunsi menampilkan value yang ada dalam object
                }
                foreach (Tablet piece in Tlist)
                {
                    piece.doit();//method ini diambil dari object Tablet
                }
            }
            else if (menu == 3)//untuk yang ketiga adalah untuk mengubah value yang ada di object
            {
                int b = LoopBack("Type?(A= Smartphone / B= Tablet)", "A", "B");//menanyakan tipe
                if (b == 0)
                {
                    Console.Write("id search  : ");//lalu menanyakan id object yang akan diinput
                    int idsearch = Convert.ToInt32(Console.ReadLine());
                    foreach (Smartphone phone in list.Where(x => x.id == idsearch))
                    {//jika sudah ditemukan kita hanya bisa mengubah value selain id
                        Console.Write("Update Name  : ");
                        phone.name = Console.ReadLine();
                        Console.Write("Update  : ");
                        user.show();
                        phone.brand = user.usr_selecty;
                        phone.color = user.usr_selectx;
                        Console.Write("Update Price  : ");
                        phone.price = Convert.ToInt32(Console.ReadLine());
                        phone.doit();//menampilkan hasil dari perubahan
                    }
                }
                else if(b == 1)
                {//sama tetapi object tablet
                    Console.Write("id search  : ");
                    int idsearch = Convert.ToInt32(Console.ReadLine());
                    foreach (Tablet piece in Tlist.Where(x => x.id == idsearch))
                    {
                        Console.Write("Update Name  : ");
                        piece.name = Console.ReadLine();
                        Console.Write("Update Screen  : ");
                        piece.screen = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Update  : ");
                        user.show();
                        piece.brand = user.usr_selecty;
                        piece.color = user.usr_selectx;
                        Console.Write("Update Price  : ");
                        piece.price = Convert.ToInt32(Console.ReadLine());
                        piece.doit();
                    }
                }
            }
        }

    }
}