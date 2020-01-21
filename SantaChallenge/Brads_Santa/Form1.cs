using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brads_Santa
{
    public partial class Form1 : Form
    {
        public DataAccess dataAccess;
        public Form1()
        {
            InitializeComponent();
            dataAccess = new DataAccess(@"Provider=Microsoft.Jet.Oledb.4.0;" + @"Data source =C:\Users\jade.kneen\Desktop\Santa_List\santa.mdb");
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            DataTable santaGifts = new DataTable();
            santaGifts = dataAccess.GetSantaVisits();

            dataGridView1.DataSource = santaGifts;
        }
    }
}
