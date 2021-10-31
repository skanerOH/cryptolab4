using crypto_lab_4;
using System;
using System.Numerics;
using System.Text;

namespace ConsoleForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] inp = Encoding.ASCII.GetBytes("Hello form Donbass children!!!");

            (Key publicKey, Key privateKey) = RSA.GenerateRSAPair();

            byte[] oaeped_plain = OAEP.TransformOAEP(inp, "SHA-256 MGF1", 10);
            byte[] chipher = RSA.EncryptRSA(oaeped_plain, privateKey);

            byte[] plain = OAEP.RestoreOAEP(RSA.DecryptRSA(chipher, publicKey), "SHA-256 MGF1");

            Console.WriteLine(Encoding.ASCII.GetString(plain));


            Console.ReadKey();
        }
    }
}
