﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Entities;


namespace Weather_site.Core.API
{
    public class Clouds : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int all { get; set; }
        public ICollection<RootObject> objects { get; set; }
    }
}