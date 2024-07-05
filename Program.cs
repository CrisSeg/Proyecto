using System;
using System.Collections;

namespace Proyecto1
{
	class Program
	{
		public static void Main(string[] args)
		{
			Empresa emp = new Empresa(); //Creo la empresa donde vamos a realizar el proyecto
			Obra obra1 = new Obra("Pepito", 153548, 1, "remodelación", 20, 0, 50000);
			Obra obra2 = new Obra("Gabi", 2165465, 2, "pintura", 50, 0, 10000);
			Obra obra3 = new Obra("Alfredo", 1565458, 3,"construcción", 0, 0, 100000);
			Obra obra4 = new Obra("Inc", 245665, 4, "construcción", 60, 0, 120000);
			Obra obra5 = new Obra("Argn", 864164, 5, "remodelación", 20, 0, 9000);
			Grupo grupo1 = new Grupo(1);
			Grupo grupo2 = new Grupo(2);
			Grupo grupo3 = new Grupo(3);
			Grupo grupo4 = new Grupo(4);
			Grupo grupo5 = new Grupo(5);
			emp.AgregarObra(obra1);
			emp.AgregarObra(obra2);
			emp.AgregarObra(obra3);
			emp.AgregarObra(obra4);
			emp.AgregarObra(obra5);
			emp.AgregarGrupo(grupo1);
			emp.AgregarGrupo(grupo2);
			emp.AgregarGrupo(grupo3);
			emp.AgregarGrupo(grupo4);
			emp.AgregarGrupo(grupo5);
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
            	
            			while (opcion != "7") 
				{
            				switch (opcion)
					{
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
                    					ModificarEstadoObra(emp);
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
		     		 				switch(op)
		     		 				{
                            						case "1":
		     		 						ListaObreros(emp);
                             							break;
			    						case "2":
                    	         						ListaObrasEj(emp);
                    	         						break;
			    						case "3":
                            	 						ListaObrasFin(emp);
                            	 						break;
			    						case "4":
                            	 						ListaDeObreros(emp);
                            	 						break;
			    						case "5":
                            	 						ListaObrasEje(emp);
                            	 						break;
                            						default:
                            	 						Console.WriteLine("Opción no válida.");
                            	 						break;
                    	                                 }
		     		 			}
		     		 			break;
		     		 		case "6":
                    					EliminarJefeObra(emp);
                    					break;
                    				case "7":
                    					Console.Write("Saliendo del Programa...");
                    					break;
                    					
                				default:
                    					Console.WriteLine("Opción no válida.");
                    					break;		
            				}
				}
	        	}
	    		catch(Exception e){
				Console.WriteLine(e.Message); //Muestra un mensaje si captura algo
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		static void AgregarObreros(Empresa emp)
		{  
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
		
		static void EliminarObrero(Empresa emp)
		{
    			Console.Write("Ingrese el número de legajo del obrero a eliminar : ");
    			int nroLegajo = int.Parse(Console.ReadLine());

    			ArrayList listObreros = new ArrayList();
    			listObreros = emp.TodosObreros();
        		foreach(Obrero o in listObreros)
        		{
        			if(o.NroLegajo == nroLegajo){
        				emp.EliminarObrero(o);
        				Console.WriteLine("El obrero se elimino con exito.");
        			}
        			else{
        				Console.WriteLine("El obrero no se elimino con exito.");
        				Console.WriteLine("El obrero es inexistente o ingrese el número de legajo correctamente.");}
				break; //Dejamos de recorrer la lista
        		}

			ArrayList listaGrupos = emp.TodosGrupos();
        		foreach (Grupo elem in listaGrupos) {
        			if (elem.NroObra == CodigoObra) {
        				ArrayList listaIntegrantes = elem.TodosIntegrantes();
        				foreach(Obrero ele in listaIntegrantes){
        					if (ele.NroLegajo == nroLegajo) {
        						elem.EliminarObrero(ele);
        				}
        				break; //Dejamos de recorrer la lista
        			}
        		}
        	}
    	}
		
	    static void AgregarJefeDeOBra(Empresa emp)
		{
		try
			{
				Console.Write("Ingrese nombre completo: ");
        			string nombreObrero = Console.ReadLine();
        			Console.Write("Ingrese dni: ");
        			int dni = int.Parse(Console.ReadLine());
        			Console.Write("Ingrese número de legajo: ");
        			int nroLegajo = int.Parse(Console.ReadLine());
        			Console.Write("Ingrese el sueldo: ");
        			double sueldoSinBonificacion =  double.Parse(Console.ReadLine());
        			string cargo = "Jefe Obra";
				Console.WriteLine("Asigne número de obra:");
				int numObra = int.Parse(Console.ReadLine());
				Console.WriteLine("Asigne un grupo libre(número de grupo): ");
				int numGrupo = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese la bonficacion que se la va a dar al jefe: ");
				double bonificacion = double.Parse(Console.ReadLine());
			
				double sueldo = sueldoSinBonificacion + (sueldoSinBonificacion*bonificacion)/100;
			
				JefeObra jfObra = new JefeObra(nombreObrero, dni, nroLegajo, sueldo, cargo, numObra, numGrupo, bonificacion);
				ArrayList listObras = new ArrayList();
				listObras = emp.TodasObras();
				ArrayList listGrupos = new ArrayList();
				listGrupos = emp.TodosGrupos();
				foreach (Obra elem in listObras) { //Recorro la lista de obras de la empresa
					foreach (Grupo ele in listGrupos) {  //Recorro la lista de grupos de la empresa
						if (elem.CodigoObra == numObra && ele.NroObra == numObra) {  //Comparo el codigo de la obra y grupo con los que pido por teclado
							if (elem.DniJefObra != 0 && ele.NroLegajoJfObra != 0) {  //Una vez que encuentre la obra y grupo que pido por teclado
								throw new PuestoOcupado();                      //Veo si el puesto esta ocupado tanto en la obra como el grupo
						}                                                   //Si esta ocupado dispara el throw de la excepción
						else{                                               //Sino agrego el jefe de obra a la lista de obreros y modifico el dniJefeObra en la obra y el grupo
							emp.AgregarObrero(jfObra);
							elem.DniJefObra = dni;
							ele.NroLegajoJfObra = nroLegajo;
							Console.WriteLine("El jefe de Obra se agrego.");
						}
					}
				}
			  }
		 	}
			catch(PuestoOcupado){Console.WriteLine("El puesto esta ocupado.");}
		}
		public class PuestoOcupado: Exception
		{}
		
		static void ListaObreros(Empresa emp)
		{
			ArrayList listaDeObreros = new ArrayList();
			listaDeObreros = emp.TodosObreros();
			foreach (Obrero elem in listaDeObreros) {
				Console.WriteLine("Nombre: " + elem.NombreObrero+"   Cargo: "+elem.Cargo+"  DNI:   "+elem.Dni+"  Sueldo: $"+elem.Sueldo);
			}
		}

		static void ModificarEstadoObr(Empresa emp)
		{
			Console.WriteLine("Ingrese el codigo de obra: ");
			int codObra = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el estado actual de la obra sin %: ");
			int estadoObra = int.Parse(Console.ReadLine());
			ArrayList listaObras = new ArrayList();
			ArrayList listaObrasFin = new ArrayList();
			listaObras = emp.TodasObras();
			listaObrasFin =emp.TodasObrasFin();
			
			foreach(Obra elem in listaObras) {                //Recorro la lista de obras 
				if (elem.CodigoObra == codObra) {         //Si el codigo de la obra es igual al del elem
					elem.EstadoAvance = estadoObra;   //Actualizo el estado de avance de la obra
				}
				if(elem.CodigoObra == 100){               //Si el estado llega a 100
					emp.EliminarObra(elem);           //Elimino la obra de la lista de obras
					emp.AgregarObraFin(elem);         //La agrego a la lista de obras finalizadas
				}
				break;
			}
			Console.WriteLine("Se logro actualizar el estado de la obra.");
		}
		static void ListaObrasEj(Empresa emp)
		{
			ArrayList listaObrasEj = new ArrayList();
			listaObrasEj = emp.TodasObras();
			foreach (Obra obr in listaObrasEj) { 
				Console.WriteLine("Codigo Obra: " + obr.CodigoObra +"   Nombre del Propietario: "+obr.NombreProp+"   Costo: "+obr.Costo+"  DNI del Propietario: "+obr.DniPro+"   Tipo de Obra: "+obr.TipoObra);
			}
		}
		
		static void ListaObrasFin(Empresa emp)
		{
			ArrayList listaObrasFin = new ArrayList();
			listaObrasFin = emp.TodasObrasFin();
			foreach (Obra ob in listaObrasFin) { 
				Console.WriteLine("Nombre del Propietario: "+ ob.NombreProp+"   DNI del Propietario: "+ob.DniPro+"   Codigo Obra: "+ob.CodigoObra+"    Costo: "+ob.Costo+"   Tipo de Obra: "+ob.TipoObra);
			}
		}
		
		static void ListaDeObreros(Empresa emp)
		{
			ArrayList listaObre = emp.TodosObreros();
			foreach (Obrero obr in listaObre) {
				if(obr.Cargo == "Jefe Obra" || obr.Cargo == "Jefe de Obra")
				{
					Console.WriteLine("Nombre: " +obr.NombreObrero+" Cargo: "+obr.Cargo+" DNI: "+obr.Dni+" Sueldo: $"+obr.Sueldo);
				}
			}
		}
		
		static void ListaObrasEje(Empresa emp)
		{
			ArrayList listaObraEj = new ArrayList();
			listaObraEj = emp.TodasObras();
			
			int obrasEj = listaObraEj.Count;
			int obrasEjR = 0;
			foreach(Obra obr in listaObraEj){
				if(obr.EstadoAvance < 100 && obr.TipoObra == "remodelacion"){
					obrasEjR++;
				}
			}
			double porcentaje = (obrasEjR*100)/obrasEj;
				
			Console.WriteLine("Porcentaje de obras de remodelacion sin finalizar: {0}%", porcentaje);
		}
		static void EliminarJefeObra(Empresa emp)
		{
			Console.WriteLine("Ingrese el dni del jefe de obra que desea eliminar: ");
			int dniJFObra = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el número de legajo del jefe de obra que desea eliminar: ");
			int nroLegajoJFObra = int.Parse(Console.ReadLine());
			ArrayList listaObreros = new ArrayList();
			ArrayList listaObras = new ArrayList();
			ArrayList listaGrupos = new ArrayList();
			
			listaObreros = emp.TodosObreros();
			listaObras = emp.TodasObras();
			listaGrupos = emp.TodosGrupos();
			
			foreach (Obrero elem in listaObreros) {                //Recorro la lista de obreros
				foreach (Obra ele in listaObras) {             //Recorro la lista de obras
					foreach (Grupo el in listaGrupos) {    //Recorro la lista de grupos
						if (elem.Dni == dniJFObra && ele.DniJefObra == dniJFObra && el.NroLegajoJefObra == nroLegajoJFObra) { //Si el dni es igual al de elem.Dni y el.Dni JeFObra y el nro legajo al de el.NroLegajo
							emp.EliminarObrero(elem); //El jefe de obra se elimina de la lista de obreros de la empresa
							ele.DniJefObra = 0;       //Ponemos el dni de jefe de obra en cero
							el.NroLegajoJefObra = 0;   //El nro de legajo tambien
						}
						break; //Deja de recorrer la lista;
					}
				}
			}
		}
	}
}
