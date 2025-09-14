
namespace AvaliacaoStreaming
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Linq.Expressions;

    public class AcessoDados
    {
        private readonly string StringDeConexao = "Server=Localhost; Database=avaliacaoStreaming; User=root; Password=123456;";

        public bool AdicionarFuncionario(string login, string email, string tel_cel, string senha, string cargo)
        {
            using (MySqlConnection conexao = new MySqlConnection(StringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string sql = "INSERT INTO funcionario (login, email, tel_cel, senha, cargo) VALUES (@login, @email, @tel_cel, @senha, @cargo)";
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@login", login);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@tel_cel", tel_cel);
                        comando.Parameters.AddWithValue("@senha", senha);
                        comando.Parameters.AddWithValue("@cargo", cargo);
                       
                        int linhasAfetadas = comando.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                   
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Dados Ja existentes!"))
                    {
                        MessageBox.Show("Erro: Login ou Email já existente.");
                    }
                    else
                        MessageBox.Show("Erro ao adicionar funcionário: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
