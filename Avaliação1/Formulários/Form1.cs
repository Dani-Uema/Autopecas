using Avaliação1.Formulários;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avaliação1
{
    public partial class Frm1 : Form
    {
        public Frm1()
        {
            InitializeComponent();
        }

        private void formulárioFilhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFabricante fabricante = new FrmFabricante();
            fabricante.MdiParent = this;
            fabricante.Show();
        }

        private void peçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPecas pecas = new FrmPecas();
            pecas.MdiParent = this;
            pecas.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes clientes = new FrmClientes();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedidos pedidos = new FrmPedidos();
            pedidos.MdiParent = this;
            pedidos.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVeiculo veiculos = new FrmVeiculo();
            veiculos.MdiParent = this;
            veiculos.Show();

        }


    }
}
