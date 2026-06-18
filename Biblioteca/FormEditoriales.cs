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
    public partial class FormEditoriales : Form
    {
        public FormEditoriales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        {
            // 1. Validamos que el nombre no esté vacío
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El nombre de la editorial es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pasamos los datos a la clase Editorial
            ed.Nombre = textBox1.Text;
            ed.Pais = textBox2.Text;

            // 3. Guardamos en la base de datos
            if (ed.Guardar())
            {
                MessageBox.Show("Editorial guardada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarTabla();    // Refresca el DataGridView
                LimpiarCampos();  // Borra los TextBox
            }
            else
            {
                MessageBox.Show("Error al guardar la editorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
}
