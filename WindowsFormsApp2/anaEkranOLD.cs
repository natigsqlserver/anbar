﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class anaEkranOLD : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        bool mouseDown;
        private Point offset;



        public anaEkranOLD()
        {

            InitializeComponent();
            simpleButton26.Visible = admin_control.check;

            
            //avtorizasiya av = new avtorizasiya();
            //av.Show();
        }



        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UserQeydiyyat uq = new UserQeydiyyat();
            uq.Show();
        }

        ///
        RibbonForm2 fr;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //    this.Hide();


            if (Application.OpenForms["RibbonForm2"] != null)
            {
                var Main = Application.OpenForms["RibbonForm2"] as RibbonForm2;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                fr = new RibbonForm2();
                fr.Show();
            }




        }
        Magaza m;
        private void simpleButton7_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["Magaza"] != null)
            {
                var Main = Application.OpenForms["Magaza"] as Magaza;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                m = new Magaza();
                m.Show();
            }
         
        }
        Anbar a;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Anbar"] != null)
            {
                var Main = Application.OpenForms["Anbar"] as Anbar;
                if (Main != null)
                {

                }
                //    Main.Close();
            }
            else
            {
                a = new Anbar();
                a.Show();
            }
        }
        TECHİZATCİ frt;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TECHİZATCİ"] != null)
            {
                var Main = Application.OpenForms["TECHİZATCİ"] as TECHİZATCİ;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                frt = new TECHİZATCİ();
                frt.Show();
            }

        }
        MÜŞTƏRİLƏR MS;
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["MUSTERILER"] != null)
            {
                var Main = Application.OpenForms["MUSTERILER"] as MÜŞTƏRİLƏR;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                MS = new MÜŞTƏRİLƏR();
                MS.Show();
            }
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

      

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        MEHSUL_ALISI_LAYOUT MA;
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["MEHSUL_ALISI_LAYOUT"] != null)
            {
                var Main = Application.OpenForms["MEHSUL_ALISI_LAYOUT"] as MEHSUL_ALİSİ;
                if (Main != null)
                {
                    //
                }
                   // Main.Close();
            }
            else
            {
                MA = new MEHSUL_ALISI_LAYOUT();
                MA.Show();
            }
        }
        MEHSUL_GAYTARMA MG;
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["MEHSUL_GAYTARMA"] != null)
            {
                var Main = Application.OpenForms["MEHSUL_GAYTARMA"] as MEHSUL_GAYTARMA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                MG = new MEHSUL_GAYTARMA();
                MG.Show();

            }
        }

        GAIME_SATISI_LAYOUT GS;
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["GAIME_SATISI_LAYOUT"] != null)
            {
                var Main = Application.OpenForms["GAIME_SATISI_LAYOUT"] as GAIME_SATISI;
                if (Main != null)
                {

                }
                 //   Main.Close();
            }
            else
            {
                GS = new GAIME_SATISI_LAYOUT();
                GS.Show();

            }

        }
        GAIME_SATIS_GAYTARMA GST;
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["GAIME_SATIS_GAYTARMA"] != null)
            {
                var Main = Application.OpenForms["GAIME_SATIS_GAYTARMA"] as GAIME_SATIS_GAYTARMA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                GST = new GAIME_SATIS_GAYTARMA();
                GST.Show();

            }


        }
        ANBARDAN_ANBARA AB;
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["ANBARDAN_ANBARA"] != null)
            {
                var Main = Application.OpenForms["ANBARDAN_ANBARA"] as ANBARDAN_ANBARA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                AB = new ANBARDAN_ANBARA();
                AB.Show();

            }

        }
        ANBARDAN_OBYEKTE AO;
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["ANBARDAN_OBYEKTE"] != null)
            {
                var Main = Application.OpenForms["ANBARDAN_OBYEKTE"] as ANBARDAN_OBYEKTE;
                if (Main != null)
                {

                }
                 //   Main.Close();
            }
            else
            {
                AO = new ANBARDAN_OBYEKTE();
                AO.Show();

            }

        }
        OBYEKTDEN_ANBARA OAT;
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["OBYEKTDEN_ANBARA"] != null)
            {
                var Main = Application.OpenForms["OBYEKTDEN_ANBARA"] as OBYEKTDEN_ANBARA;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                OAT = new OBYEKTDEN_ANBARA();
                OAT.Show();

            }
        }
           
        TECHIZATCI_ODENISI TO;
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["TECHIZATCI_ODENISI"] != null)
            {
                var Main = Application.OpenForms["TECHIZATCI_ODENISI"] as TECHIZATCI_ODENISI;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                TO = new TECHIZATCI_ODENISI();
                TO.Show();

            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Sistemdə bankla inteqrasiya mövcud deyildir.(Servis xidmətinə müraciət edin)");
            //BANK_ODENİS n = new BANK_ODENİS();
            //n.Show();
        }
        POS p;
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["POS"] != null)
            {
                var Main = Application.OpenForms["POS"] as POS;
                if (Main != null)
                {

                }
                //    Main.Close();
            }
            else
            {
                p = new POS();
                p.Show();

            }
        }
        TENZIMLEME T;
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TENZIMLEME"] != null)
            {
                var Main = Application.OpenForms["TENZIMLEME"] as TENZIMLEME;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                T = new TENZIMLEME();
                T.Show();

            }

        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void dropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void dropDownButton6_Click(object sender, EventArgs e)
        {

        }
    }
}