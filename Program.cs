using System;
using System.Collections;

namespace Practica_5
{
	class Program
	{
		static ArrayList listaAlumnos = new ArrayList();
		static ArrayList ListaMaterias = new ArrayList();
		
		public static void Main(string[] args)
		{
			int opcion;
			Console.WriteLine("##### MENU #####");
			Console.WriteLine("1_ Inscribir alumno");
			Console.WriteLine("2_ Agregar materia.");
			Console.WriteLine("3_ -incribirse a una materia");
			Console.WriteLine("4_ Materias que cursa alumno");
			Console.WriteLine("6_ salir");
			Console.WriteLine("Elija una opcion: ");
			opcion = int.Parse(Console.ReadLine());
			while (opcion != 6) {
				switch (opcion) {
					case 1:
						InscribirAlumno();
						break;
					case 2:
						AgregarMateria();
						break;
					case 3:
						InscribirMateria();
						break;
					case 4: 
						MateriasAlumno();
						break;
					default:
						Console.WriteLine("Opcion incorrecta.");
						Console.WriteLine("Intente nuevamente.");
						break;
				}
				
				Console.WriteLine("##### MENU #####");
				Console.WriteLine("1_ Inscribir alumno");
				Console.WriteLine("2_ Agregar materia.");
				Console.WriteLine("3_ incribirse a una materia");
				Console.WriteLine("4_ Materias que cursa alumno");
				Console.WriteLine("6_ salir");
				Console.WriteLine("Elija una opcion: ");
				opcion = int.Parse(Console.ReadLine());
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		static void InscribirAlumno()
		{
			string nombre;
			int dni,legajo;
		    	
			Console.WriteLine("Ingrese el nombre del alumno: ");
			nombre = Console.ReadLine();
			Console.WriteLine("Ingrese el dni del alumno: ");
			dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el legajo del alumno: ");
			legajo = int.Parse(Console.ReadLine());
			
			Alumno a = new Alumno(nombre, dni, legajo);
			listaAlumnos.Add(a);
			Console.WriteLine("El alumno se inscribio con existo.");
		}
		
		static void AgregarMateria()
		{
			Console.WriteLine("Ingrese la materia: ");
			string materia = Console.ReadLine();
			Console.WriteLine("Ingrese el dia: ");
			string dia = Console.ReadLine();
			Console.WriteLine("Ingrese el horario: ");
			string horario = Console.ReadLine();
			
			Horario h = new Horario(materia,dia,horario);
			ListaMaterias.Add(h);
			Console.WriteLine("La materia se agrego con existo.");
		}
		
		static void InscribirMateria()
		{
			int dniAl;
			string mat, dia, hor;
			
			Console.WriteLine("ingrese el dni del alumno: ");
			dniAl = int.Parse(Console.ReadLine());
			foreach (Alumno elem in listaAlumnos) {               //Recorro la lista de alumnos
				if (dniAl == elem.Dni) {                          //comparo el dni pedido con los de la lista
					Console.WriteLine("Nombre de la materia: ");  //si el dni esta en la lista pido los atributos de la materia
					mat = Console.ReadLine();                     //para agregar a la lista de horarios de alumno   
					Console.WriteLine("Dia de curasda: ");
					dia = Console.ReadLine();
					Console.WriteLine("Horario de cursada: ");
					hor = Console.ReadLine();
					
					elem.InscibirserMateria(mat, dia, hor);
				}
				else
					Console.WriteLine("El alumno no esta inscripto."); 
			}
		}
		
		static void MateriasAlumno()
		{
			int dniAlu;
			
			Console.WriteLine("ingrese el dni del alumno: ");
			dniAlu = int.Parse(Console.ReadLine());
			
			foreach (Alumno elem in listaAlumnos) {
				if (elem.Dni == dniAlu) {
					Console.WriteLine("El alumno esta inscripto a {0}", elem.CantidadMaterias());
				}
			}
		}
	}
}
