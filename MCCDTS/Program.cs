using System;

using System.Collections.Generic;

namespace MCCDTS
{
    class Program
    {
        int index;
        public SortedList<int, SortedList<string,string>> dataRegistrasiKaryawan = new SortedList<int, SortedList<string, string>>();
        static void Main(string[] args)
        {
            string active = "1";
            string presensiMode;
           
            Program authKaryawan = new Program();
            
            while (active != "0")
            {
                Console.Write("[0] Registrasi, [1] Presensi, [2] Cek Data: ");
                presensiMode = Console.ReadLine();

                string user;  
                string pass;
               
              

                switch (presensiMode)
                {
                    case "1":
                        Console.Write("Username: ");
                        user = Console.ReadLine();
                        Console.Write("Password: ");
                        pass = Console.ReadLine();
                        bool presensiSuccess = authKaryawan.PresensiHarian(user, pass);
                        if (!presensiSuccess)
                        {
                            Console.WriteLine("Presensi gagal!!!");
                        }
                        else
                        {
                            Console.WriteLine("Presensi gagal!!!");
                        }
                        break;
                    case "0":
                        Console.Write("Username: ");
                        user = Console.ReadLine();
                        Console.Write("Password: ");
                        pass = Console.ReadLine();
                        bool registrasiSuccess = authKaryawan.TambahDataKaryawan(user, pass);
                        if (!registrasiSuccess)
                        {
                            Console.WriteLine("Gagal! Panjang username setidaknya 5 karakter dan panjang password setidaknya 8 karakter");
                        } else
                        {
                            Console.WriteLine("Data berhasil ditambahkan");
                        }

                        break;
                    case "2":
                        Console.WriteLine("Data Karyawan sekarang: ");
                        authKaryawan.ShowDataKaryawan();
                        break;
                    default:
                        Console.WriteLine("Input salah");
                        
                        break;
                }
                
                Console.WriteLine("Tekan apapun untuk mengulang atau 0 untuk keluar!");
                active = Console.ReadLine();
            }

        }

        void ShowDataKaryawan()
        {
            foreach(KeyValuePair<int, SortedList<string, string>> datas in this.dataRegistrasiKaryawan)
            {
                Console.Write(datas.Key);
                foreach (KeyValuePair<string, string> data in datas.Value)
                {
                    
                    if (data.Key == "user")
                    {
                        Console.Write(" ");
                        Console.WriteLine(data.Value);
                    }
                    
                }
            }
        }

        bool PresensiHarian(string userName, string password)
        {
            foreach (KeyValuePair<int, SortedList<string, string>> datas in this.dataRegistrasiKaryawan)
            {
                bool isUser = false;
                bool isPass = false;
                foreach (KeyValuePair<string, string> data in datas.Value)
                {
                    
                    if(data.Key == "user" && data.Value ==userName) {
                        isUser = true;
                    } 
                    if (data.Key == "pass" && data.Value == password)
                    {
                        isPass = true;
                    }

                    if(isUser&& isPass)
                    {
                        
                        return true;
                    }
                }
            }

            return false;
        }

        bool TambahDataKaryawan(string userName, string password)
        {
            if (userName.Length < 4 || password.Length < 7)
            {
                
                return false;
            }
          
            SortedList<string, string> input = new SortedList<string, string>();
            input.Add("user", userName);
            input.Add("pass", password);
            
            this.dataRegistrasiKaryawan.Add(this.index++,input);
            
            return true;
        }
    }
}
