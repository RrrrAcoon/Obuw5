using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Obuw11.Modeli
{
    [Table("Tovari")]
    public class Tovar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Artikul { get; set; }
        public string Naimenovanie { get; set; }
        public int EdinicaIzmereniyaId { get; set; }
        public virtual EdinicaIzmereniya EdinicaIzmereniya { get; set; }
        public decimal Cena { get; set; }
        public int PostavchikId { get; set; }
        public virtual Postavchik Postavchik { get; set; }
        public int ProizvoditelId { get; set; }
        public virtual Proizvoditel Proizvoditel { get; set; }
        public int KategoriyaId { get; set; }
        public virtual Kategoriya Kategoriya { get; set; }
        public int Skidka { get; set; }
        public int Kolichestvo { get; set; }
        public string Opisanie { get; set; }
        public string Foto { get; set; }
        public virtual ICollection<ZakazTovar> ZakaziTovarov { get; set; }

        [NotMapped]
        public decimal TekuchayaCena => Skidka > 0 ? Cena = Cena - Cena * (decimal)Skidka / 100m : Cena;
        [NotMapped]
        public string Shapka => $"{Naimenovanie} | {Kategoriya.Nazvanie}";
        [NotMapped]
        public string CvetFona => Kolichestvo <= 0 ? "Blue" : (Skidka > 15 ? "Green" : "Transparent");
        [NotMapped]
        public string NormalnayaCena => Skidka > 0 ? "Visible" : "Collapsed";
        [NotMapped]
        public string PolniyPutKFoto
        {
            get
            {
                string papka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Kartinki");
                string put = Path.Combine(papka, Foto ?? "picture.png");
                return File.Exists(put) ? put : Path.Combine(papka, "picture.png");
            }

        }
    }
}
