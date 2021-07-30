using QuallyTeamDesafio.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuallyTeamDesafio.Domain.Entities
{
    public class Kpi : Entity
    {
        public string Nome { get; private set; }

        public ETipo Tipo { get; private set; }

        public IEnumerable<Coleta> Coletas { get; private set; }

        public Kpi(string nome, ETipo tipo)
        {
            Nome = nome;
            Tipo = tipo;
            Coletas = new List<Coleta>();
        }

        public void Coletar(DateTime dataColeta, decimal valor)
        {
            if (Coletas == null) new List<Coleta>();
            var lista = Coletas.ToList();

            if (lista.Any(_ => _.DataColeta.Date == dataColeta.Date))
            {
                var coleta = lista.First(_ => _.DataColeta.Date == dataColeta.Date);
                coleta.Atualizar(valor);
                return;
            }


            lista.Add(new Coleta(Id, dataColeta, valor));
            Coletas = lista;
        }

        public decimal CalcularValor()
        {
            switch (Tipo)
            {
                case ETipo.SOMA:
                    return CalcularSoma();
                case ETipo.MEDIA:
                    return CalcularMedia();
                default:
                    throw new NotImplementedException($"O Calculo para o tipo de KPI {Tipo} ainda não foi implementado");

            }
        }

        private decimal CalcularSoma()
        {
            if (Coletas == null || Coletas.ToList().Count() < 0) return 0;

            return Coletas.ToList().Sum(_ => _.Valor);
        }

        private decimal CalcularMedia()
        {
            if (Coletas == null || Coletas.ToList().Count() < 0) return 0;

            return Coletas.ToList().Average(_ => _.Valor);
        }
    }
}
