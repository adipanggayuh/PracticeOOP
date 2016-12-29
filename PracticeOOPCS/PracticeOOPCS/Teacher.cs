using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    class Teacher : Employee
    {
        private string ofClass;
        private string subject;
        List<Teacher> teachers = new List<Teacher>();

        public Teacher(string newName, string newId, string ofClass, string subject) : base(newName, newId)
        {
            this.ofClass = ofClass;
            this.subject = subject;
        }

        public Teacher()
        {

        }

        public override long getSalary()
        {
            long salary = base.getSalary() + 1000000;
            return salary;
        }

        public void InputDataGuru()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("==Selamat Datang di HR system==");
            Console.WriteLine("===============================");
            Console.Write("Lanjutkan? (Y/N) :");
            string opsi = Console.ReadLine();
            if (opsi == "Y" || opsi == "y")
            {
                DaftarAksi();
            }
            else if (opsi == "N" || opsi == "n")
            {
                return;
            }
        }

        private void SetDataGuru()
        {
            int jum;
            Console.WriteLine("Masukkan Jumlah Guru: ");
            int.TryParse(Console.ReadLine(), out jum);
            for (int i = 1; i <= jum; i++)
            {
                Console.WriteLine("===============");
                Console.WriteLine("Guru No." + i);

                Teacher teacherinfo = InputGuru();

                teachers.Add(teacherinfo);

            }
        }

        private void DaftarAksi()
        {
            Console.WriteLine("====================");
            Console.WriteLine("======MAIN MENU=====");
            Console.WriteLine("====================");
            Console.WriteLine("1. Input daftar guru");
            Console.WriteLine("2. Lihat daftar guru");
            Console.WriteLine("3. Lihat Tahun Kerja Semua guru");
            Console.WriteLine("4. Lihat Gaji Tahunan");
            Console.WriteLine("5. Lihat Bonus ");
            Console.WriteLine("6. Lihat Gaji perbulan ");
            Console.WriteLine("7. Keluar ");
            Console.WriteLine("================");
            Console.WriteLine("Masukkan Pilihan Anda: ");
            int pilihan;
            int.TryParse(Console.ReadLine(), out pilihan);
            if (pilihan == 1) { this.SetDataGuru(); }
            else if (pilihan == 2) { this.GetGuru(); }
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
                return;
            }

        }

        public Teacher InputGuru()
        {
            Teacher guru = new Teacher();
            int umur;
            int tahun;
            Console.WriteLine("** Input Informasi Guru **");

            Console.Write("Nama         : ");
            guru.name = Console.ReadLine();
            Console.Write("Id           : ");
            guru.id = Console.ReadLine();
            Console.Write("Umur         : ");
            int.TryParse(Console.ReadLine(), out umur);
            guru.age = umur;
            Console.Write("Tahun Bergabung  : ");
            int.TryParse(Console.ReadLine(), out tahun);
            guru.yearJoined = tahun;
            Console.Write("Mengajar di kelas    : ");
            guru.ofClass = Console.ReadLine();
            Console.Write("Pelajaran    : ");
            guru.subject = Console.ReadLine();
            return guru;

        }

        public void GetGuru()
        {
            Console.WriteLine("===============");
            Console.WriteLine("list guru: ");
            if (teachers.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Teacher rec in teachers)
                {
                    Console.WriteLine("-" + rec.name);

                }
            }

        }

        public void GetTahunKerjaSemua()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Tahun bekerja guru: ");
            if (teachers.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Teacher rec in teachers)
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
            Console.WriteLine("Gaji setahun guru: ");
            if (teachers.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {

                foreach (Teacher rec in teachers)
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
            if (teachers.Count == 0)
            {
                Console.WriteLine("Tidak ada data");
            }
            else
            {
                foreach (Teacher rec in teachers)
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
            if (teachers.Count == 0)
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

            foreach (Teacher rec in teachers)
            {
                if (rec.id == id)
                {

                    Console.WriteLine("Hitung Gaji Aktual? (Y/N) :");
                    string opsi = Console.ReadLine();
                    if (opsi == "Y" || opsi == "y")
                    {
                        rec.setTotalAbsence();
                        Console.WriteLine("Nama Guru : " + rec.name);
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
