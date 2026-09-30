using System;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

class Cliente
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Cliente(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public override string ToString()
    {
            return $"Nombre: {Nombre}, Edad: {Edad}"; 
    }
}

class Program
{
    static Queue<Cliente> colaClientes = new Queue<Cliente>();

    static void AgregarCliente()
    {
        Console.Clear();
        Console.WriteLine("===  Agregar Cliente ===");
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int edad) || edad <= 0)
        {
            Console.WriteLine("Edad inválida. Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        colaClientes.Enqueue(new Cliente(nombre, edad));
        Console.WriteLine("CLiente agregado correctamente. Presione una tecla para continuar...");
        Console.ReadLine();
    }

    static void VerClientes()
    {
        Console.Clear();
        Console.WriteLine("===  Lista de Clientes ===");

        if (colaClientes.Count == 0)
        {
            Console.WriteLine("La cola esta vacia");
        }
        else
        {
            foreach (var cliente in colaClientes)
            {
                Console.WriteLine(cliente);
            }
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadLine();

    }

    static void AtenderCliente()
    {
        Console.Clear();
        Console.WriteLine("===  Atender Cliente ===");

        if (colaClientes.Count == 0)
        {
            Console.WriteLine("No hay clientes en la cola.");
        }
        else
        {
            Cliente atentendido = colaClientes.Dequeue();
            Console.WriteLine($"Cliente atendido: {atentendido}");
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void VerClienteFrente()
    {
        Console.Clear();
        Console.WriteLine("=== Cliente al Frente ===");

        if (colaClientes.Count == 0)
        {
            Console.WriteLine("No hay clientes en la cola.");
        }
        else
        {
            Console.WriteLine($"Cliente al frente:  {colaClientes.Peek()}");
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();

    }

    static void BuscarCliente()
    {
        Console.Clear();
        Console.WriteLine("=== Buscar Cliente ===");
        Console.Write("Ingrese el nombre del cliente a buscar: ");
        string nonmbreBusquedo = Console.ReadLine();

        bool encontrado = false;
        foreach (var cliente in colaClientes)
        {
            if (cliente.Nombre.Equals(nonmbreBusquedo, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                Console.WriteLine($"Cliente encontrado: {cliente}");
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Cliente no encontrado en la cola.");
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("===  MENU DE COLA DE CLIENTES ===");
            Console.WriteLine("1. Agregar Cliente");
            Console.WriteLine("2. Ver Clientes En cola");
            Console.WriteLine("3. Atender Cliente (Dequeue)");
            Console.WriteLine("4. Ver Cliente al Frente");
            Console.WriteLine("5. Buscar Cliente");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {

                Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarCliente();
                    break;
                case 2:
                    VerClientes();
                    break;
                case 3:
                    AtenderCliente();
                    break;
                case 4:
                    VerClienteFrente();
                    break;
                case 5:
                    BuscarCliente();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }


        } while (opcion != 6);
    }
}
