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
using System.Data.SqlClient;
using SistemaPlataforma.Patrones.Patron_State;
using Controladora;

namespace SistemaPlataforma
{
    public partial class Ligas : Form
    {
        public Ligas()
        {
            #region Inicializar Componentes
            InitializeComponent();

            this.dgvEquiposInscritos.RowTemplate.Height = 90;
            this.dgvEquiposInscritos.RowHeadersVisible = false;
            #endregion
        }

        #region Patron State
        private void Ligas_Load(object sender, EventArgs e)
        {

            //#region Módulo de Seguridad
            //CSeguridad.VerificarPermisos(Convert.ToInt32(Login.idUsuario), this);
            //#endregion

            CompetenciaContext oCompetencia = new CompetenciaContext();

            if ((LigasDisponibles.fechaInicioCompetenciaSeleccionada <= DateTime.Now && LigasDisponibles.fechaFinCompetenciaSeleccioada > DateTime.Now) || (LigasDisponibles.fechaInicioCompetenciaSeleccionada >= DateTime.Now && LigasDisponibles.fechaFinCompetenciaSeleccioada > DateTime.Now))
            {
                oCompetencia.State = new DisponibleCompetenciaState(this);
            }
            if (LigasDisponibles.fechaInicioCompetenciaSeleccionada < DateTime.Now && LigasDisponibles.fechaFinCompetenciaSeleccioada > DateTime.Now)
            {
                oCompetencia.State = new EnCursoCompetenciaState(this);
            }
            if (LigasDisponibles.fechaInicioCompetenciaSeleccionada < DateTime.Now && LigasDisponibles.fechaFinCompetenciaSeleccioada < DateTime.Now)
            {
                oCompetencia.State = new FinalizadoCompetenciaState(this);
            }

            oCompetencia.AtenderSolicitud();
            
        }
        #endregion

        #region Pantalla Arrastrable
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Ligas_MouseDown(object sender, MouseEventArgs e)
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
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            LigasDisponibles frmLigasDisponibles = new LigasDisponibles();
            frmLigasDisponibles.Show();
            this.Hide();
        }
        #endregion

        #region Mensaje de Error
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Plataforma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Boton Inscribirse
        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            try
            {   

                #region Dirigir al Formulario de Seleccionar Equipo
                SeleccionarEquipo frmSeleccionarEquipo = new SeleccionarEquipo();
                frmSeleccionarEquipo.Show();
                this.Hide();
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Boton Desinscribirse
        private void btnSalir_Click(object sender, EventArgs e)
        {
            var idEquipo = "";

            #region Obtener ID Equipo Inscripto
            SqlConnection SqlCon1 = new SqlConnection();
            
            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon1.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando1 = new SqlCommand("Select * from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada + " and Equipos.capitan = '" + Login.nicknameUsuario + "'", SqlCon1);
                SqlCon1.Open();
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.HasRows == false) //Si está NO ESTÁ inscripto el Equipo entra acá
                {
                    
                }
                else //Si el equipo ESTÁ inscripto entra acá
                {
                    
                    while (registro.Read())
                    {
                        idEquipo = registro["idEquipo"].ToString();
                    }
                }
                SqlCon1.Close();
            }
            finally
            {
                if (SqlCon1.State == ConnectionState.Open)
                {
                    SqlCon1.Close();
                }
            }
            #endregion

            #region Eliminar Inscripción
            try
            {
                string rpta = "";
                DialogResult VentanaEmergente;
                VentanaEmergente = MessageBox.Show("¿Está seguro que quiere desinscribirse de la competencia?", "Plataforma", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (VentanaEmergente == DialogResult.OK)
                {
                    rpta = CInscripcion.EliminarConIdEquipo(Convert.ToInt32(idEquipo));

                    if (rpta.Equals("OK"))
                    {
                        MensajeExito msjExito = new MensajeExito();
                        msjExito.bunifuCustomLabel3.Text = "Se ha desinscrito exitosamente!";
                        msjExito.bunifuCustomLabel3.Location = new Point(11, 101);
                        msjExito.Show();
                        //MessageBox.Show("Se eliminó correctamente!");
                    }
                    else
                    {
                        MensajeDeError msjError = new MensajeDeError();
                        msjError.bunifuCustomLabel3.Text = "No se ha podido desinscribir de la competencia!";
                        msjError.bunifuCustomLabel3.Location = new Point(10, 101);
                        msjError.Show();
                        //MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            #endregion

            #region Cargar Equipos Inscriptos a la Competencia

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("select Equipos.imagenEquipo, Equipos.nombre from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada, SqlCon);
                SqlCon.Open();
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                this.dgvEquiposInscritos.DataSource = dtRecord;
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

            #region Resetear Modo Inscribirse
            this.btnSalir.Visible = false;
            this.btnSalir.Width = 160;
            this.btnSalir.Location = new Point(370, 512);

            this.btnInscribirse.Visible = true;
            this.btnInscribirse.Width = 572;
            #endregion

        }
        #endregion

        #region Boton Partidos
        private void btnPartidos_Click(object sender, EventArgs e)
        {
            Partidos frmPartidos = new Partidos();

            #region Cargar Partidos
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("select Partidos.idPartido, Partidos.fecha, Partidos.equipoA, Partidos.equipoB, Partidos.resultado, Partidos.juego, Partidos.arbitro, Competencias.nombreCompetencia from Partidos inner join Competencias on Partidos.idCompetencia = Competencias.idCompetencia where nombreCompetencia = '" + LigasDisponibles.nombreCompetenciaSeleccionada +"' order by fecha desc", SqlCon);
                SqlCon.Open();
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                frmPartidos.dgvVerPartidos.DataSource = dtRecord;
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

            #region Dirigir a Ver Partidos
            frmPartidos.dgvVerPartidos.Columns["idPartido"].Visible = false;
            frmPartidos.dgvVerPartidos.Columns["arbitro"].Visible = false;
            frmPartidos.Show();
            this.Hide();
            #endregion

        }
        #endregion

        #region Boton Partidos Finalizados
        private void btnPartidosFinalizados_Click(object sender, EventArgs e)
        {
            Partidos frmPartidos = new Partidos();

            #region Cargar Partidos
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos la conexion, el comando y ejecutamos el mismo
                SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                SqlCommand comando = new SqlCommand("select Partidos.idPartido, Partidos.fecha, Partidos.equipoA, Partidos.equipoB, Partidos.resultado, Partidos.juego, Partidos.arbitro, Competencias.nombreCompetencia from Partidos inner join Competencias on Partidos.idCompetencia = Competencias.idCompetencia where nombreCompetencia = '" + LigasDisponibles.nombreCompetenciaSeleccionada + "' order by fecha desc", SqlCon);
                SqlCon.Open();
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                frmPartidos.dgvVerPartidos.DataSource = dtRecord;
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

            #region Dirigir a Ver Partidos
            frmPartidos.dgvVerPartidos.Columns["idPartido"].Visible = false;
            frmPartidos.dgvVerPartidos.Columns["arbitro"].Visible = false;
            frmPartidos.Show();
            this.Hide();
            #endregion
        }
        #endregion

    }
}
