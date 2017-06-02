// Для выделения текстовой надписи можно использовать выделение жирным, курсивом и подчёркиванием. 
// Предложите способ хранения информации о выделении надписи и напишите программу, которая позволяет назначать и удалять текстовой надписи выделение
namespace Task06
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var userTextUI = new UserTextUI();
            while (true)
            {
                userTextUI.DisplayUI();
                var index = userTextUI.InputIndexParameter();
                if (!userTextUI.TryChangeText(index))
                {
                    Console.WriteLine(MessagesResource.ErrorIndexMessage);
                }
            }
        }
    }
}
