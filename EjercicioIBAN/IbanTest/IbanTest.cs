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
                string CuentaBanco = "00492352082414205416";

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
    }
}
