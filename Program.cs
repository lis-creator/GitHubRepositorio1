using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Definición e inicialización de los arreglos
        int[] poblacion = {
            135_446, 174_744, 182_645, 185_013, 190_863, 197_119, 214_317,
            229_866, 271_581, 391_903, 414_543, 421_050, 439_906, 475_630,
            530_586, 593_503, 1_575_819 // ✅ Población de Managua actualizada
        };

        string[] departamento = {
            "Río San Juan", "Madriz", "Rivas", "Boaco", "Chontales", "Carazo", "Granada",
            "Estelí", "Nueva Segovia", "Masaya", "Costa Caribe Sur", "León", "Chinandega",
            "Jinotega", "Costa Caribe Norte", "Matagalpa", "Managua"
        };

        // Crear diccionario
        Dictionary<string, int> diccionario = departamento
            .Zip(poblacion, (k, v) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);

        // Mostrar el diccionario sin ordenar
        Console.WriteLine("datos Desordenados");
        foreach (var item in diccionario)
        {
            Console.WriteLine($"{item.Key,-20}==> {item.Value,10:N0}");
        }
        Console.WriteLine();

        // Ordenar por valor (de menor a mayor)
        var ordenado = diccionario.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        // Departamento con menor y mayor población
        string minDepKey = ordenado.First().Key;
        string maxDepKey = ordenado.Last().Key;

        // Reasignar arreglos ordenados
        departamento = ordenado.Keys.ToArray();
        poblacion = ordenado.Values.ToArray();

        // Mostrar los datos ordenados
        Console.WriteLine("Departamentos ordenados por población:\n");
        for (int i = 0; i < poblacion.Length; i++)
        {
            Console.WriteLine($"{departamento[i],-20} ==> {poblacion[i],10:N0}");
        }

        // Mostrar la suma total y los extremos
        Console.WriteLine($"\nTotal de población nacional: {poblacion.Sum():N0}");
        Console.WriteLine($"Mayor población registrada en: {maxDepKey}");
        Console.WriteLine($"Menor población registrada en: {minDepKey}");
    }
}