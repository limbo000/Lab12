using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form2 : Form
    {
        private List<string> students;
        private List<string> subjects;
        private Dictionary<string, List<int>> grades;

        public Form2(List<string> students, List<string> subjects, Dictionary<string, List<int>> grades)
        {
            InitializeComponent();
            this.students = students;
            this.subjects = subjects;
            this.grades = grades;
            DisplayResults();
        }
        private decimal CalculateQualityOfKnowledge()
        {
            int totalStudents = students.Count;
            int excellentStudents = grades.Count(g => g.Value.All(v => v >= 4));
            return totalStudents > 0 ? (decimal)excellentStudents / totalStudents * 100 : 0;
        }

        private decimal CalculatePassRate()
        {
            int totalStudents = students.Count;
            int passedStudents = grades.Count(g => g.Value.All(v => v >= 3));
            return totalStudents > 0 ? (decimal)passedStudents / totalStudents * 100 : 0;
        }

        private int CountExcellentStudents()
        {
            return grades.Count(g => g.Value.All(v => v == 5));
        }


        private void DisplayResults()
        {
            foreach (var student in students)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = students.IndexOf(student) + 1;
                row.Cells[1].Value = student;

                for (int i = 0; i < subjects.Count; i++)
                {
                    row.Cells[i + 2].Value = grades[student][i];
                }

                dataGridView1.Rows.Add(row);
            }

            // Вычисляем и отображаем результаты
            decimal qualityOfKnowledge = CalculateQualityOfKnowledge();
            decimal passRate = CalculatePassRate();
            int excellentCount = CountExcellentStudents();

            MessageBox.Show($"Качество знаний: {qualityOfKnowledge:F2}%\n" +
                            $"Процент успеваемости: {passRate:F2}%\n" +
                            $"Количество отличников: {excellentCount}");
        }

        public decimal GetQualityOfKnowledge()
        {
            return CalculateQualityOfKnowledge();
        }

        public decimal GetPassRate()
        {
            return CalculatePassRate();
        }

        public int GetExcellentStudentsCount()
        {
            return CountExcellentStudents();
        }

        // В Form2 добавьте параметры в конструктор
        public Form2(List<string> students, List<string> subjects, Dictionary<string, List<int>> grades, decimal quality, decimal passRate, int excellentCount)
        {
            InitializeComponent();
            this.students = students;
            this.subjects = subjects;
            this.grades = grades;
            // Используйте переданные параметры
            MessageBox.Show($"Качество знаний: {quality:F2}%\n" +
            $"Процент успеваемости: {passRate:F2}%\n" +
            $"Количество отличников: {excellentCount}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



