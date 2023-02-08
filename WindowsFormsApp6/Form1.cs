using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

            List<Book> books = new List<Book>
            {
                 new Book
                 {
                      Author="Napoleon Hill",
                      Title="The Low of Success",
                       Genre="Self Improvement"
                 },
                 new Book
                 {
                     Author="Robert Kiyosoki",
                     Title="Cash Flow",
                     Genre="Self Improvement"
                 },
                 new Book
                 {
                     Author="Albahari",
                     Title="C# Nutshell",
                     Genre="Software"
                 }
            };

            comboBox1.DisplayMember = nameof(Book.Title);
            comboBox1.Items.AddRange(books.ToArray());
            comboBox1.SelectedIndex = 0;

            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                Color color = Color.FromKnownColor(knowColor);
                comboBox2.Items.Add(color);
            }





            List<string> todos = new List<string>
            {
                "Read Book",
                "Drink Coffee",
                "Write Code",
                "Write more Code",
                "Play Tennis"
            };

            checkedListBox1.Items.AddRange(todos.ToArray());

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var list = checkedListBox1.Items;
            for (int i = 0; i < list.Count; i++)
            {
                var hasExists = checkedListBox1.CheckedItems.Contains(list[i]);
                if(hasExists)
                checkedListBox1.Items.Remove(list[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var color = (Color)comboBox2.SelectedItem;
            this.BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
        }
    }
}
