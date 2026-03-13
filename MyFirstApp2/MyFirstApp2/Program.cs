//// See https://aka.ms/new-console-template for more information

using System;

namespace RPGPrototype
{
    
    public class Unit
    {
        public string Name;
        public Unit(string name) { Name = name; }
       
        public override string ToString() { return Name; }
    }

    public class Weapon
    {
        public string Name;
        public Weapon(string name) { Name = name; }
        public override string ToString() { return Name; }
    }

    
    public struct Interval
    {
        
        public float Min { get; }
        public float Max { get; }

        
        private Random random;

        
        public float Get
        {
            get
            {
                
                if (random == null) random = new Random();

                
                return (float)(random.NextDouble() * (Max - Min) + Min);
            }
        }

        
        public Interval(int minValue, int maxValue)
        {
            
            random = new Random();

            
            if (minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("Ошибка: нижняя граница была меньше нуля. Установлена в 0.");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("Ошибка: верхняя граница была меньше нуля. Установлена в 0.");
            }

            
            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
                Console.WriteLine("Ошибка: нижняя граница больше верхней. Значения поменяны местами.");
            }

            
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Ошибка: границы равны. Верхняя граница увеличена на 10.");
            }

            
            Min = minValue;
            Max = maxValue;
        }
    }

    
    public struct Room
    {
        
        public Unit Unit;
        public Weapon Weapon;

        
        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    
    public class Dungeon
    {
        
        private Room[] rooms;

        
        public Dungeon()
        {
            
            rooms = new Room[]
            {
                new Room(new Unit("Орк-Воин"), new Weapon("Ржавый топор")),
                new Room(new Unit("Гоблин-Вор"), new Weapon("Отравленный кинжал")),
                new Room(new Unit("Скелет-Лучник"), new Weapon("Костяной лук"))
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine("Unit of room " + room.Unit);
                Console.WriteLine("Weapon of room " + room.Weapon);
                Console.WriteLine("---");
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тест Interval ---");
            
            Interval interval = new Interval(-5, -5);
            Console.WriteLine($"Интервал: Min = {interval.Min}, Max = {interval.Max}");
            Console.WriteLine($"Случайное число из интервала: {interval.Get}\n");

            Console.WriteLine("--- Тест Dungeon ---");
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();

            Console.ReadLine();
        }
    }
}
