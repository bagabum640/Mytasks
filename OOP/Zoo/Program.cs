﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.ShowAviary();
        }
    }

    class Zoo
    {
        const string CommandExit = "exit";

        private Dictionary<string, string> _aviaries = new Dictionary<string, string>();
        private Menu _menu;
        string _description;
        bool isWork = true;

        public Zoo()
        {
            _menu = new Menu();
            Aviary aviary;
            aviary = new Aviary("Клетка с обезьянами", "Обезьяна", 3, 2, "У-у");
            _aviaries.Add(aviary.Name, aviary.ShowDescription());
            aviary = new Aviary("Клетка с бегемотами", "Бегемот", 1, 1, "Мэ-мэ");
            _aviaries.Add(aviary.Name, aviary.ShowDescription());
            aviary = new Aviary("Клетка с петухами", "Петух", 3, 2, "Ку-ка-ре-ку");
            _aviaries.Add(aviary.Name, aviary.ShowDescription());
            aviary = new Aviary("Клетка с морскими котиками", "Морской котик", 3, 2, "Мяу (по-морскому)");
            _aviaries.Add(aviary.Name, aviary.ShowDescription());
            aviary = new Aviary("Клетка с попугаями", "Попугай", 7, 8, "Чик-чирик");
            _aviaries.Add(aviary.Name, aviary.ShowDescription());
            _aviaries.Add("Выход", CommandExit);
        }

        public void ShowAviary()
        {
            while (isWork)
            {
                _description = _aviaries[_menu.ChooseCommand(_aviaries.Keys.ToArray())];

                if (_description == CommandExit)
                {
                    isWork = false;
                    break;
                }

                Console.WriteLine(_description);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Aviary
    {
        private string _animalName;
        private uint _maleQuantity;
        private uint _femaleQuantity;
        private string _emittedSound;

        public Aviary(string cageName, string animalName, uint maleQuantity, uint femaleQuantity, string emittedSound)
        {
            Name = cageName;
            _animalName = animalName;
            _maleQuantity = maleQuantity;
            _femaleQuantity = femaleQuantity;
            _emittedSound = emittedSound;
        }

        public string Name { get; private set; }

        public string ShowDescription()
        {
            string description = $"{Name}\nВ клетке содержится животное: {_animalName}\n" +
                $"Количество самцов в клетке: {_maleQuantity}\nКоличество самок в клетке: {_femaleQuantity}\n" +
                $"Животное издает звук: {_emittedSound}\n\n";

            return description;
        }
    }

    class Menu
    {
        public string ChooseCommand(string[] commands)
        {
            const ConsoleKey PreviousString = ConsoleKey.UpArrow;
            const ConsoleKey NextString = ConsoleKey.DownArrow;
            const ConsoleKey SelectString = ConsoleKey.Enter;

            bool isWork = true;
            int numberString = 0;
            int CursorPositionX = 0;
            int CursorPositionY = Console.CursorTop;
            ConsoleKeyInfo key;

            while (isWork)
            {
                Console.SetCursorPosition(CursorPositionX, CursorPositionY);
                WriteStrings(0, numberString, commands);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(commands[numberString]);
                Console.ResetColor();
                WriteStrings(numberString + 1, commands.Length, commands);
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case SelectString:
                        isWork = false;
                        break;

                    case NextString:
                        numberString = (numberString + 1 < commands.Length) ? numberString + 1 : 0;
                        break;

                    case PreviousString:
                        numberString = (numberString - 1 >= 0) ? numberString - 1 : commands.Length - 1;
                        break;
                }
            }

            ClearPartOfConsole(CursorPositionX, CursorPositionY, commands);
            Console.SetCursorPosition(0, 0);
            return commands[numberString];
        }

        private void WriteStrings(int firstString, int lastString, string[] strings)
        {
            for (int i = firstString; i < lastString; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }

        private void ClearPartOfConsole(int CursorPositionX, int CursorPositionY, string[] commands)
        {
            Console.SetCursorPosition(CursorPositionX, CursorPositionY);

            for (int i = 0; i < commands.Length; i++)
            {
                for (int j = 0; j < commands[i].Length; j++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }
    }
}
