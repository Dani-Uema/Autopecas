using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Avaliação1.DAO.DataAccess;
using MySql.Data.MySqlClient;

namespace Avaliação1.DAO
{
    public class PedidosDAO : BaseDAO
    {
            private VO.Pedidos vo;
            public PedidosDAO(VO.Pedidos vo)
            {
                if (DAO.listaPedidos == null)
                {
                    DAO.listaPedidos = new List<VO.Pedidos>();
                }
                this.vo = vo;
            }

            public void incluir()
            {
                try
                {
                    string sql = "insert into pedidos (CODVENDA,CODCLIENTE,CODPECA,DATAPEDIDO) " +
                        "values (@codvenda,@cliente,@pecas,@data)";
                    db.AddParameter("@codvenda", vo.codvenda, ParameterDirection.Input);
                    db.AddParameter("@cliente", vo.codcliente.codigo, ParameterDirection.Input);
                    db.AddParameter("@pecas", vo.codigo.id, ParameterDirection.Input);
                    db.AddParameter("@data", vo.data, ParameterDirection.Input);
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
                    string sql = "update pedidos set " +
                        "CODVENDA = @codvenda," +
                        "CODCLIENTE = @cliente, " +
                        "CODPECA = @pecas, " +
                        "DATAPEDIDO = @data " +
                        "where CODVENDA = @codvenda";
                    db.AddParameter("@codvenda", vo.codvenda, ParameterDirection.Input);
                    db.AddParameter("@cliente", vo.codcliente.codigo, ParameterDirection.Input);
                    db.AddParameter("@pecas", vo.codigo.id, ParameterDirection.Input);
                    db.AddParameter("@data", vo.data, ParameterDirection.Input);
                    db.Execute(sql, CommandType.Text);

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro no Código : " + ex.Message);
                }
            }
            public void remover(int cod)
            {
                try
                {
                    string sql = $"delete from pedidos where codvenda = @codvenda";
                    db.AddParameter("@codvenda", vo.codvenda, ParameterDirection.Input);
                    db.Execute(sql, CommandType.Text);

            }
                catch (Exception ex)
                {
                    throw new Exception("Erro no Código : " + ex.Message);
                }
            }

            public VO.Pedidos carregar(int cod)
            {
                string sql = $"SELECT codvenda,codcliente, codpeca, datapedido from pedidos where codvenda=@codvenda";
                db.AddParameter("@codvenda", cod, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
                try
                {
                    using (var dr = db.ExecuteReader(sql, CommandType.Text))
                    {
                        while (dr.Read())
                        {
                            vo = LoadPedidos(dr);
                        }
                        return vo;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro no Código : " + ex.Message);
                }
            }

            private VO.Pedidos LoadPedidos(DbDataReader dr)
            {
                vo = new VO.Pedidos();
                vo.codvenda=Convert.ToInt32(dr["codvenda"]);
                vo.data = Convert.ToDateTime(dr["datapedido"]); 
                vo.codcliente = new VO.Clientes();
                vo.codcliente.codigo = dr["codcliente"] != DBNull.Value ? int.Parse(dr["codcliente"].ToString()) : 0;
                vo.codigo = new VO.Pecas();
                vo.codigo.id = dr["codpeca"] != DBNull.Value ? int.Parse(dr["codpeca"].ToString()) : 0;
                return vo;
            }

            public List<VO.Pedidos> listar()
            {
                try
                {
                    string sql = "SELECT * FROM pedidos;";
                    using (var dr = db.ExecuteReader(sql, CommandType.Text))
                    {
                        var objResultado = new List<VO.Pedidos>();

                        while (dr.Read())
                        {
                            vo = LoadPedidos(dr);
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

