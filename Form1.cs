using _20;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rand = new Random();
        const int n = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr1 = new int[n*n];
            int[,] arr = new int[n, n];
            int c = 0, sum, d;
            bool fl = true;            
            while (fl)
            {
                arr1[0] = rand.Next(1, 9);
                int l = 1;
                bool flag = true;
                while (l < arr1.Length)
                {
                    do
                    {
                        flag = false;
                        arr1[l] = rand.Next(1, 10);
                        for (int j = l - 1; j >= 0; j--)
                        {
                            if (arr1[l] == arr1[j])
                                flag = true;
                        }
                    }
                    while (flag);
                    l++;
                }
                sum = 0; d = 0; l = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        arr[i, j] = arr1[l++];
                        if (i == j)
                            sum += arr[i, j];
                        if (i + j == n - 1)
                            d += arr[i, j];
                    }
                }
                fl = false;
                int stroka, stolb;
                for (int i = 0; i < n; i++)
                {
                    stolb = 0; stroka = 0;
                    for (int j = 0; j < n; j++)
                    {
                        stroka += arr[i, j];
                        stolb += arr[j, i];
                    }
                    if (stroka != sum || stolb != sum)
                        fl = true;
                }
                if (d != sum)
                    fl = true;
                c++;
            }
            label2.Visible = true;
            label2.Text = "Кол-во генераций: ";
            label1.Text = null;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    label1.Text += String.Format($"{arr[i, j],-5}");
                }
                label1.Text += String.Format("\r\n");
            }
            label2.Text += String.Format($"{c}");            
        }
    }
}