using System;
using System.Collections.Generic;

class Programa
{
    static Dictionary<string, string> usuarios = new() { { "admin", "admin123" } };
    static List<string> productos = new();
    static string usuarioActual = "";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Iniciar sesión");
            Console.WriteLine("2. Gestionar usuarios");
            Console.WriteLine("3. Gestionar productos");
            Console.WriteLine("4. Cerrar sesión");
            Console.WriteLine("5. Salir");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1": if (usuarioActual == "") IniciarSesion(); else Console.WriteLine("La sesión ya esta iniciada."); break;
                case "2": if (Autenticado()) GestionarUsuarios(); break;
                case "3": if (Autenticado()) GestionarProductos(); break;
                case "4": if (usuarioActual != "") { usuarioActual = ""; Console.WriteLine("Sesión cerrada."); } else Console.WriteLine("No hay sesión iniciada."); break;
                case "5": return;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    static void IniciarSesion()
    {
        Console.Write("Usuario: "); string usuario = Console.ReadLine()!;
        Console.Write("Contraseña: "); string contraseña = Console.ReadLine()!;
        if (usuarios.TryGetValue(usuario, out string? pass) && pass == contraseña)
        {
            usuarioActual = usuario;
            Console.WriteLine("Inicio de sesión exitoso.");
        }
        else Console.WriteLine("Credenciales incorrectas.");
    }

    static void GestionarUsuarios()
    {
        Console.WriteLine("1. Agregar usuario\n2. Eliminar usuario");
        string opcion = Console.ReadLine()!;
        Console.Write("Usuario: "); string usuario = Console.ReadLine()!;
        if (opcion == "1")
        {
            Console.Write("Contraseña: "); string contraseña = Console.ReadLine()!;
            usuarios[usuario] = contraseña;
            Console.WriteLine("Usuario agregado.");
        }
        else if (opcion == "2" && usuarios.Remove(usuario))
            Console.WriteLine("Usuario eliminado.");
        else Console.WriteLine("Operación no válida.");
    }

    static void GestionarProductos()
    {
        Console.WriteLine("1. Agregar producto\n2. Eliminar producto\n3. Listar productos");
        string opcion = Console.ReadLine()!;
        if (opcion == "1")
        {
            Console.Write("Nombre del producto: ");
            productos.Add(Console.ReadLine()!);
            Console.WriteLine("Producto agregado.");
        }
        else if (opcion == "2")
        {
            Console.Write("Nombre del producto: ");
            if (productos.Remove(Console.ReadLine()!))
                Console.WriteLine("Producto eliminado.");
            else Console.WriteLine("Producto no encontrado.");
        }
        else if (opcion == "3")
            productos.ForEach(Console.WriteLine);
        else Console.WriteLine("Opción no válida.");
    }

    static bool Autenticado()
    {
        if (usuarioActual == "") Console.WriteLine("Debe iniciar sesión primero.");
        return usuarioActual != "";
    }
}