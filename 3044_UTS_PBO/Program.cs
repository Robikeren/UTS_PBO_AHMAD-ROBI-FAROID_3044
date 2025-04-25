using System;
using System.Collections.Generic;
using System.Linq;

namespace PerpustakaanAmba
{
    abstract class ItemDasar
    {
        public abstract void TampilkanData();
    }
    class Buku : ItemDasar
    {
        public int Kode { get; private set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public string Status { get; set; }
        public Buku(int kode, string judul, string penulis, int tahun)
        {
            Kode = kode;
            Judul = judul;
            Penulis = penulis;
            TahunTerbit = tahun;
            Status = "tersedia";
        }
        public override void TampilkanData()
        {
            Console.WriteLine($"Kode Buku   : {Kode}");
            Console.WriteLine($"Judul       : {Judul}");
            Console.WriteLine($"Penulis     : {Penulis}");
            Console.WriteLine($"Tahun Terbit: {TahunTerbit}");
            Console.WriteLine($"Status      : {Status}");
        }
    }
    class PengelolaBuku
    {
        private List<Buku> daftarBuku = new List<Buku>();

        public PengelolaBuku()
        {
            daftarBuku.Add(new Buku(101, "Negeri 5 Menara", "Ahmad Fuadi", 2009));
            daftarBuku.Add(new Buku(102, "Bumi", "Tere Liye", 2014));
            daftarBuku.Add(new Buku(103, "Perahu Kertas", "Dee Lestari", 2008));
        }
        public void TambahBuku()
        {
            Console.Write("Masukkan Kode Buku: ");
            if (!int.TryParse(Console.ReadLine(), out int kode))
            {
                Console.WriteLine("Kode harus berupa angka.");
                return;
            }
            if (daftarBuku.Any(b => b.Kode == kode))
            {
                Console.WriteLine("Kode buku sudah terdaftar.");
                return;
            }
            Console.Write("Judul Buku      : ");
            string judul = Console.ReadLine();
            Console.Write("Nama Penulis    : ");
            string penulis = Console.ReadLine();
            Console.Write("Tahun Terbit    : ");
            if (!int.TryParse(Console.ReadLine(), out int tahun))
            {
                Console.WriteLine("Tahun harus angka.");
                return;
            }
            daftarBuku.Add(new Buku(kode, judul, penulis, tahun));
            Console.WriteLine("Buku berhasil ditambahkan.\n");
        }

        public void LihatSemuaBuku()
        {
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Belum ada buku di perpustakaan.");
                return;
            }
            Console.WriteLine("\nDAFTAR BUKU - PERPUS MAS AMBA KHAS BOYOLALI\n");
            foreach (var buku in daftarBuku)
            {
                buku.TampilkanData();
            }
        }
        public void UbahDataBuku()
        {
            Console.Write("Masukkan Kode Buku yang ingin diubah: ");
            if (!int.TryParse(Console.ReadLine(), out int kode))
            {
                Console.WriteLine("Kode harus berupa angka.");
                return;
            }

            var buku = daftarBuku.FirstOrDefault(b => b.Kode == kode);
            if (buku == null)
            {
                Console.WriteLine("Buku tidak ditemukan.");
                return;
            }
            Console.Write("Judul Baru       : ");
            buku.Judul = Console.ReadLine();
            Console.Write("Penulis Baru     : ");
            buku.Penulis = Console.ReadLine();
            Console.Write("Tahun Terbit Baru: ");
            if (!int.TryParse(Console.ReadLine(), out int tahun))
            {
                Console.WriteLine("Tahun harus angka.");
                return;
            }
            buku.TahunTerbit = tahun;
            Console.Write("Status Buku (tersedia/dipinjam): ");
            buku.Status = Console.ReadLine();
            Console.WriteLine(" Data buku berhasil diperbarui.\n");
        }
        public void HapusBuku()
        {
            Console.Write("Masukkan Kode Buku yang ingin dihapus: ");
            if (!int.TryParse(Console.ReadLine(), out int kode))
            {
                Console.WriteLine("Kode harus angka.");
                return;
            }
            var buku = daftarBuku.FirstOrDefault(b => b.Kode == kode);
            if (buku == null)
            {
                Console.WriteLine("Buku tidak ditemukan.");
                return;
            }
            daftarBuku.Remove(buku);
            Console.WriteLine("Buku berhasil dihapus.\n");
        }
    }
    class Program
    {
        static void Main()
        {
            PengelolaBuku pengelola = new PengelolaBuku();
            int pilihan;

            do
            {
                Console.WriteLine("\n========= MENU UTAMA =========");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Lihat Semua Buku");
                Console.WriteLine("3. Ubah Data Buku");
                Console.WriteLine("4. Hapus Buku");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih menu (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Masukkan angka yang valid.");
                    continue;
                }
                switch (pilihan)
                {
                    case 1:
                        pengelola.TambahBuku();
                        break;
                    case 2:
                        pengelola.LihatSemuaBuku();
                        break;
                    case 3:
                        pengelola.UbahDataBuku();
                        break;
                    case 4:
                        pengelola.HapusBuku();
                        break;
                    case 5:
                        Console.WriteLine("Sampai jumpa! 📖✨");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia.");
                        break;
                }
            } while (pilihan != 5);
        }
    }
}
