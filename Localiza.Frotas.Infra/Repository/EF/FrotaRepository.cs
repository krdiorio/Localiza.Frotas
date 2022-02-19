using Localiza.Frotas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Localiza.Frotas.Infra.Repository.EF
{
    public class FrotaRepository : IVeiculoRepository
    {
        private readonly FrotaContext dbContext;

        public FrotaRepository(FrotaContext dbContext) => this.dbContext = dbContext;


        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToList();

        public Veiculo GetById(Guid id) => dbContext.Veiculos.SingleOrDefault(c => c.Id == id);

        public void Update(Veiculo veiculo)
        {
            dbContext.Remove(GetById(veiculo.Id));
            dbContext.Add(veiculo);
            dbContext.SaveChanges();
        }
    }

}
