using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice2
{
    public delegate bool IsPromotabaleDelegate(Employee emp);
    public class Program
    {

        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { EMPId = 101, Name = "John", Experience = 6, Salary = 10000 });
            empList.Add(new Employee() { EMPId = 102, Name = "Johnny", Experience = 4, Salary = 40000 });
            empList.Add(new Employee() { EMPId = 103, Name = "Jaanu", Experience = 5, Salary = 30000 });
            empList.Add(new Employee() { EMPId = 104, Name = "Jenny", Experience = 7, Salary = 60000 });
            empList.Add(new Employee() { EMPId = 105, Name = "Jeni", Experience = 3, Salary = 50000 });
            IsPromotabaleDelegate isPromotable = new IsPromotabaleDelegate(PromoteBasedOnExperience);
            IsPromotabaleDelegate isPromotable1 = new IsPromotabaleDelegate(PromoteBasedOnSalary);
            Employee.PromoteEmployees(empList, isPromotable);
            Console.WriteLine("--------------------------");
            Employee.PromoteEmployees(empList, isPromotable1);
            Console.ReadLine();
        }

        public static bool PromoteBasedOnExperience(Employee emp)
        {
            if (emp.Experience > 5)
                return true;
            else
                return false;
        }

        public static bool PromoteBasedOnSalary(Employee emp)
        {
            if (emp.Salary > 40000)
                return true;
            else
                return false;
        }
    }


    public class Employee
    {
        public int EMPId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployees(List<Employee> employees, IsPromotabaleDelegate isEligibleToPromote)
        {
            foreach (Employee emp in employees)
            {
                if (isEligibleToPromote(emp))
                    Console.WriteLine("Congratualations {0}!! You have been promoted!!", emp.Name);
            }
        }
    }
}
