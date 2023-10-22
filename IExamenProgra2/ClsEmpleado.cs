using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace IExamenProgra2
{
    internal class ClsEmpleado
    {
        //atributos del Empleado
        static byte cant = 10;
        static int pos = 0;

        private static string[] cedula = new string[cant];
        private static string[] nombre = new string[cant];
        private static string[] direccion = new string[cant];
        private static string[] telefono = new string[cant];
        private static float[] salario = new float[cant];
        private static string[] temporal = new string[cant];
        private static float[] TempSalario = new float[cant];
        
        private static byte indice;

        //metodos
        public static void Inicializar() //por defecto si no se menciona es privado
        {
            Console.Clear();
            cedula = Enumerable.Repeat("NULL", cant).ToArray();
            nombre = Enumerable.Repeat("NULL", cant).ToArray();
            direccion = Enumerable.Repeat("NULL", cant).ToArray();
            telefono = Enumerable.Repeat("NULL", cant).ToArray();;
            salario = Enumerable.Repeat(0f, cant).ToArray();
            Console.WriteLine("Vectores se han inicializado con exito\nPresione Enter para continuar");
            Console.ReadLine();
        }

        // Metodo Ingresar
        public static void Ingresar()
        {
            string respuesta = "N";
            bool t = true;
            do
            {
                t = true;
                Console.Clear();
                Console.Write($"Ingrese la cedula:");
                cedula[indice] = Console.ReadLine();
                Console.Write($"Ingrese el nombre del empleado: ");
                nombre[indice] = Console.ReadLine();
                Console.Write($"Ingrese la direccion: ");
                direccion[indice] = Console.ReadLine();
                Console.Write($"Ingrese el numero de telefono: ");
                telefono[indice] = Console.ReadLine();
                Console.Write($"Ingrese el salario: ");
                float.TryParse(Console.ReadLine(), out salario[indice]);
                indice++;
                while (t == true)
                {
                    Console.Write("Desea continuar agregando empleado: S/N ");
                    respuesta = Console.ReadLine().ToString().ToUpper();
                    if (respuesta == "N") { t = false;break; }
                    if (respuesta == "S") {  t = false;break; }
                    else { Console.Write($"Ingrese una opcion valida: ") ; t = true; }
                    Console.Clear();

                }

            } while (respuesta != "N");
        }

        // Metodo Consultar por cedula
        public static void ConsultarEmpleado(string ced)
        {
            Console.Clear();
            for (int i = 0; i < cant; i++)
            {
                if (ced == cedula[i])
                {
                    Console.WriteLine("------Datos del Usuario------");
                    Console.WriteLine("Cedula: "+cedula[i]);
                    Console.WriteLine("Nombre: "+nombre[i]);
                    Console.WriteLine("Direcion: "+direccion[i]);
                    Console.WriteLine("Telefono: "+telefono[i]);
                    Console.WriteLine("Salario: "+salario[i]);
                    Console.WriteLine("-----------------------------");
                    pos = i;
                    Console.ReadLine();
                    break;
                }
            }
        }

        // Metodo Modificar Empleado
        public static void ModificarEmpleado(string ced)
        {
            int o = 0;
            bool v = true;
            Console.Clear();
            for (int i = 0; i < cant; i++)
            {
                if (ced == cedula[i])
                {
                    do
                    {
                        Console.WriteLine("Digite 1 para modificar todos los datos del usuario");
                        Console.WriteLine("Digite 2 para modificar nombre");
                        Console.WriteLine("Digite 3 para modificar direccion");
                        Console.WriteLine("Digite 4 para modificar telefono");
                        Console.WriteLine("Digite 5 para modificar salario");
                        Console.WriteLine("Digite 6 para cancelar");
                        int.TryParse(Console.ReadLine(), out o);
                        switch (o)
                        {
                            case 1:
                                Console.WriteLine("-------------------------");
                                Console.Write($"Ingrese el nuevo nombre del empleado: ");
                                nombre[i] = Console.ReadLine();
                                Console.Write($"Ingrese la nueva direccion: ");
                                direccion[i] = Console.ReadLine();
                                Console.Write($"Ingrese el nuevo numero de telefono: ");
                                telefono[i] = Console.ReadLine();
                                Console.Write($"Ingrese el nuevo salario salario: ");
                                float.TryParse(Console.ReadLine(), out salario[i]);
                                Console.ReadLine();
                                v = false; break;
                            case 2:
                                Console.Write($"Ingrese el nuevo nombre del empleado: ");
                                nombre[i] = Console.ReadLine(); v=false; break;
                            case 3:
                                Console.Write($"Ingrese la nueva direccion: ");
                                direccion[i] = Console.ReadLine();v=false; break;
                            case 4:
                                Console.Write($"Ingrese el nuevo numero de telefono: ");
                                telefono[i] = Console.ReadLine(); v = false; break;
                            case 5:
                                Console.Write($"Ingrese el nuevo salario salario: ");
                                float.TryParse(Console.ReadLine(), out salario[i]);
                                Console.ReadLine(); v = false; break;
                            case 6: v = false; break;

                            default:
                                Console.WriteLine("Opcion incorrecta");
                                break;
                        }
                    } while (v==true);
                 
                }

            }
        }

        //Metodo Eliminar Empleado
        public static void EliminarEmpleado()
        {
            string c;
            temporal = cedula;
            Console.Clear();
            Console.Write("Digite la cedula del empleado que desea eliminar: ");
            c = Console.ReadLine();

            for (int j = 0; j < cant; j++)
            {
                if (c == cedula[j])
                {
                    int x = Array.IndexOf(cedula, c);
                    temporal = cedula.Where(item => item != c).ToArray();
                    cedula = Enumerable.Repeat("NULL", cant).ToArray();

                    Console.WriteLine("Usuario eliminado con exito!");
                    for (int i = 0; i < temporal.Length; i++)
                    {
                        cedula[i] = temporal[i];
                    }

                    temporal = nombre;
                    temporal = Enumerable.Repeat("NULL", cant).ToArray();
                    Array.Copy(nombre, 0, temporal, 0, x);
                    Array.Copy(nombre, x + 1, temporal, x, nombre.Length - x - 1);
                    nombre = temporal;

                    temporal = direccion;
                    temporal = Enumerable.Repeat("NULL", cant).ToArray();
                    Array.Copy(direccion, 0, temporal, 0, x);
                    Array.Copy(direccion, x + 1, temporal, x, direccion.Length - x - 1);
                    direccion = temporal;

                    temporal = telefono;
                    temporal = Enumerable.Repeat("NULL", cant).ToArray();
                    Array.Copy(telefono, 0, temporal, 0, x);
                    Array.Copy(telefono, x + 1, temporal, x, telefono.Length - x - 1);
                    telefono = temporal;

                    TempSalario = salario;
                    TempSalario = Enumerable.Repeat(0f, cant).ToArray();
                    Array.Copy(salario, 0, TempSalario, 0, x);
                    Array.Copy(salario, x + 1, TempSalario, x, salario.Length - x - 1);
                    salario = TempSalario;

                    indice--;
                    Console.ReadLine();
                    break; 
                }

                else
                {
                    Console.WriteLine("Usuario no encontrado"); Console.ReadLine();
                    break;
                }

            }
            
            
        }

        //Creacion de vector temporal para obtener data
        public static void VectorSalarios()
        {
            float[] vecSal= salario;
            vecSal = salario.Where(item => item != 0).ToArray();
        }

        public static void Calculo(int opcion) 
        {
            float[] vecSal = salario;
            vecSal = salario.Where(item => item != 0).ToArray();
            
            //Opcion 2 - Listar
            if (opcion == 2)
            {
                for (int i = 0; i < cant; i++)
                {
                    Console.WriteLine(cedula[i]);
                    Console.WriteLine(nombre[i]);
                    Console.WriteLine(direccion[i]);
                    Console.WriteLine(telefono[i]);
                    Console.WriteLine(salario[i]);
                    Console.WriteLine("-------------------------");
                }
                Console.ReadLine();
            }

            //Opcion 3 - Promedio
            if (opcion == 3)
            {
                Console.WriteLine("El promedio de los salarios es de: "+vecSal.Average()); Console.ReadLine();
            }
            
            //Opcion 4- Salario Max y Min
            if (opcion == 4)
            {
                Console.WriteLine("El salario maximo es de " + vecSal.Max()+"\nEl salario minimo es de "+vecSal.Min()); Console.ReadLine();
            }
        }

    }
}
