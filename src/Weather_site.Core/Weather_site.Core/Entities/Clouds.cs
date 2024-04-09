using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weather_site.Core.Entities
{
    public class Clouds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int all { get; set; }
    }
}
