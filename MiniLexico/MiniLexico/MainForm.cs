
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniLexico
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int contadorDGV=0;
		string identificador="0",entero="1", real="2", pesos="23";
			
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
		
		void Analizador(string texto){
			int i=0, resultado=0;
			float res=0;
			string palabra = "";
			bool esNum=false, esFloat=false, esidentificador=false;
			while(texto.Length>i){
				while(char.IsLetterOrDigit(texto[i]) || texto[i]=='_' || texto[i]=='.'){
					palabra += texto[i].ToString();
					i++;
				}
				esNum = Int32.TryParse(palabra, out resultado);
				esFloat = float.TryParse(palabra, out res);
				if(palabra!="")
				switch(palabra){
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
						else{
							dataGridView1.Rows.Add();
							dataGridView1.Rows[contadorDGV].Cells[0].Value = "Identificador";
							dataGridView1.Rows[contadorDGV].Cells[1].Value = palabra.ToString();
							dataGridView1.Rows[contadorDGV].Cells[2].Value = identificador;
							contadorDGV++;
							palabra = "";
						}
						break;
				}
				if(!char.IsLetterOrDigit(texto[i])){
					switch(texto[i]){
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

