using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace AutoMapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                PersonId = 123,
                FirstName = "TJ",
                LastName = "Smith",
                DateOfBirth = Convert.ToDateTime("12/8/1972"),
                NickName = "Teej"
            };
            Mapper.CreateMap<Person, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.DateOfBirth));
            var employee = Mapper.Map<Employee>(person);

            Console.WriteLine("employee.EmployeeId = " + employee.EmployeeId);
            Console.WriteLine("employee.FirstName = " + employee.FirstName);
            Console.WriteLine("employee.LastName = " + employee.LastName);
            Console.WriteLine("employee.Dob = " + employee.Dob.ToShortDateString());
            Console.WriteLine("employee.ManagerId = " + employee.ManagerId);
            Console.ReadLine();
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NickName { get; set; }    
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int ManagerId { get; set; }
    }
}
