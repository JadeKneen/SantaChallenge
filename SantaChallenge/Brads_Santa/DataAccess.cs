using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brads_Santa
{
    public class DataAccess
    {
        private OleDbConnection conn = new OleDbConnection();

        public DataAccess (string constring) {
            conn.ConnectionString = constring;
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetSantaVisits()
        {
            DataTable results = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT People.Surname, People.FirstName, Addresses.Postcode, Addresses.Town, Gifts.GiftName FROM((Addresses INNER JOIN People ON Addresses.AddressId = People.AddressId) INNER JOIN Presents ON People.PersonId = Presents.PersonId) INNER JOIN Gifts ON Presents.GiftId = Gifts.GiftId; ", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(results);

            return results;
        }
    }
}
