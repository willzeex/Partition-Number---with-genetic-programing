using System;
using System.IO;

namespace NumberPartition
{
    public class ManageFile
    {
        public void GerarArquivo(int min, int max, int qtd, int qtdConuntos)
        {
            string strArquivo = qtdConuntos + "\n";
            Random random = new Random();
            for (int i = 0; i < qtd; i++)
            {
                strArquivo += random.Next(min, max) + ";";
            }

            strArquivo = strArquivo.Remove(strArquivo.Length - 1);
            string path = @"arquivo.txt";
            GravarArquivo(strArquivo, path);
        }

        public void GravarArquivo(string strArquivo, string path)
        {
            File.WriteAllText(path, strArquivo);
        }

        public string[] LerArquivo(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
