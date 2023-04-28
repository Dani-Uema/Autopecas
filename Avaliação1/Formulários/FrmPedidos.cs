using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Avaliação1
{
    public partial class FrmPedidos : Form
    {
        private BE.PedidosBE be;
        private VO.Pedidos pedidos;
        private List<VO.Pedidos> lista;
        public FrmPedidos()
        {
            pedidos = new VO.Pedidos();
            lista = new List<VO.Pedidos>();
            InitializeComponent();
            liberarEdicao(false);
            carregar();
            carregarCliente();
            carregarPecas();
        }
        private void carregarCliente()
        {
            BE.ClientesBE clientes = new BE.ClientesBE(new VO.Clientes());
            cmbcliente.DataSource = null;
            cmbcliente.DataSource = clientes.listar();
            cmbcliente.ValueMember = "codigo";
            cmbcliente.DisplayMember = "nome";
            cmbcliente.Refresh();
        }
        private void carregarPecas()
        {
            BE.PecasBE pecas = new BE.PecasBE(new VO.Pecas());
            cmbpeca.DataSource = null;
            cmbpeca.DataSource = pecas.listar();
            cmbpeca.ValueMember = "codigo";
            cmbpeca.DisplayMember = "descricao";
            cmbpeca.Refresh();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                pedidos = new VO.Pedidos();
                interfaceToObject();
                be = new BE.PedidosBE(this.pedidos);
                be.incluir();
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
            cmbcliente.SelectedIndex = -1;
            cmbpeca.SelectedIndex = -1;
            txtdata.Text = "";
        }

        private void interfaceToObject()
        {
            pedidos.codcliente = new VO.Clientes();
            pedidos.codcliente = (VO.Clientes)cmbcliente.SelectedItem;
            pedidos.codigo = new VO.Pecas();
            pedidos.codigo = (VO.Pecas)cmbpeca.SelectedItem;
            pedidos.codvenda = int.Parse(txtcodvenda.Text);
            pedidos.data = DateTime.Parse(txtdata.Text);
        }
        private void carregar()
        {
            be = new BE.PedidosBE(pedidos);
            lstpedidos.DataSource = null;
            lstpedidos.DataSource = be.listar();
            lstpedidos.ValueMember = "codvenda";
            lstpedidos.DisplayMember = "codvenda";
            lstpedidos.Refresh();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            be = new BE.PedidosBE(this.pedidos);
            pedidos = be.carregar(int.Parse(lstpedidos.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }
        private void objecttoInterface()
        {
            txtcodvenda.Text = pedidos.codvenda.ToString();
            txtdata.Text = pedidos.data.ToString("dd/MM/yyyy");
            int index = 0;
            foreach (VO.Clientes item in cmbcliente.Items)
            {
                if (item.codigo.Equals(pedidos.codcliente.codigo))
                {
                    cmbcliente.SelectedIndex = index;
                    break;
                }
                index++;    

            }
            int index1 = 0;
            foreach (VO.Pecas item in cmbpeca.Items)
            {
                if (item.id.Equals(pedidos.codigo.id))
                {
                    cmbpeca.SelectedIndex = index1;
                    break;
                }
                index1++;
            }
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
            try
            {
                pedidos = new VO.Pedidos();
                interfaceToObject();
                be = new BE.PedidosBE(this.pedidos);
                be.alterar();
                carregar();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            be = new BE.PedidosBE(this.pedidos);
            pedidos = (VO.Pedidos)lstpedidos.SelectedItem;
            be.remover(pedidos.codvenda);
            carregar();
        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
