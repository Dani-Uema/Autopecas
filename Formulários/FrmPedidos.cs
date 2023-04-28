using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Avaliação1
{
    public partial class FrmPedidos : Form
    {
        private VO.Pedidos pedidos;
        private List<VO.Pedidos> lista;
        public FrmPedidos()
        {
            pedidos = new VO.Pedidos();
            lista = new List<VO.Pedidos>();
            InitializeComponent();
            liberarEdicao(false);
            carregar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                pedidos = new VO.Pedidos();
                interfaceToObject();
                lista.Add(pedidos);
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
            txtcodvenda.Text = "";
            txtcodcliente.Text = "";
            txtcodigo.Text = "";        
        }

        private void interfaceToObject()
        {
            pedidos.codvenda = int.Parse(txtcodvenda.Text);
            pedidos.codcliente = int.Parse(txtcodcliente.Text);
            pedidos.codigo = int.Parse(txtcodigo.Text);
        }
        private void carregar()
        {
            lstpedidos.DataSource = null;
            lstpedidos.DataSource = lista;
            lstpedidos.ValueMember = "codvenda";
            lstpedidos.DisplayMember = "codigo";
            lstpedidos.Refresh();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            pedidos = ((VO.Pedidos)lstpedidos.Items[lstpedidos.SelectedIndex]);
            txtcodvenda.Text = pedidos.codvenda.ToString();
            txtcodcliente.Text = pedidos.codcliente.ToString();
            txtcodigo.Text = pedidos.codigo.ToString();
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
            lista.RemoveAt(lstpedidos.SelectedIndex);
            carregar();
        }
    }
}
