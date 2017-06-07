namespace Task01
{
    using System;

    public static class ConsoleUI //todo pn почему у тебя один и тот же класс копируется в каждый проект? сделай просто общий проект с этим классом и добавь ссылки на общий проект в каждый проект.
    {
        public static Tuple<int, int> ReadRectSides()
        {
            int a = 0, b = 0;
            for (; ;)
            {
                Console.WriteLine(MessagesResource.InputMessage);
                var strNums = (Console.ReadLine() ?? string.Empty).Split(' ');
                if (strNums.Length != 2 || !int.TryParse(strNums[0], out a) || !int.TryParse(strNums[1], out b))
                {
                    continue;
                }

                return Tuple.Create(a, b);
            }
        }

        public static void WriteResult(int? resultArea)
        {
            if (!resultArea.HasValue)
            {
                Console.WriteLine(MessagesResource.ErrorMessage);
                return;
            }

            Console.WriteLine($"Площадь треугольника: {resultArea.Value}");
        }
    }
}
