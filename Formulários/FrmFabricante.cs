using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Avaliação1
{
    public partial class FrmFabricante : Form
    {
        private VO.Fabricante fab;
        private BE.FabricanteBE be;
        private List<VO.Fabricante> lista;
        public FrmFabricante()
        {
            fab = new VO.Fabricante();
            lista = new List<VO.Fabricante>();
            InitializeComponent();
            liberarEdicao(false);
            carregar();
        }
        private void interfaceToObject()
        {
            fab.codigo = int.Parse(txtcodigo.Text);
            fab.nome = txtnome.Text;
            fab.descricao = txtdescricao.Text;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                fab = new VO.Fabricante();
                interfaceToObject();
                be = new BE.FabricanteBE(this.fab);
                be.incluir();
                lista.Add(fab);
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
            txtcodigo.Text = "";
            txtdescricao.Text = "";
            txtnome.Text = "";
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            liberarEdicao(false);
        }
        private void carregar()
        {
            lstfabricantes.DataSource = null;
            lstfabricantes.DataSource = lista;
            lstfabricantes.ValueMember = "codigo";
            lstfabricantes.DisplayMember = "nome";
            lstfabricantes.Refresh();

        }
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            fab = ((VO.Fabricante)lstfabricantes.Items[lstfabricantes.SelectedIndex]);
            txtcodigo.Text = fab.codigo.ToString();
            txtnome.Text = fab.nome.ToString();
            txtdescricao.Text = fab.descricao.ToString();
            liberarEdicao(true);
        }

        private void lstfabricantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            interfaceToObject();
            carregar();
        }
        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btnEditar.Enabled = habilita;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            lista.RemoveAt(lstfabricantes.SelectedIndex);
            carregar();
        }
    }
}
