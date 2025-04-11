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
    public partial class AddForm : Form
    {
        public int typePar;
        string connectionString = $"host=localhost;Uid=root;Pwd=;Database=db03;";
        public AddForm(string id, bool isEdit = false)
        {
            InitializeComponent();
            //LoadPartnerData(id);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            AddComboBox();
        }
        private void LoadPartnerData(string id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = $"SELECT * FROM partners WHERE idpartners = {id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["name"].ToString();
                    textBox2.Text = reader["director"].ToString();
                    textBox3.Text = reader["email"].ToString();
                    textBox4.Text = reader["phone"].ToString();
                    textBox5.Text = reader["address"].ToString();
                    textBox6.Text = reader["rating"].ToString();
                    comboBox1.SelectedItem = reader["partnertypeid"].ToString();
                }
            }
        }
        private void AddComboBox()
        {
            DataTable Rooms = new DataTable();
            using (MySqlConnection coon = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "select name from partnerstype";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(Rooms);
            }

            for (int i = 0; i < Rooms.Rows.Count; i++)
            {
                comboBox1.Items.Add(Rooms.Rows[i]["name"]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены, что хотите добавить?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    {
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "")
                        {
                            string type = comboBox1.Text;
                            string title = textBox1.Text;
                            string direct = textBox2.Text;
                            string email = textBox3.Text;
                            long phone = Convert.ToInt64(textBox4.Text);
                            string address = textBox5.Text;
                            int rating = Convert.ToInt32(textBox6.Text);
                            DataTable Rooms = new DataTable();
                            using (MySqlConnection coon = new MySqlConnection(connectionString))
                            {
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = coon;
                                cmd.CommandText = $@"select idpartnerstype from partnerstype where name = '{type}'";
                                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                                adapter.Fill(Rooms);
                            }

                            for (int i = 0; i < Rooms.Rows.Count; i++)
                            {
                                typePar = Convert.ToInt32(Rooms.Rows[i]["idpartnerstype"]);
                            }

                            string sqlQuery = $@"Insert Into `partners`
(partnertypeid,name,director,email,phone,address,rating)
Values ('{typePar}','{title}','{direct}','{email}','{phone}','{address}','{rating}')";
                            using (MySqlConnection con = new MySqlConnection())
                            {
                                con.ConnectionString = connectionString;
                                con.Open();
                                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
                                int res = cmd.ExecuteNonQuery();

                                if (res == 1)
                                {
                                    MessageBox.Show("Партнер добавлен!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    MessageBox.Show("Партнер не добавлен", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                comboBox1.Text = null;
                                textBox1.Text = null;
                                textBox2.Text = null;
                                textBox3.Text = null;
                                textBox4.Text = null;
                                textBox5.Text = null;
                                textBox6.Text = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.ShowDialog();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}