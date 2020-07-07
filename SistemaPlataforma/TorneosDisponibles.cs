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
    public partial class TorneosDisponibles : Form
    {

        #region Almacenar Credenciales de la Competencia
        public static string idCompetenciaSeleccionada = "";
        public static string nombreCompetenciaSeleccionada = "";
        public static DateTime fechaInicioCompetenciaSeleccionada;
        public static DateTime fechaFinCompetenciaSeleccioada;
        public static string juegoCompetenciaSeleccionada = "";
        public static string cuposCompetenciaSeleccionada = "";
        #endregion

        #region Inicializar Componentes
        public TorneosDisponibles()
        {
            InitializeComponent();

            #region Listar Torneos Disponibles
            ListarTorneosDisponibles();
            this.dgvTorneosDisponibles.Columns["idCompetencia"].Visible = false;
            #endregion

            #region Listar Ligas Finalizadas
            ListarTorneosFinalizadas();
            this.dgvTorneosFinalizados.Columns["idCompetencia"].Visible = false;
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
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Hide();
        }
        #endregion

        #region Pantalla Arrastrable
        private void TorneosDisponibles_Load(object sender, EventArgs e)
        {

            #region Marcar Torneos Disponibles
            VerificarEstadoTorneosDisponibles();
            #endregion

            #region Marcar Torneos En Curso
            VerificarEstadoTorneosEnCurso();
            #endregion

            #region No mostrar Torneos Finalizadas
            VerificarEstadoTorneosFinalizado();
            #endregion

            #region Obtener Torneos Finalizados
            ObtenerTorneosFinalizadas();
            #endregion

            #region Ajustar Tamaño DGV
            this.dgvTorneosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTorneosDisponibles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvTorneosDisponibles.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dgvTorneosFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTorneosFinalizados.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvTorneosFinalizados.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            #endregion
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TorneosDisponibles_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Listar Torneos Disponibles
        private void ListarTorneosDisponibles()
        {
            this.dgvTorneosDisponibles.DataSource = CCompetencia.Mostrar();
            this.dgvTorneosDisponibles.Columns["tipoCompetencia"].Visible = false;
            this.dgvTorneosDisponibles.Columns["equiposInscriptos"].Visible = false;
            this.dgvTorneosDisponibles.RowHeadersVisible = false;
            this.dgvTorneosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTorneosDisponibles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTorneosDisponibles.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvTorneosDisponibles.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //this.dgvTorneosDisponibles.RowTemplate.Height = 90;
            //this.dgvTorneosDisponibles.RowHeadersVisible = false;
            //foreach (DataGridViewColumn col in dgvTorneosDisponibles.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvTorneosDisponibles.DataSource;
            bs.Filter = dgvTorneosDisponibles.Columns[5].HeaderText.ToString() + " LIKE '%Torneo%'";
            dgvTorneosDisponibles.DataSource = bs;
        }
        #endregion

        #region Listar Torneos Finalizadas
        private void ListarTorneosFinalizadas()
        {
            this.dgvTorneosFinalizados.DataSource = CCompetencia.Mostrar();
            this.dgvTorneosFinalizados.Columns["tipoCompetencia"].Visible = false;
            this.dgvTorneosFinalizados.Columns["equiposInscriptos"].Visible = false;
            this.dgvTorneosFinalizados.RowHeadersVisible = false;
            this.dgvTorneosFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTorneosFinalizados.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTorneosFinalizados.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvTorneosFinalizados.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //this.dgvTorneosFinalizados.RowTemplate.Height = 90;
            //this.dgvTorneosFinalizados.RowHeadersVisible = false;
            //foreach (DataGridViewColumn col in dgvTorneosFinalizados.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvTorneosFinalizados.DataSource;
            bs.Filter = dgvTorneosFinalizados.Columns[5].HeaderText.ToString() + " LIKE '%Torneo%'";
            dgvTorneosFinalizados.DataSource = bs;
        }
        #endregion

        #region Verificar Estado Torneos Disponibles
        private void VerificarEstadoTorneosDisponibles()
        {
            foreach (DataGridViewRow row in dgvTorneosDisponibles.Rows)
            {
                if ((Convert.ToDateTime(row.Cells[2].Value) <= DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now) || (Convert.ToDateTime(row.Cells[2].Value) >= DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region Verificar Estado Torneos En Curso
        private void VerificarEstadoTorneosEnCurso()
        {
            foreach (DataGridViewRow row in dgvTorneosDisponibles.Rows)
            {
                if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
        #endregion

        #region Verificar Estado Torneos Finalizados
        private void VerificarEstadoTorneosFinalizado()
        {
            foreach (DataGridViewRow row in dgvTorneosDisponibles.Rows)
            {
                if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) < DateTime.Now)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvTorneosDisponibles.DataSource];
                    cm.SuspendBinding();
                    row.Visible = false;
                }
            }
        }
        #endregion

        #region Obtener Torneos Finalizados
        private void ObtenerTorneosFinalizadas()
        {
            foreach (DataGridViewRow row in dgvTorneosFinalizados.Rows)
            {
                if (!(Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) < DateTime.Now))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvTorneosFinalizados.DataSource];
                    cm.SuspendBinding();
                    row.Visible = false;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }


        #endregion

        #region Desplazar al Panel de Torneos Disponibles
        private void btnTorneosDisponibes_Click(object sender, EventArgs e)
        {
            if (panelTorneosDisponibles.Left == 856) //705
            {
                panelTorneosFinalizados.Visible = false;
                panelTorneosFinalizados.Left = 856; //705

                panelTorneosDisponibles.Visible = false;
                panelTorneosDisponibles.Left = 9;
                panelTorneosDisponibles.Visible = true;


                bunifuSeparator2.Left = btnTorneosDisponibes.Left;
                bunifuSeparator2.Width = btnTorneosDisponibes.Width;

            }
        }
        #endregion

        #region Desplazar al Panel de Torneos Finalizados
        private void btnTorneosFinalizados_Click(object sender, EventArgs e)
        {
            if (panelTorneosFinalizados.Left == 856) //705
            {
                panelTorneosDisponibles.Visible = false;
                panelTorneosDisponibles.Left = 856; //705

                panelTorneosFinalizados.Visible = false;
                panelTorneosFinalizados.Left = 9;
                panelTorneosFinalizados.Visible = true;

                bunifuSeparator2.Left = btnTorneosFinalizados.Left;
                bunifuSeparator2.Width = btnTorneosFinalizados.Width;
            }
        }

        #endregion

        #region Seleccionar Competencia en dgvTorneosDisponibles
        private void dgvTorneosDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTorneosDisponibles.Rows.Count != 0)
            {

                #region Cargamos la ID de la Competencia Seleccionada
                idCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosDisponibles.CurrentRow.Cells["idCompetencia"].Value);
                #endregion

                #region Cargamos el Nombre de la Competencia Seleccionada
                nombreCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosDisponibles.CurrentRow.Cells["colNombre"].Value);
                #endregion

                #region Cargamos la Fecha de Inicio de la Competencia Seleccionada
                fechaInicioCompetenciaSeleccionada = Convert.ToDateTime(this.dgvTorneosDisponibles.CurrentRow.Cells["colFechaInicio"].Value);
                #endregion

                #region Cargamos la Fecha Fin de la Competencia Seleccionada
                fechaFinCompetenciaSeleccioada = Convert.ToDateTime(this.dgvTorneosDisponibles.CurrentRow.Cells["colFechaFin"].Value);
                #endregion

                #region Cargamos el Juego de la Competencia Seleccionada
                juegoCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosDisponibles.CurrentRow.Cells["colJuego"].Value);
                #endregion

                #region Cargamos los Cupos de la Competencia Seleccionada
                cuposCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosDisponibles.CurrentRow.Cells["colCupos"].Value);
                #endregion

                #region Dirigir al Torneo
                Torneos frmTorneos = new Torneos();
                frmTorneos.Show();
                this.Close();
                #endregion

            }
        }
        #endregion

        #region Seleccionar Competencia en dgvTorneosFinalizados
        private void dgvTorneosFinalizados_DoubleClick(object sender, EventArgs e)
        {

            #region Cargamos la ID de la Competencia Seleccionada
            idCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosFinalizados.CurrentRow.Cells["idCompetencia"].Value);
            #endregion

            #region Cargamos el Nombre de la Competencia Seleccionada
            nombreCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosFinalizados.CurrentRow.Cells["colNombreFinalizado"].Value);
            #endregion

            #region Cargamos la Fecha de Inicio de la Competencia Seleccionada
            fechaInicioCompetenciaSeleccionada = Convert.ToDateTime(this.dgvTorneosFinalizados.CurrentRow.Cells["colFechaInicioFinalizado"].Value);
            #endregion

            #region Cargamos la Fecha Fin de la Competencia Seleccionada
            fechaFinCompetenciaSeleccioada = Convert.ToDateTime(this.dgvTorneosFinalizados.CurrentRow.Cells["colFechaFinFinalizado"].Value);
            #endregion

            #region Cargamos el Juego de la Competencia Seleccionada
            juegoCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosFinalizados.CurrentRow.Cells["colJuegoFinalizado"].Value);
            #endregion

            #region Cargamos los Cupos de la Competencia Seleccionada
            cuposCompetenciaSeleccionada = Convert.ToString(this.dgvTorneosFinalizados.CurrentRow.Cells["colCuposFinalizado"].Value);
            #endregion

            #region Dirigir al Torneo
            Torneos frmTorneos = new Torneos();
            frmTorneos.Show();
            this.Hide();
            #endregion

        }
        #endregion

    }
}
