using System;
using System.Collections;

namespace Proyecto
{
	class Program
	{
		public static void Main(string[] args)
		{
			Empresa emp = new Empresa(); //Creo la empresa donde vamos a realizar el proyecto
			try {
				Console.WriteLine("Menú de opciones:");
           	 	Console.WriteLine("1. Contratar un nuevo obrero");
            	      	Console.WriteLine("2. Eliminar un obrero");
            		Console.WriteLine("3. Contratar a un jefe de obra");
		    	Console.WriteLine("4. Modificar el estado de avance de una obra.");
	    		Console.WriteLine("5. Ver listados y procentajes");
	    		Console.WriteLine("6. Dar de baja a un jefe");
            		Console.WriteLine("7. Salir");
            		Console.Write("Seleccione una opción: ");
            		string opcion = Console.ReadLine();
            	
            		while (opcion != "7") {
            			switch (opcion){
            			
            				case "1":
                    			AgregarObreros(emp); //Paso la empresa que cree, para cada una de las funciones 
                    			break;
                			case "2":
                    			EliminarObrero(emp);
                    			break;
                			case "3":
                    			AgregarJefeDeOBra(emp);
                    			break;
                			case "4":
                    			ModificarEstadoObra();
                    			break;
                    			case "5":
		    		 		Console.WriteLine("Submenú de opciones:");
		     		 		Console.WriteLine("1. Mostrar listado de obreros");
		     		 		Console.WriteLine("2. Mostrar listado de obras en ejecución");
		     		 		Console.WriteLine("3. Mostrar listado de obras finalizadas");
		     		 		Console.WriteLine("4. Mostrar listado de jefes");
		     		 		Console.WriteLine("5. Mostrar porcentaje de obras de remodelación sin finalizar");
		     		 		Console.WriteLine("6. Salir");
		             			Console.Write("Seleccione una opción: ");
		     		 		string op = Console.ReadLine();
		     		 		while (op != "6") {
		     		 			switch(op){
                            					case "1":
		     		 					ListaDeObreros(emp);
                             						break;
			    					case "2":
                    	         					ListaObrasEj();
                    	         					break;
			    					case "3":
                            	 					ListaObrasFin();
                            	 					break;
			    					case "4":
                            	 					ListaObreros();
                            	 					break;
			    					case "5":
                            	 					ListaObrasEj();
                            	 					break;
                            					default:
                            	 					Console.WriteLine("Opción no válida.");
                            	 					break;
                    	                                 }
		     		 		}
		     		 		break;
		     		 	case "6":
                    				EliminarJefeObra();
                    				break;		
                			default:
                    				Console.WriteLine("Opción no válida.");
                    				break;		
            		}
            	     }
	        }
            		catch (PuestoOcupado) {
				Console.WriteLine("El jefe de obra no se pudo asignar a la obra o grupo");}
	    		catch(Exception){
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	static void AgregarObreros(Empresa emp){  
        	Console.Write("Ingrese nombre completo: ");
        	string nombreObrero = Console.ReadLine();
        	Console.Write("Ingrese dni: ");
        	int dni = int.Parse(Console.ReadLine());
        	Console.Write("Ingrese número de legajo: ");
        	int nroLegajo = int.Parse(Console.ReadLine());
        	Console.Write("Ingrese el sueldo: ");
        	double sueldo =  double.Parse(Console.ReadLine());
		Console.Write("Ingrese su cargo: ");
		string cargo = Console.ReadLine();
		
		
        	Obrero nuevoObrero = new Obrero(nombreObrero, dni, nroLegajo, sueldo, cargo);
        	emp.AgregarObrero(nuevoObrero);
        	Console.WriteLine("Obrero agregado correctamente.");
    	}
		
	static void EliminarObrero(Empresa emp){
    		Console.Write("Ingrese el número de legajo del obrero a eliminar : ");
    		int nroLegajo = int.Parse(Console.ReadLine());

    		ArrayList listObreros = new ArrayList();
    		listObreros = emp.TodosObreros();
        	foreach(Obrero o in listObreros)
        	{
        		if(o.NroLegajo == nroLegajo)
        		{
        			emp.ELiminarObrero(o);
        			Console.WriteLine("El obrero se elimino con exito.");
        		}
        		else{
        			Console.WriteLine("El obrero no se elimino con exito.");
        			Console.WriteLine("El obrero es inexistente o ingrese el número de legajo correctamente.");
        		}
        	}
    	}
		
	static void AgregarJefeDeOBra(Empresa emp){
		Console.Write("Ingrese nombre completo: ");
        	string nombreObrero = Console.ReadLine();
        	Console.Write("Ingrese dni: ");
        	int dni = int.Parse(Console.ReadLine());
        	Console.Write("Ingrese número de legajo: ");
        	int nroLegajo = int.Parse(Console.ReadLine());
        	Console.Write("Ingrese el sueldo: ");
        	double sueldo =  double.Parse(Console.ReadLine());
		Console.Write("Ingrese su cargo: ");
		string cargo = Console.ReadLine();
		Console.WriteLine("Asigne número de obra:");
		int numObra = int.Parse(Console.ReadLine());
		Console.WriteLine("Asigne un grupo libre(número de grupo): ");
		int numGrupo = int.Parse(Console.ReadLine());
		Console.WriteLine("Ingrese la bonficacion que se la va a dar al jefe: ");
		double bonificacion = double.Parse(Console.ReadLine());
			
		JefeObra jfObra = new JefeObra(nombreObrero, dni, nroLegajo, sueldo, cargo, numObra, numGrupo, bonificacion);
		ArrayList listObras = new ArrayList();  //Tomo la lista de obras y grupos
		listObras = emp.TodasObras();
		ArrayList listGrupos = new ArrayList();
		listGrupos = emp.TodosGrupos();
		foreach (Obra elem in listObras) { //Recorro la lista de obras de la empresa
			foreach (Grupo ele in listGrupos) {  //Recorro la lista de grupos de la empresa
				if (elem.CodigoObra == numObra && ele.NroObra == numObra) {  //Comparo el codigo de la obra y grupo con los que pido por teclado
					if (elem.DniJefObra != 0 && ele.DniJefObra != 0) {  //Una vez que encuentre la obra y grupo que pido por teclado 
						throw new PuestoOcupado();                      //Veo si el puesto esta ocupado tanto en la obra como el grupo 
						}                                                   //Si esta ocupado dispara el throw de la excepción  
						else{                                               //Sino agrego el jefe de obra a la lista de obreros y modifico el dniJefeObra en la obra y el grupo    
						 	emp.AgregarObrero(jfObra);
							elem.DniJefObra = dni;
							ele.DniJefObra = dni;}
					}
				}
			}
		}
		public class PuestoOcupado: Exception
		{}
		
		static void ListaDeObreros(Empresa emp){
			ArrayList listaDeObreros = new ArrayList();
			listaDeObreros = emp.TodosObreros();
			foreach (Obrero elem in listaDeObreros) {
				Console.WriteLine(elem);
			}
		}
	}
}
