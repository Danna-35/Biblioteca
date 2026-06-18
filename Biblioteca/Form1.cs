using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        {
            // Validación de datos vacíos
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }

            Conexión cn = new Conexión(); // Ya lee la clase porque está creada en tu Solution Explorer
            using (SqlConnection connection = cn.LeerConexion())
            {
                string query = "SELECT COUNT(1) FROM Login WHERE Usuario=@usr AND Clave=@pass";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@usr", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                    {
                        // 1. Ocultas el formulario de Login actual
                        this.Hide();

                        // 2. Creas una instancia del nuevo formulario (asegúrate de haber creado ya MenuPrincipal)
                        this.Hide();

                        // 2. Creas una instancia de Form2 (que es tu menú)
                        Form2 menu = new Form2();

                        // 3. Lo muestras en pantalla
                        menu.Show();
                    }
                    else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
        }
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
