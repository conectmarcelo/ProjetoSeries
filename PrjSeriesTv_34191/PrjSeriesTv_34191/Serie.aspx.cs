using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using PrjSeriesTv_34191.classes;

namespace PrjSeriesTv_34191
{
    public partial class Serie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["c"]== null)
            {
                Response.Redirect("Index.aspx");
            }

            if (Request["c"].ToString() == "")
            {
                Response.Redirect("Index.aspx");
            }

            string codigo = Request["c"].ToString();

            litFotoSerie.Text = "<img src='images/series/" + codigo + ".jpg' alt='Full House'>";

            clsBanco series = new clsBanco();
            MySqlDataReader dados = null;
            if (!series.Consultar("Select *from serie where cd_serie="+codigo+" ", ref dados))
            {
                return;
            }

            if (dados.HasRows)
            {
                if (dados.Read())

                {
                    litNome.Text = dados[1].ToString();
                    litNomeOriginal.Text = dados[2].ToString();
                    litAno.Text = dados[3].ToString();
                    if (dados[4].ToString() != "")
                    {
                        litEncerramento.Text = "<p>Ano Encerramento:" + dados[4].ToString() + "</p>";
                    }

                    clsBuscaCategorias busca = new clsBuscaCategorias();
                    litCategorias.Text = busca.buscaCategoriasSeries(codigo);
                }
                if (!dados.IsClosed) { dados.Close(); }
                
            }
            else
            {
                series.Desconectar();
                Response.Redirect("Index.aspx");
            }
            dados = null;
            if (!series.Consultar("Select distinct(cd_temporada) from episodio", ref dados))
            {
                return ;
            }

            if (dados.HasRows)
            {
                while (dados.Read())

                {
                    if (dados[0].ToString() != "1")
                    {
                        litTemporadasDisponiveis.Text += "<option value='" + dados[0].ToString() + "'>" + dados[0].ToString() + " Temporada</option>";
                    }
                    else {

                        litTemporadasDisponiveis.Text += "<option value='" + dados[0].ToString() + "'selected='selected'>" + dados[0].ToString() + " Temporada</option>";
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
                else
                {
                    series.Desconectar();
                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}