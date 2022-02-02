﻿using DevExpress.XtraEditors;
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

namespace WindowsFormsApp2
{
    public partial class MEHSUL_ALIS_HESABATI : DevExpress.XtraEditors.XtraForm
    {
        public MEHSUL_ALIS_HESABATI()
        {
            InitializeComponent();
        }

        private void MEHSUL_ALIS_HESABATI_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            dateEdit1.Text = dateTime.ToShortDateString();
            dateEdit2.Text = dateTime.ToShortDateString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetallData_id_(Convert.ToDateTime( dateEdit1.Text),Convert.ToDateTime(dateEdit2.Text));
        }

        public void GetallData_id_(DateTime D1_, DateTime D2_)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString =
                    "EXEC MEHSUL_ALIS_HESABAT  @d1 = @pricepoint  ,@d2=@pricepoint1 ";



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricepoint", D1_);
                command.Parameters.AddWithValue("@pricepoint1", D2_);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;

            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }
    }
}