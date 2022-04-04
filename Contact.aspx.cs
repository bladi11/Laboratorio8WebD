using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio8WebD
{
    public partial class Contact : Page
    {
        //carga de la lista de jugadores al cargar el programa
        //se coloca el static para que los datos permanezcan en la pagina y evitar la sobre escritura
        static List<Jugador> jugadores = new List<Jugador>();
        static List<Resultado> resultados = new List<Resultado>();
        static List<Reporte> reportes = new List<Reporte>();
        public void LeerJugador()
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

        public void LeerResultados()
        {
            //el mappath sirve para encontrar el archivo de jugadores 
            //"en el servidor en contrar el archivo que esta entre parentesis"
            string filename = Server.MapPath("~/Resultados.txt");

            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Resultado resultado = new Resultado();
                resultado.idjugador = Convert.ToUInt16(reader.ReadLine());
                resultado.fecha = Convert.ToDateTime(reader.ReadLine());
                resultado.equipo = reader.ReadLine();
                resultado.goles = Convert.ToInt16(reader.ReadLine());

                resultados.Add(resultado);
            }
            reader.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonCargar_Click(object sender, EventArgs e)
        {
            LeerJugador();
            LeerResultados();

            for (int i = 0; i< resultados.Count; i++)
            {
                for (int j=0; j< jugadores.Count; j++)
                {
                    if (resultados[i].idjugador == jugadores[j].id)
                    {
                        Reporte reporte = new Reporte();
                        reporte.nombre = jugadores[j].nombre;
                        reporte.goles = resultados[i].goles;

                        reportes.Add(reporte);
                    }
                }
            }
            reportes = reportes.OrderBy(g => g.goles).ToList();

            GridView1.DataSource = reportes;
            GridView1.DataBind();

            double promedio = reportes.Average(g => g.goles);

            Label1.Text = promedio.ToString();


        }
    }
}