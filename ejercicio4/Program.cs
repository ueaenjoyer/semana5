using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Multiplicación de Matrices 2x2");
        Console.WriteLine("==========================\n");
        
        // Obtener la primera matriz 2x2
        Console.WriteLine("Ingrese los valores de la primera matriz (A) 2x2:");
        var matrixA = Read2x2Matrix();
        
        // Obtener la segunda matriz 2x2
        Console.WriteLine("\nIngrese los valores de la segunda matriz (B) 2x2:");
        var matrixB = Read2x2Matrix();

        // Mostrar las matrices ingresadas
        Console.WriteLine("\nMatriz A:");
        PrintMatrix(matrixA);
        
        Console.WriteLine("\nMatriz B:");
        PrintMatrix(matrixB);

        // Multiplicar las matrices
        var result = MultiplyMatrices(matrixA, matrixB);

        // Mostrar el resultado
        Console.WriteLine("\nEl producto de las matrices A x B es:");
        PrintMatrix(result);
    }
    
    static List<List<int>> Read2x2Matrix()
    {
        var matrix = new List<List<int>>();
        
        // Leer la primera fila
        while (true)
        {
            try
            {
                Console.Write("Fila 1 (ingrese 2 números separados por espacio): ");
                var input = Console.ReadLine() ?? "";
                var row1 = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Take(2)
                    .ToList();
                
                // Asegurarse de que la fila tenga exactamente 2 elementos
                if (row1.Count < 2)
                {
                    Console.WriteLine("Error: Debe ingresar exactamente 2 números.");
                    continue;
                }
                
                // Leer la segunda fila
                Console.Write("Fila 2 (ingrese 2 números separados por espacio): ");
                input = Console.ReadLine() ?? "";
                var row2 = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Take(2)
                    .ToList();
                
                if (row2.Count < 2)
                {
                    Console.WriteLine("Error: Debe ingresar exactamente 2 números.");
                    continue;
                }
                
                matrix.Add(row1);
                matrix.Add(row2);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Por favor ingrese solo números enteros separados por un espacio.");
            }
        }
        
        return matrix;
    }

    static List<List<int>> MultiplyMatrices(List<List<int>> a, List<List<int>> b)
    {
        int aRows = a.Count;
        int aCols = a[0].Count;
        int bRows = b.Count;
        int bCols = b[0].Count;

        if (aCols != bRows)
            throw new ArgumentException("Las dimensiones de las matrices no son compatibles para la multiplicación");

        // Inicializar la matriz resultado con ceros
        var result = new List<List<int>>();
        for (int i = 0; i < aRows; i++)
        {
            result.Add(new List<int>());
            for (int j = 0; j < bCols; j++)
            {
                result[i].Add(0);
            }
        }


        // Realizar la multiplicación
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < bCols; j++)
            {
                int sum = 0;
                for (int k = 0; k < aCols; k++)
                {
                    sum += a[i][k] * b[k][j];
                }
                result[i][j] = sum;
            }
        }


        return result;
    }

    static void PrintMatrix(List<List<int>> matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine("[" + string.Join(", ", row) + "]");
        }
    }
}
