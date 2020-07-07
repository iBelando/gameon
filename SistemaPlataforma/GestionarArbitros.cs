using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Controladora;

namespace SistemaPlataforma
{
    public partial class GestionarArbitros : Form
    {

        #region Almacenar Credenciales del Usuario
        public static string idUsuarioSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public GestionarArbitros()
        {
            InitializeComponent();

            #region Carga la grilla
            ListarArbitros();
            #endregion

            #region Carga de Paises a DropdownPais

            //Carga de Paises a DropDownPais
            dropdownPais.AddItem("Argentina");
            dropdownPais.AddItem("Bolivia");
            dropdownPais.AddItem("Brasil");
            dropdownPais.AddItem("Chile");
            dropdownPais.AddItem("Colombia");
            dropdownPais.AddItem("Ecuador");
            dropdownPais.AddItem("Guyana");
            dropdownPais.AddItem("Paraguay");
            dropdownPais.AddItem("Perú");
            dropdownPais.AddItem("Trinidad y Tobago");
            dropdownPais.AddItem("Surinam");
            dropdownPais.AddItem("Uruguay");
            dropdownPais.AddItem("Venezuela");

            #endregion

            #region Carga del Rol Arbitro al DropdownRol
            dropdownRol.AddItem("Arbitro");
            dropdownRol.selectedIndex = 0;
            #endregion

            #region Configuración Panel de Consultas
            this.btnEstadoUsuario.Enabled = false;
            this.txtNombreUsuario.Enabled = false;
            this.txtEmail.Enabled = false;
            this.dropdownPais.Enabled = false;
            this.dropdownRol.Enabled = false;
            this.dtpFechaNacimiento.Enabled = false;
            #endregion

        }
        #endregion

        #region Boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Boton Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Boton Volver
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            PanelDeAdmin frmPanelGestion = new PanelDeAdmin();
            frmPanelGestion.Show();
            this.Hide();
        }
        #endregion

        #region Pantalla Arrastrable
        private void GestionarArbitros_Load(object sender, EventArgs e)
        {
            this.dgvVerArbitros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerArbitros.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvVerArbitros.RowTemplate.Height = 50;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarArbitros_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarArbitroPorNickname();
        }
        #endregion

        #region Buscar Arbitro Por Nickname
        private void BuscarArbitroPorNickname()
        {
            if (String.IsNullOrEmpty(txtBuscadorArbitro.Text) || txtBuscadorArbitro.Text == "BUSCAR ARBITRO...")
            {
                ListarArbitros();
                this.txtBuscadorArbitro.Text = "BUSCAR ARBITRO...";
            }
            else
            {
                this.dgvVerArbitros.DataSource = CArbitro.BuscarArbitroPorNombre(txtBuscadorArbitro.Text);
                this.txtBuscadorArbitro.Text = "BUSCAR ARBITRO...";
            }
        }
        #endregion

        #region Limpiar Campo Buscar Arbitro
        private void txtBuscadorArbitro_Enter(object sender, EventArgs e)
        {
            if (txtBuscadorArbitro.Text == "BUSCAR ARBITRO...")
            {
                txtBuscadorArbitro.Text = "";
            }
        }

        private void txtBuscadorArbitro_Leave(object sender, EventArgs e)
        {
            if (txtBuscadorArbitro.Text == "")
            {
                txtBuscadorArbitro.Text = "BUSCAR ARBITRO...";
            }
        }
        #endregion

        #region Listar Arbitros
        private void ListarArbitros()
        {
            this.dgvVerArbitros.DataSource = CArbitro.Mostrar();
            this.dgvVerArbitros.Columns["idUsuario"].Visible = false;
            this.dgvVerArbitros.Columns["contraseña"].Visible = false;
            this.dgvVerArbitros.Columns["imagenPerfil"].Visible = false;
            this.dgvVerArbitros.Columns["estadoUsuario"].Visible = false;
            this.dgvVerArbitros.Columns["rolUsuario"].Visible = false;
            this.dgvVerArbitros.Columns["equipos"].Visible = false;
            this.dgvVerArbitros.RowHeadersVisible = false;
            this.dgvVerArbitros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerArbitros.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvVerArbitros.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvVerArbitros.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Configuracion Campos Consultar

        #region Click en el TextBox Nombre de Usuario
        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "Nombre del Usuario..")
            {
                txtNombreUsuario.Text = "";
            }
        }

        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "")
            {
                txtNombreUsuario.Text = "Nombre del Usuario..";
            }
        }
        #endregion

        #region Click en el TextBox Email
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email..")
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email..";
            }
        }
        #endregion

        #endregion

        #region Desplazar al Panel de Consultar Arbitro
        private void btnConsultarArbitro_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(idUsuarioSeleccionado) && int.Parse(idUsuarioSeleccionado) != 0 && idUsuarioSeleccionado != "")
            {
                if (panelConsultarArbitro.Left == 856) //689
                {
                    panelBuscarArbitro.Visible = false;
                    panelBuscarArbitro.Left = 856; //689

                    panelConsultarArbitro.Visible = false;
                    panelConsultarArbitro.Left = 15;
                    panelConsultarArbitro.Visible = true;

                    bunifuSeparator1.Left = btnConsultarArbitro.Left;
                    bunifuSeparator1.Width = btnConsultarArbitro.Width;

                    txtBuscadorArbitro.Text = "BUSCAR ARBITRO...";
                    ListarArbitros();
                }
            }
        }
        #endregion

        #region Desplazar al Panel de Ver Arbitros
        private void btnVerArbitros_Click(object sender, EventArgs e)
        {
            
            if (panelBuscarArbitro.Left == 689) //689
            {
                panelConsultarArbitro.Visible = false;
                panelConsultarArbitro.Left = 689; //689

                panelBuscarArbitro.Visible = false;
                panelBuscarArbitro.Left = 15; //15
                panelBuscarArbitro.Visible = true;


                bunifuSeparator1.Left = btnVerArbitros.Left;
                bunifuSeparator1.Width = btnVerArbitros.Width;

                //ModoNuevo();
                ListarArbitros();

                #region Vaciar Variables que almacenan contenido del usuario
                idUsuarioSeleccionado = "";
                #endregion

            }
        }
        #endregion

        #region Devolver Estado del Arbitro
        private void DevolverEstadoArbitro()
        {
            int estadoUsuario = (int)(dgvVerArbitros.CurrentRow.Cells["estadoUsuario"].Value);
            if (estadoUsuario == 1)
            {
                this.btnEstadoUsuario.Value = true;
                this.btnEstadoUsuario.Enabled = false;
            }
            else
            {
                this.btnEstadoUsuario.Value = false;
                this.btnEstadoUsuario.Enabled = true;
            }
        }
        #endregion

        #region Devolver Imagen del Arbitro
        private void DevolverImagenArbitro()
        {
            byte[] imageLength = (byte[])dgvVerArbitros.CurrentRow.Cells["imagenPerfil"].Value;

            if (imageLength.Length > 0)
            {
                byte[] imageBuffer = (byte[])dgvVerArbitros.CurrentRow.Cells["imagenPerfil"].Value;
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
            }
        }
        #endregion

        #region Validar Pais Arbitro
        private static int ValidarPaisArbitro(string paisUsuario)
        {
            int index = 0;

            switch (paisUsuario)
            {
                case "Argentina":
                    index = 0;
                    break;
                case "Bolivia":
                    index = 1;
                    break;
                case "Brasil":
                    index = 2;
                    break;
                case "Chile":
                    index = 3;
                    break;
                case "Colombia":
                    index = 4;
                    break;
                case "Ecuador":
                    index = 5;
                    break;
                case "Guyana":
                    index = 6;
                    break;
                case "Paraguay":
                    index = 7;
                    break;
                case "Perú":
                    index = 8;
                    break;
                case "Trinidad y Tobago":
                    index = 9;
                    break;
                case "Surinam":
                    index = 10;
                    break;
                case "Uruguay":
                    index = 11;
                    break;
                case "Venezuela":
                    index = 12;
                    break;
            }
            return index;
        }
        #endregion

        #region Seleccionar Arbitro
        private void dgvVerArbitros_DoubleClick(object sender, EventArgs e)
        {
            if (dgvVerArbitros.Rows.Count != 0)
            {
                idUsuarioSeleccionado = Convert.ToString(this.dgvVerArbitros.CurrentRow.Cells["idUsuario"].Value);
                txtNombreUsuario.Text = Convert.ToString(this.dgvVerArbitros.CurrentRow.Cells["colNickname"].Value);
                txtEmail.Text = Convert.ToString(this.dgvVerArbitros.CurrentRow.Cells["colEmail"].Value);
                this.dropdownPais.selectedIndex = ValidarPaisArbitro(Convert.ToString(this.dgvVerArbitros.CurrentRow.Cells["colPais"].Value));
                DevolverImagenArbitro();
                this.dtpFechaNacimiento.Value = Convert.ToDateTime(this.dgvVerArbitros.CurrentRow.Cells["colFechaNacimiento"].Value);

                panelBuscarArbitro.Visible = false;
                panelBuscarArbitro.Left = 689;

                panelConsultarArbitro.Visible = false;
                panelConsultarArbitro.Left = 15;
                panelConsultarArbitro.Visible = true;
                bunifuSeparator1.Left = btnConsultarArbitro.Left;
                bunifuSeparator1.Width = btnConsultarArbitro.Width;
            }
        }
        #endregion

    }
}
