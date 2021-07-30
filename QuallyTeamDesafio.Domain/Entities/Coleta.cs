using System;

namespace QuallyTeamDesafio.Domain.Entities
{
    public class Coleta : Entity
    {
        public Guid KpiId { get; private set; }

        public DateTime DataColeta { get; private set; }

        public decimal Valor { get; private set; }

        public Coleta(Guid id, DateTime dataColeta, decimal valor)
        {
            KpiId = id;
            DataColeta = dataColeta;
            Valor = valor;
        }

        public void Atualizar(decimal valor)
        {
            Valor = valor;
        }
    }
}
