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
    public partial class GestionarRoles : Form
    {

        #region Almacenar Credenciales del Rol
        public static string idRolSeleccionado = "";
        #endregion

        #region Inicializar Componentes
        public GestionarRoles()
        {
            InitializeComponent();

            #region Carga la Grilla
            ListarRoles();
            #endregion

            ObtenerListaFormularios();
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

        #region Desplazar al Panel de Ver Roles
        private void btnVerRoles_Click(object sender, EventArgs e)
        {
            if (panelBuscarRol.Left == 856) //700
            {
                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 856; //700

                panelBuscarRol.Visible = false;
                panelBuscarRol.Left = 15;
                panelBuscarRol.Visible = true;


                bunifuSeparator1.Left = btnVerRoles.Left;
                bunifuSeparator1.Width = btnVerRoles.Width;

                #region Resetear Campos Panel Gestionar Roles
                ModoNuevo();
                #endregion

            }
        }
        #endregion

        #region Desplazar al Panel de Gestionar Roles
        private void btnGestionarRoles_Click(object sender, EventArgs e)
        {
            if (panelGestionarRoles.Left == 856) //700
            {
                panelBuscarRol.Visible = false;
                panelBuscarRol.Left = 856; //700

                panelGestionarRoles.Visible = false;
                panelGestionarRoles.Left = 15;
                panelGestionarRoles.Visible = true;

                bunifuSeparator1.Left = btnGestionarRoles.Left;
                bunifuSeparator1.Width = btnGestionarRoles.Width;
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

        #region Pantalla Arrastrable
        private void GestionarRoles_Load(object sender, EventArgs e)
        {
            this.dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRoles.RowTemplate.Height = 50;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void GestionarRoles_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Limpiar Campo Buscar Rol
        private void txtBuscarRol_Enter(object sender, EventArgs e)
        {
            if (txtBuscarRol.Text == "BUSCAR ROL...")
            {
                txtBuscarRol.Text = "";
            }
        }

        private void txtBuscarRol_Leave(object sender, EventArgs e)
        {
            if (txtBuscarRol.Text == "")
            {
                txtBuscarRol.Text = "BUSCAR ROL...";
            }
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            BuscarRolPorNombre();
        }
        #endregion

        #region Buscar Rol Por Nombre
        private void BuscarRolPorNombre()
        {
            if (String.IsNullOrEmpty(txtBuscarRol.Text) || txtBuscarRol.Text == "BUSCAR ROL...")
            {
                ListarRoles();
                this.txtBuscarRol.Text = "BUSCAR ROL...";
            }
            else
            {
                this.dgvRoles.DataSource = CRol.BuscarRolPorNombre(txtBuscarRol.Text);
                this.txtBuscarRol.Text = "BUSCAR ROL...";
            }
        }
        #endregion

        #region Listar Roles
        private void ListarRoles()
        {
            this.dgvRoles.DataSource = CRol.Mostrar();
            /*this.dgvRoles.Columns["idUsuario"].Visible = false;
            this.dgvRoles.Columns["contraseña"].Visible = false;
            this.dgvRoles.Columns["imagenPerfil"].Visible = false;
            this.dgvRoles.Columns["estadoUsuario"].Visible = false;
            this.dgvRoles.Columns["rolUsuario"].Visible = false;
            this.dgvRoles.Columns["equipos"].Visible = false;*/
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

        #region Seleccionar Rol y Modo Modificar/Eliminar
        private void dgvRoles_DoubleClick(object sender, EventArgs e)
        {
            #region Configuracion Visibilidad Botones
            this.btnNuevo.Visible = false;
            this.btnModificar.Visible = true;
            this.btnEliminar.Visible = true;
            #endregion

            #region Carga el ID del Rol Seleccionado
            idRolSeleccionado = Convert.ToString(this.dgvRoles.CurrentRow.Cells["colIdRol"].Value);
            #endregion

            #region Carga el Nombre del Rol Seleccionado
            this.txtVerRol.Text = Convert.ToString(this.dgvRoles.CurrentRow.Cells["colNombre"].Value);
            #endregion

            #region Carga los Formularios del Rol Seleccionado
            string tmpString = Convert.ToString(this.dgvRoles.CurrentRow.Cells["colAccede"].Value);
            
            if (tmpString.Contains(","))
            {
                string[] words = tmpString.Split(',');
                for (int o = 0; o < words.Length; ++o)
                {
                    for (int i = 0; i < listBox1.Items.Count; ++i)
                    {
                        string lbString = listBox1.Items[i].ToString();
                        if (lbString.Equals(words[o].Trim()))
                        {
                            listBox1.SelectedIndex = i;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; ++i)
                {
                    string lbString = listBox1.Items[i].ToString();
                    if (lbString.Equals(tmpString))
                    {
                        listBox1.SelectedIndex = i;
                    }
                }
            }
            #endregion

            panelBuscarRol.Visible = false;
            panelBuscarRol.Left = 700;
            panelGestionarRoles.Visible = false;
            panelGestionarRoles.Left = 700;

            panelGestionarRoles.Visible = false;
            panelGestionarRoles.Left = 15;
            panelGestionarRoles.Visible = true;


            bunifuSeparator1.Left = btnGestionarRoles.Left;
            bunifuSeparator1.Width = btnGestionarRoles.Width;
        }
        #endregion

        #region Limpiar Campo Nombre del Rol
        private void txtVerRol_Enter(object sender, EventArgs e)
        {
            if (txtVerRol.Text == "NOMBRE del ROL...")
            {
                txtVerRol.Text = "";
            }
        }

        private void txtVerRol_Leave(object sender, EventArgs e)
        {
            if (txtVerRol.Text == "")
            {
                txtVerRol.Text = "NOMBRE del ROL...";
            }
        }
        #endregion

        #region Obtener todos los formularios existentes
        private void ObtenerListaFormularios()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();
            Type[] Types = myAssembly.GetTypes();
            foreach (Type myType in Types)

            {
                if (myType.BaseType == null) continue;

                if (myType.BaseType.FullName == "System.Windows.Forms.Form")
                {
                    if (myType.Name != "MensajeError")
                    {
                        listBox1.Items.Add(myType.Name);
                    }
                }

                //else { MessageBox.Show(myType.Name); }      

            }
        }
        #endregion

        #region Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpStr = "";
                foreach (var item in listBox1.SelectedItems)
                {
                    if (listBox1.SelectedItems.Count > 1)
                    {
                        tmpStr += listBox1.GetItemText(item) + ", ";
                    }
                    else
                    {
                        tmpStr += listBox1.GetItemText(item);
                    }
                }

                string rpta = "";
                rpta = CRol.Insertar(this.txtVerRol.Text.Trim(), tmpStr);

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El rol se ha creado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarRoles.Visible = false;
                    panelGestionarRoles.Left = 700;
                    panelBuscarRol.Visible = false;
                    panelBuscarRol.Left = 15;
                    panelBuscarRol.Visible = true;
                    bunifuSeparator1.Left = btnVerRoles.Left;
                    bunifuSeparator1.Width = btnVerRoles.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha creado el rol correctamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        #region Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpStr1 = "";
                foreach (var item in listBox1.SelectedItems)
                {
                    if (listBox1.SelectedItems.Count > 1)
                    {
                        tmpStr1 += listBox1.GetItemText(item) + ", ";
                    }
                    else
                    {
                        tmpStr1 += listBox1.GetItemText(item);
                    }
                }

                string rpta = "";
                rpta = CRol.Editar(int.Parse(idRolSeleccionado),txtVerRol.Text.Trim(), tmpStr1);

                if (rpta.Equals("OK"))
                {
                    MensajeExito msjExito = new MensajeExito();
                    msjExito.bunifuCustomLabel3.Text = "El rol se ha modificado exitosamente!";
                    msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                    msjExito.Show();
                    //MessageBox.Show("Se guardó todo!");
                    panelGestionarRoles.Visible = false;
                    panelGestionarRoles.Left = 700;
                    panelBuscarRol.Visible = false;
                    panelBuscarRol.Left = 15;
                    panelBuscarRol.Visible = true;
                    bunifuSeparator1.Left = btnVerRoles.Left;
                    bunifuSeparator1.Width = btnVerRoles.Width;
                    ModoNuevo();
                }
                else
                {
                    MensajeDeError msjError = new MensajeDeError();
                    msjError.bunifuCustomLabel3.Text = "No se ha modificado el rol exitosamente!";
                    msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                    msjError.Show();
                    //MensajeError(rpta);
                }

                this.ListarRoles();
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
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere eliminar el rol?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CRol.Eliminar(Convert.ToInt32(idRolSeleccionado));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "El rol se ha eliminado exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                        panelGestionarRoles.Visible = false;
                        panelGestionarRoles.Left = 700;
                        panelBuscarRol.Visible = false;
                        panelBuscarRol.Left = 15;
                        panelBuscarRol.Visible = true;
                        bunifuSeparator1.Left = btnVerRoles.Left;
                        bunifuSeparator1.Width = btnVerRoles.Width;
                        ModoNuevo();
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha eliminado el rol exitosamente!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }

                    this.ListarRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Modo Nuevo
        private void ModoNuevo()
        {
            this.btnNuevo.Visible = true;
            this.btnModificar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnNuevo.Width = 622;
            this.txtVerRol.Text = "NOMBRE del ROL...";
            this.listBox1.SelectedItem = null;
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
