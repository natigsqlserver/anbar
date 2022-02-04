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
        private DataTable dt;
        private SqlDataAdapter da;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
        public static int p_id;
        public POS_LAYOUT_NEW(int user_pos_id)
        {
            InitializeComponent();
            p_id = user_pos_id;
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
        satis_json st = new satis_json();

        private void POS_LAYOUT_NEW_Load(object sender, EventArgs e)
        {
            //   textEdit3.Text = p_id.ToString();
            gridControl1.TabStop = false;
            getuser(p_id);

            st.ins_def_calc();
            DateTime dateTime = DateTime.UtcNow.Date;
            textEdit2.Text = dateTime.ToString();
          
            ///LOAD FORM
            st.del_tr();
            get_emeliyyat_nomre();
        }

        public void get_emeliyyat_nomre()
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "select 'P' +" +
                    "SUBSTRING(emeliyyat_nomre,1,2) +" +
                    " cast((cast(SUBSTRING(emeliyyat_nomre,3,len(emeliyyat_nomre))as int) +1) " +
                    "as nvarchar(20))  col1 from calculation WHERE tr=0";// position column from position table

                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    textEdit1.Text = dr["col1"].ToString();



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //MessageBox.Show("ENTER has been pressed!");
                getall(1, textEdit4.Text.ToString());
                get(textEdit1.Text.ToString());
                get_say_birmal(textEdit4.Text.ToString());
                textEdit4.Text = string.Empty;
                //deyisilmis
               
                get_cem(textEdit1.Text.ToString());
                //textEdit5.Text = string.Empty;
            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }

           

        }


        public void get_cem(string emeliyyat_n)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = " 	select sum(s) as cem " +
                    "from (	select satis_qiymeti*count(*) s " +
                    "from calculation  where  emeliyyat_nomre=@pricePoint 	group by satis_qiymeti	)t";// position column from position table
                cmd.Parameters.AddWithValue("@pricePoint", emeliyyat_n);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["cem"].ToString() == "0.000")
                    {

                    }

                    else
                    {
                        textEdit6.Text = dr["cem"].ToString();
                    }



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }
        public void get(string paramValue)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                //string queryString = "select mal_alisi_details_id,barkod,mehsul_adi,satis_qiymeti,count(*) as say" +
                //    ",satis_qiymeti*count(*) as mebleg " +
                //    "from (select  TOP 100 PERCENT * from calculation order by id desc) " +
                //    "  t  where  emeliyyat_nomre=@pricePoint group by mal_alisi_details_id,barkod,mehsul_adi,satis_qiymeti ";

                string queryString = "select m.mal_alisi_details_id,m.mehsul_adi N'MƏHSUL ADI' " +
        " , count(*) as N'SAY',v.VAHIDLER_NAME N'VAHİDİ',CAST(satis_qiymeti AS decimal(9, 2)) N'SATIŞ QİYMƏTİ', " +  
        " CAST((satis_qiymeti * count(*)) AS decimal(9, 2)) as N'TOPLAM' , " +
        " case " + 
        " when vd.EDV = N'ƏDV 18%' THEN CAST((ROUND((((satis_qiymeti* count(*) )/ 1.18)*0.18),2))  AS decimal(9, 2)) " +
        " WHEN vd.EDV = N'ƏDV-SİZ 0%' THEN 0 " +
        " WHEN vd.EDV = N'SV-2%' THEN CAST(((satis_qiymeti* count(*))*0.02) AS decimal(9, 2)) " +
        " WHEN vd.EDV = N'SV-8%' THEN CAST(((satis_qiymeti* count(*))*0.08 ) AS decimal(9, 2)) " +
        " ELSE 0 END AS N'VERGİ %' " +
                   "  from(select  TOP 100 " +
                   " PERCENT * from calculation order by id desc) " +
                   "  t left join MAL_ALISI_DETAILS m on t.mal_alisi_details_id = m.MAL_ALISI_DETAILS_ID " +
                   "   left join VAHIDLER v on m.VAHID = v.VAHIDLER_ID " +
                   "   left join VERGI_DERECESI vd on vd.EDV_ID = m.VERGI_DERECESI " +
                   "   where emeliyyat_nomre = N'PS-1' group by " +
                   "   m.mal_alisi_details_id,m.BARKOD,m.MEHSUL_ADI,satis_qiymeti, " + 
                   "   v.VAHIDLER_ID,v.VAHIDLER_NAME ,vd.EDV_ID,vd.EDV  ";


                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                gridControl1.DataSource = dt1;


                //gridView1.Columns[0].Visible = false;
                //gridView1.Columns[6].Visible = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        public void get_say_birmal(string barkod)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "exec CALC_SAY_CALCULATION @barkod=@pricepoint";// position column from position table
                cmd.Parameters.AddWithValue("@pricepoint", barkod);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    textEdit10.Text = dr["SAY"].ToString();



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }
        public void getall(int A, string bark)
        {
            int paramValue = A;

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "SELECT * FROM  dbo.POS_SATIS(1,@pricePoint);";// position column from position table
                cmd.Parameters.AddWithValue("@pricePoint", bark);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                   
                    if (string.IsNullOrEmpty(textEdit4.Text.ToString()))
                    {
                        textEdit4.Text = dr["BARKOD"].ToString();

                    }                 ///grid load                              
                    textEdit5.Text = dr["MƏHSUL ADI"].ToString();

                    //  MessageBox.Show(dr["say"].ToString());
                    for (int i = 0; i < Convert.ToInt32(dr["say"]); i++)
                    {
                        st.insert_calculation_data(textEdit1.Text.ToString(), Convert.ToInt32(dr["mal_details_id"].ToString()), dr["BARKOD"].ToString(), dr["MƏHSUL ADI"].ToString(), Convert.ToDecimal(dr["SATIŞ QİYMƏTİ"].ToString()));

                    }



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        public static int dele_migdar_mal_id;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //grid update 
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {

                int paramValue = Convert.ToInt32(dr[0]);
                dele_migdar_mal_id = Convert.ToInt32(dr[0]);
                //textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["satis_qiymeti"].ToString();
                textEdit10.Text = gridView1.GetDataRow(e.FocusedRowHandle)["say"].ToString();
                textEdit9.Text = dr[4].ToString();
                //XtraMessageBox.Show(paramValue.ToString());
                string queryString =
                    "exec CALC_SAY_CALCULATION @MAL_ALISI_DETAILS_ID=@pricePoint ";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@pricePoint", paramValue);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            //            
                            //labelControl5.Text = reader[0].ToString();
                            //textEdit1.Text = reader[1].ToString();
                            //textEdit2.Text = reader[2].ToString();
                            //textEdit4.Text = reader[3].ToString();
                            textEdit10.Text = reader[0].ToString();

                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                }
                //MessageBox.Show(paramValue.ToString());
            }

        }

        private void textEdit10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(textEdit10.Text))
                {
                    
                }
                else
                {
                    int a_ = Convert.ToInt32(textEdit10.Text.ToString());
                    if (a_ > 0 && dele_migdar_mal_id>0)
                    {
                        st.del_migdar_calculation(dele_migdar_mal_id,Convert.ToInt32(textEdit10.Text.ToString()));
                    }
                 //   getall(1, textEdit4.Text.ToString());
                    get(textEdit1.Text.ToString());
                    get_say_birmal(textEdit4.Text.ToString());
                    textEdit4.Text = string.Empty;
                    //deyisilmis

                    get_cem(textEdit1.Text.ToString());

                    textEdit9.Text = "";
                    textEdit10.Text = "";
                    textEdit12.Text = "";
                    textEdit13.Text = "";

                }
               
            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }

        }

        private void textEdit9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(textEdit9.Text))
                {

                }
                else
                {
                    int a_ = Convert.ToInt32(textEdit10.Text.ToString());
                    if (a_ > 0 && dele_migdar_mal_id > 0)
                    {
                        // st.del_migdar_calculation(dele_migdar_mal_id, Convert.ToInt32(textEdit10.Text.ToString()));
                        st.update_satis_giymeti_(dele_migdar_mal_id, Convert.ToDecimal(textEdit9.Text.ToString()));
                    }
                    //   getall(1, textEdit4.Text.ToString());
                    get(textEdit1.Text.ToString());
                    get_say_birmal(textEdit4.Text.ToString());
                    textEdit4.Text = string.Empty;
                    //deyisilmis

                    get_cem(textEdit1.Text.ToString());


                    textEdit9.Text = "";
                    textEdit10.Text = "";
                    textEdit12.Text = "";
                    textEdit13.Text = "";
                }

            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }

        }

        private void textEdit12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(textEdit12.Text))
                {

                }
                else
                {
                    int a_ = Convert.ToInt32(textEdit10.Text.ToString());
                    //if (a_ > 0 && dele_migdar_mal_id > 0)
                    //{
                        // st.del_migdar_calculation(dele_migdar_mal_id, Convert.ToInt32(textEdit10.Text.ToString()));
                        //if (string.IsNullOrEmpty(textEdit12.Text) || string.IsNullOrEmpty(textEdit13.Text))
                        st.pos_guzest_insert_(textEdit1.Text.ToString(),
                            dele_migdar_mal_id, textEdit12.Text.ToString(), textEdit13.Text.ToString());
                    //}
                    //   getall(1, textEdit4.Text.ToString());
                    get(textEdit1.Text.ToString());
                    get_say_birmal(textEdit4.Text.ToString());
                    textEdit4.Text = string.Empty;
                    //deyisilmis

                    get_cem(textEdit1.Text.ToString());


                    textEdit9.Text = "";
                    textEdit10.Text = "";
                    textEdit12.Text = "";
                    textEdit13.Text = "";
                }

            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void textEdit13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(textEdit13.Text))
                {

                }
                else
                {
                    int a_ = Convert.ToInt32(textEdit10.Text.ToString());
                    //if (a_ > 0 && dele_migdar_mal_id > 0)
                    //{
                        // st.del_migdar_calculation(dele_migdar_mal_id, Convert.ToInt32(textEdit10.Text.ToString()));
                        //if (string.IsNullOrEmpty(textEdit12.Text) || string.IsNullOrEmpty(textEdit13.Text))
                            st.pos_guzest_insert_(textEdit1.Text.ToString(),
                                dele_migdar_mal_id, textEdit12.Text.ToString(), textEdit13.Text.ToString());
                    //}
                    //   getall(1, textEdit4.Text.ToString());
                    get(textEdit1.Text.ToString());
                    get_say_birmal(textEdit4.Text.ToString());
                    textEdit4.Text = string.Empty;
                    //deyisilmis

                    get_cem(textEdit1.Text.ToString());


                    textEdit9.Text = "";
                    textEdit10.Text = "";
                    textEdit12.Text = "";
                    textEdit13.Text = "";
                }

            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }
        static TextEdit textboxname;


        private void textEdit9_Click(object sender, EventArgs e)
        {
            textboxname = textEdit9;
        }
        private void textEdit10_Click(object sender, EventArgs e)
        {
            textboxname = textEdit10;
        }

        private void textEdit12_Click(object sender, EventArgs e)
        {
            textboxname = textEdit12;
        }

        private void textEdit13_Click(object sender, EventArgs e)
        {
            textboxname = textEdit13;
        }
        private void textEdit7_Click(object sender, EventArgs e)
        {
            textboxname = textEdit7;
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            
            if (textboxname!=null)
            {
                textboxname.Text = textboxname.Text + "1";
            }
            
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "2";
            }

        }

        private void simpleButton171_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "3";
            }

        }
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "4";
            }

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "5";
            }

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "6";
            }

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "7";
            }

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "8";
            }

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "9";
            }

        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + "0";
            }

        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                textboxname.Text = textboxname.Text + ".";
            }

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (textboxname != null)
            {
                char[] text = textboxname.Text.ToCharArray();
            string text2 = string.Empty;
            for (int i = 0; i < text.Length-1; i++)
            {
                text2 += text[i].ToString();
            }
            textboxname.Text = text2;
             }
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            labelControl1.Focus();
            textboxname = null;
        }
    }
}