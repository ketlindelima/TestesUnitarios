// Testando Lista de Histórico

using Calculadora.Services;

ValidadorCalculadora calc = new ValidadorCalculadora();

calc.Somar(3,9);
calc.Dividir(8,7);
calc.Multiplicar(8,2);
calc.Subtrair(5,3);

var historicoCalculadora = calc.Historico();

foreach (var item in historicoCalculadora)
{
    Console.WriteLine(item);
}