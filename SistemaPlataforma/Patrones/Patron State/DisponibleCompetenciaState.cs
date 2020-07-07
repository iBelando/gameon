using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SistemaPlataforma.Patrones.Patron_State
{
    public class DisponibleCompetenciaState : CompetenciaState
    {
        private Ligas ligas;
        private Torneos torneos;

        public DisponibleCompetenciaState(Ligas ligas)
        {
            this.ligas = ligas;
        }

        public DisponibleCompetenciaState(Torneos torneos)
        {
            this.torneos = torneos;
        }

        public override void Respuesta()
        {
            if (ligas != null)
            {
                #region Cargar Datos de la Liga

                #region Cargar Nombre de la Liga
                ligas.label2.Text = LigasDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio de la Liga
                ligas.dtpFechaInicio.Value = LigasDisponibles.fechaInicioCompetenciaSeleccionada;
                ligas.dtpFechaInicio.Enabled = false;
                #endregion

                #region Cargar Fecha Fin de la Liga
                ligas.dtpFechaFin.Value = LigasDisponibles.fechaFinCompetenciaSeleccioada;
                ligas.dtpFechaFin.Enabled = false;
                #endregion

                #region Cargar Juego de la Liga
                ligas.txtJuego.Text = LigasDisponibles.juegoCompetenciaSeleccionada;
                ligas.txtJuego.Enabled = false;
                #endregion

                #region Cargar Tipo de Competencia
                ligas.txtTipoCompetencia.Text = "LIGA";
                ligas.txtTipoCompetencia.Enabled = false;
                #endregion

                #region Cargar Cupos de la Liga
                ligas.btnCantidadEquipos.Text = LigasDisponibles.cuposCompetenciaSeleccionada;
                ligas.btnCantidadEquipos.Enabled = false;
                #endregion

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
                    ligas.dgvEquiposInscritos.DataSource = dtRecord;
                    SqlCon.Close();
                    ligas.dgvEquiposInscritos.RowHeadersVisible = false;
                    ligas.dgvEquiposInscritos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ligas.dgvEquiposInscritos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ligas.dgvEquiposInscritos.RowTemplate.Height = 50;
                    foreach (DataGridViewColumn col in ligas.dgvEquiposInscritos.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open)
                    {
                        SqlCon.Close();
                    }
                }
                #endregion

                #region Configurar dgvEquiposInscriptos
                ligas.dgvEquiposInscritos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ligas.dgvEquiposInscritos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                foreach (DataGridViewColumn col in ligas.dgvEquiposInscritos.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                #endregion

                #region Verificar Equipo Inscripto
                SqlConnection SqlCon1 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon1.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando1 = new SqlCommand("Select * from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada + " and Equipos.capitan = '" + Login.nicknameUsuario + "'", SqlCon);
                    SqlCon.Open();
                    SqlDataReader registro = comando1.ExecuteReader();
                    if (registro.HasRows == false) //Si NO está inscripto el Equipo entra acá
                    {
                        ligas.btnSalir.Visible = false;
                        ligas.btnSalir.Width = 160;
                        ligas.btnSalir.Location = new Point(370, 512);

                        ligas.btnInscribirse.Visible = true;
                        ligas.btnInscribirse.Width = 572;
                    }
                    else //Si el equipo ESTÁ inscripto entra acá
                    {
                        ligas.btnInscribirse.Visible = false;
                        ligas.btnInscribirse.Width = 160;

                        ligas.btnSalir.Visible = true;
                        ligas.btnSalir.Location = new Point(127, 455);
                        ligas.btnSalir.Width = 572;
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
            }
            else
            {
                #region Cargar Datos del Torneo

                #region Cargar Nombre del Torneo
                torneos.label2.Text = TorneosDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio del Torneo
                torneos.dtpFechaInicio.Value = TorneosDisponibles.fechaInicioCompetenciaSeleccionada;
                torneos.dtpFechaInicio.Enabled = false;
                #endregion

                #region Cargar Fecha Fin del Torneo
                torneos.dtpFechaFin.Value = TorneosDisponibles.fechaFinCompetenciaSeleccioada;
                torneos.dtpFechaFin.Enabled = false;
                #endregion

                #region Cargar Juego del Torneo
                torneos.txtJuego.Text = TorneosDisponibles.juegoCompetenciaSeleccionada;
                torneos.txtJuego.Enabled = false;
                #endregion

                #region Cargar Tipo de Competencia
                torneos.txtTipoCompetencia.Text = "TORNEO";
                torneos.txtTipoCompetencia.Enabled = false;
                #endregion

                #region Cargar Cupos del Torneo
                torneos.btnCantidadEquipos.Text = TorneosDisponibles.cuposCompetenciaSeleccionada;
                torneos.btnCantidadEquipos.Enabled = false;
                #endregion

                #endregion

                #region Cargar Equipos Inscriptos a la Competencia

                SqlConnection SqlCon = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando = new SqlCommand("select Equipos.imagenEquipo, Equipos.nombre from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + TorneosDisponibles.idCompetenciaSeleccionada, SqlCon);
                    SqlCon.Open();
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);
                    torneos.dgvEquiposInscritos.DataSource = dtRecord;
                    SqlCon.Close();
                    torneos.dgvEquiposInscritos.RowTemplate.Height = 50;
                    torneos.dgvEquiposInscritos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    torneos.dgvEquiposInscritos.RowHeadersVisible = false;
                    torneos.dgvEquiposInscritos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewColumn col in torneos.dgvEquiposInscritos.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open)
                    {
                        SqlCon.Close();
                    }
                }
                #endregion

                #region Verificar Equipo Inscripto
                SqlConnection SqlCon1 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon1.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando1 = new SqlCommand("Select * from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + TorneosDisponibles.idCompetenciaSeleccionada + " and Equipos.capitan = '" + Login.nicknameUsuario + "'", SqlCon);
                    SqlCon.Open();
                    SqlDataReader registro = comando1.ExecuteReader();
                    if (registro.HasRows == false) //Si NO está inscripto el Equipo entra acá
                    {
                        torneos.btnSalir.Visible = false;
                        torneos.btnSalir.Width = 160;
                        torneos.btnSalir.Location = new Point(370, 512);

                        torneos.btnInscribirse.Visible = true;
                        torneos.btnInscribirse.Width = 572;
                    }
                    else //Si el equipo ESTÁ inscripto entra acá
                    {
                        torneos.btnInscribirse.Visible = false;
                        torneos.btnInscribirse.Width = 160;

                        torneos.btnSalir.Visible = true;
                        torneos.btnSalir.Location = new Point(127, 455); //105,512
                        torneos.btnSalir.Width = 572;
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
            }
        }
    }
}
