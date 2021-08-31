
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnalizadorLexico
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int contadorDGV=0;
		string identificador="0",entero="1", real="2",Cadena="3", tipo="4", OpSum="5",OpMul="6", OpRelac="7", opOr="8",
			OpAnd="9", OpNot="10", OpIgualdad="11", pyc="12", coma="13", parentesisI="14", parentesisD="15", 
			llaveI="16", llaveD="17", igual="18", IF="19", WHILE="20", RETURN="21", ELSE="22", pesos="23";
			
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string palabra;
			contadorDGV=0;
			dataGridView1.Rows.Clear();
			palabra = textBox1.Text;
			palabra += '$';
			Analizador(palabra);
		}
		
		void Analizador(string texto){//a22.4a 22.2
			int i=0, resultado=0;
			float res=0;
			string palabra = "";
			bool esNum=false, esFloat=false, esidentificador=false;
			while(texto.Length>i){
				while(char.IsLetterOrDigit(texto[i]) || texto[i]=='_' || texto[i]=='.'){
					palabra += texto[i].ToString();
					if(char.IsDigit(texto[i]))
						esidentificador=true;
					i++;
				}
				esNum = Int32.TryParse(palabra, out resultado);
				esFloat = float.TryParse(palabra, out res);
				if(palabra!="")
				switch(palabra){
					case "if":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = IF;
						contadorDGV++;
						palabra = "";
						break;
					case "while":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = WHILE;
						contadorDGV++;
						palabra = "";
						break;
					case "return":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						contadorDGV++;
						dataGridView1.Rows[contadorDGV].Cells[2].Value = RETURN;
						palabra = "";
						break;
					case "else":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = ELSE;
						contadorDGV++;
						palabra = "";
						break;
					case "int":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = tipo;
						contadorDGV++;
						palabra = "";
						break;
					case "float":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = tipo;
						contadorDGV++;
						palabra = "";
						break;
					case "char":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = tipo;
						contadorDGV++;
						palabra = "";
						break;
					case "void":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = tipo;
						contadorDGV++;
						palabra = "";
						break;
					case "for":
						dataGridView1.Rows.Add();
						dataGridView1.Rows[contadorDGV].Cells[0].Value = "Palabra Reservada";
						dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
						dataGridView1.Rows[contadorDGV].Cells[2].Value = tipo;
						contadorDGV++;
						palabra = "";
						break;
					default:
						if(esNum){
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Entero";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = entero;
							contadorDGV++;
							palabra = "";
							esNum=false;
							resultado = 0;
						}
						else if(esFloat){
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Real";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = real;
							contadorDGV++;
							palabra = "";
							esFloat=false;
							res = 0;
						}
						else if(esidentificador){
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Identificador";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = identificador;
							contadorDGV++;
							palabra = "";
							esidentificador=false;
						}
						else{
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Cadena";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = Cadena;
							contadorDGV++;
							palabra = "";
						}
						break;
				}
				if(!char.IsLetterOrDigit(texto[i])){
					switch(texto[i]){
						case ';':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Punto y coma";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = pyc;
							contadorDGV++;
							i++;
							break;
						case ',':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Coma";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = coma;
							contadorDGV++;
							i++;
							break;
						case '(':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Parentesis izquierdo";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = parentesisI;
							contadorDGV++;
							i++;
							break;
						case ')':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Parentesis derecho";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = parentesisD;
							contadorDGV++;
							i++;
							break;
						case '{':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Llave izquierda";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = llaveI;
							contadorDGV++;
							i++;
							break;
						case '}':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Llave derecha";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = llaveD;
							contadorDGV++;
							i++;
							break;
					    case '=':
							if(texto[i+1]=='=' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op.Igualdad";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'=';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Igual";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								dataGridView1.Rows[contadorDGV].Cells[2].Value = igual;
								contadorDGV++;
								i++;
							}
							break;
						case '+':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op.Adicion - Suma";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = OpSum;
							contadorDGV++;
							i++;
							break;
						case '-':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op.Adicion - Resta";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = OpSum;
							contadorDGV++;
							i++;
							break;
						case '*':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op.Multiplicacion";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = OpMul;
							contadorDGV++;
							i++;
							break;
						case '/':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op.Multiplicacion - Division";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = OpMul;
							contadorDGV++;
							i++;
							break;
						case '<':
							if(texto[i+1]=='=' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Relacional - - Menor o igual que";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'=';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Relacional - Menor que";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i++;
							}
							break;
						case '>':
							if(texto[i+1]=='=' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Relacional - Mayor o igual que";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'=';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Relacional - Mayor que";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i++;
							}
							break;
						case '&':
							if(texto[i+1]=='&' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. And";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'&';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpAnd;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "ERROR";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								contadorDGV++;
								i++;
							}
							break;
						case '|':
							if(texto[i+1]=='|' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Or";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'|';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = opOr;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "ERROR";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								contadorDGV++;
								i++;
							}
							break;
						case '!':
							if(texto[i+1]=='=' && texto[i+1]!='$' && texto[i+1]!=' '){
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Igualdad - Diferente de";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString()+'=';
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpRelac;
								contadorDGV++;
								i = i+2;
							}
							else{
								dataGridView1.Rows.Add();
								dataGridView1.Rows[contadorDGV].Cells[0].Value = "Op. Not";
								dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
								dataGridView1.Rows[contadorDGV].Cells[2].Value = OpNot;
								contadorDGV++;
								i++;
							}
							break;
						case '$':
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "FIN";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = texto[i].ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = pesos;
							contadorDGV++;
							i++;
							break;
						default:
							i++;
							break;
					}				
				}
			}
		}
	}
}