using System;
using System.Collections.Generic;

public class ListManager
{
    private List<string> items = new List<string>();

    public void NewList() => items.Clear();

    public bool InsertElement(String element)
    {
        if (items.Count < 100)
        {
            items.Add(element);
            return true;
        }
        return false;
    }

    public bool DeteleElement(int pos)
    {
        if (pos >= 0 && pos < items.Count)
        {
            items.RemoveAt(pos);
            return true;
        }

        return false;

    }

    public int Fin(string element) => items.IndexOf(element);
    public string Succ(int pos) => (pos >= 0 && pos < items.Count - 1) ? items[pos + 1] : null;
    public string Pred(int pos) => (pos > 0 && pos < items.Count) ? items[pos - 1] : null;
    public bool IsEmpty() => items.Count == 0;
    public int Count() => items.Count;
    public string GetItem(int index) => (index >= 0 && index < items.Count) ? items[index] : null;
    
}

class Program
{
    static void Main()
    {
        ListManager manager = new ListManager();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("**** MENU DE GESTION DE LISTA ****");
            Console.WriteLine("\nSeleccione una opcion: ");
            Console.WriteLine("1. Crear nueva lista");
            Console.WriteLine("2. Insertar elemento");
            Console.WriteLine("3. Eliminar elemento");
            Console.WriteLine("4. Buscar elemento");
            Console.WriteLine("5. Mostrar Lista)");
            Console.WriteLine("6. Sucesor u Predecesor");
            Console.WriteLine("7. Salir");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.NewList();
                    Console.WriteLine("Nueva lista creada.");
                    break;

                case "2":
                    Console.Write("Ingrese el elemento a insertar: ");
                    string elementToInsert = Console.ReadLine();
                    if (manager.InsertElement(elementToInsert))
                        Console.WriteLine("Elemento insertado con exito");
                    else
                        Console.WriteLine("Error: lista llena (Maximo 100)");
                    break;

                case "3":
                    Console.Write("Ingrese la posicion a eliminar (0-indexada): ");

                    if (int.TryParse(Console.ReadLine(), out int delPos)) 
                    {
                        if (manager.DeteleElement(delPos))
                            Console.WriteLine("Elemento eliminado. ");
                        else
                            Console.WriteLine("Posicion invalida. ");
                    }
                    break;

                case "4":
                    Console.Write("Ingrese el elemento a buscar: ");
                    string toFiend = Console.ReadLine();
                    int foundPos = manager.Fin(toFiend);
                    if (foundPos != -1)
                        Console.WriteLine($"Elemento encontrado en la posicion: {foundPos}");
                    else
                        Console.WriteLine("Elemento no encontrado.");
                    break;

                case "5":
                    if (manager.IsEmpty())
                    {
                        Console.WriteLine("La lista esa vacia.");
                    }
                    else
                    {
                        Console.WriteLine("Elemento en la lista: ");   
                        for (int i = 0; i < manager.Count(); i++)
                        {
                            Console.WriteLine($"[{i}]: {manager.GetItem(i)}");
                        }
                    }
                    break;

                case "6":
                    Console.Write("Ingrese la posicion para susesor y predecesor: ");
                    if (int.TryParse(Console.ReadLine(), out int pos)) ;
                    {
                        string pred = manager.Pred(pos);
                        string succ = manager.Succ(pos);

                        Console.WriteLine(pred != null ? $"Predecesor: {pred}" : "No hay predecesor.");
                        Console.WriteLine(succ != null ? $"Sucesor: {succ}" : "No hay sucesor.");
                    }
                    break;

                case "7":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida. Intente de nuevo.");
                    break;

            }
            Console.ReadKey();
        }
    }
}