using System;
using Xunit;

namespace Cursoonline.DominioTest
{
    public class PrimeiroTeste
    {
        [Fact(DisplayName ="Teste 1")]
        public void Testar()
        {
            //Organiza��o
            int a = 1;
            int b = 3;

            //A��o
            a = b;

            //Assertividade
            Assert.Equal(a, b);

        }
    }
}
