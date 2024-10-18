using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form3 : Form
    {
        private List<string> students;
        private Dictionary<string, List<int>> grades;

        public Form3(List<string> students, Dictionary<string, List<int>> grades)
        {
            InitializeComponent();
            this.students = students;
            this.grades = grades;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Index", "№");
            dataGridView1.Columns.Add("Student", "Студент");
            dataGridView1.Columns.Add("Stipend", "Стипендия");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal minStipend = decimal.Parse(textBox1.Text);
            decimal highStipend = decimal.Parse(textBox2.Text);
            List<string> stipendResults = new List<string>();

            dataGridView1.Rows.Clear(); // Очищаем предыдущие результаты

            foreach (var student in students)
            {
                int excellentCount = grades[student].Count(g => g == 5);
                decimal stipend = excellentCount > 0 ? highStipend : minStipend;
                stipendResults.Add($"{student}: {stipend}");
            }

            foreach (var result in stipendResults)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                var parts = result.Split(':');
                row.Cells[0].Value = stipendResults.IndexOf(result) + 1;
                row.Cells[1].Value = parts[0];
                row.Cells[2].Value = parts[1].Trim();
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
