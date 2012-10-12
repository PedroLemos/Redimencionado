using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trabalho1
{
    public partial class Form1 : Form
    {
        public LinkedList<Filme> Filmes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filmes = new LinkedList<Filme>();
        }

        //Verifica se o filmes ja existe
        private Filme Existente(string Nome)
        {
            foreach (Filme p in Filmes)
                if (p.Nome == Nome)
                    return p;
            return null;
        }

        //Faz a remoção
        private void Remover()
        {
            if (listViewDados.SelectedItems.Count == 0)
                return;

            ListViewItem item = listViewDados.SelectedItems[0];
            Filme p = Existente(item.Text);
            if (p != null)
                Filmes.Remove(p);
            listViewDados.Items.Remove(item);
        }

        private void Limpar()
        {
            textBoxCadFilme.Text = "";
            comboBoxCadGenero.SelectedIndex = -1;
            textBoxCadLocal.Text = "";
            dateTimePickerCadData.Value = DateTime.Now;
        }

        private void TirarLabel()
        {
            labelCadData.Visible = false;
            labelCadGenero.Visible = false;
            labelCadLocal.Visible = false;
            labelCadNome.Visible = false;
        }

        private void Editar()
        {
            buttonCancelar.Visible = true;
            buttonSalvar.Visible = true;
            buttonEditar.Visible = false;
            buttonRemover.Visible = false;
            buttonCadCadastrar.Visible = false;

            //Carrega os itens nos campos
            if (listViewDados.SelectedItems.Count != 0)
            {
                textBoxCadFilme.Text = listViewDados.SelectedItems[0].SubItems[0].Text;
                comboBoxCadGenero.Text = listViewDados.SelectedItems[0].SubItems[1].Text;
                textBoxCadLocal.Text = listViewDados.SelectedItems[0].SubItems[2].Text;
                dateTimePickerCadData.Text = listViewDados.SelectedItems[0].SubItems[3].Text;
            }
        }


        private void checkBoxBuscaNome_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBuscaNome.Enabled = checkBoxBuscaNome.Checked;
        }

        private void checkBoxBuscaGenero_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBuscaGenero.Enabled = checkBoxBuscaGenero.Checked;
        }

        private void checkBoxBuscaLocal_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBuscaLocal.Enabled = checkBoxBuscaLocal.Checked;
        }

        private void checkBoxBuscaData_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerBuscaData1.Enabled = checkBoxBuscaData.Checked;
            dateTimePickerBuscaData2.Enabled = checkBoxBuscaData.Checked;
        }

        private void buttonCadCadastrar_Click(object sender, EventArgs e)
        {
            if (textBoxCadFilme.Text.Trim() == "")
            {
                labelCadLocal.Visible = false;
                labelCadGenero.Visible = false;
                labelCadNome.Text = "*Campo Nome invalido.";
                labelCadNome.Visible = true;
                textBoxCadFilme.Focus();
            }

            else if (comboBoxCadGenero.SelectedIndex == -1)
            {
                labelCadNome.Visible = false;
                labelCadLocal.Visible = false;
                labelCadGenero.Text = "Genero não selecionado.";
                labelCadGenero.Visible = true;
                comboBoxCadGenero.Focus();
            }

            else if (textBoxCadLocal.Text.Trim() == "")
            {
                labelCadNome.Visible = false;
                labelCadGenero.Visible = false;
                labelCadLocal.Text = "*Campo local invalido.";
                labelCadLocal.Visible = true;
                textBoxCadLocal.Focus();
            }

            else
            {
                ListViewItem item = new ListViewItem();

                item = new ListViewItem(textBoxCadFilme.Text);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();

                subitem = new ListViewItem.ListViewSubItem(item, comboBoxCadGenero.SelectedItem.ToString());
                item.SubItems.Add(subitem);

                subitem = new ListViewItem.ListViewSubItem(item, textBoxCadLocal.Text);
                item.SubItems.Add(subitem);

                subitem = new ListViewItem.ListViewSubItem(item, dateTimePickerCadData.Text);
                item.SubItems.Add(subitem);

                listViewDados.Items.Add(item);
                Limpar();
                TirarLabel();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxCadFilme.Text.Trim() == "")
            {
                labelCadLocal.Visible = false;
                labelCadGenero.Visible = false;
                labelCadNome.Text = "*Campo Nome invalido.";
                labelCadNome.Visible = true;
                textBoxCadFilme.Focus();
            }

            else if (comboBoxCadGenero.SelectedIndex == -1)
            {
                labelCadNome.Visible = false;
                labelCadLocal.Visible = false;
                labelCadGenero.Text = "Genero não selecionado.";
                labelCadGenero.Visible = true;
                comboBoxCadGenero.Focus();
            }

            else if (textBoxCadLocal.Text.Trim() == "")
            {
                labelCadNome.Visible = false;
                labelCadGenero.Visible = false;
                labelCadLocal.Text = "*Campo local invalido.";
                labelCadLocal.Visible = true;
                textBoxCadLocal.Focus();
            }

            else
            {
                listViewDados.SelectedItems[0].SubItems[0].Text = textBoxCadFilme.Text;
                listViewDados.SelectedItems[0].SubItems[1].Text = comboBoxCadGenero.Text;
                listViewDados.SelectedItems[0].SubItems[2].Text = textBoxCadLocal.Text;
                listViewDados.SelectedItems[0].SubItems[3].Text = dateTimePickerCadData.Text;
            }
            buttonCancelar.Visible = false;
            buttonSalvar.Visible = false;
            buttonEditar.Visible = true;
            buttonRemover.Visible = true;
            buttonCadCadastrar.Visible = true;
            Limpar();
            TirarLabel();
        }


        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desejar realmente excluir esse cadastro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                Remover();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            TirarLabel();
            Editar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            buttonCancelar.Visible = false;
            buttonSalvar.Visible = false;
            buttonEditar.Visible = true;
            buttonRemover.Visible = true;
            buttonCadCadastrar.Visible = true;
            Limpar();
            TirarLabel();
        }

        private void listViewDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDados.SelectedIndices != null)
            {
                buttonEditar.Enabled = true;
            }
            else
                buttonEditar.Enabled = false;
        }
    }
}
