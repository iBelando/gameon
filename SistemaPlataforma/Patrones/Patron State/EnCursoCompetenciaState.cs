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
    public class EnCursoCompetenciaState : CompetenciaState
    {
        private Ligas ligas;
        private Torneos torneos;

        public EnCursoCompetenciaState(Ligas ligas)
        {
            this.ligas = ligas;
        }

        public EnCursoCompetenciaState(Torneos torneos)
        {
            this.torneos = torneos;
        }

        public override void Respuesta()
        {
            if (ligas != null)
            {
                #region Desplazar al Panel de Liga En Curso
                ligas.panelLigaDisponible.Visible = false;
                ligas.panelLigaDisponible.Left = 859; //695

                ligas.panelLigaEnCurso.Visible = false;
                ligas.panelLigaEnCurso.Left = 19;
                ligas.panelLigaEnCurso.Visible = true;
                #endregion

                #region Cargar Datos de la Liga

                #region Cargar Nombre de la Liga
                ligas.label1.Text = LigasDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio de la Liga
                ligas.dtpInicio.Value = LigasDisponibles.fechaInicioCompetenciaSeleccionada;
                ligas.dtpInicio.Enabled = false;
                #endregion

                #region Cargar Fecha Fin de la Liga
                ligas.dtpFin.Value = LigasDisponibles.fechaFinCompetenciaSeleccioada;
                ligas.dtpFin.Enabled = false;
                #endregion

                #region Cargar Juego de la Liga
                ligas.txtJuegoLiga.Text = LigasDisponibles.juegoCompetenciaSeleccionada;
                ligas.txtJuegoLiga.Enabled = false;
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

                ligas.txtNumeroEquipos.Text = cantEquipos;
                ligas.txtNumeroEquipos.Enabled = false;
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
                ligas.dgvTablaPosiciones.RowHeadersVisible = false;
                ligas.dgvTablaPosiciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ligas.dgvTablaPosiciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ligas.dgvTablaPosiciones.RowTemplate.Height = 50;
                foreach (DataGridViewColumn col in ligas.dgvTablaPosiciones.Columns)
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

                ligas.dgvTablaPosiciones.Columns["colLogoEquipoEnCurso"].Visible = false;
                ligas.dgvTablaPosiciones.RowTemplate.Height = 30;
                ligas.dgvTablaPosiciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ligas.dgvTablaPosiciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ligas.dgvTablaPosiciones.Enabled = true;
                ligas.dgvTablaPosiciones.ReadOnly = false;
                ligas.dgvTablaPosiciones.RowHeadersVisible = false;

                foreach (DataGridViewColumn col in ligas.dgvTablaPosiciones.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                #endregion

                #endregion
            }
            else
            {
                #region Desplazar al Panel de Torneo En Curso
                torneos.panelTorneoDisponible.Visible = false;
                torneos.panelTorneoDisponible.Left = 867; //694

                torneos.panelTorneosEnCurso.Visible = false;
                torneos.panelTorneosEnCurso.Left = 19;
                torneos.panelTorneosEnCurso.Visible = true;
                #endregion

                #region Cargar Datos del Torneo

                #region Cargar Nombre del Torneo
                torneos.label1.Text = TorneosDisponibles.nombreCompetenciaSeleccionada;
                #endregion

                #region Cargar Fecha Inicio del Torneo
                torneos.dtpInicio.Value = TorneosDisponibles.fechaInicioCompetenciaSeleccionada;
                torneos.dtpInicio.Enabled = false;
                #endregion

                #region Cargar Fecha Fin del Torneo
                torneos.dtpFin.Value = TorneosDisponibles.fechaFinCompetenciaSeleccioada;
                torneos.dtpFin.Enabled = false;
                #endregion

                #region Cargar Juego del Torneo
                torneos.txtJuegoTorneo.Text = TorneosDisponibles.juegoCompetenciaSeleccionada;
                torneos.txtJuegoTorneo.Enabled = false;
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

                torneos.txtNumeroEquipos.Text = cantEquipos;
                torneos.txtNumeroEquipos.Enabled = false;
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
                for (int i = 0; i < equipos1.Count; i++)
                {
                    if (equipos1.Count >= 1) //equipos1[0] != null
                    {
                        torneos.panel1.Visible = true;
                        torneos.label5.Text = equipos1[0];

                        if (equipos2.Count >= 1)
                        {
                            torneos.label4.Text = equipos2[0];
                        }
                        else
                        {
                            torneos.label4.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 2) //equipos1[1] != null
                    {
                        torneos.panel2.Visible = true;
                        torneos.label7.Text = equipos1[1];

                        if (equipos2.Count >= 2)
                        {
                            torneos.label6.Text = equipos2[1];
                        }
                        else
                        {
                            torneos.label6.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 3) //equipos1[2] != null
                    {
                        torneos.panel3.Visible = true;
                        torneos.label9.Text = equipos1[2];

                        if (equipos2.Count >= 3)
                        {
                            torneos.label8.Text = equipos2[2];
                        }
                        else
                        {
                            torneos.label8.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 4) //equipos1[3] != null
                    {
                        torneos.panel4.Visible = true;
                        torneos.label11.Text = equipos1[3];

                        if (equipos2.Count >= 4)
                        {
                            torneos.label10.Text = equipos2[3];
                        }
                        else
                        {
                            torneos.label10.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 5) //equipos1[4] != null
                    {
                        torneos.panel5.Visible = true;
                        torneos.label13.Text = equipos1[4];

                        if (equipos2.Count >= 5)
                        {
                            torneos.label12.Text = equipos2[4];
                        }
                        else
                        {
                            torneos.label12.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 6) //equipos1[5] != null
                    {
                        torneos.panel6.Visible = true;
                        torneos.label15.Text = equipos1[5];

                        if (equipos2.Count >= 6)
                        {
                            torneos.label14.Text = equipos2[5];
                        }
                        else
                        {
                            torneos.label14.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 7) //equipos1[6] != null
                    {
                        torneos.panel7.Visible = true;
                        torneos.label23.Text = equipos1[6];

                        if (equipos2.Count >= 7)
                        {
                            torneos.label22.Text = equipos2[6];
                        }
                        else
                        {
                            torneos.label22.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 8) //equipos1[7] != null
                    {
                        torneos.panel8.Visible = true;
                        torneos.label25.Text = equipos1[7];

                        if (equipos2.Count >= 8)
                        {
                            torneos.label24.Text = equipos2[7];
                        }
                        else
                        {
                            torneos.label24.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 9) //equipos1[8] != null
                    {
                        torneos.panel9.Visible = true;
                        torneos.label17.Text = equipos1[8];

                        if (equipos2.Count >= 9)
                        {
                            torneos.label16.Text = equipos2[8];
                        }
                        else
                        {
                            torneos.label16.Text = "Bye";
                        }
                        
                    }
                    if (equipos1.Count >= 10) //equipos1[9] != null
                    {
                        torneos.panel10.Visible = true;
                        torneos.label19.Text = equipos1[9];
                        
                        if (equipos2.Count >= 10)
                        {
                            torneos.label18.Text = equipos2[9];
                        }
                        else
                        {
                            torneos.label18.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 11) //equipos1[10] != null
                    {
                        torneos.panel11.Visible = true;
                        torneos.label21.Text = equipos1[10];

                        if (equipos2.Count >= 11)
                        {
                            torneos.label20.Text = equipos2[10];
                        }
                        else
                        {
                            torneos.label20.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 12) //equipos1[11] != null
                    {
                        torneos.panel12.Visible = true;
                        torneos.label27.Text = equipos1[11];
                        
                        if (equipos2.Count >= 12)
                        {
                            torneos.label26.Text = equipos2[11];
                        }
                        else
                        {
                            torneos.label26.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 13) //equipos1[12] != null
                    {
                        torneos.panel13.Visible = true;
                        torneos.label29.Text = equipos1[12];
                        
                        if (equipos2.Count >= 13)
                        {
                            torneos.label28.Text = equipos2[12];
                        }
                        else
                        {
                            torneos.label28.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 14) //equipos1[13] != null
                    {
                        torneos.panel14.Visible = true;
                        torneos.label31.Text = equipos1[13];
                        
                        if (equipos2.Count >= 14)
                        {
                            torneos.label30.Text = equipos2[13];
                        }
                        else
                        {
                            torneos.label30.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 15) //equipos1[14] != null
                    {
                        torneos.panel15.Visible = true;
                        torneos.label33.Text = equipos1[14];
                        
                        if (equipos2.Count >= 15)
                        {
                            torneos.label32.Text = equipos2[14];
                        }
                        else
                        {
                            torneos.label32.Text = "Bye";
                        }
                    }
                    if (equipos1.Count >= 16 && (resultado[14] == "2-0" || resultado[14] == "2-1")) //equipos1[14] != null
                    {
                        torneos.panel15.Visible = true;
                        torneos.label33.Text = equipos1[14];
                        torneos.label33.ForeColor = System.Drawing.Color.GreenYellow;
                        torneos.label32.Text = equipos2[14];
                    }
                    if (equipos1.Count >= 16 && (resultado[14] == "0-2" || resultado[14] == "1-2")) //equipos1[14] != null
                    {
                        torneos.panel15.Visible = true;
                        torneos.label33.Text = equipos1[14];
                        torneos.label32.ForeColor = System.Drawing.Color.GreenYellow;
                        torneos.label32.Text = equipos2[14];
                    }
                }

                #endregion

                #region Validar Union Partidos Bracket
                if (torneos.panel1.Visible == true && torneos.panel2.Visible == true)
                {
                    torneos.bunifuSeparator7.Visible = true;
                }
                if (torneos.panel3.Visible == true && torneos.panel4.Visible == true)
                {
                    torneos.bunifuSeparator8.Visible = true;
                }
                if (torneos.panel5.Visible == true && torneos.panel6.Visible == true)
                {
                    torneos.bunifuSeparator11.Visible = true;
                }
                if (torneos.panel7.Visible == true && torneos.panel8.Visible == true)
                {
                    torneos.bunifuSeparator12.Visible = true;
                }
                if (torneos.panel9.Visible == true && torneos.panel10.Visible == true)
                {
                    torneos.bunifuSeparator9.Visible = true;
                }
                if (torneos.panel11.Visible == true && torneos.panel12.Visible == true)
                {
                    torneos.bunifuSeparator13.Visible = true;
                }
                if (torneos.panel13.Visible == true && torneos.panel14.Visible == true)
                {
                    torneos.bunifuSeparator10.Visible = true;
                }
                #endregion

                #endregion

            }

        }
    }
}
