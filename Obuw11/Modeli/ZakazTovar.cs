using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obuw11.Modeli
{
    [Table("ZakaziTovarov")]
    public class ZakazTovar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ZakazId{ get; set; }
        public virtual Zakaz Zakaz{ get; set; }
        public int TovarId { get; set; }
        public virtual Tovar Tovar{ get; set; }
        public int Kolichestvo{ get; set; }
       

    }
}
