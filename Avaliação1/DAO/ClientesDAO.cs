using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Avaliação1.DAO.DataAccess;
using MySql.Data.MySqlClient;

namespace Avaliação1.DAO
{
    public class ClientesDAO : BaseDAO
    {
        private VO.Clientes vo;

        public ClientesDAO(VO.Clientes vo)
        {
            if (DAO.listaClientes == null)
            {
                DAO.listaClientes = new List<VO.Clientes>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into clientes (COD,NOME,CPF, ENDERECO, CIDADE, ESTADO, PAIS) " +
                    "values (@cod,@nome,@cpf, @end, @cid, @est, @pais)";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@cpf", vo.cpf, ParameterDirection.Input);
                db.AddParameter("@end", vo.endereco, ParameterDirection.Input);
                db.AddParameter("@cid", vo.cidade, ParameterDirection.Input);
                db.AddParameter("@est", vo.estado, ParameterDirection.Input);
                db.AddParameter("@pais", vo.pais, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }
        public void alterar()
        {
            try
            {
                string sql = "update clientes set " +
                    "NOME = @nome," +
                    "CPF = @cpf," +
                    "ENDERECO = @end," +
                    "CIDADE = @cid," +
                    "ESTADO = @est," +
                    "PAIS = @pais " +
                    "where COD = @cod";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@cpf", vo.cpf, ParameterDirection.Input);
                db.AddParameter("@end", vo.endereco, ParameterDirection.Input);
                db.AddParameter("@cid", vo.cidade, ParameterDirection.Input);
                db.AddParameter("@est", vo.estado, ParameterDirection.Input);
                db.AddParameter("@pais", vo.pais, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }
        public void remover(int id)
        {
            try
            {
                string sql = $"delete from clientes where COD = @cod";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Clientes carregar(int cod)
        {
            string sql = $"SELECT cod,nome,cpf, endereco, cidade, estado, pais from clientes where  COD=@cod";
            db.AddParameter("@cod", cod, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadClientes(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Clientes LoadClientes(DbDataReader dr)
        {
            vo = new VO.Clientes();
            vo.codigo = Convert.ToInt32(dr["cod"]);
            vo.nome = dr["nome"] != DBNull.Value ? dr["nome"].ToString() : "";
            vo.cpf = dr["cpf"] != DBNull.Value ? dr["cpf"].ToString() : "";
            vo.endereco = dr["endereco"] != DBNull.Value ? dr["endereco"].ToString() : "";
            vo.cidade = dr["cidade"] != DBNull.Value ? dr["cidade"].ToString() : "";
            vo.estado = dr["estado"] != DBNull.Value ? dr["estado"].ToString() : "";
            vo.pais = dr["pais"] != DBNull.Value ? dr["pais"].ToString() : "";
            return vo;
        }

        public List<VO.Clientes> listar()
        {
            try
            {
                string sql = "SELECT * FROM clientes;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Clientes>();

                    while (dr.Read())
                    {
                        vo = LoadClientes(dr);
                        objResultado.Add(vo);
                    }
                    return objResultado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }
    }
}

