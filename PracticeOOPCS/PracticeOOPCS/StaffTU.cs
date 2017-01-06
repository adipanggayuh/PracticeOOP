using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    class StaffTU : Employee, ISalary
    {
        List<StaffTU> staffTUs = new List<StaffTU>();
        public StaffTU(string newName, string newId) : base(newName, newId)
        {
            this.name = name;
            this.id = id;
        }

        public StaffTU()
        {

        }

        public override long getSalary()
        {
            long salary = base.getSalary() + 150000;
            return salary;
        }

        public void InputDataStaffTU()
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

        private void SetDataStaffTU()
        {
            int jum;
            Console.WriteLine("Masukkan Jumlah Staff TU: ");
            int.TryParse(Console.ReadLine(), out jum);
            for (int i = 1; i <= jum; i++)
            {
                Console.WriteLine("===============");
                Console.WriteLine("Staff No. " + i);

                StaffTU staffinfo = InputStaffTU();

                staffTUs.Add(staffinfo);

            }
        }

        private void DaftarAksi()
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("======MAIN MENU=====");
            Console.WriteLine("====================");
            Console.WriteLine("1. Input daftar staff");
            Console.WriteLine("2. Lihat daftar staff");
            Console.WriteLine("3. Lihat Tahun Kerja Semua staff");
            Console.WriteLine("4. Lihat Gaji Tahunan");
            Console.WriteLine("5. Lihat Bonus ");
            Console.WriteLine("6. Lihat Gaji perbulan ");
            Console.WriteLine("7. Keluar ");
            Console.WriteLine("================");
            Console.WriteLine("Masukkan Pilihan Anda: ");
            int pilihan;
            int.TryParse(Console.ReadLine(), out pilihan);
            if (pilihan == 1) { this.SetDataStaffTU(); }
            else if (pilihan == 2) { this.Getstaff(); }
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

        public StaffTU InputStaffTU()
        {
            StaffTU staff = new StaffTU();
            int umur;
            int tahun;
            Console.Clear();
            Console.WriteLine("** Input Informasi staff **");

            Console.Write("Nama         : ");
            staff.name = Console.ReadLine();
            Console.Write("Id           : ");
            staff.id = Console.ReadLine();
            Console.Write("Umur         : ");
            int.TryParse(Console.ReadLine(), out umur);
            staff.age = umur;
            Console.Write("Tahun Bergabung  : ");
            int.TryParse(Console.ReadLine(), out tahun);
            staff.yearJoined = tahun;
            return staff;

        }

        public void Getstaff()
        {
            Console.WriteLine("===============");
            Console.WriteLine("list staff: ");
            if (staffTUs.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (StaffTU rec in staffTUs)
                {
                    Console.WriteLine("-" + rec.name);

                }
            }

        }

        public void GetTahunKerjaSemua()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Tahun bekerja staff: ");
            if (staffTUs.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (StaffTU rec in staffTUs)
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
            Console.WriteLine("Gaji setahun staff: ");
            if (staffTUs.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {

                foreach (StaffTU rec in staffTUs)
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
            if (staffTUs.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (StaffTU rec in staffTUs)
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
            if (staffTUs.Count == 0)
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

            foreach (StaffTU rec in staffTUs)
            {
                if (rec.id == id)
                {

                    Console.WriteLine("Hitung Gaji Aktual? (Y/N) :");
                    string opsi = Console.ReadLine();
                    if (opsi == "Y" || opsi == "y")
                    {
                        rec.setTotalAbsence();
                        Console.WriteLine("Nama staff : " + rec.name);
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
