using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlataforma.Patrones.Patron_State
{
    public class FinalizadoCompetenciaState : CompetenciaState
    {
        private Ligas ligas;
        private Torneos torneos;

        public FinalizadoCompetenciaState(Ligas ligas)
        {
            this.ligas = ligas;
        }

        public FinalizadoCompetenciaState(Torneos torneos)
        {
            this.torneos = torneos;
        }

        public override void Respuesta()
        {
            if (ligas != null)
            {
                #region Desplazar al Panel de Liga Finalizada
                if (ligas.panelLigaFin.Left == 1694 || ligas.panelLigaFin.Left == 695) //1371 || 695
                {
                    ligas.panelLigaEnCurso.Visible = false;
                    ligas.panelLigaEnCurso.Left = 859; //695
                    ligas.panelLigaDisponible.Visible = false;
                    ligas.panelLigaDisponible.Left = 859; //695


                    ligas.panelLigaFin.Visible = false;
                    ligas.panelLigaFin.Left = 13;
                    ligas.panelLigaFin.Visible = true;

                }
                #endregion

                #region Cargar Datos de la Liga

                #region Cargar Nombre de la Liga
                ligas.label3.Text = LigasDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio de la Liga
                ligas.dtpInicioLiga.Value = LigasDisponibles.fechaInicioCompetenciaSeleccionada;
                ligas.dtpInicioLiga.Enabled = false;
                #endregion

                #region Cargar Fecha Fin de la Liga
                ligas.dtpFinLiga.Value = LigasDisponibles.fechaFinCompetenciaSeleccioada;
                ligas.dtpFinLiga.Enabled = false;
                #endregion

                #region Cargar Juego de la Liga
                ligas.txtJuegoLigaFin.Text = LigasDisponibles.juegoCompetenciaSeleccionada;
                ligas.txtJuegoLigaFin.Enabled = false;
                #endregion

                #region Cargar Cantidad de Equipos Inscriptos
                var cantEquipos = "";

                #region Obtener Cantidad Equipos Inscriptos
                SqlConnection SqlCon1 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon1.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando1 = new SqlCommand("select count(*) as cantidadEquipos from Inscripciones where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada, SqlCon1);
                    SqlCon1.Open();
                    SqlDataReader registro = comando1.ExecuteReader();
                    if (registro.HasRows == false) //Si está NO ESTÁ inscripto el Equipo entra acá
                    {

                    }
                    else //Si el equipo ESTÁ inscripto entra acá
                    {

                        while (registro.Read())
                        {
                            cantEquipos = registro["cantidadEquipos"].ToString();
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

                ligas.txtNumeroEquiposLigaFin.Text = cantEquipos;
                ligas.txtNumeroEquiposLigaFin.Enabled = false;
                #endregion

                #endregion

                #region Cargar Tabla de Posiciones

                #region Definir Variables a Llenar
                List<string> logosEquipos = new List<string>();
                List<string> nombresEquipo = new List<string>();
                List<string> victoriasEquipo = new List<string>();
                List<string> derrotasEquipo = new List<string>();
                string cantPuntos = "";
                #endregion

                /*#region Obtener Logo y Nombre de los Equipos
                SqlConnection SqlCon3 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon3.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando3 = new SqlCommand("select imagenEquipo, nombre from Inscripciones inner join Equipos on Inscripciones.idEquipo = Equipos.idEquipo where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada + " order by nombre desc", SqlCon3);
                    SqlCon3.Open();
                    SqlDataReader registro3 = comando3.ExecuteReader();
                    while (registro3.Read())
                    {
                        logosEquipos.Add(registro3["imagenEquipo"].ToString());
                        nombresEquipo.Add(registro3["nombre"].ToString());
                    }
                    SqlCon3.Close();
                }
                finally
                {
                    if (SqlCon3.State == ConnectionState.Open)
                    {
                        SqlCon3.Close();
                    }
                }
                #endregion*/

                #region Obtener Victorias de los Equipos
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select nombre, count(resultado) as Victorias from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada + " AND ((resultado = '2-1' and equipoA = nombre) or(resultado = '1-2' and equipoB = nombre) or(resultado = '2-0' and equipoA = nombre) or(resultado = '0-2' and equipoB = nombre)) group by nombre order by Victorias desc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        victoriasEquipo.Add(registro4["Victorias"].ToString());
                        nombresEquipo.Add(registro4["nombre"].ToString());
                    }
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

                #region Obtener Derrotas de los Equipos
                SqlConnection SqlCon5 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon5.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando5 = new SqlCommand("select count(resultado) as Derrotas from Partidos inner join Equipos on ((Equipos.nombre = Partidos.equipoA) or(Equipos.nombre = Partidos.equipoB)) where idCompetencia = " + LigasDisponibles.idCompetenciaSeleccionada + " AND ((resultado = '2-1' and equipoB = nombre) or (resultado = '1-2' and equipoA = nombre) or (resultado = '2-0' and equipoB = nombre) or (resultado = '0-2' and equipoA = nombre)) group by nombre", SqlCon5);
                    SqlCon5.Open();
                    SqlDataReader registro5 = comando5.ExecuteReader();
                    while (registro5.Read())
                    {
                        derrotasEquipo.Add(registro5["Derrotas"].ToString());
                    }
                    SqlCon5.Close();
                }
                finally
                {
                    if (SqlCon5.State == ConnectionState.Open)
                    {
                        SqlCon5.Close();
                    }
                }
                #endregion

                #region Cargar Tabla de Posiciones
                //create datatable and columns,
                DataTable dtable = new DataTable();
                //dtable.Columns.Add(new DataColumn("Column 1"));
                //dtable.Columns.Add(new DataColumn("Column 2"));
                //dtable.Columns.Add(new DataColumn("Column 3"));
                //dtable.Columns.Add(new DataColumn("Column 4"));
                //dtable.Columns.Add(new DataColumn("Column 5"));
                //dtable.Columns.Add(new DataColumn("Column 6"));
                ligas.dgvPartidosFinalizados.RowTemplate.Height = 50;
                ligas.dgvPartidosFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ligas.dgvPartidosFinalizados.RowHeadersVisible = false;
                ligas.dgvPartidosFinalizados.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn col in ligas.dgvPartidosFinalizados.Columns)
                {
                    dtable.Columns.Add(col.Name);
                    col.DataPropertyName = col.Name;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //simple way create object for rowvalues here i have given only 2 add as per your requirement
                object[] RowValues = { "", "", "", "", "", "" };

                //assign values into row object
                int posicion = 1;
                for (int i = 0; i < nombresEquipo.Count; i++)
                {
                    cantPuntos = Convert.ToString(3 * Convert.ToInt32(victoriasEquipo[i]));
                    RowValues[0] = "# " + posicion;
                    //RowValues[1] = logosEquipos[i];
                    RowValues[2] = nombresEquipo[i];
                    RowValues[3] = cantPuntos;
                    RowValues[4] = victoriasEquipo[i];
                    RowValues[5] = derrotasEquipo[i];

                    DataRow dRow;
                    dRow = dtable.Rows.Add(RowValues);

                    dtable.AcceptChanges();

                    posicion = posicion + 1;
                }

                //now bind datatable to gridview... 
                ligas.dgvTablaPosiciones.DataSource = dtable;

                ligas.dgvPartidosFinalizados.Columns["colLogoLigaFin"].Visible = false;
                ligas.dgvPartidosFinalizados.RowTemplate.Height = 30;
                ligas.dgvPartidosFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ligas.dgvPartidosFinalizados.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ligas.dgvPartidosFinalizados.Enabled = true;
                ligas.dgvPartidosFinalizados.ReadOnly = false;
                ligas.dgvPartidosFinalizados.RowHeadersVisible = false;

                foreach (DataGridViewColumn col in ligas.dgvPartidosFinalizados.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                #endregion

                #endregion
            }
            else
            {
                #region Desplazar al Panel de Torneo Finalizado
                if (torneos.panelTorneosFinalizados.Left == 1707 || torneos.panelTorneosFinalizados.Left == 867) //1371 || 694
                {
                    torneos.panelTorneosEnCurso.Visible = false;
                    torneos.panelTorneosEnCurso.Left = 1707;
                    torneos.panelTorneoDisponible.Visible = false;
                    torneos.panelTorneoDisponible.Left = 1707;


                    torneos.panelTorneosFinalizados.Visible = false;
                    torneos.panelTorneosFinalizados.Left = 13;
                    torneos.panelTorneosFinalizados.Visible = true;

                }
                #endregion

                #region Cargar Datos del Torneo

                #region Cargar Nombre del Torneo
                torneos.label3.Text = TorneosDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio del Torneo
                torneos.bunifuDatepicker1.Value = TorneosDisponibles.fechaInicioCompetenciaSeleccionada;
                torneos.bunifuDatepicker1.Enabled = false;
                #endregion

                #region Cargar Fecha Fin del Torneo
                torneos.bunifuDatepicker2.Value = TorneosDisponibles.fechaFinCompetenciaSeleccioada;
                torneos.bunifuDatepicker2.Enabled = false;
                #endregion

                #region Cargar Juego del Torneo
                torneos.bunifuMetroTextbox2.Text = TorneosDisponibles.juegoCompetenciaSeleccionada;
                torneos.bunifuMetroTextbox2.Enabled = false;
                #endregion

                #region Cargar Cantidad de Equipos Inscriptos
                var cantEquipos = "";

                #region Obtener Cantidad Equipos Inscriptos
                SqlConnection SqlCon1 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon1.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando1 = new SqlCommand("select count(*) as cantidadEquipos from Inscripciones where idCompetencia = " + TorneosDisponibles.idCompetenciaSeleccionada, SqlCon1);
                    SqlCon1.Open();
                    SqlDataReader registro = comando1.ExecuteReader();
                    if (registro.HasRows == false) //Si está NO ESTÁ inscripto el Equipo entra acá
                    {

                    }
                    else //Si el equipo ESTÁ inscripto entra acá
                    {

                        while (registro.Read())
                        {
                            cantEquipos = registro["cantidadEquipos"].ToString();
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

                torneos.bunifuMetroTextbox1.Text = cantEquipos;
                torneos.bunifuMetroTextbox1.Enabled = false;
                #endregion

                #endregion

                #region Carga Bracket

                #region Definir Variables a Llenar
                List<string> equipos1 = new List<string>();
                List<string> resultado = new List<string>();
                List<string> equipos2 = new List<string>();
                List<string> partidos = new List<string>();
                #endregion

                #region Obtener Partidos de los Equipos
                SqlConnection SqlCon4 = new SqlConnection();

                try
                {
                    //Establecemos la conexion, el comando y ejecutamos el mismo
                    SqlCon4.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PlataformaProduccion;Integrated Security=True";
                    SqlCommand comando4 = new SqlCommand("select * from Partidos where idCompetencia = " + TorneosDisponibles.idCompetenciaSeleccionada + " order by idPartido asc", SqlCon4);
                    SqlCon4.Open();
                    SqlDataReader registro4 = comando4.ExecuteReader();
                    while (registro4.Read())
                    {
                        equipos1.Add(registro4["equipoA"].ToString());
                        resultado.Add(registro4["resultado"].ToString());
                        equipos2.Add(registro4["equipoB"].ToString());
                    }
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

                #region Validar Partidos Bracket
                if (equipos1.Count >= 1) //equipos1[0] != null
                {
                    torneos.panel30.Visible = true;
                    torneos.label63.Text = equipos1[0];
                    torneos.label62.Text = equipos2[0];
                }
                if (equipos1.Count >= 2) //equipos1[1] != null
                {
                    torneos.panel29.Visible = true;
                    torneos.label61.Text = equipos1[1];
                    torneos.label60.Text = equipos2[1];
                }
                if (equipos1.Count >= 3) //equipos1[2] != null
                {
                    torneos.panel28.Visible = true;
                    torneos.label59.Text = equipos1[2];
                    torneos.label58.Text = equipos2[2];
                }
                if (equipos1.Count >= 4) //equipos1[3] != null
                {
                    torneos.panel27.Visible = true;
                    torneos.label57.Text = equipos1[3];
                    torneos.label56.Text = equipos2[3];
                }
                if (equipos1.Count >= 5) //equipos1[4] != null
                {
                    torneos.panel26.Visible = true;
                    torneos.label55.Text = equipos1[4];
                    torneos.label54.Text = equipos2[4];
                }
                if (equipos1.Count >= 6) //equipos1[5] != null
                {
                    torneos.panel25.Visible = true;
                    torneos.label53.Text = equipos1[5];
                    torneos.label52.Text = equipos2[5];
                }
                if (equipos1.Count >= 7) //equipos1[6] != null
                {
                    torneos.panel24.Visible = true;
                    torneos.label51.Text = equipos1[6];
                    torneos.label50.Text = equipos2[6];
                }
                if (equipos1.Count >= 8) //equipos1[7] != null
                {
                    torneos.panel23.Visible = true;
                    torneos.label49.Text = equipos1[7];
                    torneos.label48.Text = equipos2[7];
                }
                if (equipos1.Count >= 9) //equipos1[8] != null
                {
                    torneos.panel22.Visible = true;
                    torneos.label47.Text = equipos1[8];
                    torneos.label46.Text = equipos2[8];
                }
                if (equipos1.Count >= 10) //equipos1[9] != null
                {
                    torneos.panel21.Visible = true;
                    torneos.label45.Text = equipos1[9];
                    torneos.label44.Text = equipos2[9];
                }
                if (equipos1.Count >= 11) //equipos1[10] != null
                {
                    torneos.panel20.Visible = true;
                    torneos.label43.Text = equipos1[10];
                    torneos.label42.Text = equipos2[10];
                }
                if (equipos1.Count >= 12) //equipos1[11] != null
                {
                    torneos.panel19.Visible = true;
                    torneos.label41.Text = equipos1[11];
                    torneos.label40.Text = equipos2[11];
                }
                if (equipos1.Count >= 13) //equipos1[12] != null
                {
                    torneos.panel18.Visible = true;
                    torneos.label39.Text = equipos1[12];
                    torneos.label38.Text = equipos2[12];
                }
                if (equipos1.Count >= 14) //equipos1[13] != null
                {
                    torneos.panel17.Visible = true;
                    torneos.label37.Text = equipos1[13];
                    torneos.label36.Text = equipos2[13];
                }
                if (equipos1.Count >= 15) //equipos1[14] != null
                {
                    torneos.panel16.Visible = true;
                    torneos.label35.Text = equipos1[14];
                    torneos.label34.Text = equipos2[14];
                }
                if (equipos1.Count >= 15 && (resultado[14] == "2-0" || resultado[14] == "2-1"))
                {
                    torneos.panel16.Visible = true;
                    torneos.label35.Text = equipos1[14];
                    torneos.label35.ForeColor = System.Drawing.Color.GreenYellow;
                    torneos.label34.Text = equipos2[14];
                }
                if (equipos1.Count >= 15 && (resultado[14] == "0-2" || resultado[14] == "1-2"))
                {
                    torneos.panel16.Visible = true;
                    torneos.label35.Text = equipos1[14];
                    torneos.label34.ForeColor = System.Drawing.Color.GreenYellow;
                    torneos.label34.Text = equipos2[14];
                }
                #endregion

                #region Validar Union Partidos Bracket
                if (torneos.panel30.Visible == true && torneos.panel29.Visible == true)
                {
                    torneos.bunifuSeparator20.Visible = true;
                }
                if (torneos.panel28.Visible == true && torneos.panel27.Visible == true)
                {
                    torneos.bunifuSeparator19.Visible = true;
                }
                if (torneos.panel26.Visible == true && torneos.panel25.Visible == true)
                {
                    torneos.bunifuSeparator16.Visible = true;
                }
                if (torneos.panel24.Visible == true && torneos.panel23.Visible == true)
                {
                    torneos.bunifuSeparator15.Visible = true;
                }
                if (torneos.panel22.Visible == true && torneos.panel21.Visible == true)
                {
                    torneos.bunifuSeparator18.Visible = true;
                }
                if (torneos.panel20.Visible == true && torneos.panel19.Visible == true)
                {
                    torneos.bunifuSeparator14.Visible = true;
                }
                if (torneos.panel18.Visible == true && torneos.panel17.Visible == true)
                {
                    torneos.bunifuSeparator17.Visible = true;
                }
                #endregion

                #endregion
            }
        }
    }
}
