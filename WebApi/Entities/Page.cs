using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities{
    public class Page {
        public Page()
        {
            this.state = true;
        }

        public void update(PageDto dto, DataContext context)
        {
            this.description = dto.description;
            this.state = true;
        }

        [Key]
        public int idPage { get; set; }

        [StringLength (50)]
        public string description { get; set; }
        public bool state { get; set; }
    }
}