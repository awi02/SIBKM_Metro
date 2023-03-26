using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daythreeproj
{
    internal class Variantselect:Variant
    {
        public string usr_selectx;//Color
        public string usr_selecty;//Brand
        private int select() {//untuk pengambilan keputusan brand/warna
            int s = Convert.ToInt32(Console.ReadLine());
            return s;
        }
        public Variantselect()//consruct
        {
        }
        public override void show()//menampilkan brand dan warna sekaligus memangil method select diatas
        {
            while (true)
            {
                selection = 0;
                Console.WriteLine("");
                Console.WriteLine("Select Color :");
                foreach (string o in Color)
                {
                    Console.Write(selection++ + " " + o + " ;");
                }
                Console.WriteLine("");
                usr_selectx = Color[select()];
                selection = 0;
                Console.WriteLine("Brand :");
                foreach (string i in Brand)
                {
                    Console.Write(selection++ + " " + i + " ;");
                }
                Console.WriteLine("");
                usr_selecty = Brand[select()];
                break;
            }
        }
    }
}
