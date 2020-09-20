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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositorio
                var produtos = _produtoRepository.Listar();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem contúdo
                if (produtos.Count == 0)
                return NoContent();

                //Caso exista retorna Ok e os produtos cadastrados
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos

                });
            }
            catch (Exception ex)
            {
                //TODO : Cadastrar mensagem de erro no dominio logErro
                return BadRequest(new {
                    StatusCode= 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, enviei um e-mail para email@email.com informando"
                });
            }
        }

        // GET 
        [HttpGet("{id}")]

        public IActionResult Get(Guid id)

        {
            try
            {

                //Busco o produto no repositorio
                Produto produto =  _produtoRepository.BuscarPorId(id);

                //Verfifica se o produto existe
                //Caso produto não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso produto exista retorna
                //Ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // POST 
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        //PUT 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);
                if (produtoTemp == null)
                    return NotFound();

                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE 
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

    }
}
