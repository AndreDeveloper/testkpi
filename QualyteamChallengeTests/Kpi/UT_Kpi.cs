using QuallyTeamDesafio.Domain.Entities;
using QuallyTeamDesafio.Domain.Entities.Enums;
using System;
using Xunit;

namespace QualyteamChallengeTests.KpiTests
{
    public class UT_Kpi
    {

        /// <summary>
        /// Método que testa a soma das coletas do kpi sem coletar coletas com a mesma data
        /// </summary>
        [Fact]
        public void ValidarSomaSemRepetirDataComSucesso()
        {
            //arrange
            var kpiSoma = new Kpi("Vendas", ETipo.SOMA);

            kpiSoma.Coletar(new DateTime(2020, 3, 14), 750);
            kpiSoma.Coletar(new DateTime(2020, 3, 15), 560);
            kpiSoma.Coletar(new DateTime(2020, 3, 16), 654.5M);
            kpiSoma.Coletar(new DateTime(2020, 3, 17), 327.2M);
            kpiSoma.Coletar(new DateTime(2020, 3, 18), 400);


            var valorSoma = kpiSoma.CalcularValor();

            Assert.Equal(2691.7M, valorSoma);
        }

        /// <summary>
        /// Método que testa a soma das coletas do kpi com coletas com a mesma data
        /// </summary>
        [Fact]
        public void ValidarSomaRepetindoDataComSucesso()
        {
            //arrange
            var kpiSoma = new Kpi("Vendas", ETipo.SOMA);

            kpiSoma.Coletar(new DateTime(2020, 3, 14), 750);
            kpiSoma.Coletar(new DateTime(2020, 3, 15), 560);
            kpiSoma.Coletar(new DateTime(2020, 3, 16), 654.5M);
            kpiSoma.Coletar(new DateTime(2020, 3, 17), 327.2M);
            kpiSoma.Coletar(new DateTime(2020, 3, 18), 400);

            kpiSoma.Coletar(new DateTime(2020, 3, 18), 200);


            var valorSoma = kpiSoma.CalcularValor();

            Assert.Equal(2491.7M, valorSoma);
        }

    }
}
