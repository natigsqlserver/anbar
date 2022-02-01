using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class GAIME_SATIS_GAYTARMA : DevExpress.XtraBars.Ribbon.RibbonForm
    {

     

        public GAIME_SATIS_GAYTARMA()
        {
            InitializeComponent();
        }

        private void GAIME_SATIS_GAYTARMA_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = false;
            DateTime dateTime = DateTime.UtcNow.Date;       

            dateEdit4.Text = dateTime.ToShortDateString();
            GETKOD();
        }
        private string qeryString = "EXEC   [dbo].[GAIME_SATISI_GAYTARMA] ";


        public void GETKOD()
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
            {

                SqlCommand command = new SqlCommand(qeryString, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //XtraMessageBox.Show(reader[0].ToString());

                        textEdit6.Text = reader[0].ToString();
                        textEdit6.Enabled = false;

                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    XtraMessageBox.Show(ex.Message);
                }
            }

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        public void searchlookupedit()
        {


        }
        private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {


        }
        public static string gaime_satis_details_id;
        private void searchLookUpEdit1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        CRUD_GAIME_SATISI CG = new CRUD_GAIME_SATISI();
        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            //
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                decimal a = Convert.ToDecimal(row[6]);
                decimal y = Convert.ToDecimal(row[7]);

                if (a >= y)
                {
                    int B = Convert.ToInt32(row[0].ToString());
                    if (B > 0)
                    {
                        int x = CG.insert_gaime_satis_gaytarma_proc_(B, Convert.ToDecimal(row[7]),
                            textEdit6.Text.ToString(), Convert.ToDateTime(dateEdit4.Text),memoEdit1.Text.ToString());
                    }

                    gridControl1.DataSource = null;
                    textEdit2.Text = "";
                    textEdit5.Text = "";
                    textEdit1.Text = "";
                    GETKOD();
                }
                else
                {
                    XtraMessageBox.Show("MİQDAR ÇOX OLA BİLMƏZ");
                }
                
            }

        }
        private void clear()
        {
         
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            // clear();
            gaytarilan_siyahi G = new gaytarilan_siyahi();
            G.Show();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            musteri_gaytar MG = new musteri_gaytar(this);
            MG.Show();
        }

        public void data_(string musteri_adi_ , string _emeliyyat_nomre_, string gaime_main_id_,string gaime_nomre_)
        {
            textEdit2.Text = musteri_adi_;
            textEdit5.Text = gaime_nomre_;
            textEdit1.Text = _emeliyyat_nomre_;
            GetallData_id_(gaime_nomre_);
        }
        public void GetallData_id_(string id_)
        {
            
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString = "select  gd.GAIME_SATISI_DETAILS_ID, gm.EMELIIYYAT_NOMRE " +
                    "AS N'SATIŞ ƏMƏLİYYAT №', " +
                     " gm.TARIX AS N'TARİX',ct.SIRKET_ADI AS N'TƏCHİZATÇI ADI' " +
                    " ,md.MEHSUL_ADI AS N'MƏHSUL ADI',gd.SATIS_GIYMETI as " +
                    "'BİR VAHİDİN QİYMƏTİ',gd.MIGDARI -isnull(gdg.migdar,0.00) AS N'MİQDARI'  " +
                    " ,0 AS N'QAYTARILACAQ MİQDAR' " +
                    " from GAIME_SATISI_MAIN gm inner " +
                    " join GAIME_SATISI_DETAILS gd " +
                    " on gm.GAIME_SATISI_MAIN_ID = gd.GAIME_SATISI_MAIN_ID " +
                    " left join " +
                    " ( " +
                    " (select gaime_satis_details_id, sum(isnull(migdar, 0.00)) migdar from gaime_satis_gaytarma " +

                    "  group  by gaime_satis_details_id) ) gdg on gdg.gaime_satis_details_id=gd.GAIME_SATISI_DETAILS_ID " +
                    " inner join MAL_ALISI_DETAILS md on md.MAL_ALISI_DETAILS_ID = gd.MAL_DETAILS_ID " +
                    " inner join MAL_ALISI_MAIN mm on mm.MAL_ALISI_MAIN_ID = md.MAL_ALISI_MAIN_ID " +
                    " inner join COMPANY.TECHIZATCI ct on ct.TECHIZATCI_ID = mm.TECHIZATCI_ID " +
                    " WHERE GM.EMELIIYYAT_NOMRE = @pricepoint " +
                    "  and gd.MIGDARI -isnull(gdg.migdar,0.00)>0 " ;
                   

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricepoint", id_);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }

    }
}