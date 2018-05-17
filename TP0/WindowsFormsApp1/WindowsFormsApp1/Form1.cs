using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Cliente cliente = new Cliente();
        List<Dispositivo> dispositivos = new List<Dispositivo>();
        
        public Form1()
        {
            InitializeComponent();
        }

        List<Dispositivo> cargarDispositivosDesdeJson(JArray jsonDispArray)
        {
            //List<Dispositivo> dispositivos = new List<Dispositivo>();
            
            for (int cont = 0; cont < jsonDispArray.Count; cont++) {

                JObject jsonDispositivos = JObject.Parse(jsonDispArray[cont].ToString());

                dispositivos.Add(new Dispositivo()
                {
                    dispositivoON = (bool)jsonDispositivos["dispositivoON"],
                    Kwh = (Double)jsonDispositivos["Kwh"],
                    tipo = (String)jsonDispositivos["tipo"]
                });
            }
            return dispositivos;
        }

        int cargarClaseClienteDesdeJson(JArray jsonArray) {

            int banderaDeCarga = 0;
            for (int cont = 0; cont < jsonArray.Count; cont++)
            {
                

                    //objeto json, carga un array json para recorrerlo y cargar los datos según corresponda en el obj cliente.
                    JObject jsonCliente = JObject.Parse(jsonArray[cont].ToString());

                    //siempre que los datos del array se correspondan con el usuario logueado los cargará.
                    if ((String)jsonCliente["usuario"]==textBox1.Text) {
                    cliente.nombreYApellido = (String)jsonCliente["nombreYApellido"];
                    cliente.numeroDocumento = (String)jsonCliente["numeroDocumento"];
                    cliente.tipoDocumento = (String)jsonCliente["tipoDocumento"];
                    cliente.domicilioServicio = (String)jsonCliente["domicilioServicio"];
                    cliente.telefono = (String)jsonCliente["telefono"];
                    cliente.fechaAltaServicio = (String)jsonCliente["fechaAltaServicio"];
                    cliente.categoria = (String)jsonCliente["categoria"];
                    cliente.usuario = (String)jsonCliente["usuario"];
                    cliente.contrasenia = (String)jsonCliente["contrasenia"];
                    JObject resultado = JObject.Parse(jsonArray[cont].ToString());
                    JArray jsonDispArray = JArray.Parse(resultado["dispositivos"].ToString());
                    cliente.dispositivos = cargarDispositivosDesdeJson(jsonDispArray);
                    banderaDeCarga = 1;
                    
                }
            }
            return banderaDeCarga;
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                //Leo archivo JSON, lo recorro y lo deposito en un array json.
                string fileJSON = File.ReadAllText(@"C:\Users\Facultad\Desktop\Clientes.json"); ///
                //de un string a json array para facilitar el recorrer los datos del archivo json.
                JArray jsonArray = JArray.Parse(fileJSON); 

                //control de login correcto.
                int banderaUnoCorrecto = 0;

                //recorre el array según los clientes que existan en el json
                for (int cont = 0; cont < jsonArray.Count; cont++) 
                {
                    JObject jsonCliente = JObject.Parse(jsonArray[cont].ToString());
                    
                    if ((String)jsonCliente["usuario"] == textBox1.Text && (String)jsonCliente["contrasenia"] == textBox2.Text)
                    {//cuando un usuario logueado se encuentra en el json, va a cargar los datos al objeto cliente y activa las opciones que puede usar.
                        
                        if (cargarClaseClienteDesdeJson(jsonArray) > 0)
                        { label1.Text = "JSON Cargado " + DateTime.Today; groupBox2.Enabled = true; }
                        if (textBox1.Text=="Admin") { groupBox1.Enabled = true; groupBox2.Enabled = true; }
                        banderaUnoCorrecto = 1;
                    }

                }

                if(banderaUnoCorrecto==0)
                {//control de login
                    MessageBox.Show("Datos de login incorrectos.", "Atención");
                }


            }
            else
            {//control de ingreso de datos.
                MessageBox.Show("Debe ingresar datos de usuario y contraseña.", "Atención");
            }

        }

        private void btnCantDispApagados_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cliente.cantidadDeDispositivosOFF());
        }

        private void btnCantDispEncendidos_Click(object sender, EventArgs e)
        {  
            MessageBox.Show(cliente.cantidadDeDispositivosON());
        }

        private void gestionEnergia_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cliente.cantidadDeDispositivosTotales());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cliente.antiguedadEnMeses());
            
        }

        private void button6_Click(object sender, EventArgs e)
        {//ver si es necesario porque en el enunciado solo decía: que el administrador debía consultar la cantidad de meses 
         //como admin(no dice nada más-consultar al profe) 
            MessageBox.Show("Ingresar con los datos del usuario para realizar la gestión de apartado Cliente.");
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(cliente.consumo(),"Consumo");
        }
    }
}
