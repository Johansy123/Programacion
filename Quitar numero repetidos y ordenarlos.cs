using System;

class Program
{
    static void Main()
    {
        int[] numeros = new int[8];

        for (int i = 0; i < 8; i++)
        {
            Console.Write("Ingresa el numero " + (i + 1) + ": ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        int[] sinduplicados = new int[8];
        int cantidadsinduplicados = 0;

        for (int i = 0; i < numeros.Length; i++)
        {
            bool yaexiste = false;

            for (int j = 0; j < cantidadsinduplicados; j++)
            {
                if (sinduplicados[j] == numeros[i])
                {
                    yaexiste = true;
                    break;
                }
            }

            if (!yaexiste)
            {
                sinduplicados[cantidadsinduplicados] = numeros[i];
                cantidadsinduplicados++;
            }
        }

        for (int i = 0; i < cantidadsinduplicados - 1; i++)
        {
            for (int j = 0; j < cantidadsinduplicados - 1 - i; j++)
            {
                if (sinduplicados[j] > sinduplicados[j + 1])
                {
                    int temp = sinduplicados[j];
                    sinduplicados[j] = sinduplicados[j + 1];
                    sinduplicados[j + 1] = temp;
                }
            }
        }

        Console.Write("\nLista ordenada sin duplicados: ");
        for (int i = 0; i < cantidadsinduplicados; i++)
        {
            Console.Write(sinduplicados[i] + " ");
        }
        Console.WriteLine();
    }
}