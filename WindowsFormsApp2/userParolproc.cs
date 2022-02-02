using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class userParolproc
    {
        //string ConString = "Data Source=DESKTOP-UB3DILS;Initial Catalog=NewInteko;Integrated Security=True";
        string insertUser = "userParol_insert";
        string updateUser = "userParol_update";
        string deleteUser = "userParol_delete";

        public void INSERT_user(string login, string parol, int admin,string  AD_ ,string EMAILL_ ,string TELEFON_ ,
string  SV_NO_ ,string  UNVAN_ ,DateTime DOGUM_TARIXI_ ,string GAN_GRUPU_ 
)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(insertUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;
            param = cmd.Parameters.Add("@parol", SqlDbType.VarChar);
            param.Value = parol;
            param = cmd.Parameters.Add("@admin", SqlDbType.Int);
            param.Value = admin;
            param = cmd.Parameters.Add("@AD", SqlDbType.NVarChar,100);
            param.Value = AD_;
            param = cmd.Parameters.Add("@EMAILL", SqlDbType.NVarChar, 100);
            param.Value = EMAILL_;
            param = cmd.Parameters.Add("@TELEFON", SqlDbType.NVarChar, 100);
            param.Value = TELEFON_;
            param = cmd.Parameters.Add("@SV_NO", SqlDbType.NVarChar, 100);
            param.Value = SV_NO_;
            param = cmd.Parameters.Add("@UNVAN", SqlDbType.NVarChar, 100);
            param.Value = UNVAN_;
            param = cmd.Parameters.Add("@DOGUM_TARIXI", SqlDbType.Date);
            param.Value = DOGUM_TARIXI_;
            param = cmd.Parameters.Add("@GAN_GRUPU", SqlDbType.NVarChar,100);
            param.Value = GAN_GRUPU_;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_user(int id,string login, string parol, int admin, string AD_, string EMAILL_, string TELEFON_,
string SV_NO_, string UNVAN_, DateTime DOGUM_TARIXI_, string GAN_GRUPU_)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(updateUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = id;
            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;
            param = cmd.Parameters.Add("@parol", SqlDbType.VarChar);
            param.Value = parol;
            param = cmd.Parameters.Add("@admin", SqlDbType.Int);
            param.Value = admin;
            param = cmd.Parameters.Add("@AD", SqlDbType.NVarChar, 100);
            param.Value = AD_;
            param = cmd.Parameters.Add("@EMAILL", SqlDbType.NVarChar, 100);
            param.Value = EMAILL_;
            param = cmd.Parameters.Add("@TELEFON", SqlDbType.NVarChar, 100);
            param.Value = TELEFON_;
            param = cmd.Parameters.Add("@SV_NO", SqlDbType.NVarChar, 100);
            param.Value = SV_NO_;
            param = cmd.Parameters.Add("@UNVAN", SqlDbType.NVarChar, 100);
            param.Value = UNVAN_;
            param = cmd.Parameters.Add("@DOGUM_TARIXI", SqlDbType.Date);
            param.Value = DOGUM_TARIXI_;
            param = cmd.Parameters.Add("@GAN_GRUPU", SqlDbType.NVarChar, 100);
            param.Value = GAN_GRUPU_;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DELETE_user(string login)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(deleteUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
