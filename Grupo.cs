/*
 * Creado por SharpDevelop.
 * Usuario: nico_
 * Fecha: 30/5/2024
 * Hora: 19:55
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace Proyecto
{
	public class Grupo
	{
		private int nroObra;
		private int nroLegajoJefObra;
		private ArrayList listaIntegrantes;
		
		public Grupo(int nroObra, JefeObra jefObra)
		{
			this.nroObra = nroObra;
			this.jefObra = jefObra;
			listaIntegrantes = new ArrayList();
		}
		
		public int NroObra
		{
			set{nroObra = value;}
			get{return nroObra;}
		}
		
		public int NroLegajoJefObra
		{
			set{nroLegajoJefObra = value;}
			get{return nroLegajoJefObra;}
		}
		
		public void AgregarIntegrantes(Obrero o)
		{ listaIntegrantes.Add(o); }
		
		public void EliminarObrero(Obrero o)
		{ listaIntegrantes.Remove(o); }
		
		public ArrayList TodosIntegrantes()
		{return listaIntegrantes;}
	}
}
