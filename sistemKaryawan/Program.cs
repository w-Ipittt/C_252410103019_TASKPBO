using System;
using System.Collections.Generic;

namespace TugasPBO
{
    public class Karyawan
    {
        public string Nama;
        public double Gaji;
        public Karyawan(string nama, double gaji)
        {
            this.Nama = nama;
            this.Gaji = gaji;
        }
        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }
        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama : {Nama}, Gaji : {Gaji}");
        }
    }
}

//karyawan tetap
namespace TugasPBO
{
    public class Tetap : Karyawan
    {
        public double Tunjangan;
        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            this.Tunjangan = tunjangan;
        }
        public double HitungGajiTotal()
        {
            return Gaji + Tunjangan;
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} bekerja sebagai karyawan tetap.");
        }
        public override void InfoKaryawan()
        {
            Console.WriteLine($"Nama : {Nama}, Gaji : {Gaji}, Tunjangan : {Tunjangan}, Total : {HitungGajiTotal()}");
        }
    }
}

//kontrak
namespace TugasPBO
{
    public class Kontrak : Karyawan
    {
        public int jangkaWaktu;
        public Kontrak(string nama, double gaji, int jangkawaktu) : base(nama, gaji)
        {
            this.jangkaWaktu = jangkawaktu;
        }
        public void CekKontrak()
        {
            Console.WriteLine($"Kontrak {Nama} berlaku selama {jangkaWaktu} bulan.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} bekerja sebagai karyawan kontrak.");
        }
        public override void InfoKaryawan()
        {
            Console.WriteLine($"Nama : {Nama}, Gaji : {Gaji}, Jangka Waktu : {jangkaWaktu} bulan");
        }
    }
}

//manager
namespace TugasPBO
{
    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }
        public void Memimpin()
        {
            Console.WriteLine($"{Nama} sedang memimpin tim.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} (Manager) mengatur dan mengawasi pekerjaan tim. ");
        }
    }
}

//staff
namespace TugasPBO
{
    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }
        public void KerjakanTugas()
        {
            Console.WriteLine($"{Nama} sedang mengerjakan tugas harian.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} (Staff) mengerjakan tugas administrasi.");
        }
    }
}

//karyawan magang
namespace TugasPBO
{
    public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int jangkawaktu) : base(nama, gaji, jangkawaktu) { }
        public void Belajar()
        {
            Console.WriteLine($"{Nama} sedang belajar di perusahaan ini.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} (Magang) membantu pekerjaan sambil belajar.");
        }
    }
}

//freelancer 
namespace TugasPBO
{
    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int jangkawaktu) : base(nama, gaji, jangkawaktu) { }
        public void AmbilProyek()
        {
            Console.WriteLine($"{Nama} mengambil proyek baru.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} (Freelancer) mengerjakan proyek secara mandiri.");
        }
    }
}

//perusahaan
namespace TugasPBO
{
    public class Perusahaan
    {
        public List<Karyawan> Daftar = new List<Karyawan>();
        public void TambahKaryawan(Karyawan karyawan)
        {
            Daftar.Add(karyawan);
        }
        public void DaftarKaryawan()
        {
            foreach (Karyawan k in Daftar)
            {
                k.InfoKaryawan();
            }
        }
    }
}

//nah baru programnyeah
namespace TugasPBO
{
    class Program
    {
        static void Main(string[] args)
        {
            Perusahaan perusahaan = new Perusahaan();

            Manager manager = new Manager("Risma", 10000000, 3000000);
            Staff staff = new Staff("Ipit", 6000000, 1000000);
            Magang magang = new Magang("Ody", 1500000, 6);
            Freelancer freelancer = new Freelancer("Riski", 4000000, 3);

            perusahaan.TambahKaryawan(manager);
            perusahaan.TambahKaryawan(staff);
            perusahaan.TambahKaryawan(magang);
            perusahaan.TambahKaryawan(freelancer);

            Console.WriteLine("-- Daftar Karyawan --");
            perusahaan.DaftarKaryawan();

            //soal 1
            manager.Kerja();
            freelancer.Kerja();

            //soal 2
            manager.Memimpin();

            //soal 3
            manager.InfoKaryawan();
            Console.WriteLine($"Nama: {manager.Nama}, Gaji: {manager.Gaji}, Tunjangan: {manager.Tunjangan}");

            //soal 4
            magang.Belajar();

            //soal 5 
            Karyawan k = new Staff("Ario", 6000000, 1000000);
            k.Kerja();
        }
    }
}