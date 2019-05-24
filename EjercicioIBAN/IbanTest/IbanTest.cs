using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolucionBancaria;
using NUnit.Framework;

namespace IbanTest
{
    [TestFixture]
    public class IbanTest
    {
        [Test]
        public void LaCuentaNoTieneLongitudValida()
        {
            try
            {
                string CuentaBanco = "92352082414205416";

                IBAN.esUnCCValido(CuentaBanco);
                Assert.Fail("Numero Incorrecto");
            }
            catch (LongitudIncorrectaException)
            {
                //Tiene que fallar la longitud de la cuenta
            }
        }

        [Test]
        public void LaCuentaEsValida()
        {

            string CuentaBanco = "00492352082414205416";

            IBAN.esUnCCValido(CuentaBanco);
            Assert.IsTrue(IBAN.esUnCCValido(CuentaBanco));
        }

        [Test]
        public void ElIBANValida()
        {
            string CuentaIBAN = "ES1000492352082414205416";

            IBAN.ComprobarIBAN(CuentaIBAN);
        }

        [Test]
        public void TeCalculaElNumeroIBANCorrectamente()
        {
            string Cuenta = "00492352082414205416";
            Assert.AreEqual("10", IBAN.CalcularIBAN("00492352082414205416"));
        }
        [Test]
        public void AlIntroducirCaracterIncorrectoFalla()
        {
            try
            {
                string CuentaBanco = "P0492352082414205416";

                IBAN.esUnCCValido(CuentaBanco);
                Assert.Fail("Caracter no Válido");
            }
            catch (ParametroFormatoIncorrecto)
            {
                //Tiene que fallar por meterle un caracter incorrecto
            }
        }
    }
}
