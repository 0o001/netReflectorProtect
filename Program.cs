using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace netReflectorProtect
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = ".Net Reflector Protect";

            var open = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Open Exe File",
                Filter = "Exe File|*.exe"
            };

            using (open)
            {
                while (true)
                {
                    if (open.ShowDialog() == DialogResult.OK)
                    {

                        using (FileStream fileStream = new FileStream(open.FileName, FileMode.Open, FileAccess.Write))
                        {
                            fileStream.Seek(244L, SeekOrigin.Begin);
                            fileStream.WriteByte(11);
                            fileStream.Flush();
                        }

                        Console.WriteLine(".Net Reflector Protection Successful");
                        Console.WriteLine("File: " + open.FileName);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to make a new one...");

                        Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
