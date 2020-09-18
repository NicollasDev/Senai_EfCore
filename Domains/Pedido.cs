using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
        }

    }
}
