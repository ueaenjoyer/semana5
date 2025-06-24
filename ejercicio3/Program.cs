// Lista de asignaturas
List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
List<string> notas = new List<string>();

// Pedir al usuario las notas para cada asignatura
foreach (string asignatura in asignaturas)
{
    Console.Write($"¿Qué nota has sacado en {asignatura}? ");
    string? nota = Console.ReadLine();
    if (!string.IsNullOrEmpty(nota))
    {
        notas.Add(nota);
    }
    else
    {
        notas.Add("No especificada");
    }
}

// Mostrar las notas de cada asignatura
Console.WriteLine("\nTus calificaciones son:");
for (int i = 0; i < asignaturas.Count; i++)
{
    Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
}
