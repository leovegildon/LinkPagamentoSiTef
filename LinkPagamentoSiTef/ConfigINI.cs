using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace LinkPagamentoSiTef
{
    class ConfigINI
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName);

        public static string LerINI(string fileNameAndPath, string key)
        {

            if (System.IO.File.Exists(@fileNameAndPath) == false)
                return "";

            string[] texto = File.ReadAllLines(@fileNameAndPath);

            for (int linhas = 0; linhas < texto.Length; linhas++)
            {
                if (texto[linhas].Trim() == key && texto.Length - 1 > linhas)
                    return texto[linhas + 1].Trim();
            }

            return string.Empty;

        }
        public static void WriteINI(string fileNameAndPath, string section, string key, string text)
        {
            WritePrivateProfileString(section, key, text, fileNameAndPath);
        }
    }
}
