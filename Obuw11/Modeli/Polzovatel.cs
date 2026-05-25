using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obuw11.Modeli
{
    [Table("Polzovateli")]
    public class Polzovatel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol{ get; set; }
        public string Familiya { get; set; }
        public string Imya{ get; set; }
        public string Otchestvo{ get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }

        public virtual ICollection<Zakaz> Zakazi{ get; set; }

        public string FIO => $"{Familiya} {Imya} {Otchestvo}".Trim();

    }
}
