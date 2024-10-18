using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        private List<string> students = new List<string>();
        private List<string> subjects = new List<string>();
        private Dictionary<string, List<int>> grades = new Dictionary<string, List<int>>();
        private Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeGroups();
            DisplayGroups();
            InitializeStudents();
        }

        private void InitializeGroups()
        {
            groups.Add("Группа A", new List<string>());
            groups.Add("Группа B", new List<string>());
        }

        private void DisplayGroups()
        {
            comboBox1.Items.Clear();
            foreach (var group in groups.Keys)
            {
                comboBox1.Items.Add(group);
            }
        }

        private void InitializeStudents()
        {
            grades.Add("Иванов И.И.", GenerateRandomGrades());
            grades.Add("Петров П.П.", GenerateRandomGrades());
            grades.Add("Сидоров С.С.", GenerateRandomGrades());
            grades.Add("Кузнецов К.К.", GenerateRandomGrades());
            grades.Add("Смирнов С.С.", GenerateRandomGrades());

            foreach (var student in grades.Keys)
            {
                if (student.StartsWith("Иван") || student.StartsWith("Сидоров"))
                {
                    groups["Группа A"].Add(student);
                }
                else
                {
                    groups["Группа B"].Add(student);
                }
                students.Add(student);
            }
        }

        private List<int> GenerateRandomGrades()
        {
            return new List<int>
            {
                random.Next(2, 6),
                random.Next(2, 6),
                random.Next(2, 6)
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string group = comboBox1.Text;
            string studentName = textBoxStudentName.Text;

            if (!string.IsNullOrWhiteSpace(group) && !string.IsNullOrWhiteSpace(studentName))
            {
                if (groups[group].Count < 5)
                {
                    students.Add(studentName);
                    groups[group].Add(studentName);
                    grades.Add(studentName, GenerateRandomGrades());
                    MessageBox.Show($"Студент {studentName} добавлен в группу {group}.");
                }
                else
                {
                    MessageBox.Show($"Группа {group} уже заполнена.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите группу и введите имя студента.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subjects.Clear();
            subjects.Add("История");
            subjects.Add("Информатика");
            subjects.Add("Правоведение");
            MessageBox.Show("Предметы добавлены: " + string.Join(", ", subjects));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Случайные оценки уже присвоены при инициализации студентов.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 resultsForm = new Form2(students, subjects, grades);
            resultsForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 stipendForm = new Form3(students, grades);
            stipendForm.Show();
        }
    }
}
