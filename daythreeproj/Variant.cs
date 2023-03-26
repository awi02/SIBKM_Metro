using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daythreeproj
{
    abstract class Variant//abstrac class yang diganakan menampung variasi dari smartphone/tablet
    {
        public string[] Color = { "Black", "White", "Maroon", "Turquoise", "Gray", "Navy" };
        public string[] Brand = { "Apple", "Samsung", "Xiaomi", "Asus", "Oppo", "Vivo" };
        public abstract void show();//abstract
        public int selection;
    }
}
