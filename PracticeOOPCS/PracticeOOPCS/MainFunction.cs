using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCS
{
    class MainFunction
    {
        public void CRUD()
        {
            Console.Clear();
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
                Environment.Exit(0);
            }

        }
        private void DaftarAksi()
        {
            BACK:
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("======MAIN MENU=====");
            Console.WriteLine("====================");
            Console.WriteLine("1. Pilih Tipe Employee");
            Console.WriteLine("2. Input Tipe Employee");
            Console.WriteLine("3. Tutorial");
            Console.WriteLine("4. Keluar");
            Console.WriteLine("================");
            Console.WriteLine("Masukkan Pilihan Anda: ");
            int pilihan;
            int.TryParse(Console.ReadLine(), out pilihan);
            if (pilihan == 1)
            {
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("======Pilih Tipe Employee=====");
                Console.WriteLine("====================");
                Console.WriteLine("1. Guru");
                Console.WriteLine("2. Staff TU");
                Console.WriteLine("3. Security");
                Console.Write("Masukkan Pilihan Anda: ");
                var nomor = Console.ReadLine();
                if (nomor == "1")
                {
                    Teacher newteach = new Teacher();
                    newteach.InputDataGuru();
                    Console.ReadLine();
                    goto BACK;
                }
                else if (nomor == "2")
                {
                    StaffTU newstaff = new StaffTU();
                    newstaff.InputDataStaffTU();
                    Console.ReadLine();
                    goto BACK;
                }
                else if (nomor == "3")
                {
                    Security newsecurity = new Security();
                    newsecurity.InputDataSecurity();
                    Console.ReadLine();
                    goto BACK;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Masukkan yang anda input salah ! Tekan sembarang tombol untuk melanjutkan..");
                }

            }

            else if (pilihan == 2)
            {

            }
            else if (pilihan == 3)
            {
                Console.WriteLine("====================");
                Console.WriteLine("Under Constructions");
                Console.WriteLine("====================");
            }
            else if (pilihan == 4)
            {
                Environment.Exit(0);
            }

        }
    }
}
