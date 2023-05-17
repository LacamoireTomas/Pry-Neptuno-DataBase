using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pry_Neptuno_DataBase
{
    public partial class frmConsulta : Form
    {

        OleDbConnection ConexionDBNeptuno;

        OleDbCommand ComandoDBNeptuno;
        
        OleDbDataReader ComandoDBNeptunoDataReader;
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnConectarme_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionDBNeptuno = new OleDbConnection();
                ConexionDBNeptuno.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Neptuno.accdb";
                ConexionDBNeptuno.Open();

                label1.Text = "Bien ahi";
            }
            catch (Exception exeption)
            {
                label1.Text = "Hubo Un Error" + exeption.Message + exeption.Source;
                
            }

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ComandoDBNeptuno=new OleDbCommand();
                ComandoDBNeptuno.Connection = ConexionDBNeptuno;
                ComandoDBNeptuno.CommandType = CommandType.TableDirect;
                ComandoDBNeptuno.CommandText = "Clientes";

                ComandoDBNeptunoDataReader = ComandoDBNeptuno.ExecuteReader();

                

                    while(ComandoDBNeptunoDataReader.Read()) 
                {
                    dgvTablaClientes.Rows.Add(ComandoDBNeptunoDataReader[0], ComandoDBNeptunoDataReader[1], 
                                ComandoDBNeptunoDataReader[2], ComandoDBNeptunoDataReader[3],
                             ComandoDBNeptunoDataReader[4], ComandoDBNeptunoDataReader[5]
                             , ComandoDBNeptunoDataReader[6], ComandoDBNeptunoDataReader[7], 
                             ComandoDBNeptunoDataReader[8], ComandoDBNeptunoDataReader[9]
                                , ComandoDBNeptunoDataReader[10]);
                }

            }
            catch (Exception error)
            {

                label1.Text = "Bardiaste" +"\n"+ error.Message+ error.Source;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void imgNeptuno_Click(object sender, EventArgs e)
        {

        }
    }
}
