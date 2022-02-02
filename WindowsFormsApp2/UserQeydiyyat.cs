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
    public partial class UserQeydiyyat : DevExpress.XtraEditors.XtraForm
    {
        userParolproc up = new userParolproc();
        public UserQeydiyyat()
        {
            InitializeComponent();
            getall();
        }
       // string ConString = "Data Source=DESKTOP-UB3DILS;Initial Catalog=NewInteko;Integrated Security=True";

        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString = "SELECT * FROM userParol where Ulogin !='Inteko'";
                SqlCommand command = new SqlCommand(queryString, connection);


                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridControl1.DataSource = dt;

                //for (int i = 0; i < 2; i++)
                //{
                //    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                //}

                ////gridView1.Columns[3].OptionsColumn.ReadOnly = true;
                //for (int i = 2; i < 8; i++)
                //{
                //    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var val = checkBox1.Checked ? 1 : 0;
            up.INSERT_user(textEdit1.Text, textEdit2.Text,val,textEdit3.Text.ToString(),textEdit4.Text.ToString(),
                textEdit9.Text.ToString(),textEdit5.Text.ToString(),textEdit6.Text.ToString(),Convert.ToDateTime(dateEdit1.Text),
                textEdit8.Text.ToString());
            getall();
            clear();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                int var;//= Convert.ToInt32(dr[3]);

                if (checkBox1.Checked == true)
                {
                    var = 1;
                }
                else
                {
                    var = 0;
                }
              up.UPDATE_user(Convert.ToInt32(dr[0].ToString()),textEdit1.Text.ToString(), textEdit2.Text.ToString(), var,textEdit3.Text.ToString(),
                  textEdit4.Text.ToString(),textEdit9.Text.ToString(),textEdit5.Text.ToString(),
                  textEdit6.Text.ToString(),Convert.ToDateTime( dateEdit1.Text),textEdit8.Text.ToString());
                getall();
            }
           
        }
        public void clear()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit9.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            dateEdit1.Text = "";
            textEdit8.Text = "";
            checkBox1.Checked = false;
                
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                up.DELETE_user(dr[1].ToString());
                getall();
                clear();
            }
            


        }



            private void UserQeydiyyat_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = true;
         
            textEdit1.TabIndex = 1;
            textEdit2.TabIndex = 2;
            textEdit3.TabIndex = 3;
            textEdit4.TabIndex = 4;
            textEdit9.TabIndex = 5;
            textEdit5.TabIndex = 6;
            textEdit6.TabIndex = 7;
            dateEdit1.TabIndex = 8;
            textEdit8.TabIndex = 9;
            checkBox1.TabIndex = 10;
            simpleButton1.TabIndex = 11;
            simpleButton2.TabIndex=12;
            simpleButton3.TabIndex=13;

            gridView1.Columns[0].Visible = false;
            gridControl1.TabStop = false;
        }
        public static int id_;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
               
                int iu = Convert.ToInt32(dr[3]);
                //  up.UPDATE_user(Convert.ToInt32(dr[0].ToString()),dr[1].ToString(), dr[2].ToString(), var);
                //  XtraMessageBox.Show(iu.ToString());

                textEdit1.Text = dr[1].ToString();//istifadeci adi
                textEdit2.Text = dr[2].ToString();//parol
               // int admin_ = Convert.ToInt32(dr[3].ToString());
                textEdit3.Text = dr[4].ToString();
                textEdit4.Text = dr[5].ToString();
                textEdit9.Text = dr[6].ToString();
                textEdit5.Text = dr[7].ToString();
                textEdit6.Text = dr[8].ToString();
                dateEdit1.Text = dr[9].ToString();
                textEdit8.Text = dr[10].ToString();

                if (iu > 0)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }
    }
}

