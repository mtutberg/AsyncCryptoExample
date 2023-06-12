// See https://aka.ms/new-console-template for more information
using AsymCryptoExample;

String txt;

Console.WriteLine("Choose your action:");
Console.WriteLine("1 - Generate RSA Key");
Console.WriteLine("2 - Enter your text and encrypt");
Console.WriteLine("3 - Decrypt encrypted text");
Console.WriteLine("4 - Decrypt without private key (Will cause error)");
ConsoleKeyInfo cki = Console.ReadKey();
Console.WriteLine();

switch (cki.Key)
{
    case ConsoleKey.D1:
        AsymCrypto.GenerateKey();
        Console.WriteLine("RSA key is generated");
        break;
    case ConsoleKey.D2:
        Console.Write("Enter your text to encrypt: ");
        txt = Console.ReadLine();
        AsymCrypto.Encrypt(txt);
        break;
    case ConsoleKey.D3:
        txt = AsymCrypto.Decrypt();
        Console.Write("Your text was: ");
        Console.WriteLine(txt);
        break;
    case ConsoleKey.D4:
        txt = AsymCrypto.DecryptWithoutPrivateKey();
        Console.Write("Your text was: ");
        Console.WriteLine(txt);
        break;
    default:

        break;

}