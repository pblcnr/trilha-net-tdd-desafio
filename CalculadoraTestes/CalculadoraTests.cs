using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTests
{
    private CalculadoraImp _calc;
    private List<string> listaHistorico;

    public CalculadoraTests()
    {
        _calc = new CalculadoraImp();
        listaHistorico = new List<string>();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void TesteSomar(int num1, int num2, int resultado)
    {
        // Act
        int resultadCalculadora = _calc.Somar(num1, num2);
        listaHistorico.Insert(0, "Res: " + resultadCalculadora);

        // Assert
        Assert.Equal(resultado, resultadCalculadora);
    }
    [Theory]
    [InlineData(6, 2, 4)]
    [InlineData(5, 5, 0)]
    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        // Act
        int resultadCalculadora = _calc.Subtrair(num1, num2);
        listaHistorico.Insert(0, "Res: " + resultadCalculadora);

        // Assert
        Assert.Equal(resultado, resultadCalculadora);
    }
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void TesteMultiplicar(int num1, int num2, int resultado)
    {
        // Act
        int resultadCalculadora = _calc.Multiplicar(num1, num2);
        listaHistorico.Insert(0, "Res: " + resultadCalculadora);

        // Assert
        Assert.Equal(resultado, resultadCalculadora);
    }
    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        // Act
        int resultadCalculadora = _calc.Dividir(num1, num2);
        listaHistorico.Insert(0, "Res: " + resultadCalculadora);

        // Assert
        Assert.Equal(resultado, resultadCalculadora);
    }
    
    [Fact]
    public void TestarDivisaoPorZero()
    {
        // Assert
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
        // Arrange
        var lista = _calc.historico();
        listaHistorico.RemoveRange(3, listaHistorico.Count - 3);

        // Act
        _calc.Somar(1, 2);
        _calc.Somar(3, 4);
        _calc.Somar(5, 6);
        _calc.Somar(7, 8);


        // Assert
        Assert.NotEmpty(_calc.historico());
        Assert.Equal(3, lista.Count);
    }
}