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
    public partial class gaytarilan_siyahi : DevExpress.XtraEditors.XtraForm
    {
        public gaytarilan_siyahi()
        {
            InitializeComponent();
        }

        private void gaytarilan_siyahi_Load(object sender, EventArgs e)
        {
            //   getall();

            DateTime dateTime = DateTime.UtcNow.Date;

            dateEdit1.Text = dateTime.ToShortDateString();
            dateEdit2.Text = dateTime.ToShortDateString();
        }

        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                // Provide the query string with a parameter placeholder.
                string queryString =
                  " select gd.TARIX as N'SATIŞ TARİXİ', gd.EMMELIYYAT_NOMRE N'SATIŞ №'  ,  " +
                  " md.MEHSUL_ADI N'MƏHSUL ADI',gd.MIGDARI N'SATILAN MİQDAR',gm.tarix_ N'QAYTARILMA TARİXİ' , " +
                  " gm.emeliyyat_nomre N'QAYTARMA  № ', " +
                   " gm.migdar N'QAYTARILMIŞ MİQDAR' " +
                  " from gaime_satis_gaytarma gm " +
                    " inner  join GAIME_SATISI_DETAILS gd " +
                    "on gd.GAIME_SATISI_DETAILS_ID = gm.gaime_satis_details_id " +
                    " inner  join MAL_ALISI_DETAILS md on md.MAL_ALISI_DETAILS_ID = gd.MAL_DETAILS_ID ";



                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                //gridView1.Columns[0].Visible = false;

                //gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }

        public void getall_date_(DateTime d1,DateTime d2)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                // Provide the query string with a parameter placeholder.
                string queryString =
                  " select gd.TARIX as N'SATIŞ TARİXİ', gd.EMMELIYYAT_NOMRE N'SATIŞ №' ,  ct.SIRKET_ADI as  N'TƏCHİZATÇI ADI' ,  " +
                  " md.MEHSUL_ADI N'MƏHSUL ADI',gd.MIGDARI N'SATILAN MİQDAR',gm.tarix_ N'QAYTARILMA TARİXİ' , " +
                  " gm.emeliyyat_nomre N'QAYTARMA  № ', " +
                   " gm.migdar N'QAYTARILMIŞ MİQDAR' " +
                  " from gaime_satis_gaytarma gm " +
                    " inner  join GAIME_SATISI_DETAILS gd " +
                    "on gd.GAIME_SATISI_DETAILS_ID = gm.gaime_satis_details_id " +
                    " inner  join MAL_ALISI_DETAILS md on md.MAL_ALISI_DETAILS_ID = gd.MAL_DETAILS_ID " +
                   " inner join MAL_ALISI_MAIN mm on mm.MAL_ALISI_MAIN_ID = md.MAL_ALISI_MAIN_ID " +

                   "  inner join COMPANY.TECHIZATCI ct on ct.TECHIZATCI_ID = mm.TECHIZATCI_ID " +
                    "  AND gm.tarix_ between @pricePoint and @pricePoint1 ";



                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", d1);
                command.Parameters.AddWithValue("@pricePoint1", d2);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                //gridView1.Columns[0].Visible = false;

                //gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            getall_date_(Convert.ToDateTime(dateEdit1.Text), Convert.ToDateTime(dateEdit2.Text));
        }
    }
}