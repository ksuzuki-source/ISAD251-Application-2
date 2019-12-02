using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ISAD251WebApp.Models
{
        public class OrderDetails
        {
           
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Date { get; set; }

        public virtual Products Product { get; set; }
        }
    }

