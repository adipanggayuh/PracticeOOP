using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    interface ISalary
    {
        void GetTahunKerjaSemua();
        int GetTahunKerja(int tahunkerja);
        void GetSalaryTahunanSemua();
        long GetSalaryTahunan(long salary);
        double GetBonus(int totalKerja, long salaryTahunan);
        void GetBonusTotal();
        void GetId();
        void GetEachSalary(string id);
    }
}
