using System;
using Xunit;

namespace Cursoonline.DominioTest
{
    public class PrimeiroTeste
    {
        [Fact(DisplayName ="Teste 1")]
        public void Testar()
        {
            //Organização
            int a = 1;
            int b = 3;

            //Ação
            a = b;

            //Assertividade
            Assert.Equal(a, b);

        }
    }
}
