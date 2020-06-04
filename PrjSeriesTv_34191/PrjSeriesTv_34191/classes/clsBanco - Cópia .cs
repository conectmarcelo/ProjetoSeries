using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace PrjSeriesTv_34191.classes
{
    class clsBanco
    {
        #region Propriedades
        public string msgerro { get; private set; }
        #endregion

        #region Variáveis
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;       
        string linhaConexao = "";
        #endregion

        #region Construtor
        public clsBanco()
        {
            linhaConexao = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=prjseriestv";
        }
        #endregion

        #region Conectar
        /// <summary>
        /// Conecta ao MySQL usando os dados de conexão definidos
        /// </summary>
        /// <returns>True caso a conexão tenha sido estabelecida. False se houve erro na conexão</returns>
        private bool Conectar()
        {
            try
            {
                conexao = new MySqlConnection(linhaConexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                return true;
            }
            catch (Exception Erro)
            {
                msgerro = Erro.Message;
                return false;
            }
        }
        #endregion

        #region Desconectar
        /// <summary>
        /// Desconecta do banco MySQL
        /// </summary>
        /// <returns>True caso a conexão tenha sido cancelada. False se não foi possível desconectar</returns>
        public bool Desconectar()
        {
            try
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
                return true;
            }
            catch (Exception Erro)
            {
                msgerro = Erro.Message;
                return false;
            }
        }
        #endregion

        #region Executar
        /// <summary>
        /// Executa comandos SQL no banco de dados ( Inserts, Deletes, Update, Creates, etc )
        /// </summary>
        /// <param name="sql">Comando SQL completo à ser executado</param>
        /// <returns>TRUE se a execução foi bem sucedida. FALSE se houve algum erro durante a execução.</returns>
        public bool Executar(string sql)
        {
            try
            {
                bool status = false;
                if (Conectar())
                {
                    cSQL = new MySqlCommand(sql, conexao);
                    int resultado = cSQL.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        msgerro = "Erro na execução do comando. Verifique os dados e tente novamente.";
                    }
                }
                else
                {
                    return false;
                }
                Desconectar();
                return status;
            }
            catch (Exception Erro)
            {
                msgerro = Erro.Message;
                return false;
            }
        }
        #endregion

        #region Consultar
        /// <summary>
        /// Realiza a execução de um SELECT no Banco de dados
        /// </summary>
        /// <param name="sql">Comando SELECT completo à ser executado</param>
        /// <param name="dados">Objeto MySqlDataReader já definido naAplicação, passado como referência para que se tenha acesso externo ao retorno do comando.</param>
        /// <returns>TRUE se a consulta foi bem sucedida. FALSE se houve erro na execução do SELECT</returns>
        public bool Consultar(string sql, ref MySqlDataReader dados)
        {
            try
            {
                if (Conectar())
                {
                    cSQL = new MySqlCommand(sql, conexao);
                    dados = cSQL.ExecuteReader();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception Erro)
            {
                msgerro = Erro.Message;
                return false;
            }
        }
        #endregion
    }
}
