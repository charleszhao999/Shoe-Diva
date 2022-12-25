using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoe_Diva
{
    public partial class Purchase : Form
    {
        int flag;
        public Purchase(int flag)
        {
            InitializeComponent();
            this.flag = flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请正确输入订单信息！");
            }
            else if (textBox2.Text.Length != 11)
            {
                MessageBox.Show("请输入正确的手机号！");
            }
            else if (int.Parse(DBHelper.GetDataSet("select * from Shoes where SId=" + flag).Tables[0].Rows[0]["inventory"].ToString()) < int.Parse(textBox3.Text))
            {
                MessageBox.Show("库存不足，请重新输入订购量！");
            }
            else
            {
                string sql = "insert into Orders values(" + flag + ",'" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ")";
                DBHelper.execute(sql);
                //使shoes表中的相应商品库存量减去相应的数量
                int num = int.Parse(DBHelper.GetDataSet("select * from Shoes where SId=" + flag).Tables[0].Rows[0]["inventory"].ToString());
                if (num == int.Parse(textBox3.Text))
                {
                    sql = "delete from Shoes where Sid=" + flag;
                    DBHelper.execute(sql);
                }
                else
                {
                    sql = "UPDATE Shoes set inventory=" + num + " WHERE SId=" + flag;
                    DBHelper.execute(sql);
                }
                MessageBox.Show("订单提交成功！");
                this.Close();
            }
        }
    }
}
