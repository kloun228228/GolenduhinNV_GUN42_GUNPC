//// See https://aka.ms/new-console-template for more information
class Programm
{
    static void Main(string[] args)
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i < 10; i++)
        {
            Console.Write(a + " ");
            int temp = a;
            a = b;
            b = temp + b;
        }
        for (int i = 2; i <= 20; i += 2)
        {
            Console.WriteLine(a + " ");

        }
       
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
            
                Console.Write($"{i * j}\t");
            }
            Console.WriteLine(); 
        }
        Console.WriteLine();


        
        string password = "qwerty";
        string userInput;

        do
        {
            Console.Write("Введите пароль: ");
            userInput = Console.ReadLine();

            if (userInput != password)
            {
                Console.WriteLine("Неверный пароль. Попробуйте снова.");
            }

        } while (userInput != password);

        Console.WriteLine("Доступ разрешен!");

       
       Console.ReadLine();



















    }






}
