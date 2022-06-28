using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Save_Data_To_Cloud
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("");
        public Register()
        {
            InitializeComponent();
        }

        private void resetB_Click(object sender, EventArgs e)
        {
            resetX();
        }

        private void resetX()
        {
            fnameT.Clear();
            lnameT.Clear();
            emailT.Clear();
            addressRtxb.Clear();
            genderCmb.SelectedIndex = -1;
            ageS.Value = 0;
            saRd.Checked = false;
            nonRd.Checked = false;

            fnameT.Focus();

        }

        private void saveB_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("", con);
                try
                {
                    com.ExecuteNonQuery();
                    resetX();

                }
                catch (Exception exx)
                {

                    MessageBox.Show("Failed to save to the database\n\n" + exx.Message);
                }

                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to connect to the database\n\n" + ex.Message);
            }

        }
    }
}
