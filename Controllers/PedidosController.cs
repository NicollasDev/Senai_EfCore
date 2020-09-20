using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using Senai.EfCore.Repositories;

namespace Senai.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController()
        {
            _pedidoRepository = new PedidoRepository();
        }
        [HttpPost]
        public IActionResult Post(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Adiciona um pedido
                Pedido pedido = _pedidoRepository.Adicionar(pedidosItens);
                return Ok(pedido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidoRepository.Listar();

                if (pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pedido = _pedidoRepository.BuscarPorId(id);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
