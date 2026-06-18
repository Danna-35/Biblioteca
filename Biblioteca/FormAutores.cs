using System;
using System.Windows.Forms;

using System;
using System.Data;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class FormAutores : Form
    {
        // 1. Declaramos la clase Autor globalmente para el formulario
        Autor aut = new Autor();

        public FormAutores()
        {
            InitializeComponent();
        }

        // Se ejecuta al cargar el formulario
        private void FormAutores_Load(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        // Función para cargar los datos en el DataGridView
        private void LlenarTabla()
        {
            try
            {
                // Revisa si tu tabla se llama dataGridView1 o dgvAutores en el diseño
                dataGridView1.DataSource = aut.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los autores: " + ex.Message);
            }
        }

        // Función para limpiar los cuadros de texto
        private void LimpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        // BOTÓN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El nombre del autor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            aut.Nombre = textBox2.Text;
            aut.Nacionalidad = textBox3.Text;

            if (aut.Guardar())
            {
                MessageBox.Show("Autor guardado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarTabla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        {
            // 1. Validamos que el txtId tenga un número (es decir, que se seleccionó un autor)
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, seleccione un autor de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos confirmación antes de borrar
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este autor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                    // 3. Convertimos el ID del cuadro de texto a entero
                    int id = Convert.ToInt32(textBox1.Text);

                    // 4. Llamamos al método usando el objeto "aut"
                    if (aut.Eliminar(id))
                    {
                    MessageBox.Show("Autor eliminado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarTabla();    // Refresca la lista en pantalla
                    LimpiarCampos();  // Limpia los TextBox
                }
                else
                {
                    MessageBox.Show("Error al intentar eliminar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            
        {
            // 1. Validamos que se haya seleccionado un registro de la tabla (revisando el ID)
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, seleccione un autor de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validamos que no dejen el nombre vacío
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El nombre del autor no puede quedar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Pasamos los datos de los TextBox a las propiedades del objeto "aut"
            aut.IdAutor = Convert.ToInt32(textBox1.Text);
            aut.Nombre = textBox2.Text;
            aut.Nacionalidad = textBox3.Text;

            // 4. Ejecutamos el método Actualizar
            if (aut.Actualizar())
            {
                MessageBox.Show("Autor actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarTabla();    // Refresca el DataGridView
                LimpiarCampos();  // Vacía los cuadros de texto
            }
            else
            {
                MessageBox.Show("Error al actualizar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
}