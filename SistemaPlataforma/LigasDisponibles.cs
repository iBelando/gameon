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
    public partial class LigasDisponibles : Form
    {

        #region Almacenar Credenciales de la Competencia
        public static string idCompetenciaSeleccionada = "";
        public static string nombreCompetenciaSeleccionada = "";
        public static DateTime fechaInicioCompetenciaSeleccionada;
        public static DateTime fechaFinCompetenciaSeleccioada;
        public static string juegoCompetenciaSeleccionada = "";
        public static string cuposCompetenciaSeleccionada = "";
        #endregion

        #region Inicializa Componentes
        public LigasDisponibles()
        {
            InitializeComponent();

            #region Listar Ligas Disponibles
            ListarLigasDisponibles();
            this.dgvLigasDisponibles.Columns["idCompetencia"].Visible = false;
            #endregion

            #region Listar Ligas Finalizadas
            ListarLigasFinalizadas();
            this.dgvLigasFinalizadas.Columns["idCompetencia"].Visible = false;
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
        private void LigasDisponibles_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            #region Marcar Ligas Disponibles
            VerificarEstadoLigasDisponibles();
            #endregion

            #region Marcar Ligas En Curso
            VerificarEstadoLigasEnCurso();
            #endregion

            #region No mostrar Ligas Finalizadas
            VerificarEstadoLigasFinalizado();
            #endregion

            #region Obtener Ligas Finalizadas
            ObtenerLigasFinalizadas();
            #endregion

            #region Ajustar Tamaño DGV
            this.dgvLigasDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLigasDisponibles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvLigasDisponibles.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dgvLigasFinalizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLigasFinalizadas.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvLigasFinalizadas.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            #endregion

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void LigasDisponibles_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Listar Ligas Disponibles
        private void ListarLigasDisponibles()
        {
            this.dgvLigasDisponibles.DataSource = CCompetencia.Mostrar();
            this.dgvLigasDisponibles.Columns["tipoCompetencia"].Visible = false;
            this.dgvLigasDisponibles.Columns["equiposInscriptos"].Visible = false;
            this.dgvLigasDisponibles.RowHeadersVisible = false;
            this.dgvLigasDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLigasDisponibles.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLigasDisponibles.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvLigasDisponibles.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //this.dgvLigasDisponibles.RowTemplate.Height = 90;
            //this.dgvLigasDisponibles.RowHeadersVisible = false;
            //foreach (DataGridViewColumn col in dgvLigasDisponibles.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvLigasDisponibles.DataSource;
            bs.Filter = dgvLigasDisponibles.Columns[5].HeaderText.ToString() + " LIKE '%Liga%'";
            dgvLigasDisponibles.DataSource = bs;
        }
        #endregion

        #region Listar Ligas Finalizadas
        private void ListarLigasFinalizadas()
        {
            this.dgvLigasFinalizadas.DataSource = CCompetencia.Mostrar();
            this.dgvLigasFinalizadas.Columns["tipoCompetencia"].Visible = false;
            this.dgvLigasFinalizadas.Columns["equiposInscriptos"].Visible = false;
            this.dgvLigasFinalizadas.RowHeadersVisible = false;
            this.dgvLigasFinalizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLigasFinalizadas.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLigasFinalizadas.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dgvLigasFinalizadas.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //this.dgvLigasFinalizadas.RowTemplate.Height = 90;
            //this.dgvLigasFinalizadas.RowHeadersVisible = false;
            //foreach (DataGridViewColumn col in dgvLigasFinalizadas.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvLigasFinalizadas.DataSource;
            bs.Filter = dgvLigasFinalizadas.Columns[5].HeaderText.ToString() + " LIKE '%Liga%'";
            dgvLigasFinalizadas.DataSource = bs;
        }
        #endregion

        #region Verificar Estado Ligas Disponibles
        private void VerificarEstadoLigasDisponibles()
        {
            foreach (DataGridViewRow row in dgvLigasDisponibles.Rows)
            {
                if ((Convert.ToDateTime(row.Cells[2].Value) <= DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now) || (Convert.ToDateTime(row.Cells[2].Value) >= DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region Verificar Estado Ligas En Curso
        private void VerificarEstadoLigasEnCurso()
        {
            foreach (DataGridViewRow row in dgvLigasDisponibles.Rows)
            {
                if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) > DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
        #endregion

        #region Verificar Estado Ligas Finalizados
        private void VerificarEstadoLigasFinalizado()
        {
            foreach (DataGridViewRow row in dgvLigasDisponibles.Rows)
            {
                if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) < DateTime.Now)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvLigasDisponibles.DataSource];
                    cm.SuspendBinding();
                    row.Visible = false;
                }
            }
        }
        #endregion

        #region Obtener Ligas Finalizados
        private void ObtenerLigasFinalizadas()
        {
            foreach (DataGridViewRow row in dgvLigasFinalizadas.Rows)
            {
                if (!(Convert.ToDateTime(row.Cells[2].Value) < DateTime.Now && Convert.ToDateTime(row.Cells[3].Value) < DateTime.Now))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvLigasFinalizadas.DataSource];
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

        #region Desplazar al Panel de Ligas Finalizadas
        private void btnLigasFinalizadas_Click(object sender, EventArgs e)
        {
            if (panelLigasFinalizadas.Left == 856) //700
            {
                panelLigasDisponibles.Visible = false;
                panelLigasDisponibles.Left = 856; //700

                panelLigasFinalizadas.Visible = false;
                panelLigasFinalizadas.Left = 9;
                panelLigasFinalizadas.Visible = true;

                bunifuSeparator2.Left = btnLigasFinalizadas.Left;
                bunifuSeparator2.Width = btnLigasFinalizadas.Width;
            }
        }
        #endregion

        #region Desplazar al Panel de Ligas Disponibles
        private void btnLigasDisponibes_Click(object sender, EventArgs e)
        {
            if (panelLigasDisponibles.Left == 856) //700 
            {
                panelLigasFinalizadas.Visible = false;
                panelLigasFinalizadas.Left = 856; //700

                panelLigasDisponibles.Visible = false;
                panelLigasDisponibles.Left = 9;
                panelLigasDisponibles.Visible = true;


                bunifuSeparator2.Left = btnLigasDisponibes.Left;
                bunifuSeparator2.Width = btnLigasDisponibes.Width;

            }
        }


        #endregion

        #region Seleccionar Competencia en dgvLigasDisponibles
        private void dgvLigasDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLigasDisponibles.Rows.Count != 0)
            {

                #region Cargamos la ID de la Competencia Seleccionada
                idCompetenciaSeleccionada = Convert.ToString(this.dgvLigasDisponibles.CurrentRow.Cells["idCompetencia"].Value);
                #endregion

                #region Cargamos el Nombre de la Competencia Seleccionada
                nombreCompetenciaSeleccionada = Convert.ToString(this.dgvLigasDisponibles.CurrentRow.Cells["colNombre"].Value);
                #endregion

                #region Cargamos la Fecha de Inicio de la Competencia Seleccionada
                fechaInicioCompetenciaSeleccionada = Convert.ToDateTime(this.dgvLigasDisponibles.CurrentRow.Cells["colFechaInicio"].Value);
                #endregion

                #region Cargamos la Fecha Fin de la Competencia Seleccionada
                fechaFinCompetenciaSeleccioada = Convert.ToDateTime(this.dgvLigasDisponibles.CurrentRow.Cells["colFechaFin"].Value);
                #endregion

                #region Cargamos el Juego de la Competencia Seleccionada
                juegoCompetenciaSeleccionada = Convert.ToString(this.dgvLigasDisponibles.CurrentRow.Cells["colJuego"].Value);
                #endregion

                #region Cargamos los Cupos de la Competencia Seleccionada
                cuposCompetenciaSeleccionada = Convert.ToString(this.dgvLigasDisponibles.CurrentRow.Cells["colCupos"].Value);
                #endregion

                #region Dirigir a la Liga
                Ligas frmLigas = new Ligas();
                frmLigas.Show();
                this.Hide();
                #endregion

            }
        }
        #endregion

        #region Seleccionar Competencia en dgvLigasFinalizadas
        private void dgvLigasFinalizadas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLigasFinalizadas.Rows.Count != 0)
            {

                #region Cargamos la ID de la Competencia Seleccionada
                idCompetenciaSeleccionada = Convert.ToString(this.dgvLigasFinalizadas.CurrentRow.Cells["idCompetencia"].Value);
                #endregion

                #region Cargamos el Nombre de la Competencia Seleccionada
                nombreCompetenciaSeleccionada = Convert.ToString(this.dgvLigasFinalizadas.CurrentRow.Cells["colNombreFinalizado"].Value);
                #endregion

                #region Cargamos la Fecha de Inicio de la Competencia Seleccionada
                fechaInicioCompetenciaSeleccionada = Convert.ToDateTime(this.dgvLigasFinalizadas.CurrentRow.Cells["colFechaInicioFinalizado"].Value);
                #endregion

                #region Cargamos la Fecha Fin de la Competencia Seleccionada
                fechaFinCompetenciaSeleccioada = Convert.ToDateTime(this.dgvLigasFinalizadas.CurrentRow.Cells["colFechaFinFinalizado"].Value);
                #endregion

                #region Cargamos el Juego de la Competencia Seleccionada
                juegoCompetenciaSeleccionada = Convert.ToString(this.dgvLigasFinalizadas.CurrentRow.Cells["colJuegoFinalizado"].Value);
                #endregion

                #region Cargamos los Cupos de la Competencia Seleccionada
                cuposCompetenciaSeleccionada = Convert.ToString(this.dgvLigasFinalizadas.CurrentRow.Cells["colCuposFinalizados"].Value);
                #endregion

                #region Dirigir a la Liga
                Ligas frmLigas = new Ligas();
                frmLigas.Show();
                this.Hide();
                #endregion

            }
        }
        #endregion

    }
}
