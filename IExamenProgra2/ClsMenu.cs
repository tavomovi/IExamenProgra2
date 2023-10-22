using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace IExamenProgra2
{
    internal class ClsMenu
    {
        // atributo
        private int opcion = 0;
        static string ced;

        // metodos
        public void mostrar()
        {
            int opcion = 0;
            
            do
            {

                Console.Clear();
                Console.WriteLine("******* Menu Empleado *******");
                Console.WriteLine("1- Inicializar Arreglo");  //Listo
                Console.WriteLine("2- Agregar Empleado");   //Listo
                Console.WriteLine("3- Consultar Empleado por cedula");   //Listo
                Console.WriteLine("4- Modificar Empleado");   //Listo
                Console.WriteLine("5- Borrar Empleado"); //Listo
                Console.WriteLine("6- Menu Reportes");
                Console.WriteLine("7- Salir");
                Console.Write("Digite una opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1: 
                        ClsEmpleado.Inicializar(); break;
                    case 2: 
                        ClsEmpleado.Ingresar(); break;
                    case 3:
                        Buscar();
                        ClsEmpleado.ConsultarEmpleado(ced); break;
                    case 4:
                        Buscar();
                        ClsEmpleado.ModificarEmpleado(ced); break;
                    case 5: 
                        ClsEmpleado.EliminarEmpleado();  break;
                    case 6: submenu(); break;
                    case 7: 
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta");
                        Console.ReadLine();
                        break;
                }
            } while (opcion != 7);
        }

        public void submenu()
        {
            int opcion = 0;

            do
            {

                Console.Clear();
                Console.WriteLine("******* Menu Empleado *******");
                Console.WriteLine("1- Consultar por numero de cedula"); 
                Console.WriteLine("2- Listar todos los empleados");   
                Console.WriteLine("3- Calcular promedio");   
                Console.WriteLine("4- Calcular salario mas alto y mas bajo");   
                Console.WriteLine("5- Regresar al menu principal"); 

                Console.Write("Digite una opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1:
                        Buscar();
                        ClsEmpleado.ConsultarEmpleado(ced); break;

                    case 2:
                        ClsEmpleado.Calculo(opcion); break;

                    case 3:
                        ClsEmpleado.Calculo(opcion); break;

                    case 4:
                        ClsEmpleado.Calculo(opcion); break;

                    case 5: break;

                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            } while (opcion != 5);
        }

        public static void Buscar()
        {
            Console.Write("Digite la cedula que desea buscar: ");
            ced = Console.ReadLine();

        }
    }
}
