using Microsoft.EntityFrameworkCore;
using Senai.EfCore.Contexts;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criação do objeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Carrinho de compras",
                    OrderDate = DateTime.Now,
                    PedidosItens = new List<PedidoItem>() 
                };

                //Percorra a lista de pedidos itens e adiciona a lista de pedidosItens 
                foreach (var item in pedidosItens)
                {
                    //Adiciona um pedidoITEM A LISTA
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do objeto pedido criado acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }
                //Adiciona o pedido ao seu contexto
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                .Include(c => c.PedidosItens)
                .ThenInclude(c => c.Produto)
                .FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
