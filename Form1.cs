using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace FunToGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ResButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            string str = Formula.Text;
            char[] b = str.ToCharArray();
            int length = 0;
            string func = "";
            double a = 0.00;
            DataTable table = new DataTable();
            for (int i = 0; i < b.Length; i++)
            {
                if(b[i]=='x')
                {
                    length = i;
                    break;
                }
            }
            for (int i = 0; i <= 2000; i++)
            {
                if (length != 0)
                {
                    b[length - 1] = Convert.ToChar(i);
                    for (int j = 0; j < b.Length; j++)
                    {
                        func += b[j];
                    }
                }
                else
                {
                    func = Formula.Text;
                }
                a = Convert.ToDouble(table.Compute(func, null));
                chart1.Series[0].Points.AddXY(i, a);
                func = "";
            }
        }
    }
}
