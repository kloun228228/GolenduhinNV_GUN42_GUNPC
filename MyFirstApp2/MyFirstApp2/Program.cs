//// See https://aka.ms/new-console-template for more information
//using System;


namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] array3 = { 0, 1, 1, 2, 3, 5, 8, 13 };

            
            string[] months = {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };


            int[,] matrix = {
              {2, 3, 4 },
             {4, 9, 16 },
             {8, 27, 64 },



             };


            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[] { Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) };

            

            
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            
            Array.Copy(array, 0, array2, 0, 3);

            
            Console.WriteLine("Результат копирования (array2): " + string.Join(", ", array2));


            Array.Resize(ref array, array.Length * 2);

            Console.WriteLine("Новый размер первого массива: " + array.Length);
            Console.WriteLine("Содержимое после Resize: " + string.Join(", ", array));

            
            Console.ReadKey();
        }
    }
}








