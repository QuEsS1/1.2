using System;
using System.Data;
try
{
    IHexadec2 hex = new Hexadec2();
    hex.Input();
    hex.Output();
    Hexadec2 hex1 = new Hexadec2();
    hex1.Input();
    hex1.Output();
    hex.Subtract(hex1);
    hex.Divide(hex1);

}catch(Exception exp)
{
    Console.WriteLine(exp.Message);
}
interface IHexadec2
{
    void Input();
    void Output();
    void Subtract(Hexadec2 hexadec2);
    void Divide(Hexadec2 hexadec2);
}
abstract class Hexadec : IHexadec2
{
    protected string integerPart;
    protected string fractionalPart;
    public abstract void Input();
    public abstract void Output();
    public abstract void Subtract(Hexadec2 hexadec2);
    public abstract void Divide(Hexadec2 hexadec2);
}
class Hexadec2 : Hexadec
{
    public override void Input()
    {
        Console.WriteLine("Введите целую часть используя 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F");
        integerPart = Console.ReadLine();
        Console.WriteLine("Введите дробную часть используя 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F");
        string fractionInput = Console.ReadLine().PadRight(3, '0'); 
        fractionalPart = fractionInput.Substring(0, 3); 
    }
    public override void Output()
    {
        Console.WriteLine($"Шестнадцатиричное число: {integerPart}.{fractionalPart}");
    }
    public override void Subtract(Hexadec2 hexadec2)
    {
        int int1 = Convert.ToInt32(integerPart, 16);
        double frac1 = Convert.ToInt32(fractionalPart, 16) / Math.Pow(16, fractionalPart.Length);
        double num1 = int1 + frac1;
        int int2 = Convert.ToInt32(hexadec2.integerPart, 16);
        double frac2 = Convert.ToInt32(hexadec2.fractionalPart, 16) / Math.Pow(16, hexadec2.fractionalPart.Length);
        double num2 = int2 + frac2;
        double result = num1 - num2;
        int resultInt = (int)Math.Truncate(result);
        double resultFrac = result - resultInt;
        int fracInt = (int)(resultFrac * Math.Pow(16, 3)); 
        string fracHex = Convert.ToString(fracInt, 16).PadLeft(3, '0'); 
        Console.WriteLine($"Результат вычитания: {resultInt.ToString("X")}.{fracHex}");
    }
    public override void Divide(Hexadec2 hexadec2)
    {
        int int1 = Convert.ToInt32(integerPart, 16);
        double frac1 = Convert.ToInt32(fractionalPart, 16) / Math.Pow(16, fractionalPart.Length);
        double num1 = int1 + frac1;
        int int2 = Convert.ToInt32(hexadec2.integerPart, 16);
        double frac2 = Convert.ToInt32(hexadec2.fractionalPart, 16) / Math.Pow(16, hexadec2.fractionalPart.Length);
        double num2 = int2 + frac2;
        double result = num1 / num2;
        int resultInt = (int)Math.Truncate(result);
        double resultFrac = result - resultInt;
        int resultFracInt = (int)(resultFrac * Math.Pow(16, 3)); 
        string fracHex = Convert.ToString(resultFracInt, 16).PadLeft(3, '0'); 
        Console.WriteLine($"Результат деления: {resultInt.ToString("X")}.{fracHex}");
    }
}


