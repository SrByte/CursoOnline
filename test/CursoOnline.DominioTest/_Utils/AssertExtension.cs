using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.DominioTest._Utils
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagemEsperada)
        {
            if (exception.Message == mensagemEsperada)
                Assert.True(true);
            else
                Assert.False(true);

        }
    }
}
