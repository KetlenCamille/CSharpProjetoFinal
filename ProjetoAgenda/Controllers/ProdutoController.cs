﻿using Controllers.Base;
using Controllers.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ProdutoController : IBaseController<Produto>
    {
        Contexto contexto = new Contexto();

        public Produto BuscarPorId(int idProduto)
        {
            return contexto.Produtos.Find(idProduto);
        }

        public void Cadastrar(Produto produto)
        {
            if(produto == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }
        }
    
        public void Editar(Produto produto)
        {
            contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int idProduto)
        {
            Produto produtoExcluir = BuscarPorId(idProduto);

            if(produtoExcluir != null)
            {
                contexto.Entry(produtoExcluir).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Produto> ListarTodos()
        {
            return contexto.Produtos.ToList();
        }

        public IList<Produto> ListarPorNome(string nomeProduto)
        {
            return null;
                //contexto.Produtos.Where(a => a.descricaoProduto.ToLower() == nomeProduto.ToLower() AND a.ativoProduto == "True").ToList();
        }

    }
}
