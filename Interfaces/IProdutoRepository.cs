using Senai.EfCore.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        List<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto Produto);
        void Editar(Produto produto);
        void Remover(Guid id);
    }
}
