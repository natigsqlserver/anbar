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
    public partial class TECHIZATCI_SEC : DevExpress.XtraEditors.XtraForm
    {
        private readonly GAIME_SATISI_LAYOUT frm1;
        public TECHIZATCI_SEC(GAIME_SATISI_LAYOUT frm_)
        {
            InitializeComponent();
            frm1 = frm_;
        }

        private void TECHIZATCI_SEC_Load(object sender, EventArgs e)
        {
            getall();
        }
        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                // Provide the query string with a parameter placeholder.
                string queryString =
                  "SELECT * FROM GAIME_SATIS_SEARCH() ";



                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;

                //gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }
        public static string techizatci_adi;
        public static string mehsul_adi;
        public static string satis_giymeti;
        public static int mal_det_id;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
              

                //  XtraMessageBox.Show(id.ToString());
                techizatci_adi = dr[1].ToString();
                mehsul_adi = dr[3].ToString();
                satis_giymeti = dr[5].ToString();
                mal_det_id = Convert.ToInt32( dr[2].ToString());
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            frm1.techizatci_axtar(techizatci_adi, mehsul_adi, satis_giymeti,mal_det_id);
           // frm1.lookUpEdit8GEtData_yeni(mal_det_id);
            
            this.Close();
        }
    }
}