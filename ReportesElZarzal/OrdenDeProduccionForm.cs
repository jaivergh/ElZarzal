using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ReportesElZarzal
{
	public partial class OrdenDeProduccionForm : Form
	{
		public OrdenDeProduccionForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			string numOp = NumOPTxtBox.Text;

			OrdenProduccionReport ordenDeProduccionReport = new OrdenProduccionReport();
			//ProcesosSubreport procesosSubreport = new ProcesosSubreport();
			//InformeComponentesSubreport informeComponentesSubreport = new InformeComponentesSubreport();

			SqlConnection conProcesos = new SqlConnection();
			SqlConnection conComponentes = new SqlConnection();
			SqlConnection conInfEncabezado = new SqlConnection();

			conProcesos.ConnectionString = ConfigurationManager.ConnectionStrings["ConProcesos_OP"].ToString();
			conComponentes.ConnectionString = ConfigurationManager.ConnectionStrings["ConInformeComponentes"].ToString();
			conInfEncabezado.ConnectionString = ConfigurationManager.ConnectionStrings["ConInformeComponentes"].ToString();

			string sqlInfEncabezado = @"SELECT [TIPO_DOC]
									,[NUM_OP]
									,[REF]
									,[NOM_REF]
									,[FECHA_CREACION]
									,[USUARIO]
									,[f851_cant_ordenada_base]
								FROM [ZZL_View_MM_INFORME_COMPONENTES]";

			string sqlComponentes = @"SELECT [TIPO_DOC]
									  ,[NUM_OP]
									  ,[f850_ind_estado]
									  ,[REF]
									  ,[NOM_REF]
									  ,[CANT_REQ]
									  ,[UND_MEDIDA]
									  ,[FECHA]
									  ,[FECHA_CREACION]
									  ,[USUARIO]
									  ,[f120_referencia]
									  ,[f120_descripcion]
									  ,[f851_fecha_inicio]
									  ,[f851_fecha_terminacion]
									  ,[f851_cant_ordenada_base]
								  FROM [dbo].[ZZL_View_MM_INFORME_COMPONENTES]";

			if (numOp != null && numOp != "")
			{
				sqlComponentes += @" WHERE NUM_OP = " + numOp;
				sqlInfEncabezado += @" WHERE NUM_OP = " + numOp;
			}

			sqlInfEncabezado += @" GROUP BY [TIPO_DOC]
									,[NUM_OP]
									,[REF]
									,[NOM_REF]
									,[FECHA_CREACION]
									,[USUARIO]
									,[f851_cant_ordenada_base]";


			string  sqlProcesos = @"SELECT [id_ref]
									  ,[PROCESO]
									  ,[LIMITE_PROCESO]
								  FROM [Procesos_OP]";


			DataSet procesosDS = new DataSet();
			DataSet componentesDS = new DataSet();
			DataSet encabezadoDS = new DataSet();

			SqlDataAdapter procesosAdapter = new SqlDataAdapter(sqlProcesos, conProcesos);
			SqlDataAdapter componentesAdapter = new SqlDataAdapter(sqlComponentes, conComponentes);
			SqlDataAdapter encabezadoAdapter = new SqlDataAdapter(sqlInfEncabezado, conInfEncabezado);

			procesosAdapter.Fill(procesosDS, "Procesos_OP");
			componentesAdapter.Fill(componentesDS, "ZZL_View_MM_INFORME_COMPONENTES");
			encabezadoAdapter.Fill(encabezadoDS, "ZZL_View_MM_INFORME_COMPONENTES");

			DataTable procesosDT = procesosDS.Tables["Procesos_OP"];
			DataTable componenteDT = componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"];
			DataTable encabezadoDT = encabezadoDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"];

			Console.WriteLine("encabezadoDT");
			foreach (DataRow dataRow in encabezadoDT.Rows)
			{
				foreach (var item in dataRow.ItemArray)
				{
					Console.Write(item);
				}
				Console.WriteLine();
			}

			Console.WriteLine("componenteDT");
			foreach (DataRow dataRow in componenteDT.Rows)
			{
				foreach (var item in dataRow.ItemArray)
				{
					Console.Write(item);
				}
				Console.WriteLine();
			}

			Console.WriteLine("procesosDT");
			foreach (DataRow dataRow in procesosDT.Rows)
			{
				foreach (var item in dataRow.ItemArray)
				{
					Console.Write(item);
				}
				Console.WriteLine();
			}
			ordenDeProduccionReport.DataSourceConnections.Clear();
			ordenDeProduccionReport.SetDataSource(componenteDT);
			//procesosSubreport.SetDataSource(procesosDS.Tables["Procesos_OP"]);
			//informeComponentesSubreport.SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);

			//ordenDeProduccionReport.Subreports[0].DataSourceConnections.Clear();
			//ordenDeProduccionReport.Subreports[0].Database.Tables[0].SetDataSource(componenteDT);
			//ordenDeProduccionReport.Subreports[0].Database.Tables[0].SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);
			//ordenDeProduccionReport.Subreports[0].SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);
			ordenDeProduccionReport.Subreports[0].DataSourceConnections.Clear();
			ordenDeProduccionReport.Subreports[0].SetDataSource(procesosDS.Tables["Procesos_OP"]);

			

			//ordenDeProduccionReport.s
			crystalReportViewer1.ReportSource = ordenDeProduccionReport;
			crystalReportViewer1.Refresh();
		}
	}
}
