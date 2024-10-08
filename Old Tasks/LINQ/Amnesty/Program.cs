﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();

            prison.Work();
        }
    }

    class Prison
    {        
        private List<Prisoner> _prisoners = new List<Prisoner>();

        public Prison()
        {
            _prisoners.Add(new Prisoner("Джони Две Куртки", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Майк Кислые Яйца", "Сел на пенек"));
            _prisoners.Add(new Prisoner("Джошуа Липкий Язык",  "Кинул пацана"));
            _prisoners.Add(new Prisoner("Кейси Дрявый Кисет",  "Не толерантен"));
            _prisoners.Add(new Prisoner("Василий Комок Блох", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Артем Крестный Отец", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Радик Закатанный Таз", "Шумел после десяти"));
            _prisoners.Add(new Prisoner("Сэмюэль Желтый Снег", "Не ел суп"));
        }            

        public void Work()
        {
            string offence = "Антиправительственное";

            ShowPrisoners();            
            Console.WriteLine("Проведена амнистия заключенных за антиправительственное престпуление!");            
            StopShowing();
            _prisoners = _prisoners.Where(prisoner => prisoner.Offense != offence).ToList();            
            ShowPrisoners();            
        }

        private void ShowPrisoners()
        {
            Console.WriteLine("Список заключенных:\n");

            foreach (var prisoner in _prisoners)
            {
                prisoner.Show();
            }

            StopShowing();
        }

        private void StopShowing()
        {
            Console.ReadKey();
            Console.Clear();
        }                
    }

    class Prisoner
    {
        public Prisoner(string name, string offense)
        {
            Name = name;
            Offense = offense;
        }

        public string Name { get; private set; }
        public string Offense { get; private set; }

        public void Show()
        {
            Console.WriteLine($"Имя: {Name}. Преступление: {Offense}.");
        }
    }
}

