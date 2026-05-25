using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obuw11.Modeli
{
    [Table("EdiniciIzmereniy")]
    public class EdinicaIzmereniya
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public string Nazvanie{ get; set; }
        public virtual ICollection<Tovar> Tovari{ get; set; }
    }
}
