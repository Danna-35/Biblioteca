using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biblioteca
{
    public partial class FormCategorias : Form
    {
        // Declaramos la clase Categoria para usar sus métodos
        Categoria cat = new Categoria();

        public FormCategorias()
        {
            InitializeComponent();
        }

        // Se ejecuta al abrir el formulario
        private void FormCategorias_Load(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        // Carga los datos en tu DataGridView
        private void LlenarTabla()
        {
            try
            {
                dataGridView1.DataSource = cat.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        // BOTÓN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            cat.NombreCategoria = textBox2.Text;
            cat.Descripcion = textBox3.Text;

            if (cat.Guardar())
            {
                MessageBox.Show("Guardado con éxito.");
                LlenarTabla();
                LimpiarCampos();
            }
        }

        // BOTÓN EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label1.Text)) return;

            cat.IdCategoria = Convert.ToInt32(textBox1.Text);
            cat.NombreCategoria = textBox2.Text;
            cat.Descripcion = textBox3.Text;

            if (cat.Actualizar())
            {
                MessageBox.Show("Actualizado con éxito.");
                LlenarTabla();
                LimpiarCampos();
            }
        }

        // BOTÓN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            int id = Convert.ToInt32(textBox1.Text);
            if (cat.Eliminar(id))
            {
                MessageBox.Show("Eliminado con éxito.");
                LlenarTabla();
                LimpiarCampos();
            }
        }

        // Al hacer clic en la tabla, pasa los datos a los TextBox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["IdCategoria"].Value.ToString();
                textBox2.Text = row.Cells["NombreCategoria"].Value.ToString();
                textBox3.Text = row.Cells["Descripcion"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        {
            // Validamos que el campo del nombre no esté vacío
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pasamos los datos de los TextBox a las propiedades de la clase Categoria
            cat.NombreCategoria = textBox2.Text;
            cat.Descripcion = textBox3.Text;

            // Ejecutamos el método Guardar de la clase que conecta con SQL Server
            if (cat.Guardar())
            {
                MessageBox.Show("Categoría guardada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarTabla(); // Refresca automáticamente el DataGridView para ver el nuevo registro
                LimpiarCampos(); // Deja los TextBox vacíos para ingresar otra categoría
            }
            else
            {
                MessageBox.Show("Error al guardar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

        private void button3_Click(object sender, EventArgs e)
        {
           
        {
            // 1. Validamos que el txtId no esté vacío (significa que seleccionaste una fila)
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos confirmación al usuario para evitar borrar por error
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta categoría?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // 3. Convertimos el ID del cuadro de texto a número
                int id = Convert.ToInt32(textBox1.Text);

                // 4. Ejecutamos el método Eliminar de la clase Categoria
                if (cat.Eliminar(id))
                {
                    MessageBox.Show("Categoría eliminada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarTabla();    // Refresca la tabla automáticamente
                    LimpiarCampos();  // Limpia los TextBox
                }
                else
                {
                    MessageBox.Show("Error al intentar eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
          
        {
            // 1. Validamos que haya un ID seleccionado
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validamos que el nombre no lo hayan dejado vacío al editar
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El nombre de la categoría no puede quedar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Pasamos los datos a la clase Categoria
            cat.IdCategoria = Convert.ToInt32(textBox1.Text);
            cat.NombreCategoria = textBox2.Text;
            cat.Descripcion = textBox3.Text;

            // 4. Ejecutamos el método Actualizar de la clase
            if (cat.Actualizar())
            {
                MessageBox.Show("Categoría actualizada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarTabla();    // Refresca la lista para ver los cambios
                LimpiarCampos();  // Limpia los TextBox
            }
            else
            {
                MessageBox.Show("Error al actualizar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
}