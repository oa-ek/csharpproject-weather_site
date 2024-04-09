using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Wind
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public double speed { get; set; }
        public int deg { get; set; }
    }
}
