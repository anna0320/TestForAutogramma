using System.Text.RegularExpressions;
class TestForAutogramma
{
    public static void Main()
    {
        #region Задача 1
        //Самое длинное начало-наибольший префикс, далее буду отталкиваться от этого определения.
        Console.Write("Введите значения через пробел: ");
        var input = Console.ReadLine()?.Split(); //разбиваем строку на подстроки
        Console.WriteLine(string.Format(LongestCommonPrefix(input)));

        #endregion
        #region Задача 2
        Console.Write("Введите строку: ");
        string? str = Console.ReadLine();
        MatchCollection numbers = Regex.Matches(str!, @"\d+"); //создаём коллекцию всех совпадений в строке
        int sum = 0;
        foreach (Match number in numbers) //производим итерацию по элементам для получения суммы чисел
            sum += int.Parse(number.Value);
        Console.WriteLine(sum);
        #endregion
        #region Задача 3
        string[] strings = { "*", "-", "5", "6", "7" };
        Polska(strings);
        #endregion

    }
    //метод польской нотации
    public static void Polska(string[] args)
    {
        Stack<string> st = new Stack<string>();
        for (int i = args.Length - 1; i >= 0; i--)
        {
            //Ecли получаем число, то добавляем его в стек
            try
            {   //Если возникает исключение,значит, получаем либо оператор, либо ошибку
                double temp = double.Parse(args[i]);
                st.Push(args[i]);
                continue;
            }
            catch
            { }
            if (args[i] == "/")
            {
                double a = double.Parse(st.Pop());
                double b = double.Parse(st.Pop());
                st.Push((a / b).ToString());
                continue;
            }

            if (args[i] == "*")
            {
                double a = double.Parse(st.Pop());
                double b = double.Parse(st.Pop());
                st.Push((a * b).ToString());
                continue;
            }

            if (args[i] == "+")
            {
                double a = double.Parse(st.Pop());
                double b = double.Parse(st.Pop());
                st.Push((a + b).ToString());
                continue;
            }

            if (args[i] == "-")
            {
                double a = double.Parse(st.Pop());
                double b = double.Parse(st.Pop());
                st.Push((a - b).ToString());
                continue;
            }

        }
        Console.WriteLine(st.Pop());
        Console.ReadLine();
    }
    //метод для нахождения наибольшего префикса
    public static string LongestCommonPrefix(string[]? strs)
    {
        int len = strs!.Length;
        string prefix = strs[0];
        for (int i = 1; i < len; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix == "") return "-";
            }
        }
        return prefix;
    }
}
