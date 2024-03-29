﻿using System;
using System.Collections.Generic;
using Clase_2;
using Clase_3;
using Clase_4;
using MetodologíasDeProgramaciónI;

namespace Clase_1
{
	//Ejercicio n°1
	public interface Comparable {
    	bool sosIgual(Comparable c);
    	bool sosMayor(Comparable c);
    	bool sosMenor(Comparable c);
    	
	}
	//Ejercicio n°2
	public class Numero : Comparable {
        private int valor;

        public Numero(int v){
        	valor = v;
        }
        
        public int GetValor(){
       		return valor;
        }

    	public bool sosIgual(Comparable c){
      		return valor == ((Numero)c).GetValor();
    	}
    	public bool sosMayor(Comparable c){
        	return valor > ((Numero)c).GetValor();
    	}
    	public bool sosMenor(Comparable c){
        	return valor < ((Numero)c).GetValor();
    	}
    	override public String ToString(){
        	return valor.ToString();
    	}
    }
	// Ejercicio n°3
	public interface Coleccionable{
   		int cuantos();
    	Comparable minimo();
    	Comparable maximo();
    	void agregar(Comparable c);
    	bool contiene(Comparable c);
    	void cambiarEst_Alumnos(Estrategia_Comp e);
    	Iterator crearIterador();
	}
	// Ejercicio n°4
	public class Pila : Coleccionable, Iterable{
    	private List<Comparable> elementos;
    	private int Contador;
    	
    	public Iterator crearIterador(){
    		return new IteradorDeCollection(elementos,Contador);
    	}
    	
    	public Pila(){
        	elementos = new List<Comparable>();
    	}

    	public void push(Comparable p){
    	    elementos.Add(p);
    	}
    	
    	public Comparable pop(){
        	Comparable resultado = elementos[elementos.Count-1];
        	elementos.RemoveAt(elementos.Count-1);
        	return resultado;
    	}
    	
    	public void cambiarEst_Alumnos(Estrategia_Comp e){
    		for (int i = 0; i <elementos.Count; i++) {
    			((alumno)elementos[i]).CE(e);
    		}
    	}

    	public void rrt(Estrategia_Comp e){
    		for (int i = 0; i <elementos.Count; i++) {
    			
    		}
    	}
    	
    	public int cuantos(){
        	return elementos.Count;
    	}
    	public Comparable minimo(){
        	Comparable resultado = elementos[0];
        	for (int x = 1; x < elementos.Count; x++)
        	{
            	if(elementos[x].sosMenor(resultado))
                	resultado = elementos[x];
        	}
        	return resultado;
    	}
    	public Comparable maximo(){
        	Comparable resultado = elementos[0];
        	for (int x = 1; x < elementos.Count; x++)
        	{
            	if(elementos[x].sosMayor(resultado))
                	resultado = elementos[x];
        	}
        	return resultado;
    	}
    	public void agregar(Comparable c){
        	this.push(c);
    	}
    	public bool contiene(Comparable c){
        	for (int x = 0; x < elementos.Count; x++){
            	if(elementos[x].sosIgual(c))
                	return true;
        	}
            
        	return false;
    	}
    	
}
	public class Cola : Coleccionable,  Iterable{
		private List<Comparable> elementos;
		private int Contador;
		
		public Iterator crearIterador(){
    		return new IteradorDeCollection(elementos,Contador);
    	}
		
    	public Cola(){
        	elementos = new List<Comparable>();
    	}
		
    	public void push(Comparable c){
    	    elementos.Add(c);
    	}
    	public Comparable pop(){
        	Comparable resultado = elementos[0];
        	elementos.RemoveAt(0);
        	return resultado;
    	}
		
		public void cambiarEst_Alumnos(Estrategia_Comp e){
    		for (int i = 0; i <elementos.Count; i++) {
    			((alumno)elementos[i]).CE(e);
    		}
    	}

    	public int cuantos(){
        	return elementos.Count;
    	}
    	public Comparable minimo(){
        	Comparable resultado = elementos[0];
        	for (int x = 1; x < elementos.Count; x++)
        	{
            	if(elementos[x].sosMenor(resultado))
                	resultado = elementos[x];
        	}
        	return resultado;
    	}
    	public Comparable maximo(){
        	Comparable resultado = elementos[0];
        	for (int x = 1; x < elementos.Count; x++)
        	{
            	if(elementos[x].sosMayor(resultado))
                	resultado = elementos[x];
        	}
        	return resultado;
    	}
    	public void agregar(Comparable c){
        	this.push(c);
    	}
    	public bool contiene(Comparable c){
        	for (int x = 0; x < elementos.Count; x++){
            	if(elementos[x].sosIgual(c))
                	return true;
        	}
            
        	return false;
		}
	}
	//	Ejercicio n°8
	public class ColeccionMultiple : Coleccionable{
		private Pila pila;
		private Cola cola;
		private List<Comparable> elementos;
		private int Contador;
		
		public Iterator crearIterador(){
    		return new IteradorDeCollection(elementos,Contador);
    	}
		
		public ColeccionMultiple(Pila Pila,Cola COLA){
			pila=Pila;
			cola=COLA;
		}
		public int cuantos(){
			int p=pila.cuantos();
			int c=cola.cuantos();
        	return	p+c;
    	}
    	public Comparable minimo(){
			Comparable min_P = pila.minimo();
			Comparable min_c = cola.minimo();
			if (min_c.sosMenor(min_P)){
                return min_c;
            }
            else{
                return min_P;
            }
    	}
    	public Comparable maximo(){
			Comparable min_P = pila.maximo();
			Comparable min_c = cola.maximo();
			if (min_c.sosMayor(min_P)){
                return min_c;
            }
            else{
                return min_P;
            }
    	}
    	public void agregar(Comparable c){
			throw new NotImplementedException();
    	}//No hace nada
		
		public void cambiarEst_Alumnos(Estrategia_Comp e)
		{ //cambia a todos
			cola.cambiarEst_Alumnos(e);
			pila.cambiarEst_Alumnos(e);
		}

		
    	public bool contiene(Comparable c){
			if (pila.contiene(c) || cola.contiene(c)){
                return true;
            }
            else
                return false;
		}
	}
	//	Ejercicio n°11
	public class Persona :Observado, Comparable{
		private string nombre;
		private int dni;
		
		
		public Persona(string n, int d){
			nombre=n;
			dni=d;
		}
		
		public string GetNombre(){
            return nombre;
        }
		
        public int GetDni(){
            return dni;
        }
		//comparacion por dni
		public virtual bool sosIgual(Comparable c){
			return dni == ((Persona)c).GetDni();
			//return nombre.CompareTo((Persona)c).ge);
		}
		
		public virtual bool sosMayor(Comparable c){
			return dni > ((Persona)c).GetDni();
		}
		
		public virtual bool sosMenor(Comparable c){
			return dni < ((Persona)c).GetDni();
		}
	}//COMPARAR POR NOMBRE
	//	Ejercicio n°15
	public class alumno : Persona,Ialumno{
		private static Random pregunta = new Random();
		private int legajo;
		private double promedio;
		string Calificacion;
		Estrategia_Comp Est;
		
		private static Random Nota = new Random();
		
		public alumno(string nombre,int dni, int l, double p) : base (nombre, dni){
			legajo=l;
			promedio=p;
			Est = new porDNI();
		}
		
		public int ResponderPregunta(int Pregunta){
			Pregunta = Nota.Next(1,3);
			return Pregunta;
		}
		
		
		public string MostrarCalificacion(){
			return GetNombre()+"    "+ Calificacion;
		}
		public string SetCalificacion(int puntaje){
			Calificacion= (puntaje.ToString());
			return Calificacion;
		}
		
		public void SetEst(Estrategia_Comp Est){
			Estrategia_Comp Comparado =Est;
		}
		
		public void CE(Estrategia_Comp e){
			Est=e;
		}
		public string GetNombre(){
			return base.GetNombre();
		}
		
		public int GetDNI(){
			return base.GetDni();
		}
		
		public int GetLegajo(){
            return legajo;
        }
		
        public double GetPromedio(){
            return promedio;
        }
		
		public string GetCalificacion(){
			return Calificacion;
		}
		
		public override bool sosIgual(Comparable c){          
			return Est.sosIgual(this,c);
		}
        public override bool sosMayor(Comparable c){ 
			return Est.sosMayor(this,c);
		}
        public override bool sosMenor(Comparable c){
			return Est.sosMenor(this,c);
		}
		
		public override string ToString(){
            string a = ((alumno)this).GetNombre();
            int b = ((alumno)this).GetDni();
            int c = ((alumno)this).GetLegajo();
            double d = ((alumno)this).GetPromedio();

            return Convert.ToString("("+a + "-" + b + "-" + c + "-" + d+ ")");
		}
	}
	class Program
	{
		static Random azar = new Random();
		static Random DNI = new Random();
		static Random nums = new Random();
		static Random leg = new Random();
		static Random pro = new Random();
		
		public static void Main(string[] args)
		{
			//Pila p = new Pila();
			//llenarAlumno(p);
			//cambiarEstrategiaMain(p, new porPromedio());
			//informar(p);
			
			Menu();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void cambiarEstrategiaMain(Coleccionable c, Estrategia_Comp e){
			c.cambiarEst_Alumnos(e);
        }
		
		// Ejercico n°5
		private static void llenar(Coleccionable l){
			for (int i = 1; i < 21; i++) {
				int num=azar.Next(30);
				Comparable n= new Numero(num);
				l.agregar(n);
			}
    	}
		//	Ejercicio n°12
		private static void llenarPersona(Coleccionable lp){
			string[] nombre ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"};
			for (int i = 0; i <= 20; i++) {
				int dni = DNI.Next(10000000,99999999);
				int numero	= nums.Next(26);
				Persona per = new Persona(nombre[numero],dni);
				lp.agregar(per);
			}
				
		}
		//	Ejercicio n°16
		private static void llenarAlumno(Coleccionable la){
			string[] nombre ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"};
			for (int i = 0; i <= 20; i++) {
				int legs = leg.Next(10000,99999);
				double p= pro.NextDouble();
				int dni = DNI.Next(10000000,99999999);
				int numero	= nums.Next(26);
				p=Math.Round(p,2)*10;
				alumno l = new alumno(nombre[numero],dni,legs,p);
				la.agregar(l);
			}
		}
		//	Ejercicio n°6
		private static void informar(Coleccionable i){
			Console.WriteLine("La Lista tiene un total de "+i.cuantos()+" Elementos");
			Console.WriteLine("El numero menor de la Lista es: "+i.minimo());
			Console.WriteLine("El numero mayor de la Lista es: "+i.maximo());
			Console.WriteLine("Ingrese un numero");
			int x= int.Parse(Console.ReadLine());
			Numero num = new Numero(x);
			if (i.contiene(num)) {
				Console.WriteLine("El numero esta en la Lista y es :"+num);
			}
			else
				Console.WriteLine("El numero no esta en la Lista y es :"+num);
		}
		//	Ejercicio n°7
		//	Menu primncipal (no el por defecto)
		private static void Menu(){
			
			/*//Principio del EJ n°7
			Cola cola = new Cola();
			Pila pila = new Pila();
			Console.WriteLine("Datos de Cola");
			llenar(cola);
			informar(cola);
			Console.WriteLine("Datos de Pila");
			llenar(pila);
			informar(pila);
			//Fin del EJ n°7*/
			
			/*//Principio del EJ n°9
			ColeccionMultiple multiple = new ColeccionMultiple(pila,cola);
			informar(multiple);
			//Fin del EJ n°9*/
			 
			/*//Principio del EJ n°13
			llenarPersona(pila);
			llenarPersona(cola);
			//Fin del EJ n°13*/
		
			/*//Principio del EJ n°17
			llenarAlumno(pila);
			llenarAlumno(cola);
			//Fin del EJ n°17
			*/
				
			/*//Practica n°2---Ejercicio 8
				Cola cola = new Cola();
				Pila pila = new Pila();
				Conjunto conjunto = new Conjunto();
				Dictionary dictionary = new Dictionary();
				llenarAlumno(conjunto);
				//Ejercicio 10 --Practica 2
				llenarAlumno(pila);
				cambiarEstrategiaMain(pila, new porPromedio());
				informar(pila);*/
					
			/*Console.WriteLine("Elija una opción para crear Fabrica: ");
			Console.WriteLine("1)Crear un Numero.\n2)Crear Alumnos.\n3)Crear Vendedores.\4)Crear Student");
			int Option = int.Parse(Console.ReadLine());
			Console.WriteLine(Fabrica.CrearAleatorio(Option));
			*/
			
			/*	string nombre="a";
			int num=3;
			Pila pila = new Pila();
			Cola cola = new Cola();
			Clase_3.Program.LlenarUnico(pila,3);
			Gerente gen= new Gerente(nombre,num);
			Iterator iter = pila.crearIterador();
			while (!iter.Fin()) {
				Vendedor ven =(Vendedor)iter.Actual();
				iter.Siguiente();
				ven.AgregarObservador(gen);
			}
			Clase_3.Program.JornadaDeVentas(pila);
			gen.Cerrar();
			*/	
			
			//Practica 4--Ejercicio n°4
			Teacher teacher = new Teacher();
				for (int i = 0; i < 10; i++) {
					//Student studen = new AdaptadorAlumnos((Ialumno)Fabrica.CrearAleatorio(2));
					Ialumno decorado = ((Ialumno)Fabrica.CrearAleatorio(2));
					decorado = new Dec_Legs(decorado);
					decorado = new Dec_Letra(decorado);
					decorado = new Dec_Calificacion(decorado);
					decorado = new Dec_Asterisco(decorado);
					Student studen = new AdaptadorAlumnos(decorado);
					teacher.goToClass(studen);	
				}
				teacher.teachingAClass();
				
				Console.WriteLine("------------------------");
				/*for (int i = 0; i < 10; i++) {
					Student studen = new AdaptadorAlumnos((Ialumno)Fabrica.CrearAleatorio(2));
					teacher.goToClass(studen);	
				}				
				teacher.teachingAClass();
				*/	 
			
			}
		}
	}

	