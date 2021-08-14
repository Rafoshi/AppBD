using AppBD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBD.Database
{
    public class Consultas
    {
        readonly Conexao con = new Conexao();


        //Consulta dos produtos
        public void CadastrarProduto(Produto produto)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `appdb`.`tbl_produto` (`prod_nome`, `prod_valor`, `prod_quantidade`) VALUES (@Nome, @Valor, @Quantidade);", con.ConnectionDB());
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = produto.Valor;
            cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = produto.Quantidade;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void EditarProduto(Produto produto)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `appdb`.`tbl_produto` SET `prod_nome` = @Nome, `prod_valor` = @Valor, `prod_quantidade` = @Quantidade WHERE (`prod_cod` = @ID);", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = produto.Codigo;
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = produto.Valor;
            cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = produto.Quantidade;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public List<Produto> ListarProdutos()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM appdb.tbl_produto;", con.ConnectionDB());
            var todosProdutos = cmd.ExecuteReader();
            return ListarTodosProdutos(todosProdutos);
        }

        private List<Produto> ListarTodosProdutos(MySqlDataReader todosProdutos)
        {
            var TodosProdutos = new List<Produto>();

            while (todosProdutos.Read())
            {
                var tempProd = new Produto()
                {
                    Codigo = int.Parse(todosProdutos["prod_cod"].ToString()),
                    Nome = (todosProdutos["prod_nome"].ToString()),
                    Valor = int.Parse(todosProdutos["prod_valor"].ToString()),
                    Quantidade = int.Parse(todosProdutos["prod_quantidade"].ToString()),
                };
                TodosProdutos.Add(tempProd);
            }
            todosProdutos.Close();
            return TodosProdutos;
        }

        public Produto ConsultarProdutoPeloCodigo(int produtoID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM appdb.tbl_produto WHERE PROD_COD = @ID;", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = produtoID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Produto dto = new Produto();
                    {
                        dto.Codigo = Convert.ToInt32(reader[0]);
                        dto.Nome = Convert.ToString(reader[1]);
                        dto.Valor = Convert.ToInt32(reader[2]);
                        dto.Quantidade = Convert.ToInt32(reader[3]);

                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();

            Produto produto = new Produto();
            return produto;
        }

        public void ExcluirProduto(string produtoID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `appdb`.`tbl_produto` WHERE (`prod_cod` = @ProdutoID);", con.ConnectionDB());
            cmd.Parameters.Add("@ProdutoID", MySqlDbType.VarChar).Value = produtoID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        //Consulta dos clientes
        public void CadastrarClientes(Cliente cliente)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `appdb`.`tbl_cliente` (`cliente_nome`, `cliente_cpf`, `cliente_telefone`, `cliente_logradouro`, `cliente_cidade`, `cliente_estado`, `cliente_numero`) VALUES (@Nome, @Cpf, @Telefone, @Logradouro, @Cidade, @Estado, @NumeroEndereco);", con.ConnectionDB());
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = cliente.Estado;
            cmd.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = cliente.Cpf;
            cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = cliente.Cidade;
            cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = cliente.Logradouro;
            cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            cmd.Parameters.Add("@NumeroEndereco", MySqlDbType.VarChar).Value = cliente.NumeroEndereco;


            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public List<Cliente> ListarClientes()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TBL_CLIENTE;", con.ConnectionDB());
            var todosClientes = cmd.ExecuteReader();
            return ListarTodosClientes(todosClientes);
        }

        private List<Cliente> ListarTodosClientes(MySqlDataReader todosClientes)
        {
            var TodosClientes = new List<Cliente>();

            while (todosClientes.Read())
            {
                var tempCli = new Cliente()
                {
                    Codigo = int.Parse(todosClientes["cliente_cod"].ToString()),
                    Nome = (todosClientes["cliente_nome"].ToString()),
                    Cpf = (todosClientes["cliente_cpf"].ToString()),
                    Telefone = (todosClientes["cliente_telefone"].ToString()),
                    Logradouro = (todosClientes["cliente_logradouro"].ToString()),
                    NumeroEndereco = (todosClientes["cliente_numero"].ToString()),
                    Cidade = (todosClientes["cliente_cidade"].ToString()),
                    Estado = (todosClientes["cliente_estado"].ToString()),
                };
                TodosClientes.Add(tempCli);
            }
            todosClientes.Close();
            return TodosClientes;
        }

        public void ExcluirCliente(string clienteID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `appdb`.`tbl_cliente` WHERE (`cliente_cod` = @ClienteID);", con.ConnectionDB());
            cmd.Parameters.Add("@ClienteID", MySqlDbType.VarChar).Value = clienteID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void EditarCliente(Cliente cliente)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `appdb`.`tbl_cliente` SET `cliente_nome` = @Nome, `cliente_cpf` = @Cpf, `cliente_telefone` = @Telefone, `cliente_logradouro` = @Logradouro, `cliente_cidade` = @Cidade, `cliente_estado` = @Estado, `cliente_numero` = @NumeroEndereco WHERE (`cliente_cod` = @ID);", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = cliente.Codigo;
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = cliente.Estado;
            cmd.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = cliente.Cpf;
            cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = cliente.Logradouro;
            cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = cliente.Cidade;
            cmd.Parameters.Add("@NumeroEndereco", MySqlDbType.VarChar).Value = cliente.NumeroEndereco;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public Cliente ConsultarClientePeloCodigo(int clienteID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM appdb.TBL_CLIENTE WHERE CLIENTE_COD = @ID;", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = clienteID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Cliente dto = new Cliente();
                    {
                        dto.Codigo = Convert.ToInt32(reader[0]);
                        dto.Nome = Convert.ToString(reader[1]);
                        dto.Cpf = Convert.ToString(reader[2]);
                        dto.Telefone = Convert.ToString(reader[3]);
                        dto.Logradouro = Convert.ToString(reader[4]);
                        dto.Cidade = Convert.ToString(reader[5]);
                        dto.Estado = Convert.ToString(reader[6]);
                        dto.NumeroEndereco = Convert.ToString(reader[7]);

                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();

            Cliente cliente = new Cliente();
            return cliente;
        }


        //Consultas funcionários

        public List<Funcionario> ListarFuncionarios()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TBL_FUNCIONARIO;", con.ConnectionDB());
            var todosFuncionarios = cmd.ExecuteReader();
            return ListarTodosFuncionarios(todosFuncionarios);
        }

        private List<Funcionario> ListarTodosFuncionarios(MySqlDataReader todosFuncionarios)
        {
            var TodosFuncionarios = new List<Funcionario>();

            while (todosFuncionarios.Read())
            {
                var tempFunc = new Funcionario()
                {
                    Codigo = int.Parse(todosFuncionarios["func_cod"].ToString()),
                    Nome = (todosFuncionarios["func_nome"].ToString()),
                    Cpf = (todosFuncionarios["func_cpf"].ToString()),
                    Telefone = (todosFuncionarios["func_telefone"].ToString()),
                    Logradouro = (todosFuncionarios["func_logradouro"].ToString()),
                    NumeroEndereco = (todosFuncionarios["func_numero"].ToString()),
                    Cidade = (todosFuncionarios["func_cidade"].ToString()),
                    Estado = (todosFuncionarios["func_estado"].ToString()),
                };
                TodosFuncionarios.Add(tempFunc);
            }
            todosFuncionarios.Close();
            return TodosFuncionarios;
        }

        public void ExcluirFuncionario(string funcionarioID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `appdb`.`tbl_funcionario` WHERE (`func_cod` = @FuncionarioID);", con.ConnectionDB());
            cmd.Parameters.Add("@FuncionarioID", MySqlDbType.VarChar).Value = funcionarioID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void CadastrarFuncionarios(Funcionario cliente)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `appdb`.`tbl_funcionario` (`func_nome`, `func_cpf`, `func_telefone`, `func_logradouro`, `func_cidade`, `func_estado`, `func_numero`) VALUES (@Nome, @Cpf, @Telefone, @Logradouro, @Cidade, @Estado, @NumeroEndereco);	", con.ConnectionDB());
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = cliente.Estado;
            cmd.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = cliente.Cpf;
            cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = cliente.Cidade;
            cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = cliente.Logradouro;
            cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            cmd.Parameters.Add("@NumeroEndereco", MySqlDbType.VarChar).Value = cliente.NumeroEndereco;


            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void EditarFuncionario(Funcionario funcionario)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `appdb`.`tbl_funcionario` SET `func_nome` = @Nome, `func_cpf` = @Cpf, `func_telefone` = @Telefone, `func_logradouro` = @Logradouro, `func_cidade` = @Cidade, `func_estado` = @Estado, `func_numero` = @NumeroEndereco WHERE (`func_cod` = @ID);", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = funcionario.Codigo;
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = funcionario.Nome;
            cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = funcionario.Estado;
            cmd.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = funcionario.Cpf;
            cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = funcionario.Logradouro;
            cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = funcionario.Telefone;
            cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = funcionario.Cidade;
            cmd.Parameters.Add("@NumeroEndereco", MySqlDbType.VarChar).Value = funcionario.NumeroEndereco;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public Funcionario ConsultarFuncionarioPeloCodigo(int funcionarioID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM appdb.TBL_FUNCIONARIO WHERE FUNC_COD = @ID;", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = funcionarioID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Funcionario dto = new Funcionario();
                    {
                        dto.Codigo = Convert.ToInt32(reader[0]);
                        dto.Nome = Convert.ToString(reader[1]);
                        dto.Cpf = Convert.ToString(reader[2]);
                        dto.Telefone = Convert.ToString(reader[3]);
                        dto.Logradouro = Convert.ToString(reader[4]);
                        dto.Cidade = Convert.ToString(reader[5]);
                        dto.Estado = Convert.ToString(reader[6]);
                        dto.NumeroEndereco = Convert.ToString(reader[7]);

                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();

            Funcionario funcionario = new Funcionario();
            return funcionario;
        }
    }
}