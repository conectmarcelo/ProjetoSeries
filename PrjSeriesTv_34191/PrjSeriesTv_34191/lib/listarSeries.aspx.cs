using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrjSeriesTv_34191.classes;
using MySql.Data.MySqlClient;


namespace PrjSeriesTv_34191.lib
{
    public partial class listarSeries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsBanco series = new clsBanco();
            MySqlDataReader dados = null;
            if (!series.Consultar("Select * from serie", ref dados ))
            {
                return;
            }

            string retorno = "";
            while (dados.Read())
            {
                retorno += "<div class='fl iconeSerie'>";
                retorno += "    <a href = 'Serie.aspx?c="+ dados[0].ToString()+"'>";
                retorno += "        <div>";
                retorno += "            <figure>";
                retorno += "                <img src='images/series/" + dados[0].ToString() + ".jpg' alt='Imagem da Série" + dados[1].ToString() + "'>";
                retorno += "            </figure>";
                retorno += "        </div>";
                retorno += "        <div class='idIconeSerie'>";
                retorno += "            <span class='titulo'>"+ dados[1].ToString()+"</span><br>";
                retorno += "            <span class='subtitulo'>" + dados[2].ToString() + " - " + dados[3].ToString() + " - Comédia, Drama, Família</span>";
                retorno += "        </div>";
                retorno += "    </a>";
                retorno += "</div>";            
            
            }

            if (!dados.IsClosed) { dados.Close();}
            series.Desconectar();

            Response.Write(retorno);
        }
    }
}