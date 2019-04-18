using Cursoonline.DominioTest._Builders;
using Cursoonline.DominioTest._util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Cursoonline.DominioTest.Cursos
{

    //Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matriculadas para o mesmo.

    //Critério de aceite

    //- Criar um curso com nome,carga horária, público alvo e valor do curso.
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor.
    //- Todos os campos do curso são obrigatórios.
    //- Curso deve ter uma descrição. Na situação atual eu teria que criar uma descrição em todos os métodos

    public class CursoTest
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly int _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        /// <summary>
        /// A cada inicialização de um método, o construtor será chamado
        /// </summary>
        /// <param name="output"></param>
        public CursoTest(ITestOutputHelper output)
        {
            this._output = output;
            _output.WriteLine("Construtor sendo executado");

            _nome = "Curso de PHP";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950.10;
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DevoCriarCurso()
        {
            //Forma mais simples de criar um objeto esperado, simulação 
            //const string nome = "Curso de PHP", publicoAlvo = "Desempregados";
            //const int cargaHoraria = 4;
            //const double valor = 100.99;

            //var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Assert.Equal(nome, curso.Nome);
            //Assert.Equal(cargaHoraria, curso.CargaHoraria);
            //Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            //Assert.Equal(valor, curso.Valor);

            //Forma usando plugin expectedObject para evitar n chamadas do Assert.Equal(propriedade)

            Curso curso = CursoBuilder.Novo().Build();

            curso.ToExpectedObject().ShouldMatch(curso);

        }

        //Quando vamos desenv. software temos 2 modelos para seguir: Rica e o Anemico
        //Animico é o mais usado, onde criamos uma classe de dominio , sua tabela no  banco de dados e usamos classes auxiliares para 
        //validação 
        //No modelo rico que casa com o DDD, criamos uma classe de dominio já com a validação da regra de negócio
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string NomeInvalido)
        {
            
            //Ao criar o objeto o teste espera que a classe valide e retorne um erro
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(NomeInvalido).Build()).ComMensagem("Nome inválido");            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //Ao criar o objeto o teste espera que a classe valide e retorne um erro
            var message = Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida)).Message;
            Assert.Equal("Carga horária inválida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            //Ao criar o objeto o teste espera que a classe valide e retorne um erro
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor inválido");
            
        }

    }



    public enum PublicoAlvo
    {
        Estudante, Universitário, Empregado, Empreendedor
    }





    public class Curso
    {
        public string Nome { get; private set; }
        public string Descricao { get;private set }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, string descricao,double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))            
                throw new ArgumentException("Nome inválido");
            
            if (cargaHoraria < 1)            
                throw new ArgumentException("Carga horária inválida");
            
            if (valor < 1)
                 throw new ArgumentException("Valor inválido");

            this.Nome = nome;
            this.Descricao = descricao;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
            
        }
    }

}
