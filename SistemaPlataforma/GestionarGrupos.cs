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
using System.Data.SqlClient;

namespace SistemaPlataforma
{
    public partial class GestionarGrupos : Form
    {

        #region Almacenar Credenciales del Grupo
        public static string idGrupoSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public GestionarGrupos()
        {
            InitializeComponent();

            ListarGrupos();
            ListarRoles();

            ModoNuevo();
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

        #region Pantalla Arrastrable
        private void GestionarGrupos_Load(object sender, EventArgs e)
        {
            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarGrupos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        #region Limpiar Campo Buscar Grupo
        private void txtBuscarGrupo_Enter(object sender, EventArgs e)
        {
            if (txtBuscarGrupo.Text == "BUSCAR GRUPO...")
            {
                txtBuscarGrupo.Text = "";
            }
        }

        private void txtBuscarGrupo_Leave(object sender, EventArgs e)
        {
            if (txtBuscarGrupo.Text == "")
            {
                txtBuscarGrupo.Text = "BUSCAR GRUPO...";
            }
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarGrupoPorNombre();
        }
        #endregion

        #region Buscar Grupo Por Nombre
        private void BuscarGrupoPorNombre()
        {
            if (String.IsNullOrEmpty(txtBuscarGrupo.Text) || txtBuscarGrupo.Text == "BUSCAR GRUPO...")
            {
                ListarGrupos();
                this.txtBuscarGrupo.Text = "BUSCAR GRUPO...";
            }
            else
            {
                this.dgvRoles.DataSource = CRol.BuscarRolPorNombre(txtBuscarGrupo.Text);
                this.txtBuscarGrupo.Text = "BUSCAR GRUPO...";
            }
        }
        #endregion

        #region Listar Grupos
        private void ListarGrupos()
        {
            this.dgvGrupos.DataSource = CGrupo.Mostrar();
            this.dgvGrupos.RowHeadersVisible = false;
            this.dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvGrupos.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvGrupos.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #endregion

        #region Modo Nuevo
        private void ModoNuevo()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnNuevo.Width = 782;
            this.btnNombreDelGrupo.Text = "NOMBRE del GRUPO...";

            foreach (DataGridViewRow row in dgvRoles.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    row.Cells[0].Value = false;
                }
            }

        }

        #endregion

        #region Limpiar Campo Nombre del Grupo
        private void btnNombreDelGrupo_Enter(object sender, EventArgs e)
        {
            if (btnNombreDelGrupo.Text == "NOMBRE del GRUPO...")
            {
                btnNombreDelGrupo.Text = "";
            }
        }

        private void btnNombreDelGrupo_Leave(object sender, EventArgs e)
        {
            if (btnNombreDelGrupo.Text == "")
            {
                btnNombreDelGrupo.Text = "NOMBRE del GRUPO...";
            }
        }
        #endregion

        #region Desplazar al Panel de Ver Grupos
        private void btnVerGrupos_Click(object sender, EventArgs e)
        {
            if (panelBuscarGrupo.Left == 856) //695
            {
                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 856; //695

                panelBuscarGrupo.Visible = false;
                panelBuscarGrupo.Left = 15;
                panelBuscarGrupo.Visible = true;


                bunifuSeparator1.Left = btnVerGrupos.Left;
                bunifuSeparator1.Width = btnVerGrupos.Width;

                #region Resetear Campos Panel Gestionar Roles
                ModoNuevo();
                #endregion

            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Grupos
        private void btnGestionarGrupos_Click(object sender, EventArgs e)
        {
            if (panelGestionarRoles.Left == 856) //695
            {
                panelBuscarGrupo.Visible = false;
                panelBuscarGrupo.Left = 856; //695

                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 15;
                panelGestionarRoles.Visible = true;

                bunifuSeparator1.Left = btnGestionarGrupos.Left;
                bunifuSeparator1.Width = btnGestionarGrupos.Width;
            }
        }


        #endregion

        #region Seleccionar Grupo y Modo Modificar/Eliminar
        private void dgvGrupos_DoubleClick(object sender, EventArgs e)
        {
            #region Configuracion Visibilidad Botones
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            #endregion

            #region Carga el ID del Grupo Seleccionado
            idGrupoSeleccionado = Convert.ToString(this.dgvGrupos.CurrentRow.Cells["colIdGrupo"].Value);
            #endregion

            #region Carga el Nombre del Grupo Seleccionado
            this.btnNombreDelGrupo.Text = Convert.ToString(this.dgvGrupos.CurrentRow.Cells["colNombre"].Value);
            #endregion

            #region Carga los Formularios del Rol Seleccionado

            #region Obtenemos los Roles Habilitados
            List<string> rolesAsociados = new List<string>();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("select Roles.nombreRol from Grupos_Roles inner join Roles on Grupos_Roles.idRol = Roles.idRol where idGrupo = " + idGrupoSeleccionado, SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    rolesAsociados.Add(registro["nombreRol"].ToString());
                }
                SqlCon.Close();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            #endregion

            #region Habilitamos en el dgvRoles los Roles Asociados
            for (int i = 0; i < rolesAsociados.Count; i++)
            {
                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    if (Convert.ToString(row.Cells[2].Value) == rolesAsociados[i].ToString())
                    {
                        row.Cells[0].Value = true;
                    }
                }
            }
            #endregion

            #endregion

            panelBuscarGrupo.Visible = false;
            panelBuscarGrupo.Left = 695;
            panelGestionarRoles.Visible = false;
            panelGestionarRoles.Left = 695;

            panelGestionarRoles.Visible = false;
            panelGestionarRoles.Left = 15;
            panelGestionarRoles.Visible = true;


            bunifuSeparator1.Left = btnGestionarGrupos.Left;
            bunifuSeparator1.Width = btnGestionarGrupos.Width;
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string idGrupoRecienCreado = "";
            string nombreGrupoRecienCreado = this.btnNombreDelGrupo.Text;

            #region Insertar Grupo Nuevo
            try
            {
                string rpta = "";
                rpta = CGrupo.Insertar(this.btnNombreDelGrupo.Text.Trim());

                if (rpta.Equals("OK"))
                {
                    
                }
                else
                {
                    MensajeError(rpta);
                }

                //this.ListarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

            #region Verificar Roles Seleccionados
            List<string> idRoles = new List<string>();
            foreach (DataGridViewRow row in dgvRoles.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colHabilitar"].Value) == true)
                {
                    idRoles.Add(Convert.ToString(row.Cells["idRol"].Value));
                }
            }
            #endregion

            #region Obtener Id Grupo Recien Agregado
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("Select * from Grupos where nombreGrupo = '" + nombreGrupoRecienCreado + "'", SqlCon);
                SqlCon.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    idGrupoRecienCreado = (registro["idGrupo"].ToString());
                }
                SqlCon.Close();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            #endregion

            #region Asociar Grupo con Rol
            try
            {
                string rpta = "";

                for (int i = 0; i < idRoles.Count; i++)
                {
                    rpta = CGrupo.AsociarGrupoConRol(Convert.ToInt32(idGrupoRecienCreado), Convert.ToInt32(idRoles[i].ToString()));

                    if (rpta.Equals("OK"))
                    {
                        
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido asociar el Grupo con el Rol!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }
                }

                MensajeExito msjExito = new MensajeExito();
                msjExito.bunifuCustomLabel3.Text = "Se ha podido crear el grupo exitosamente!";
                msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                msjExito.Show();
                //MessageBox.Show("Se guardó todo!");
                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 695;

                panelBuscarGrupo.Visible = false;
                panelBuscarGrupo.Left = 15;
                panelBuscarGrupo.Visible = true;


                bunifuSeparator1.Left = btnVerGrupos.Left;
                bunifuSeparator1.Width = btnVerGrupos.Width;
                ModoNuevo();
                this.ListarGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

        }

        #endregion

        #region Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            #region Eliminar Grupo de la tabla de Grupos
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el rol?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CGrupo.Eliminar(Convert.ToInt32(idGrupoSeleccionado));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "Se ha eliminado el grupo exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido eliminar el grupo correctamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

            #region Eliminar Roles Asociados al Grupo en la tabla Grupos_Roles
            try
            {
                string rpta = "";
                rpta = CGrupo.EliminarGrupoConRolesAsociados(Convert.ToInt32(idGrupoSeleccionado));
                
                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 695;
                panelBuscarGrupo.Visible = false;
                panelBuscarGrupo.Left = 15;
                panelBuscarGrupo.Visible = true;
                bunifuSeparator1.Left = btnVerGrupos.Left;
                bunifuSeparator1.Width = btnVerGrupos.Width;
                ModoNuevo();
                this.ListarGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

        }
        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            #region Modificar Nombre Grupo
            try
            {
                string rpta = "";
                rpta = CGrupo.Editar(int.Parse(idGrupoSeleccionado), btnNombreDelGrupo.Text.Trim());

                if (rpta.Equals("OK"))
                { 

                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha podido modificar el Nombre del Grupo!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

            #region Verificar Roles Seleccionados
            List<string> idRoles = new List<string>();
            foreach (DataGridViewRow row in dgvRoles.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colHabilitar"].Value) == true)
                {
                    idRoles.Add(Convert.ToString(row.Cells["idRol"].Value));
                }
            }
            #endregion

            #region Asociar Grupo con Rol
            try
            {
                string rpta = "";
                rpta = CGrupo.EliminarGrupoConRolesAsociados(Convert.ToInt32(idGrupoSeleccionado));
                for (int i = 0; i < idRoles.Count; i++)
                {
                    rpta = CGrupo.AsociarGrupoConRol(Convert.ToInt32(idGrupoSeleccionado), Convert.ToInt32(idRoles[i].ToString()));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "Se ha modificado el grupo exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido asociar el Grupo con el Rol!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }
                }
                MessageBox.Show("Se guardó todo!");
                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 695;

                panelBuscarGrupo.Visible = false;
                panelBuscarGrupo.Left = 15;
                panelBuscarGrupo.Visible = true;


                bunifuSeparator1.Left = btnVerGrupos.Left;
                bunifuSeparator1.Width = btnVerGrupos.Width;
                ModoNuevo();
                this.ListarRoles();
                this.ListarGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion
        }
        #endregion

        #region Listar Roles
        private void ListarRoles()
        {
            this.dgvRoles.DataSource = CRol.Mostrar();
            this.dgvRoles.Columns["idRol"].Visible = false;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRoles.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvRoles.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

    }
}
