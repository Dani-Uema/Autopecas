using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Avaliação1.DAO.DataAccess;
using MySql.Data.MySqlClient;

namespace Avaliação1.DAO
{
     public class PecasDAO : BaseDAO
    {
        private VO.Pecas vo;
        public PecasDAO(VO.Pecas vo)
        {
            if (DAO.listaPecas == null)
            {
                DAO.listaPecas = new List<VO.Pecas>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into pecas (ID,CODIGO,DESCRICAO,CODBARRAS) " +
                    "values (@id,@cod,@desc,@cbarras)";
                db.AddParameter("@id", vo.id, ParameterDirection.Input);
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@desc", vo.descricao, ParameterDirection.Input);
                db.AddParameter("@cbarras", vo.codbarras, ParameterDirection.Input);

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
                string sql = "update pecas set " +
                    "ID = @id," +
                    "CODIGO = @cod," +
                    "DESCRICAO = @desc," +
                    "CODBARRAS= @cbarras " +
                    "where ID = @id";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@id", vo.id, ParameterDirection.Input);
                db.AddParameter("@desc", vo.descricao, ParameterDirection.Input);
                db.AddParameter("@cbarras", vo.codbarras, ParameterDirection.Input);
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
                string sql = $"delete from pecas where ID = @id";
                db.AddParameter("@id", vo.id, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Pecas carregar(int id)
        {
            string sql = $"SELECT ID,codigo,descricao,codbarras from pecas where ID=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadPecas(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Pecas LoadPecas(DbDataReader dr)
        {
            vo = new VO.Pecas();
            vo.id = Convert.ToInt32(dr["ID"]);
            vo.codigo = Convert.ToInt32(dr["codigo"]);
            vo.codbarras = dr["codbarras"] != DBNull.Value ? dr["codbarras"].ToString() : "";
            vo.descricao = dr["descricao"] != DBNull.Value ? dr["descricao"].ToString() : "";
            return vo;
        }

        public List<VO.Pecas> listar()
        {
            try
            {
                string sql = "SELECT * FROM pecas;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Pecas>();

                    while (dr.Read())
                    {
                        vo = LoadPecas(dr);
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

