
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
                catch (MySqlException ex) 
                {
                    
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Erro: O login ou o e-mail informado já está cadastrado.");
                    }
                    else
                    {
                        MessageBox.Show("Erro de banco de dados ao adicionar funcionário: " + ex.Message);
                    }
                    return false;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message);
                    return false;
                }
            }
        }
        

        public bool VerificarLoginUsuario(string email, string senha)
        {
            using (MySqlConnection conexao = new MySqlConnection(StringDeConexao))
            {
                try
                {
                    conexao.Open();
                    
                    string sql = "SELECT COUNT(*) FROM usuario WHERE email = @email AND senha = @senha";

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", senha);

                        
                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        
                        return count == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no banco de dados: " + ex.Message);
                    
                    return false;
                }
            }
        }
    }
}


