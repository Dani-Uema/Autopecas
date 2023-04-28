using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Avaliação1.DAO.DataAccess;
using MySql.Data.MySqlClient;

namespace Avaliação1.DAO
{
    public class FabricanteDAO : BaseDAO
    {
        private VO.Fabricante vo;
        public FabricanteDAO(VO.Fabricante vo)
        {
            if (DAO.listaFabricante == null)
            {
                DAO.listaFabricante = new List<VO.Fabricante>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into fabricante (ID,NOME,DESCRICAO) " +
                    "values (@cod,@nome,@desc)";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@desc", vo.descricao, ParameterDirection.Input);

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
                string sql = "update fabricante set " +
                    "NOME = @nome," +
                    "DESCRICAO = @desc " +
                    "where ID = @cod";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@desc", vo.descricao, ParameterDirection.Input);
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
                string sql = $"delete from fabricante where ID = @cod";
                db.AddParameter("@cod", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Fabricante carregar(int id)
        {
            string sql = $"SELECT ID,nome,descricao from fabricante where  ID=@cod";
            db.AddParameter("@cod", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadFabricante(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Fabricante LoadFabricante(DbDataReader dr)
        {
            vo = new VO.Fabricante();
            vo.codigo = Convert.ToInt32(dr["ID"]);
            vo.nome = dr["nome"] != DBNull.Value ? dr["nome"].ToString() : "";
            vo.descricao = dr["descricao"] != DBNull.Value ? dr["descricao"].ToString() : "";
            return vo;
        }

        public List<VO.Fabricante> listar()
        {
            try
            {
                string sql = "SELECT * FROM fabricante;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Fabricante>();

                    while (dr.Read())
                    {
                        vo = LoadFabricante(dr);
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

