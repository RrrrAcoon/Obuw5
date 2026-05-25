using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obuw11.Modeli
{
    [Table("Zakazi")]
    public class Zakaz
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataZakaza { get; set; }
        public DateTime? DataVidachi { get; set; }
        public int PunktVidachiId { get; set; }
        public virtual PunktVidachi PunktVidachi{ get; set; }
        public int PolzovatelId { get; set; }
        public virtual Polzovatel Polzovatel{ get; set; }
        public int KodPolucheniya { get; set; }
        public int StatusZakazaId { get; set; }
        public StatusZakaza StatusZakaza { get; set; }
        public virtual ICollection<ZakazTovar> ZakaziTovarov {  get; set; }

       

    }
}
