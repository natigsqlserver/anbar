using DevExpress.XtraEditors;
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
    public partial class POS_LAYOUT_NEW : DevExpress.XtraEditors.XtraForm
    {
        public static int p_id;
        public POS_LAYOUT_NEW(int user_pos_id)
        {
            InitializeComponent();
            p_id = user_pos_id;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {

        }
        public void getuser(int x_id)
        {
            //YEKUN_MEBLEG 

            string queryString = " select AD  from userParol where id =@pricePoint3";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

           
            command.Parameters.AddWithValue("@pricePoint3", x_id);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit3.Text = dr[0].ToString();
            }
            connection.Close();
        }

        private void POS_LAYOUT_NEW_Load(object sender, EventArgs e)
        {
            //   textEdit3.Text = p_id.ToString();
            getuser(p_id);
        }
    }
}