using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Models
{

    public interface IStudentRepository
    {
        List<Student> GetAllStudent();

        Student GetStudentById(int Id);

        void AddStudent(Student obj);
    }

    public class StudentRepository : IStudentRepository
    {
        List<Student> list = new List<Student>();
        public StudentRepository()
        {
            for (int i = 0; i < 2; i++)
            {
                Student obj = new Student();
                obj.Id = i;
                obj.Grade = i;
                obj.FirstName = $"FirstName {i}";
                obj.LastName = $"LastName {i}";
                obj.City = $"City {i}";
                list.Add(obj);
            }
        }
        public void AddStudent(Student obj)
        {
            list.Add(obj);
        }

        public List<Student> GetAllStudent()
        {
            return list;
        }

        public Student GetStudentById(int Id)
        {
            return list.Where(p => p.Id == Id).FirstOrDefault();
        }
    }
}
