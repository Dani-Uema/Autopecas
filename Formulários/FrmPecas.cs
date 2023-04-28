using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Avaliação1 
{
    public partial class FrmPecas : Form
    {
        private VO.Pecas pecas;
        private List<VO.Pecas> lista;
        private BE.PecasBE be;
        public FrmPecas()
        {
            pecas = new VO.Pecas();
            lista = new List<VO.Pecas>();
            InitializeComponent();
            liberarEdicao(false);
            carregar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                pecas = new VO.Pecas();
                interfaceToObject();
                be = new BE.PecasBE(this.pecas);
                be.incluir();                
                lista.Add(pecas);
                Limpar();
                carregar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }
        private void Limpar()
        {
            txtid.Text = "";
            txtcodigo.Text = "";
            txtdescricao.Text = "";
            txtcodigodebarras.Text = "";
        }
        private void interfaceToObject()
        {
            pecas.id = int.Parse(txtid.Text);
            pecas.codigo = int.Parse(txtcodigo.Text);
            pecas.codbarras = txtcodigodebarras.Text;
            pecas.descricao = txtdescricao.Text;
        }
        private void carregar()
        {
            lstpeças.DataSource = null;
            lstpeças.DataSource = lista;
            lstpeças.ValueMember = "id";
            lstpeças.DisplayMember = "codigo";
            lstpeças.Refresh();
        }
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            pecas = ((VO.Pecas)lstpeças.Items[lstpeças.SelectedIndex]);
            txtid.Text = pecas.codigo.ToString();
            txtcodigo.Text = pecas.codigo.ToString();
            txtdescricao.Text = pecas.descricao.ToString();
            txtcodigodebarras.Text = pecas.codbarras.ToString();
            liberarEdicao(true);
        }
        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btnEditar.Enabled = habilita;
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            liberarEdicao(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            interfaceToObject();
            carregar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
                lista.RemoveAt(lstpeças.SelectedIndex);
                carregar();
        }

        private void btnSelecionar_Click_1(object sender, EventArgs e)
        {
            pecas = ((VO.Pecas)lstpeças.Items[lstpeças.SelectedIndex]);
            txtid.Text = pecas.codigo.ToString();
            txtcodigo.Text = pecas.codigo.ToString();
            txtdescricao.Text = pecas.descricao.ToString();
            txtcodigodebarras.Text = pecas.codbarras.ToString();
            liberarEdicao(true);
        }
    }
}
