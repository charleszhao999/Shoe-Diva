using System.Data;

namespace Shoe_Diva
{
    public partial class Form1 : Form
    {
        int flag = 0;
        bool[] available = new bool[] { true, true, true, true };
        Image[] imgs;


        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            Image a = pictureBox1.Image;
            Image b = pictureBox2.Image;
            Image c = pictureBox3.Image;
            Image d = pictureBox4.Image;
            imgs = new Image[] { a, b, c, d };
            initItems();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            flag = 0;
            refreshInfo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase(1);
            purchase.Show();
            initItems();
            refreshInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase(2);
            purchase.Show();
            initItems();
            refreshInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase(3);
            purchase.Show();
            initItems();
            refreshInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase(4);
            purchase.ShowDialog();
            initItems();
            refreshInfo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            flag = 1;
            refreshInfo();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag = 2;
            refreshInfo();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            flag = 3;
            refreshInfo();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            flag = 4;
            refreshInfo();
        }
        private void refreshInfo()
        {
            if (flag != 0 && available[flag - 1])
            {
                DataTable shoe = DBHelper.GetDataSet("select * from Shoes where SId=" + flag).Tables[0];
                label2.Text = shoe.Rows[0]["model"].ToString();
                label7.Text = shoe.Rows[0]["origin"].ToString();
                label8.Text = shoe.Rows[0]["prize"].ToString();
                label9.Text = shoe.Rows[0]["inventory"].ToString();
                dataGridView1.DataSource = DBHelper.GetDataSet("select customer from Orders where SId=" + flag).Tables[0];
            }
            else
            {
                label2.Text = "…Ã∆∑œÍ«È";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                dataGridView1.DataSource = null;
            }
        }
        private void initItems()
        {
            PictureBox[] pics = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            Button[] buttons = new Button[] { button1, button2, button3, button4 };
            for (int i = 0; i < 4; i++)
            {
                DataSet ds = DBHelper.GetDataSet("select * from Shoes where SId=" + (i + 1));
                if (ds.Tables[0].Rows.Count == 0)
                {
                    pics[i].Image = Properties.Resources.sold_out;
                    buttons[i].Enabled = false;
                    available[i] = false;
                }
                else
                {
                    pics[i].Image = imgs[i];
                    buttons[i].Enabled = true;
                    available[i] = true;
                }
            }
        }
    }
}