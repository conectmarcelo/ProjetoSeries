using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PrjSeriesTv_34191.classes
{
    public class clsBuscaCategorias
    {
        

        public string buscaCategoriasSeries(string codigoSerie)
        {
            #region Conexão

            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=prjseriestv";

            MySqlConnection conexao = new MySqlConnection(linhaConexao);

            try
            {
                conexao.Open();
               
            }
            catch
            {
                return "";
            }

            #endregion

            # region Busca codigos de categoria na serie_categoria

            MySqlCommand cSQL = new MySqlCommand("Select cd_categoria from serie_categoria where cd_serie = " + codigoSerie, conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            List<string> codigosCategoria = new List<string>();

            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    codigosCategoria.Add(dados["cd_categoria"].ToString());

                }
                if (!dados.IsClosed) { dados.Close(); }
            }
                #endregion
                List<string> nomesCategoria = new List<string>();
                for (int i = 0; i < codigosCategoria.Count; i++)
                {
                    cSQL = new MySqlCommand("Select nm_categoria from categoria where cd_categoria = " + codigosCategoria[i], conexao);
                    dados = cSQL.ExecuteReader();


                #region Busca nomes das categroias na tabela categoria

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            nomesCategoria.Add(dados["nm_categoria"].ToString());

                        }
                        if (!dados.IsClosed) { dados.Close(); }
                    }
                }
                #endregion

                string nomes = "";

                for (int i = 0; i < nomesCategoria.Count; i++)
                {
                    nomes += nomesCategoria[i] = ",";
                }

            nomes = nomes.Substring(0, nomes.Length );
                if (conexao.State == ConnectionState.Open) { conexao.Close(); }
                return nomes;

            
        }
    }
}