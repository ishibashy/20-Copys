using System;
using System.IO;

public class copyNum
{
    static int count = 0;//ファイルの個数
    static string[] files;//ディレクトリの名前
    static int beginNum = 0;
    static int lengthNum = 0;
    static int[] rNum = new int[20];


    static void DoIt(string dir)
    {
        dir += "\\"; 
        files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
        foreach (string s in files)
        {
            Console.WriteLine("files[{0}]:{1}", count, s);
            count++;
        }
        Console.WriteLine("{0}個のファイル", count);
    }

    static void RandomNum()
    {
        Random rnd = new Random();
        for (int i = 0; i < rNum.Length ; i++)
        {
            rNum[i] = rnd.Next(count);
            Console.WriteLine(rNum[i]);
        }
    }

    static void cOpyNum(string dir)
    {
        for (int i = 0; i < rNum.Length; i++)
        {
            String st = beginNum.ToString();
            String stFilePath = dir + "\\" + st + ".png";
            System.IO.File.Copy(files[rNum[i]], stFilePath, true);
            Console.WriteLine(stFilePath);
            beginNum++;
        }
    }

    static void Main(string[] args)
    {
                                        //コマンドライン引数に
        if (args.Length == 0) return;   //参照先があるか
        if (args.Length < 3)            //ファイル名の開始番号があるか
            beginNum = 0;
        else
            beginNum = int.Parse(args[2]);
        if (args.Length < 4)            //ファイルの数があるか
            lengthNum = 20;
        else
            lengthNum = int.Parse(args[3]);
        rNum = new int[lengthNum];

        DoIt(args[0]);      //指定したディレクトリ以下のファイルフルパスを配列に代入
        RandomNum();        //指定したディレクトリのファイル数から20個の乱数を生成
        cOpyNum(args[1]);   //上記配列と乱数を使って指定ディレクトリに連番でファイルをコピー
    }
}



