using Senai.EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Interfaces
{
  public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
