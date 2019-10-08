using System;

namespace L02_C_
{
    class L02
    {
        static void Main(string[] args)
        {
            PrintAllTodos();
        }
        public static void PrintAllTodos()
        {
            Todos todos = new Todos();
            Console.WriteLine(todos.ToString());
        }
    }
}
