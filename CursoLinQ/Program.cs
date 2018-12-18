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



            //Single() : Retorna o primeiro que seja unico, ele gera uma exceção caso não seja o unico elemento!
            Produto produto3 = produtos.SingleOrDefault(x => x.Nome.Contains("M")); /*Contains é Case-sensitive*/



            //SkipWhile(condição) : Pula enquanto a condição é verdadeira
            var produtosBaratos = produtos.SkipWhile(x => x.Valor > 1000).ToList();
            Console.WriteLine("\n -------------SkipWhile  \n");
            produtosBaratos.ForEach(x => {
                Console.WriteLine(string.Concat(x.Nome, " R$", x.Valor));
            });



            //Sum(), Max(), Mim()
            Console.WriteLine("\n -------------Sum,Max,Min  \n");            
            var somaDosValores = produtos.Sum(x => x.Valor);
            var valorMaximo = produtos.Max(x => x.Valor);
            var valorMinimo = produtos.Min(x => x.Valor);
            Console.WriteLine("\n Soma dos valores: " + somaDosValores + "\n ValorMaximo: " + valorMaximo + "\n Valor Minino: " + valorMinimo);
                                 


            //Union() : Une dois vetor e não repete os repitidos!
            Console.WriteLine("\n -------------Union()  \n");
            int[] vet1 = { 1, 10, 3, 8, 8, 5, 6 };
            int[] vet2 = { 2, 1, 55, 66, 77, 77, 23, 99, 20 };

            IEnumerable<int> union = vet1.Union(vet2);

            union.OrderBy(x=>x).ToList().ForEach(num =>
            {
                Console.WriteLine(num);
            });



            //Distinct() : Exibe somente uma vez os elementos de um vetor que são repetidos!
            Console.WriteLine("\n -------------Distinct()  \n");
            int[] vetD = { 1, 2, 3, 1, 2, 3, 4, 6, 5, 4, 5, 6 };
            var resultadoDistinct = vetD.Distinct();

            resultadoDistinct.OrderBy(x => x).ToList().ForEach(num =>
            {
                Console.WriteLine(num);
            });
            Console.WriteLine("\n Distinct com Objetos: \n");
            IEnumerable<string> produtoFiltro = produtos.Where(x => x.Nome.Contains("Iphone")).Select(x => x.Nome).Distinct();

            produtoFiltro.ToList().ForEach(nomePorduto =>
            {
                Console.WriteLine(nomePorduto);
            });


            //Any() : pergunta se existe algum elemento na coleção! retorna treu ou false!
            Console.WriteLine("\n -------------Any()  \n");
            if (produtos.Any(x => x.Valor > 1000))
            {
                Console.WriteLine("Existe Produtos com valores acima de 1000");
            }


            //AsQueryable : Converte IEnumerable para IQueryble
            // IQueryble : É uma coleção de dados, que é usado para fazer um filtro de uma consulta no banco!
            // Escreve uma consulta(select) para depois executar ela com ToList();
            Console.WriteLine("\n -------------IQueryble()  \n");
            using (lojaContext ef = new lojaContext())
            {

                var query = ef.Produtoes;
                //int? valor = 1000;
                //string tenhaLetra = "o";
            }







            //
            Console.WriteLine("\n -------------  \n");



            //
            Console.WriteLine("\n -------------  \n");



            Console.ReadKey();
        }
    }
}
