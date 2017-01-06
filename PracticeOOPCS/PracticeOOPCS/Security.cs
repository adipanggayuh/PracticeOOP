using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    class Security : Employee, ISalary
    {
        List<Security> securitys = new List<Security>();
        public override long getSalary()
        {
            long salary = base.getSalary() + 150000;
            return salary;
        }

        public void InputDataSecurity()
        {
            Console.Write("Lanjutkan? (Y/N) :");
            string opsi = Console.ReadLine();
            if (opsi == "Y" || opsi == "y")
            {
                DaftarAksi();
            }
            else if (opsi == "N" || opsi == "n")
            {
                Environment.Exit(0);
            }
        }

        private void SetDataSecurity()
        {
            int jum;
            Console.WriteLine("Masukkan Jumlah security : ");
            int.TryParse(Console.ReadLine(), out jum);
            for (int i = 1; i <= jum; i++)
            {
                Console.WriteLine("===============");
                Console.WriteLine("security No. " + i);

                Security securityinfo = InputSecurity();

                securitys.Add(securityinfo);

            }
        }

        private void DaftarAksi()
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("======MAIN MENU=====");
            Console.WriteLine("====================");
            Console.WriteLine("1. Input daftar security");
            Console.WriteLine("2. Lihat daftar security");
            Console.WriteLine("3. Lihat Tahun Kerja Semua security");
            Console.WriteLine("4. Lihat Gaji Tahunan");
            Console.WriteLine("5. Lihat Bonus ");
            Console.WriteLine("6. Lihat Gaji perbulan ");
            Console.WriteLine("7. Keluar ");
            Console.WriteLine("================");
            Console.WriteLine("Masukkan Pilihan Anda: ");
            int pilihan;
            int.TryParse(Console.ReadLine(), out pilihan);
            if (pilihan == 1) { this.SetDataSecurity(); }
            else if (pilihan == 2) { this.Getsecurity(); }
            else if (pilihan == 3) { this.GetTahunKerjaSemua(); }
            else if (pilihan == 4) { this.GetSalaryTahunanSemua(); }
            else if (pilihan == 5) { this.GetBonusTotal(); }
            else if (pilihan == 6) { this.GetId(); }
            else
            {
                return;
            }
            Console.WriteLine("Lanjutkan? (Y/N) :");
            string opsi = Console.ReadLine();
            if (opsi == "Y" || opsi == "y")
            {
                DaftarAksi();
            }
            else if (opsi == "N" || opsi == "n")
            {
                Environment.Exit(0);
            }

        }

        public Security InputSecurity()
        {
            Security security = new Security();
            int umur;
            int tahun;
            Console.Clear();
            Console.WriteLine("** Input Informasi security **");

            Console.Write("Nama         : ");
            security.name = Console.ReadLine();
            Console.Write("Id           : ");
            security.id = Console.ReadLine();
            Console.Write("Umur         : ");
            int.TryParse(Console.ReadLine(), out umur);
            security.age = umur;
            Console.Write("Tahun Bergabung  : ");
            int.TryParse(Console.ReadLine(), out tahun);
            security.yearJoined = tahun;
            return security;

        }

        public void Getsecurity()
        {
            Console.WriteLine("===============");
            Console.WriteLine("list security: ");
            if (securitys.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Security rec in securitys)
                {
                    Console.WriteLine("-" + rec.name);

                }
            }

        }

        public void GetTahunKerjaSemua()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Tahun bekerja security: ");
            if (securitys.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Security rec in securitys)
                {
                    Console.WriteLine("-" + rec.name);
                    int totalKerja = GetTahunKerja(rec.yearJoined);
                    Console.WriteLine("Total Kerja : " + totalKerja + " Tahun");
                }
            }

        }

        public int GetTahunKerja(int tahunkerja)
        {
            int tahunIni = DateTime.Now.Year;
            int totalKerja = tahunIni - tahunkerja;
            return totalKerja;
        }

        public void GetSalaryTahunanSemua()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Gaji setahun security: ");
            if (securitys.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {

                foreach (Security rec in securitys)
                {
                    Console.WriteLine("-" + rec.name);
                    long gajiTotal = GetSalaryTahunan(rec.getSalary());
                    Console.WriteLine("Total gaji setahun : " + gajiTotal);
                }
            }
        }

        public long GetSalaryTahunan(long salary)
        {
            long gajiTotal = salary * 12;
            return gajiTotal;
        }

        public double GetBonus(int totalKerja, long salaryTahunan)
        {

            if (totalKerja <= 1) { return salaryTahunan * 5 / 100; }
            else if (totalKerja == 2) { return salaryTahunan * 10 / 100; }
            else if (totalKerja > 2 && totalKerja <= 5) { return salaryTahunan * 15 / 100; }
            return salaryTahunan * 20 / 100;
        }

        public void GetBonusTotal()
        {
            Console.WriteLine("===============");
            Console.WriteLine("bonus: ");
            if (securitys.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Security rec in securitys)
                {
                    Console.WriteLine("-" + rec.name);
                    long gaji = GetSalaryTahunan(rec.getSalary());
                    int tahun = GetTahunKerja(rec.yearJoined);
                    double bonus = GetBonus(tahun, gaji);
                    Console.WriteLine("bonus : " + bonus);
                }
            }
        }


        public void GetId()
        {
            if (securitys.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                Console.WriteLine("Masukkan Id: ");
                string id = Console.ReadLine();
                GetEachSalary(id);
            }

        }
        public void GetEachSalary(string id)
        {

            foreach (Security rec in securitys)
            {
                if (rec.id == id)
                {

                    Console.WriteLine("Hitung Gaji Aktual? (Y/N) :");
                    string opsi = Console.ReadLine();
                    if (opsi == "Y" || opsi == "y")
                    {
                        rec.setTotalAbsence();
                        Console.WriteLine("Nama security : " + rec.name);
                        Console.WriteLine("Gaji Pokok: " + getSalary());
                        long totalSalary = rec.getTotalSalary();
                        Console.WriteLine("Gaji Aktual: " + totalSalary);
                    }
                    else if (opsi == "N" || opsi == "n")
                    {
                        return;
                    }
                }
            }
        }
    }
}
