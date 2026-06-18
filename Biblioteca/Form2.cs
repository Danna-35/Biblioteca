using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void gestiónDeCaategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategorias frmCat = new FormCategorias();
            frmCat.ShowDialog(); // ShowDialog hace que se abra encima del menú de forma correcta
        }

        private void gestiónDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAutores frmAut = new FormAutores();
            frmAut.ShowDialog();
        }

        private void gestiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditoriales frmEdi = new FormEditoriales();
            frmEdi.ShowDialog();
        }
    }
}
