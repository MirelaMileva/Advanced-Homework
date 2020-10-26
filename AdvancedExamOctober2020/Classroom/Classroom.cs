using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom()
        {
            students = new List<Student>();
        }

        public Classroom(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }
        public int Capacity { get; set; }

        public int Count
            => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count + 1 <= this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";

        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";

        }

        public string GetSubjectInfo(string subject)
        {
            Student[] studentsBySubject = this.students.Where(s => s.Subject == subject).ToArray();

            if (studentsBySubject.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var currStudent in studentsBySubject)
                {
                    sb.AppendLine($"{currStudent.FirstName} {currStudent.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }

        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                return student;
            }

            return null;
        }
    }
}
