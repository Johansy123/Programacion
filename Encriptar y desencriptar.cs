using System;

class Program
{

    static double[,] A = {
        {  1, -2,  2 },
        { -1,  1,  3 },
        {  1, -1, -4 }
    };

    static double[,] Ainv;

    static void Main()
    {
        Ainv = Inversa(A);

        int opcion;
        do
        {
            Console.WriteLine(" ***** Menu *****");
            Console.WriteLine("1. Encriptar");
            Console.WriteLine("2. Desencriptar");
            Console.WriteLine("3. Encriptar y desencriptar");
            Console.WriteLine("4. Salir");
            Console.Write("Opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe introducir un numero.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Mensaje a encriptar: ");
                    string msg = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(msg))
                    {
                        Console.WriteLine("El mensaje no puede estar vacio.");
                        break;
                    }
                    int[] cripto = Encriptar(msg);
                    Mostrar(cripto);
                    break;

                case 2:
                    Console.Write("Criptograma (numeros separados por espacio): ");
                    int[] numeros = LeerNumeros(Console.ReadLine());
                    if (numeros.Length % 3 != 0)
                    {
                        Console.WriteLine("La cantidad de numeros debe ser multiplo de 3.");
                        break;
                    }
                    Console.WriteLine(Desencriptar(numeros));
                    break;

                case 3:
                    Console.Write("Mensaje: ");
                    string msg2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(msg2))
                    {
                        Console.WriteLine("El mensaje no puede estar vacio.");
                        break;
                    }
                    int[] c2 = Encriptar(msg2);
                    Mostrar(c2);
                    Console.WriteLine(Desencriptar(c2));
                    break;

                case 4:
                    Console.WriteLine("Fin del programa.");
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }

        } while (opcion != 4);
    }

    static int[] Encriptar(string mensaje)
    {
        int[] codigos = TextoACodigos(mensaje);

        int resto = codigos.Length % 3;
        int total = (resto == 0) ? codigos.Length : codigos.Length + (3 - resto);

        int[] c = new int[total];
        Array.Copy(codigos, c, codigos.Length);

        int[] resultado = new int[total];
        for (int i = 0; i < total; i += 3)
        {
            for (int j = 0; j < 3; j++)
            {
                resultado[i + j] = (int)(c[i] * A[0, j] + c[i + 1] * A[1, j] + c[i + 2] * A[2, j]);
            }
        }
        return resultado;
    }

    static string Desencriptar(int[] cripto)
    {
        int[] codigos = new int[cripto.Length];

        for (int i = 0; i < cripto.Length; i += 3)
        {
            for (int j = 0; j < 3; j++)
            {
                double valor = cripto[i] * Ainv[0, j] + cripto[i + 1] * Ainv[1, j] + cripto[i + 2] * Ainv[2, j];
                codigos[i + j] = (int)Math.Round(valor);
            }
        }
        return CodigosATexto(codigos);
    }

    static int[] TextoACodigos(string mensaje)
    {
        mensaje = mensaje.ToUpper();
        int[] codigos = new int[mensaje.Length];
        for (int i = 0; i < mensaje.Length; i++)
        {
            char c = mensaje[i];
            codigos[i] = (c == ' ') ? 0 : (c - 'A' + 1);
        }
        return codigos;
    }

    static string CodigosATexto(int[] codigos)
    {
        string resultado = "";
        foreach (int c in codigos)
        {
            resultado += (c == 0) ? " " : ((char)('A' + c - 1)).ToString();
        }
        return resultado;
    }


    static double[,] Inversa(double[,] m)
    {
        double det = m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
                   - m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0])
                   + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

        double[,] adj = new double[3, 3];
        adj[0, 0] = m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1];
        adj[1, 0] = -(m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]);
        adj[2, 0] = m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0];
        adj[0, 1] = -(m[0, 1] * m[2, 2] - m[0, 2] * m[2, 1]);
        adj[1, 1] = m[0, 0] * m[2, 2] - m[0, 2] * m[2, 0];
        adj[2, 1] = -(m[0, 0] * m[2, 1] - m[0, 1] * m[2, 0]);
        adj[0, 2] = m[0, 1] * m[1, 2] - m[0, 2] * m[1, 1];
        adj[1, 2] = -(m[0, 0] * m[1, 2] - m[0, 2] * m[1, 0]);
        adj[2, 2] = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];

        double[,] inv = new double[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                inv[i, j] = adj[i, j] / det;

        return inv;
    }

    static int[] LeerNumeros(string texto)
    {
        string[] partes = texto.Split(' ');
        int[] numeros = new int[partes.Length];
        for (int i = 0; i < partes.Length; i++)
        {
            int.TryParse(partes[i], out numeros[i]);
        }
        return numeros;
    }

    static void Mostrar(int[] arreglo)
    {
        foreach (int n in arreglo)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}
