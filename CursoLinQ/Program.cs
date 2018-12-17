using CursoLinQ.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoLinQ
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Produto> produtos = new List<Produto>();

            using (lojaContext ef = new lojaContext())
            {
                produtos = ef.Produtoes.ToList();
            } 

            produtos.ForEach(x => {
                Console.WriteLine(x.Nome);
            });
            

            
            //First() : Retorna o primeiro produto de nossa coleção, retorna uma exceção caso esteja vazia
            Produto produto1 = produtos.First();
            Produto produto1_1 = produtos.First(x => x.Nome.Contains("a"));



            //FirstOrDefault() : Retorna o primeiro produto de noss coleção, retorna null caso esteja vazia
            Produto produto2 = produtos.FirstOrDefault();



            //Take(x) : retorna os x primeirso
            var ProdutosPaginados1 = produtos.Take(2).ToList();
            Console.WriteLine("\n -------------Produtos Paginados com Take:  \n");
            ProdutosPaginados1.ForEach(x => {
                Console.WriteLine(x.Nome);
            });



            //Skip(x) : Pula a posição x
            var ProdutosPaginados2 = produtos.Skip(1).Take(2).ToList();
            Console.WriteLine("\n -------------Produtos Paginados com Take e Skip:  \n");
            ProdutosPaginados2.ForEach(x => {
                Console.WriteLine(x.Nome);
            });



            //Count() : informa a quantidade de uma coleção
            int qtdeProdutos = produtos.Count();
            int qtdeProdutosComLetraA = produtos.Count(x => x.Nome.Contains("a"));
            Console.WriteLine("\n -------------Count  \n");
            Console.WriteLine($"qtdeProdutos: {qtdeProdutos}, qtdeProdutosComLetraA: {qtdeProdutosComLetraA}");



            //Single() : Retorna o primeiro, caso tenha mais de 1, ele gera uma exceção
            Produto produto3 = produtos.SingleOrDefault(x => x.Nome.Contains("M")); /*Contains é Case-sensitive*/






            Console.WriteLine("\n -------------  \n");


            Console.ReadKey();
        }
    }
}
