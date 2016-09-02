using System;
using System.IO;

namespace Copy20
{
    public class Copy20
    {
        static int count = 0;
        static string[] files;
        static int[] r20 = new int[20];

        static void DoIt(string dir)
        {

            files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            foreach (string s in files)
            {
                Console.WriteLine("files[{0}]:{1}", count, s);
                count++;
            }
            Console.WriteLine("{0}個のファイル", count);
        }

        static void Random20()
        {
            Random rnd = new Random();
            for (int i = 0; i < r20.Length; i++)
            {
                r20[i] = rnd.Next(count);
                Console.WriteLine(r20[i]);
            }
        }

        static void cOpy20(string dir)
        {
            for (int i = 0; i < r20.Length; i++)
            {
                String st = i.ToString();
                String stFilePath = dir + st + ".png";
                System.IO.File.Copy(files[r20[i]], stFilePath, true);
                Console.WriteLine(stFilePath);
            }
        }

        static void Main(string[] args)
        {

            if (args.Length == 0) return;

            DoIt(args[0]);//指定したディレクトリ以下のファイルフルパスを配列に代入
            Random20();//指定したディレクトリのファイル数から20個の乱数を生成
            cOpy20(args[1]);//上記配列と乱数を使って指定ディレクトリに連番でファイルをコピー
        }
    }
}




