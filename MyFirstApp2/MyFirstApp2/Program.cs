//// See https://aka.ms/new-console-template for more information
//using System;

//Console.WriteLine("Enter first integer number:");
//if (!int.TryParse(Console.ReadLine(), out int a))
//{
//    Console.WriteLine("Not a number!");
//    return;
//}

//Console.WriteLine("Enter second integer number:");
//if (!int.TryParse(Console.ReadLine(), out int b))
//{
//    Console.WriteLine("Not a number!");
//    return;
//}

//Console.WriteLine("Enter operator (& or ^):");
//string s = Console.ReadLine();

//if (string.IsNullOrEmpty(s) || s.Length != 1)
//{
//    Console.WriteLine("Wrong sign!");
//    return;
//}

//int result;

//switch (s[0])
//{
//    case '&':
//        result = a & b;
//        break;

//    case '^':
//        result = a ^ b;
//        break;

//    default:
//        Console.WriteLine("Wrong sign!");
//        return;
//}

//Console.WriteLine($"Result (decimal): {result}");
//Console.WriteLine($"Result (binary): {Convert.ToString(result, 2)}");
//Console.WriteLine($"Result (hex): {Convert.ToString(result, 16).ToUpper()}");
