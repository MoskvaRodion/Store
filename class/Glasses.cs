using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Glasses
    {
    [Key]
    public int id { get; set; }
        public string nazvanie { get; set; }
        public string model { get; set; }
        public string pol { get; set; }
        public string proizvoditel { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public int price_on_glass { get; set; }
        public byte[]? Image { get; set; }
        public int type { get; set; }
        public bool actual { get; set; }    

        public static Glasses currentGlasses;
}
public class Material
{
    [Key]
    public int id_type { get; set; }
    public string? Name_type { get; set; }

    public static Material CurrentMaterial = null;
}

