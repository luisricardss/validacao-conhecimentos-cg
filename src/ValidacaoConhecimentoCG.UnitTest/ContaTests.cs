using ValidacaoConhecimentoCG.API.Application.Requests.Conta;

namespace ValidacaoConhecimentoCG.UnitTest
{
    [TestClass]
    public class ContaTests
    {
        private const string NOME_VALIDO = "Conta";
        private const string DESCRICAO_VALIDO = "Descrição";

        [TestMethod]
        public void InvalidoNomeNull()
        {
            var conta = new ContaRequest
            {
                Nome = null,
                Descricao = DESCRICAO_VALIDO
            };

            Assert.IsFalse(conta.EhValido());
        }

        [TestMethod]
        public void InvalidoNomeVazio()
        {
            var conta = new ContaRequest
            {
                Nome = string.Empty,
                Descricao = DESCRICAO_VALIDO
            };

            Assert.IsFalse(conta.EhValido());
        }

        [TestMethod]
        public void InvalidoDescricaoNull()
        {
            var conta = new ContaRequest
            {
                Nome = NOME_VALIDO,
                Descricao = null
            };

            Assert.IsFalse(conta.EhValido());
        }

        [TestMethod]
        public void InvalidoDescricaoVazio()
        {
            var conta = new ContaRequest
            {
                Nome = NOME_VALIDO,
                Descricao = string.Empty
            };

            Assert.IsFalse(conta.EhValido());
        }

        [TestMethod]
        public void ValidoNomeDescricao()
        {
            var conta = new ContaRequest
            {
                Nome = NOME_VALIDO,
                Descricao = DESCRICAO_VALIDO
            };

            Assert.IsTrue(conta.EhValido());
        }
    }
}