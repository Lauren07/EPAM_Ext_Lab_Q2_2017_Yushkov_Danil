using System;
using System.Collections.Generic;

namespace Task03
{
    public class ConsoleUI
    {
        public bool IsWork;
        public List<Figure> Figures;
        private string[] menuCommands;
        private Dictionary<string, Func<Figure>> creatorFigures;

        public ConsoleUI()
        {
            this.menuCommands = new[] { "Add - добавить фигуру", "Show - показать все фигуры", "Exit - выйти из программы" };
            this.IsWork = true;
            this.Figures = new List<Figure>();
            this.creatorFigures = new Dictionary<string, Func<Figure>>();
            this.creatorFigures["Line"] = () => new Line();
            this.creatorFigures["Rectangle"] = () => new Rectangle();
            this.creatorFigures["Round"] = () => new Round();
            this.creatorFigures["Circle"] = () => new Circle();
            this.creatorFigures["Ring"] = () => new Ring();
        }

        public void AddFigures()
        {
            Console.WriteLine($"{ConsoleResource.InputMessage}");
            foreach (var figure in this.creatorFigures)
            {
                Console.WriteLine(figure.Key);
            }

            for (; ;)
            {
                var type = Console.ReadLine();
                if (this.creatorFigures.ContainsKey(type))
                {
                    this.Figures.Add(this.creatorFigures[type].Invoke());
                    break;
                }

                Console.WriteLine(ConsoleResource.TypeNotFound);
            }

            Console.WriteLine(ConsoleResource.SuccessAddedMessage);
            Console.WriteLine(ConsoleResource.DividingLine);
        }

        public void ShowFigures()
        {
            foreach (var figure in this.Figures)
            {
                Console.WriteLine($"Тип фигуры: {figure.GetType()}");
                figure.Display();
                Console.WriteLine();
            }

            Console.WriteLine(ConsoleResource.DividingLine);
        }

        public void StartMenu()
        {
            Console.WriteLine(ConsoleResource.MenuMessage);
            foreach (var describeCommand in this.menuCommands)
            {
                Console.WriteLine(describeCommand);
            }

            var command = Console.ReadLine();
            switch (command)
            {
                case "Add":
                    this.AddFigures();
                    break;
                case "Show":
                    this.ShowFigures();
                    break;
                case "Exit":
                    this.IsWork = false;
                    break;
            }
        }
    }
}
