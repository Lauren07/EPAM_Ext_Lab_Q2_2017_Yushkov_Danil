namespace Task06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConsoleTextUI
    {
        private List<TextParameter> textParameters;

        public ConsoleTextUI()
        {
            this.textParameters = new List<TextParameter>();
            this.textParameters.Add(new TextParameter("bold"));
            this.textParameters.Add(new TextParameter("italic"));
            this.textParameters.Add(new TextParameter("underline"));
        }

        public void DisplayUI()
        {
            var activeParameters = this.textParameters.Where(param => param.IsEnable);
            var strParameters = activeParameters.Count() > 0 ? string.Join(", ", activeParameters) : "none";
            Console.WriteLine($"Параметры надписи: {strParameters}");
            Console.WriteLine("Введите:");
            for (var i = 0; i < this.textParameters.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}: {this.textParameters[i]}");
            }
        }

        public int InputIndexParameter()
        {
            int result;
            for (; ;)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }

                Console.WriteLine(MessagesResource.ErrorMessage);
            }
        }

        public bool TryChangeText(int indexParameter)
        {
            if (indexParameter < 1 || indexParameter > this.textParameters.Count)
            {
                return false;
            }

            this.textParameters[indexParameter - 1].IsEnable = !this.textParameters[indexParameter - 1].IsEnable;
            return true;
        }
    }
}
