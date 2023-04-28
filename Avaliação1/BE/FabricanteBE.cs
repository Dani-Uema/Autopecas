using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliação1.BE
{
    public class FabricanteBE : BaseBE
    {
        private VO.Fabricante vo;
        private DAO.FabricanteDAO dao;

        public FabricanteBE(VO.Fabricante vo)
        {
            this.vo = vo;
        }

        public void incluir()
        {
            if (string.IsNullOrEmpty(this.vo.nome))
            {
                throw new Exception("Nome obrigatorio");
            }

            dao = new DAO.FabricanteDAO(this.vo);
            dao.incluir();
        }
        public void alterar()
        {
            dao = new DAO.FabricanteDAO(this.vo);
            dao.alterar();
        }
        public VO.Fabricante carregar(int id)
        {
            dao = new DAO.FabricanteDAO(this.vo);
            return dao.carregar(id);
        }
        public void remover(int id)
        {
            dao = new DAO.FabricanteDAO(this.vo);
            dao.remover(id);
        }

        public List<VO.Fabricante> listar()
        {
            dao = new DAO.FabricanteDAO(this.vo);
            return dao.listar();
        }
    }
}


    