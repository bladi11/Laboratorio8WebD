using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio8WebD
{
    public partial class _Default : Page
    {
        //carga de la lista de jugadores al cargar el programa
        //se coloca el static para que los datos permanezcan en la pagina y evitar la sobre escritura
        static List<Jugador> jugadores = new List<Jugador>();
        static List<Resultado> resultados = new List<Resultado>();

        public void Leer()
        {
            //el mappath sirve para encontrar el archivo de jugadores 
            //"en el servidor en contrar el archivo que esta entre parentesis"
            string filename = Server.MapPath("~/Jugadores.txt");

            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Jugador jugador = new Jugador();
                jugador.id = Convert.ToInt16(reader.ReadLine());
                jugador.nombre = reader.ReadLine();
                jugador.equipo = reader.ReadLine();

                jugadores.Add(jugador);
            }
            reader.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Leer(); //carga la lista de jugadores

            DropDownList1.DataValueField = "id";
            DropDownList1.DataMember = "nombre";

            DropDownList1.DataSource = jugadores;
            DropDownList1.DataBind(); //remplaza el refresh


        }

        private void Guardar()
        {
            string filename = Server.MapPath("~/Resultados.txt");

            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var resultado in resultados)
            {
                writer.WriteLine(resultado.idjugador);
                writer.WriteLine(resultado.fecha);
                writer.WriteLine(resultado.equipo);
                writer.WriteLine(resultado.goles);

            }
           
            writer.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Resultado resultado = new Resultado();

            resultado.idjugador = Convert.ToInt16(DropDownList1.SelectedValue);
            resultado.fecha = Calendar1.SelectedDate;
            resultado.equipo = TextBoxEquipo.Text;
            resultado.goles = Convert.ToInt16(TextBoxGoles.Text);

            resultados.Add(resultado);

            Guardar();
        }
    }
}