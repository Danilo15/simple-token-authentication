using ProductWebAPI.Models;
using System.Collections.Generic;

namespace ProductWebAPI.DAL
{
    public class SistranInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SistranContext>
    {
        protected override void Seed(SistranContext context)
        {
            var products = new List<Product>
            {
                new Product { Nome = "Caneta", Descricao = "Objeto para escrever", Preco = 10 },
                new Product { Nome = "Lápis", Descricao = "Objeto para escrever", Preco = 11 },
                new Product { Nome = "Borracha", Descricao = "Objeto para apagar", Preco = 12 }
            };

            products.ForEach(p => context.Products.Add(p));

            context.SaveChanges();
        }
    }
}