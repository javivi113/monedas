using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace monedas
{
    public class Monedas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string moneda { get; set; }

        public decimal ValorActual { get; set; }

        public decimal ValorMax {get; set;}
    }
}
