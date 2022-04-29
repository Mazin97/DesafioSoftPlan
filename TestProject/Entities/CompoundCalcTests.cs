using CompoundCalcApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject.Entities
{
    [TestClass]
    public class CompoundCalcTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_calculo_deve_ser_calculado_os_juros_compostos_e_convertido_para_string()
        {
            var calc = new CompoundCalc(100, 5);

            var calcresult = calc.Calculate(0.01F);

            var calcResultTruncated = Math.Round(calcresult, 2, MidpointRounding.ToZero);

            var calcResultTruncatedToString = calcResultTruncated.ToString("F");

            Assert.AreEqual(calcResultTruncatedToString, "105,10");
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_calculo_sem_periodo_o_mesmo_deve_ser_invalido()
        {
            var calc = new CompoundCalc(100, 0);
            Assert.AreEqual(calc.Valid, false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_calculo_sem_taxa_o_mesmo_deve_ser_invalido()
        {
            var calc = new CompoundCalc(100, 5);
            calc.Calculate(0);
            Assert.AreEqual(calc.Valid, false);
        }
    }
}
