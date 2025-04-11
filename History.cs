using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoroninEkz
{
    public partial class History : Form
    {
        string connectionString = $"host=localhost;Uid=root;Pwd=;Database=db03;";
        int id = Convert.ToInt32(MainForm.historyid);
        static public string historyid;
        public History()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.ShowDialog();
            this.Close();
        }

        private void History_Load(object sender, EventArgs e)
        {
            GetDate();
        }
        private void GetDate()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection())
                {
                    con.ConnectionString = connectionString;

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand($@"SELECT partnerproductsid, products.name AS 'Продукция', count AS 'Количество продукции', date AS 'Дата' FROM partnerproducts
INNER JOIN `products` ON product = products.article
where partner = {id};", con);
                    cmd.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    dataGridView1.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выводе информации о партнерах.", "Ошибка");
            }
        }
    }
}
