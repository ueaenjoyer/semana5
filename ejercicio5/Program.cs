using System;
using System.Linq;

Console.WriteLine("Ingrese una lista de números separados por comas:");
string? entrada = Console.ReadLine();

if (string.IsNullOrWhiteSpace(entrada))
{
    Console.WriteLine("No se ingresaron números.");
    return;
}

try
{
    // Convertir la entrada en una lista de números
    var numeros = entrada.Split(',')
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => double.Parse(x))
                        .ToList();

    if (numeros.Count == 0)
    {
        Console.WriteLine("No se encontraron números válidos.");
        return;
    }

    // Calcular la media
    double media = numeros.Average();
    
    // Calcular la varianza
    double varianza = numeros.Sum(x => Math.Pow(x - media, 2)) / numeros.Count;
    
    // Calcular la desviación típica
    double desviacionTipica = Math.Sqrt(varianza);

    // Mostrar los resultados
    Console.WriteLine($"\nCantidad de números: {numeros.Count}");
    Console.WriteLine($"Media: {media:N4}");
    Console.WriteLine($"Desviación típica: {desviacionTipica:N4}");
}
catch (FormatException)
{
    Console.WriteLine("Error: Asegúrese de ingresar solo números separados por comas.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}
