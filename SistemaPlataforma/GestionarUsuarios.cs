using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace SistemaPlataforma
{
    public partial class GestionarUsuarios : Form
    {

        #region Almacenar Credenciales del Usuario
        public static string idUsuarioSeleccionado = "";
        public static string contraseñaEncriptadaUsuarioSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public GestionarUsuarios()
        {
            InitializeComponent();
            ListarUsuarios();

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

            #region Carga de Roles a DropdownRol

            //Carga de Roles a DrodpDownRol

            dropdownRol.AddItem("Administrador");
            dropdownRol.AddItem("Arbitro");
            dropdownRol.AddItem("Jugador");

            /*SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("Select nombreGrupo from Grupos", SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    dropdownRol.AddItem(registro["nombreGrupo"].ToString());
                }
                SqlCon.Close();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }*/

            #endregion

            #region Carga de Equipos Existentes en el sistema a DropdownEquipo

            dropdownEquipo.AddItem("Sin Equipo");

            SqlConnection SqlCon11 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon11.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando11 = new SqlCommand("Select nombre from equipos", SqlCon11);
                SqlCon11.Open();
                SqlDataReader registro11 = comando11.ExecuteReader();
                while (registro11.Read())
                {
                    dropdownEquipo.AddItem(registro11["nombre"].ToString());
                }
                SqlCon11.Close();
            }
            finally
            {
                if (SqlCon11.State == ConnectionState.Open)
                {
                    SqlCon11.Close();
                }
            }

            #endregion

            ModoNuevo();
        }
        #endregion

        #region Modo Nuevo
        private void ModoNuevo()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnNuevo.Width = 630; //495 || 502
            this.txtNombreUsuario.Text = "Nombre del Usuario..";
            this.txtEmail.Text = "Email..";
            this.txtContraseña.Text = "Contraseña..";
            this.dtpFechaNacimiento.Value = DateTime.Today;
            this.btnEstadoUsuario.Value = true;
            this.pictureBox2.Image = global::SistemaPlataforma.Properties.Resources.equipo;
            dropdownPais.selectedIndex = 0;
            dropdownRol.selectedIndex = 0;
            dropdownEquipo.selectedIndex = 0;
            btnEstadoUsuario.Enabled = false;
            txtContraseña.isPassword = false;
        }
        #endregion

        #region Modo Modificar y Eliminar
        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            #region Configuracion Visibilidad Botones
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            this.btnEstadoUsuario.Enabled = true;
            #endregion

            #region Devolver Imagen y Estado del Usuario
            DevolverImagenUsuario();
            DevolverEstadoUsuario();
            #endregion

            #region Carga el ID del Usuario
            idUsuarioSeleccionado = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);
            #endregion

            #region Carga la Contraseña Encriptada del Usuario
            contraseñaEncriptadaUsuarioSeleccionado = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["contraseña"].Value);
            #endregion

            #region Carga el Nombre del Usuario
            this.txtNombreUsuario.Text = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colNickname"].Value);
            #endregion

            #region Carga el Mail del Usuario
            this.txtEmail.Text = Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colEmail"].Value);
            #endregion

            #region Carga el Pais del Usuario
            this.dropdownPais.selectedIndex = ValidarPaisUsuario(Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colPais"].Value));
            #endregion

            #region Carga el Equipo del Usuario
            int Selected = -1;
            int count = 1000000000;
            for (int i = 0; (i <= (count - 1)); i++)
            {
                dropdownEquipo.selectedIndex = i;
                if ((string)(dropdownEquipo.selectedValue) == Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colEquipos"].Value))
                {
                    Selected = i;
                    break;
                }

            }

            dropdownEquipo.selectedIndex = Selected;
            #endregion

            #region Carga la Fecha de Nacimiento del Usuario
            this.dtpFechaNacimiento.Value = Convert.ToDateTime(this.dgvUsuarios.CurrentRow.Cells["colFechaNacimiento"].Value);
            #endregion

            #region Carga el Rol del Usuario
            this.dropdownRol.selectedIndex = ValidarRolUsuario(Convert.ToString(this.dgvUsuarios.CurrentRow.Cells["colRolUsuario"].Value));
            #endregion

            #region Configuracion de los Paneles
            panelBuscarUsuario.Visible = false;
            panelBuscarUsuario.Left = 698;

            panelGestionarUsuario.Visible = false;
            panelGestionarUsuario.Left = 70;
            panelGestionarUsuario.Visible = true;

            bunifuSeparator1.Left = btnGestionarUsuarios.Left;
            bunifuSeparator1.Width = btnGestionarUsuarios.Width;
            txtContraseña.isPassword = false;
            #endregion

        }
        #endregion

        #region Validar Pais Usuario
        private static int ValidarPaisUsuario(string paisUsuario)
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

        #region Validar Rol Usuario
        private static int ValidarRolUsuario(string rolUsuario)
        {
            int index = 0;

            switch (rolUsuario)
            {
                case "Administrador":
                    index = 0;
                    break;
                case "Arbitro":
                    index = 1;
                    break;
                case "Jugador":
                    index = 2;
                    break;
            }
            return index;
        }
        #endregion

        #region Modificar Estado Usuario
        public int ModificarEstadoUsuario()
        {
            int valorEstadoUsuario = 0;
            if (btnEstadoUsuario.Value == true)
            {
                valorEstadoUsuario = 1;
            }
            else
            {
                valorEstadoUsuario = 0;
            }

            return valorEstadoUsuario;
        }
        #endregion

        #region Devolver Imagen del Usuario
        private void DevolverImagenUsuario()
        {
            byte[] imageLength = (byte[])dgvUsuarios.CurrentRow.Cells["imagenPerfil"].Value;
            if (imageLength.Length > 0) //!DBNull.Value.Equals(dgvUsuarios.CurrentRow.Cells["imagenPerfil"].Value)
            {
                byte[] imageBuffer = (byte[])dgvUsuarios.CurrentRow.Cells["imagenPerfil"].Value;
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);
            }
        }
        #endregion

        #region Devolver Estado del Usuario
        private void DevolverEstadoUsuario()
        {
            int estadoUsuario = (int)(dgvUsuarios.CurrentRow.Cells["estadoUsuario"].Value);
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

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Configuracion Campos Gestionar

        #region Click en el Formulario
        private void GestionarUsuarios_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Click en el TextBox Nombre Usuario
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

        #region Click en el TextBox Contraseña
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña..")
            {
                txtContraseña.Text = "";
                txtContraseña.isPassword = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.isPassword = false;
                txtContraseña.Text = "Contraseña..";
            }
        }
        #endregion

        #endregion

        #region Listar Usuarios
        private void ListarUsuarios()
        {
            this.dgvUsuarios.DataSource = CUsuario.Mostrar();
            this.dgvUsuarios.Columns["idUsuario"].Visible = false;
            this.dgvUsuarios.Columns["contraseña"].Visible = false;
            this.dgvUsuarios.Columns["imagenPerfil"].Visible = false;
            this.dgvUsuarios.Columns["estadoUsuario"].Visible = false;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsuarios.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Buscar Usuario Por Nickname
        private void BuscarUsuarioPorNickname()
        {
            if (String.IsNullOrEmpty(txtBuscarUsuario.Text) || txtBuscarUsuario.Text == "BUSCAR USUARIO...")
            {
                ListarUsuarios();
                this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
            else
            {
                this.dgvUsuarios.DataSource = CUsuario.BuscarUsuarioPorNickname(txtBuscarUsuario.Text);
                this.txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }

        }
        #endregion

        #region Cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Minimizar Formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Desplazar al Panel de Ver Usuarios
        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            if (panelBuscarUsuario.Left == 698)
            {
                panelGestionarUsuario.Visible = false;
                panelGestionarUsuario.Left = 698;

                panelBuscarUsuario.Visible = false;
                panelBuscarUsuario.Left = 15;
                panelBuscarUsuario.Visible = true;


                bunifuSeparator1.Left = btnVerUsuarios.Left;
                bunifuSeparator1.Width = btnVerUsuarios.Width;

                ModoNuevo();
                ListarUsuarios();
            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Usuarios
        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {

            if (panelGestionarUsuario.Left == 698 || panelGestionarUsuario.Left == 856)
            {
                panelBuscarUsuario.Visible = false;
                panelBuscarUsuario.Left = 698;

                panelGestionarUsuario.Visible = false;
                panelGestionarUsuario.Left = 70;
                panelGestionarUsuario.Visible = true;

                bunifuSeparator1.Left = btnGestionarUsuarios.Left;
                bunifuSeparator1.Width = btnGestionarUsuarios.Width;

                txtBuscarUsuario.Text = "BUSCAR USUARIO...";
                ListarUsuarios();
            }
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

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarUsuarioPorNickname();
        }
        #endregion

        #region Limpiar Campo Buscar Usuario al hacer click
        private void txtBuscarUsuario_Enter(object sender, EventArgs e)
        {
            if (txtBuscarUsuario.Text == "BUSCAR USUARIO...")
            {
                txtBuscarUsuario.Text = "";
            }
        }

        private void txtBuscarUsuario_Leave(object sender, EventArgs e)
        {
            if (txtBuscarUsuario.Text == "")
            {
                txtBuscarUsuario.Text = "BUSCAR USUARIO...";
            }
        }
        #endregion

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                rpta = CUsuario.Insertar(this.txtNombreUsuario.Text.Trim(), this.dropdownPais.selectedValue.Trim(), this.dtpFechaNacimiento.Value, this.txtEmail.Text.Trim(), this.dropdownEquipo.selectedValue.Trim(), CUsuario.EncriptarContraseña(this.txtContraseña.Text.Trim()), CRol.InsertarRolUsuario(this.dropdownRol.selectedValue), imagen);


                if (rpta.Equals("OK"))
                {

                    #region Obtener ID de Grupo
                    SqlConnection SqlCon12 = new SqlConnection();

                    var idObtenidoDelGrupo = "";

                    SqlCon12.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando12 = new SqlCommand("Select idGrupo from Grupos where nombreGrupo LIKE '%" + this.dropdownRol.selectedValue + "%'", SqlCon12);
                    SqlCon12.Open();
                    SqlDataReader registro12 = comando12.ExecuteReader();
                    while (registro12.Read())
                    {
                        idObtenidoDelGrupo = registro12["idGrupo"].ToString();
                    }
                    SqlCon12.Close();
                    #endregion

                    #region Insertar Grupo a Usuario
                    SqlConnection SqlCon4 = new SqlConnection();

                    try
                    {
                        var rolSeleccionado = dropdownRol.selectedValue;
                        //Establecemos la conexion, el comando y ejecutamos el mismo
                        SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                        SqlCommand comando4 = new SqlCommand("Insert into Grupos_Usuarios Values ('" + int.Parse(idObtenidoDelGrupo) + "','" + 3 + "')", SqlCon4);
                        SqlCon4.Open();
                        comando4.ExecuteNonQuery();
                        SqlCon4.Close();
                    }
                    finally
                    {
                        if (SqlCon4.State == ConnectionState.Open)
                        {
                            SqlCon4.Close();
                        }
                    }
                    #endregion

                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El usuario ha sido creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarUsuario.Visible = false;
                    panelGestionarUsuario.Left = 698;
                    panelBuscarUsuario.Visible = false;
                    panelBuscarUsuario.Left = 15;
                    panelBuscarUsuario.Visible = true;
                    bunifuSeparator1.Left = btnVerUsuarios.Left;
                    bunifuSeparator1.Width = btnVerUsuarios.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido crear el nuevo usuario correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Boton Subir Imagen
        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox2.Image = Image.FromFile(dialog.FileName);
            }
        }
        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imagen = ms.GetBuffer();
                rpta = CUsuario.Editar(int.Parse(idUsuarioSeleccionado), this.txtNombreUsuario.Text.Trim(), this.dropdownPais.selectedValue.Trim(), this.dtpFechaNacimiento.Value, this.txtEmail.Text.Trim(), this.dropdownEquipo.selectedValue.Trim(), CUsuario.ValidarNuevaContraseña(contraseñaEncriptadaUsuarioSeleccionado, txtContraseña.Text.Trim()), CRol.InsertarRolUsuario(this.dropdownRol.selectedValue), imagen, ModificarEstadoUsuario());

                if (rpta.Equals("OK"))
                {
                    //#region Obtener ID de Grupo
                    //SqlConnection SqlCon12 = new SqlConnection();

                    //var idObtenidoDelGrupo = "";

                    //SqlCon12.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    //SqlCommand comando12 = new SqlCommand("Select idGrupo from Grupos where nombreGrupo LIKE '%" + this.dropdownRol.selectedValue + "%'", SqlCon12);
                    //SqlCon12.Open();
                    //SqlDataReader registro12 = comando12.ExecuteReader();
                    //while (registro12.Read())
                    //{
                    //    idObtenidoDelGrupo = registro12["idGrupo"].ToString();
                    //}
                    //SqlCon12.Close();
                    //#endregion

                    //#region Modificar Grupo a Usuario
                    //SqlConnection SqlCon4 = new SqlConnection();

                    //try
                    //{
                    //    var rolSeleccionado = dropdownRol.selectedValue;
                    //    //Establecemos la conexion, el comando y ejecutamos el mismo
                    //    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                    //    SqlCommand comando4 = new SqlCommand("Insert into Grupos_Usuarios Values ('" + int.Parse(idObtenidoDelGrupo) + "','" + int.Parse(idUsuarioSeleccionado) + "')", SqlCon4);
                    //    SqlCon4.Open();
                    //    comando4.ExecuteNonQuery();
                    //    SqlCon4.Close();
                    //}
                    //finally
                    //{
                    //    if (SqlCon4.State == ConnectionState.Open)
                    //    {
                    //        SqlCon4.Close();
                    //    }
                    //}
                    //#endregion

                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El usuario se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarUsuario.Visible = false;
                    panelGestionarUsuario.Left = 698;
                    panelBuscarUsuario.Visible = false;
                    panelBuscarUsuario.Left = 15;
                    panelBuscarUsuario.Visible = true;
                    bunifuSeparator1.Left = btnVerUsuarios.Left;
                    bunifuSeparator1.Width = btnVerUsuarios.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se han podido salvar los cambios!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el usuario?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CUsuario.Eliminar(Convert.ToInt32(idUsuarioSeleccionado));

                    if (rpta.Equals("OK"))
                    {

                        //#region Obtener ID de Grupo
                        //SqlConnection SqlCon12 = new SqlConnection();

                        //var idObtenidoDelGrupo = "";

                        //SqlCon12.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                        //SqlCommand comando12 = new SqlCommand("Select idGrupo from Grupos where nombreGrupo LIKE '%" + this.dropdownRol.selectedValue + "%'", SqlCon12);
                        //SqlCon12.Open();
                        //SqlDataReader registro12 = comando12.ExecuteReader();
                        //while (registro12.Read())
                        //{
                        //    idObtenidoDelGrupo = registro12["idGrupo"].ToString();
                        //}
                        //SqlCon12.Close();
                        //#endregion

                        //#region Eliminar Grupo y Usuario
                        //SqlConnection SqlCon4 = new SqlConnection();

                        //try
                        //{
                        //    var rolSeleccionado = dropdownRol.selectedValue;
                        //    //Establecemos la conexion, el comando y ejecutamos el mismo
                        //    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                        //    SqlCommand comando4 = new SqlCommand("Delete from Grupos_Usuarios where idGrupo = '" + int.Parse(idObtenidoDelGrupo) + "' and idUsuario = '" + int.Parse(idUsuarioSeleccionado) + "'", SqlCon4);
                        //    SqlCon4.Open();
                        //    comando4.ExecuteNonQuery();
                        //    SqlCon4.Close();
                        //}
                        //finally
                        //{
                        //    if (SqlCon4.State == ConnectionState.Open)
                        //    {
                        //        SqlCon4.Close();
                        //    }
                        //}
                        //#endregion

                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "El usuario ha sido eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarUsuario.Visible = false;
                        panelGestionarUsuario.Left = 698;
                        panelBuscarUsuario.Visible = false;
                        panelBuscarUsuario.Left = 15;
                        panelBuscarUsuario.Visible = true;
                        bunifuSeparator1.Left = btnVerUsuarios.Left;
                        bunifuSeparator1.Width = btnVerUsuarios.Width;
                        ModoNuevo();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar el usuario correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Pantalla Arrastrable
        private void GestionarUsuarios_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

    }
}
