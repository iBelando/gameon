using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Controladora;

namespace SistemaPlataforma
{
    public partial class AuditoríaPartidos : Form
    {

        #region Inicializar Componentes
        public AuditoríaPartidos()
        {
            InitializeComponent();

            //#region Módulo de Seguridad
            ////CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Configuración de Altura de Celdas del dgvAuditoriaPartidos
            this.dgvAuditoríaPartidos.RowTemplate.Height = 50;
            #endregion

        }
        #endregion

        #region Pantalla Arrastrable
        private void AuditoríaPartidos_Load(object sender, EventArgs e)
        {

            #region Cargar Partidos Auditados
            SqlConnection SqlCon4 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                SqlCommand comando4 = new SqlCommand("Select IdPartido as 'IDPARTIDO', Fecha as 'FECHA', EquipoA as 'EQUIPO A', EquipoB as 'EQUIPO B', Resultado as 'RESULTADO', usuarioAuditoria as 'USUARIO', fechaAuditoria as 'FECHA.MOV', movimientoAuditoria as 'ACCIÓN' from Partidos order by fechaAuditoria desc", SqlCon4);
                SqlCon4.Open();
                SqlDataAdapter registro4 = new SqlDataAdapter(comando4);
                DataTable dtRecord = new DataTable();
                registro4.Fill(dtRecord);
                dgvAuditoríaPartidos.DataSource = dtRecord;
                SqlCon4.Close();
                this.dgvAuditoríaPartidos.RowHeadersVisible = false;
                this.dgvAuditoríaPartidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvAuditoríaPartidos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            finally
            {
                if (SqlCon4.State == ConnectionState.Open)
                {
                    SqlCon4.Close();
                }
            }
            #endregion
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AuditoríaPartidos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Hide();
        }
        #endregion

        #region Limpiar Campo Buscar Partido
        private void txtBuscarPartido_Enter(object sender, EventArgs e)
        {
            if (txtBuscarPartido.Text == "BUSCAR PARTIDO...")
            {
                txtBuscarPartido.Text = "";
            }
        }

        private void txtBuscarPartido_Leave(object sender, EventArgs e)
        {
            if (txtBuscarPartido.Text == "")
            {
                txtBuscarPartido.Text = "BUSCAR PARTIDO...";
            }
        }
        #endregion

        #region Boton Buscar
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dgvAuditoríaPartidos.DataSource;
            //bs.Filter = dgvAuditoríaPartidos.Columns[0].HeaderText.ToString() + " = '" + this.txtBuscarPartido.Text + "'";
            //dgvAuditoríaPartidos.DataSource = bs;

            #region Cargar Partidos Auditados
            SqlConnection SqlCon4 = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaAuditoria;Integrated Security=True";
                SqlCommand comando4 = new SqlCommand("Select IdPartido as 'IDPARTIDO', Fecha as 'FECHA', EquipoA as 'EQUIPO A', EquipoB as 'EQUIPO B', Resultado as 'RESULTADO', usuarioAuditoria as 'USUARIO', fechaAuditoria as 'FECHA.MOV', movimientoAuditoria as 'ACCIÓN' from Partidos order by fechaAuditoria desc", SqlCon4);
                SqlCon4.Open();
                SqlDataAdapter registro4 = new SqlDataAdapter(comando4);
                DataTable dtRecord = new DataTable();
                registro4.Fill(dtRecord);
                dgvAuditoríaPartidos.DataSource = dtRecord;
                SqlCon4.Close();
                this.dgvAuditoríaPartidos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAuditoríaPartidos.RowHeadersVisible = false;
                foreach (DataGridViewColumn col in this.dgvAuditoríaPartidos.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            finally
            {
                if (SqlCon4.State == ConnectionState.Open)
                {
                    SqlCon4.Close();
                }
            }
            #endregion

            DataView dv = ((DataTable)dgvAuditoríaPartidos.DataSource).DefaultView;
            dv.RowFilter = "IDPARTIDO = " + txtBuscarPartido.Text +"";
            dgvAuditoríaPartidos.DataSource = dv;
        }
        #endregion

    }
}
