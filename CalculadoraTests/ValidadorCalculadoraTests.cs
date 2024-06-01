using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora.Services;
using Xunit;

namespace CalculadoraTests
{
    public class ValidadorCalculadoraTests
    {
        private ValidadorCalculadora _calculadora = new ValidadorCalculadora();

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(3,6,9)]
        public void DeveSomarDoisInteiros(int num1, int num2, int resultadoTeste)
        {   
            var resultadoReal = _calculadora.Somar(num1, num2);
            Assert.Equal(resultadoTeste, resultadoReal);
        }

        [Theory]
        [InlineData(2,1,1)]
        [InlineData(30,10,20)]
        public void DeveSubtrairDoisInteiros(int num1, int num2, int resultadoTeste)
        {   
            var resultadoReal = _calculadora.Subtrair(num1, num2);
            Assert.Equal(resultadoTeste, resultadoReal);
        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(3,5,15)]
        public void DeveMultiplicarDoisInteiros(int num1, int num2, int resultadoTeste)
        {   
            var resultadoReal = _calculadora.Multiplicar(num1, num2);
            Assert.Equal(resultadoTeste, resultadoReal);
        }

        [Theory]
        [InlineData(2,2,1)]
        [InlineData(12,6,2)]
        public void DeveDividirDoisInteiros(int num1, int num2, int resultadoTeste)
        {   
            var resultadoReal = _calculadora.Dividir(num1, num2);
            Assert.Equal(resultadoTeste, resultadoReal);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Assert.Throws<DivideByZeroException>(
                () => _calculadora.Dividir(3,0));

        }

        [Fact]
        public void HistoricoNaoDeveSerVazio()
        {   
            // Arrange
            _calculadora.Somar(3,2);
            _calculadora.Somar(4,6);
            _calculadora.Somar(9,7);
            _calculadora.Somar(12,48);

            var lista = _calculadora.Historico();

            Assert.NotEmpty(_calculadora.Historico());
            Assert.Equal(3, lista.Count);
        }
    }
}