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
			OrdenDeProduccionReport ordenDeProduccionReport = new OrdenDeProduccionReport();
			ProcesosSubreport procesosSubreport = new ProcesosSubreport();
			InformeComponentesSubreport informeComponentesSubreport = new InformeComponentesSubreport();

			SqlConnection conProcesos = new SqlConnection();
			conProcesos.ConnectionString = 
		}
	}
}
