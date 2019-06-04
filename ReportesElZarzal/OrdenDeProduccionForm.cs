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

		SqlConnection conProcesos;
		SqlConnection conComponentes;

		public OrdenDeProduccionForm()
		{
			InitializeComponent();


			conProcesos = new SqlConnection();
			conComponentes = new SqlConnection();

			conProcesos.ConnectionString = ConfigurationManager.ConnectionStrings["ConProcesos_OP"].ToString();
			conComponentes.ConnectionString = ConfigurationManager.ConnectionStrings["ConInformeComponentes"].ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RecuperarButton.Enabled = false;

			if (conProcesos.State == ConnectionState.Closed)
				conProcesos.Open();

			if (conComponentes.State == ConnectionState.Closed)
				conComponentes.Open();

			string numOp = NumOPTxtBox.Text;

			if (!int.TryParse(numOp, out int n))
				return;

			OrdenProduccionReport ordenDeProduccionReport = new OrdenProduccionReport();

			

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
									,[f200_razon_social]
								  FROM [dbo].[ZZL_View_MM_INFORME_COMPONENTES]";

			if (numOp != null && numOp != "")
			{
				sqlComponentes += @" WHERE NUM_OP = " + numOp +
									" ORDER BY CANT_REQ DESC";
			} else
			{
				//MessageBox.Show("Atención", "Por favor ingreso un numero de proceso", MessageBoxButtons.OK);
				return;
			}
			


			string  sqlProcesos = @"SELECT [id_ref]
									  ,[PROCESO]
									  ,[LIMITE_PROCESO]
								  FROM [Procesos_OP]";


			
			DataSet componentesDS = new DataSet();

			
			SqlDataAdapter componentesAdapter = new SqlDataAdapter(sqlComponentes, conComponentes);
			
			componentesAdapter.Fill(componentesDS, "ZZL_View_MM_INFORME_COMPONENTES");
			
			DataTable componenteDT = componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"];

			string f120_ref = null;

			if (componenteDT.Rows.Count > 0)

			f120_ref = componenteDT.Rows[0].Field<string>("f120_referencia");

			
			sqlProcesos += @" WHERE id_ref = " + "'" + f120_ref +"'" +
							" ORDER BY CAST(PROCESO as varchar(MAX))";
			

			DataSet procesosDS = new DataSet();

			SqlDataAdapter procesosAdapter = new SqlDataAdapter(sqlProcesos, conProcesos);

			procesosAdapter.Fill(procesosDS, "Procesos_OP");

			DataTable procesosDT = procesosDS.Tables["Procesos_OP"];



			//Console.WriteLine("componenteDT");
			//foreach (DataRow dataRow in componenteDT.Rows)
			//{
			//	foreach (var item in dataRow.ItemArray)
			//	{
			//		Console.Write(item);
			//	}
			//	Console.WriteLine();
			//}

			//Console.WriteLine("procesosDT");
			//foreach (DataRow dataRow in procesosDT.Rows)
			//{
			//	foreach (var item in dataRow.ItemArray)
			//	{
			//		Console.Write(item);
			//	}
			//	Console.WriteLine();
			//}
			ordenDeProduccionReport.DataSourceConnections.Clear();
			ordenDeProduccionReport.SetDataSource(componenteDT);
			//procesosSubreport.SetDataSource(procesosDS.Tables["Procesos_OP"]);
			//informeComponentesSubreport.SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);

			//ordenDeProduccionReport.Subreports[0].DataSourceConnections.Clear();
			//ordenDeProduccionReport.Subreports[0].Database.Tables[0].SetDataSource(componenteDT);
			//ordenDeProduccionReport.Subreports[0].Database.Tables[0].SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);
			//ordenDeProduccionReport.Subreports[0].SetDataSource(componentesDS.Tables["ZZL_View_MM_INFORME_COMPONENTES"]);
			ordenDeProduccionReport.Subreports[0].DataSourceConnections.Clear();
			ordenDeProduccionReport.Subreports[0].SetDataSource(procesosDT);

			

			//ordenDeProduccionReport.s
			crystalReportViewer1.ReportSource = ordenDeProduccionReport;
			crystalReportViewer1.Refresh();
			conComponentes.Close();
			conProcesos.Close();
			RecuperarButton.Enabled = true;
		}

		private void OrdenLabel_Click(object sender, EventArgs e)
		{

		}

		private void NumOPTxtBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
