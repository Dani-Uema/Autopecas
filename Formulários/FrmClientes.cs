using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Avaliação1
{
    public partial class FrmClientes : Form
    {
        private VO.Clientes clientes;
        private List<VO.Clientes> lista;
        private BE.ClientesBE be;
        public FrmClientes()
        {
            clientes = new VO.Clientes();
            lista = new List<VO.Clientes>();
            InitializeComponent();

            liberarEdicao(false);
            carregar();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                clientes = new VO.Clientes();
                interfaceToObject();
                lista.Add(clientes);
                Limpar();
                carregar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }

        private void interfaceToObject()
        {
            clientes.codigo = int.Parse(txtcodigo.Text);
            clientes.nome = txtnome.Text;
            clientes.cpf = txtcpf.Text;
            clientes.endereco = txtendereco.Text;
            clientes.cidade = txtcidade.Text;
            clientes.estado = txtestado.Text;
            clientes.pais = txtpais.Text;
        }

        private void carregar()
        {
            lstclientes.DataSource = null;
            lstclientes.DataSource = lista;
            lstclientes.ValueMember = "codigo";
            lstclientes.DisplayMember = "nome";
            lstclientes.Refresh();
        }
        private void Limpar()
        {
            txtnome.Text = "";
            txtcodigo.Text = "";
            txtcpf.Text = "";
            txtendereco.Text = "";
            txtcidade.Text = "";
            txtestado.Text = "";
            txtpais.Text = "";
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            clientes = ((VO.Clientes)lstclientes.Items[lstclientes.SelectedIndex]);
            txtnome.Text = clientes.nome.ToString();
            txtcodigo.Text = clientes.codigo.ToString();
            txtcpf.Text = clientes.cpf.ToString();
            txtendereco.Text = clientes.endereco.ToString();
            txtcidade.Text = clientes.cidade.ToString();
            txtestado.Text = clientes.estado.ToString();
            txtpais.Text = clientes.pais.ToString();
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
            lista.RemoveAt(lstclientes.SelectedIndex);
            carregar();
        }



    }

}
