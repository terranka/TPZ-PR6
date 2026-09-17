using System;
using TPZ_PR4;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== TPZ PR5: ДЕМОНСТРАЦІЙНИЙ КОНСОЛЬНИЙ ЗАСТОСУНОК ===");

var linear = new LinearEquation(2.5, -5.0);
Console.WriteLine($"Linear y(4.0) = {linear.Calculate(4.0)}");

var quad = new QuadraticEquation(1.0, -5.0, 6.0);
quad.FindRoots(out double r1, out double r2, out _);
Console.WriteLine($"Quadratic roots: x1 = {r1}, x2 = {r2}");

Console.WriteLine("Для запуску модульних тестів виконайте команду: dotnet test");
