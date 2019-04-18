using System;
using Xunit;

namespace Cursoonline.DominioTest._util
{
    /// <summary>
    /// Esta classe foi criada para evitar que se tenha dois assert dentro do método de teste
    /// Ela extende a sessão da classe e pega e personaliza o retorno
    /// </summary>
    public static class AssertExtension
    {

        public static void ComMensagem(this ArgumentException exception,string mensagem)
        {
            if(exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true,$"Esperava a mensagem '{mensagem}'");
            }
        }
    }
}
