using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Opiskelijat
{
    public partial class Form1 : Form
    {
        // Yhteysmerkkijono (voit k‰ytt‰‰ App.configia tai kovakoodata t‰m‰n)
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Opiskelijat;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load; // Kun lomake ladataan
            buttonlisaa.Click += ButtonLisaa_Click; // Lis‰‰-napin tapahtuma
            buttonPoista.Click += ButtonPoista_Click; // Poista-napin tapahtuma
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOpiskelijat();
            LoadRyhmia();
        }

        // Opiskelijoiden tietojen lataaminen
        private void LoadOpiskelijat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT O.id, O.etunimi, O.sukunimi, R.ryhmannimi " +
                               "FROM Opiskelija O " +
                               "LEFT JOIN Opiskelijaryhma R ON O.ryhma_id = R.id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table; // N‰ytet‰‰n tiedot DataGridViewiss‰
            }
        }

        // Ryhmien lataaminen ComboBoxiin
        private void LoadRyhmia()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, ryhmannimi FROM Opiskelijaryhma";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBoxRyhma.DataSource = table;
                comboBoxRyhma.DisplayMember = "ryhmannimi"; // N‰ytet‰‰n ryhm‰n nimi
                comboBoxRyhma.ValueMember = "id"; // Ryhm‰n ID arvona
            }
        }

        // Opiskelijan lis‰‰minen
        private void ButtonLisaa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEtunimi.Text) || string.IsNullOrWhiteSpace(textBoxSukunimi.Text) || comboBoxRyhma.SelectedValue == null)
            {
                MessageBox.Show("T‰yt‰ kaikki kent‰t ennen lis‰‰mist‰!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Opiskelija (etunimi, sukunimi, ryhma_id) VALUES (@etunimi, @sukunimi, @ryhma_id)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@etunimi", textBoxEtunimi.Text);
                    cmd.Parameters.AddWithValue("@sukunimi", textBoxSukunimi.Text);
                    cmd.Parameters.AddWithValue("@ryhma_id", comboBoxRyhma.SelectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Opiskelija lis‰tty onnistuneesti!");
            LoadOpiskelijat(); // P‰ivitet‰‰n DataGridView
            ClearInputs();
        }

        // Opiskelijan poistaminen
        private void ButtonPoista_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Valitse poistettava opiskelija!");
                return;
            }

            int opiskelijaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Opiskelija WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", opiskelijaId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Opiskelija poistettu onnistuneesti!");
            LoadOpiskelijat(); // P‰ivitet‰‰n DataGridView
        }

        // Syˆttˆkenttien tyhjent‰minen
        private void ClearInputs()
        {
            textBoxEtunimi.Clear();
            textBoxSukunimi.Clear();
            comboBoxRyhma.SelectedIndex = -1;
        }

        private void Sukunimi_Click(object sender, EventArgs e)
        {

        }
    }
}