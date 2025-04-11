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
using MySql.Data.MySqlClient;

namespace VoroninEkz
{

    public partial class MainForm : Form
    {
        public Discount dis = new Discount(); 
        static public float bb = 0;
        static public string id;
        static public string historyid;
        int currentRowIndex;
        string connectionString = $"host=localhost;Uid=root;Pwd=;Database=db03;";
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetDate();
        }
        private void GetDate()
        {
            try
            {
                DataTable finalTable = new DataTable();
                string query = @"
               		SELECT 
					idpartners AS 'idPartners',
                    concat_ws(' ', partnerstype.name, '|' ,partners.name) AS 'Заголовок',
                    director AS 'Директор',
                    phone AS 'Телефон',
                    rating AS 'Рейтинг',
                    IFNULL(SUM(partnerproducts.count), 0) AS 'Всего_покупок'
                FROM db03.partners
                INNER JOIN partnerstype ON partners.partnertypeid = partnerstype.idpartnerstype
                LEFT JOIN partnerproducts ON partners.idpartners = partnerproducts.partner
                GROUP BY partners.idpartners
                "
                ;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    DataTable formatedtable = new DataTable();
                    formatedtable.Columns.Add("idPartners", typeof(int));
                    formatedtable.Columns.Add("Информация о партнёре", typeof(string));
                    formatedtable.Columns.Add("Скидка", typeof(string));

                    foreach (DataRow row in resultTable.Rows)
                    {
                        string header = row["Заголовок"].ToString();
                        string director = row["Директор"].ToString();
                        string number = row["Телефон"].ToString();
                        string rating = row["Рейтинг"].ToString();
                        double totalSales = Convert.ToDouble(row["Всего_покупок"]);

                        double discount = dis.FoundDiscount(totalSales);

                        string partnerinfp = $"{header}\nДиректор: {director}\nТелефон: {number}\nРейтинг: {rating}";

                        formatedtable.Rows.Add(row["idPartners"].ToString(), partnerinfp, $"{discount}%");
                    }
                    finalTable = formatedtable;
                }

                dataGridView1.DataSource = finalTable;
                dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(id);
            this.Visible = false;
            addForm.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) // Убедитесь, что строка выбрана
            {
                int partnerId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["idPartners"].Value.ToString());

                // Открытие формы редактирования
                AddForm addForm = new AddForm(partnerId.ToString(), true); // true указывает, что это редактирование
                this.Visible = false;
                addForm.ShowDialog();
                this.Close();
            }
        }
        private void history(object sender, EventArgs e)
        {
            historyid = dataGridView1.Rows[currentRowIndex].Cells["idpartners"].Value.ToString();
            History history = new History();
            this.Visible = false;
            history.ShowDialog();
            this.Close();
        }
        private void delete(object sender, EventArgs e)
        {
            int idPar = Convert.ToInt32(dataGridView1.Rows[currentRowIndex].Cells["idPartners"].Value.ToString());
            string strCon = connectionString;
            string strCmd = $"DELETE FROM partnerproducts WHERE partner = {idPar}";
            string strCmd2 = $"DELETE FROM `partners` WHERE idpartners = {idPar}";
            using (MySqlConnection con = new MySqlConnection())
            {
                try
                {

                    con.ConnectionString = strCon;

                    con.Open();


                    MySqlCommand cmd = new MySqlCommand(strCmd, con);
                    MySqlCommand cmd2 = new MySqlCommand(strCmd2, con);

                    DialogResult dr = MessageBox.Show("Вы хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int res = cmd.ExecuteNonQuery();
                        int res2 = cmd2.ExecuteNonQuery();
                        MessageBox.Show("Запись успешно удалена!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        GetDate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Удалить", delete));
                    m.MenuItems.Add(new MenuItem("История", history));

                    this.currentRowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                    dataGridView1.Rows[currentRowIndex].Selected = true;

                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
