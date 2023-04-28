using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Avaliação1.Formulários
{
    public partial class FrmVeiculo : Form
    {
        private VO.Veiculos vo;
        private List<VO.Veiculos> lista;
        private BE.VeiculoBE be;
        public FrmVeiculo()
        {
            InitializeComponent();
            InicializarVeiculos();
            liberarEdicao(false);
            carregar();
            carregarFabricante();
           
        }
        private void carregarFabricante()
        {
            BE.FabricanteBE fabricante = new BE.FabricanteBE(new VO.Fabricante());
            cmbFabricante.DataSource = null;
            cmbFabricante.DataSource = fabricante.listar();
            cmbFabricante.ValueMember = "codigo";
            cmbFabricante.DisplayMember = "nome";
            cmbFabricante.Refresh();
        }

        private void InicializarVeiculos()
        {
            vo = new VO.Veiculos();
        }

        private void interfaceToObject()
        {
            vo.ano = int.Parse(txtAno.Text);
            vo.codigo = int.Parse(txtCodigo.Text);
            vo.modelo = txtModelo.Text;
            vo.potencia = txtPotencia.Text;
            vo.fabricante = new VO.Fabricante();
            vo.fabricante = (VO.Fabricante) cmbFabricante.SelectedItem;
            //vo.fabricante = cmbFabricante.SelectedItem.ToString();

        }
        private void objecttoInterface()
        {
            txtAno.Text = vo.ano.ToString();
            txtCodigo.Text = vo.codigo.ToString();
            txtModelo.Text = vo.modelo.ToString();
            txtPotencia.Text = vo.potencia.ToString();
            int index = 0;
            foreach (VO.Fabricante item in cmbFabricante.Items)
            {
                if (item.codigo.Equals(vo.fabricante.codigo))
                {
                    cmbFabricante.SelectedIndex = index;
                    return;
                }
                index++;    

            }
            //cmbFabricante.SelectedItem = vo.fabricante.ToString();
        }
        private void Limpar()
        {
            txtAno.Text = "";
            txtCodigo.Text = "";
            txtModelo.Text = "";
            txtPotencia.Text = "";
            cmbFabricante.SelectedIndex = -1;
        }
        private void carregar()
        {
            be = new BE.VeiculoBE(vo);
            lstveiculos.DataSource = null;
            lstveiculos.DataSource = be.listar();
            lstveiculos.SelectedIndex = -1;
            lstveiculos.ValueMember = "codigo";
            lstveiculos.DisplayMember = "modelo";
            lstveiculos.Refresh();

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            liberarEdicao(false);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            be = new BE.VeiculoBE(this.vo);
            vo = be.carregar(int.Parse(lstveiculos.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }

        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btnEditar.Enabled = habilita;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            interfaceToObject();
            be = new BE.VeiculoBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            be = new BE.VeiculoBE(this.vo);
            be.remover(lstveiculos.SelectedIndex);
            carregar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                vo = new VO.Veiculos();
                interfaceToObject();
                be = new BE.VeiculoBE(this.vo);
                be.incluir();
                carregar();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }
    }
}
