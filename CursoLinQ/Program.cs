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
            lojaContext ef = new lojaContext();

            var produtos = ef.Produtoes.ToList();

            produtos.ForEach(x => {
                Console.WriteLine(x.Nome);

            });


            Console.ReadKey();
        }
    }
}
