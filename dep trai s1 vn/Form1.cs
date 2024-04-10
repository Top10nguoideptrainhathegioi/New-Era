using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;

namespace dep_trai_s1_vn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public double calc()
        {
            string typecustomer = cbcustomertype.Text.Trim();
            string member = txtmember.Text.Trim();
            string lastmonth = txtlastmonth.Text.Trim();
            string currentmonth = txtcurrentmonth.Text.Trim();
            double money = 0;
            double usedWater = int.Parse(currentmonth) - int.Parse(lastmonth);
            if (typecustomer == "Household")
            {
                if (!int.TryParse(lastmonth, out _))
                {
                    if (!int.TryParse(lastmonth, out _))
                    {
                        MessageBox.Show("Vui long nhap so ", "Thong bao");
                        return money;
                    }
                    else if (!int.TryParse(currentmonth, out _))
                    {
                        MessageBox.Show("Vui long nhap so ", "Thong bao");
                        return money;
                    }
                    else if (!int.TryParse(member, out _))
                    {
                        MessageBox.Show("Vui long nhap so", "Thong bao");
                        return money;
                    }
                    else if (int.Parse(member) < 1)
                    {
                        MessageBox.Show("So luong thanh vien phai nhieu hon 1", "Thong bao");
                        return money;
                    }
                    else if (int.Parse(currentmonth) - int.Parse(lastmonth) < 0 || int.Parse(lastmonth) < 0 || int.Parse(currentmonth) < 0)
                    {
                        MessageBox.Show("Vui long kiem tra lai hoa don cua ban");
                        return money;
                    }
                    else
                    {
                        double memberUsedWater = usedWater / int.Parse(member);
                        if (memberUsedWater < 0)
                        {
                            //money = 100%
                            money = usedWater * 5973 * 1.1;
                            textBox1.Text = Convert.ToString(money);
                            return money;
                        }
                        else if (memberUsedWater > 10 && memberUsedWater <= 20)
                        {
                            money = usedWater * 7052 * 1.1;
                            textBox1.Text = Convert.ToString(money);
                            return money;
                        }
                        else if (memberUsedWater > 20 && memberUsedWater <= 30)
                        {
                            money = usedWater * 8699 * 1.1;
                            textBox1.Text = Convert.ToString(money);
                            return money;
                        }
                        else
                        {
                            money = usedWater * 15929 * 1.1;
                            textBox1.Text = Convert.ToString(money);
                            return money;
                        }
                    }

                }
                return money;
            }
            // dich vu cong dng
            else if (typecustomer == "Public Services")
            {
                money = usedWater * 9955 * 1.1;
                textBox1.Text = Convert.ToString(money);
                return money;
            }
            //day la don vi sx
            else if (typecustomer == "Production Units")
            {
                money = usedWater * 11615 * 1.1;
                textBox1.Text = Convert.ToString(money);
                return money;
            }
            //neu la business
            else if (typecustomer == "Business Services")
            {
                money = usedWater * 22068 * 1.1;
                textBox1.Text = Convert.ToString(money);
                return money;
            }
            return money;

        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            calc();
            textBox1.Text = ToString(); 
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtmember.Clear();
            txtlastmonth.Clear();
            txtcurrentmonth.Clear();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = txtname.Text;
            item.SubItems.Add(txtcurrentmonth.Text);
            item.SubItems.Add(txtlastmonth.Text);
            item.SubItems.Add(cbcustomertype.Text);
            lstvresult.Items.Add(item);
            btnedit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double WaterBill = calc();
            string customerName = txtname.Text.Trim();
            string customerType = cbcustomertype.Text.Trim();
            string member = txtmember.Text.Trim();
            string currentmonthIndex = txtcurrentmonth.Text.Trim();
            string lastmonthIndex = txtlastmonth.Text.Trim();
            string strWaterBill = Convert.ToString(WaterBill);
            ListViewItem item = new ListViewItem(customerName);
            item.SubItems.Add(currentmonthIndex);
            item.SubItems.Add(member);
            item.SubItems.Add(lastmonthIndex);
            item.SubItems.Add(customerType);
            item.SubItems.Add(strWaterBill);
            lstvresult.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstvresult.View = View.Details;
            lstvresult.Columns.Add("Name", 100);
            lstvresult.Columns.Add("Member", 50);
            lstvresult.Columns.Add("Last Month Index", 150);
            lstvresult.Columns.Add("Current Month Index", 150);
            lstvresult.Columns.Add("Result", 80);
        }

        private void lstvresult_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
