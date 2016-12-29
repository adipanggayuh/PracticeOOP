using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    class Employee
    {
        protected string name { get; set; }
        protected string id { get; set; }
        protected int age { get; set; }
        protected int yearJoined { get; set; }
        protected int totalAbsence { get; set; }

        public Employee(string name, string id)
        {

            this.name = name;
            this.id = id;
        }

        public Employee()
        {

        }

        public virtual long getSalary()
        {
            long standard = 2700000;
            return standard;
        }

        public int getTotalAbsence()
        {

            return totalAbsence;
        }

        public void setTotalAbsence(int totalAbsence)
        {

            this.totalAbsence = totalAbsence;
        }
        public void setTotalAbsence()
        {
            int absen;
            Console.WriteLine("masukkan total absen:");
            int.TryParse(Console.ReadLine(), out absen);

            this.totalAbsence = absen;
        }

        public long getDeductedSalary()
        {
            if (getTotalAbsence() == 0)
            {
                return 0;
            }
            long salaryPerDay = getSalary() / 20;
            return salaryPerDay * getTotalAbsence();
        }

        public long getTotalSalary()
        {
            long totalSalary = getSalary() - getDeductedSalary();
            return totalSalary;
        }
    }
}
