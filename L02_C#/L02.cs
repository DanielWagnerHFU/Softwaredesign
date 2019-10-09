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
             Console.WriteLine(todos.ToStringWithoutInput());
            // Console.WriteLine(todos.Todo_13());
            // Console.WriteLine(todos.Todo_14());
            // Console.WriteLine(todos.Todo_15());
            // Console.WriteLine(todos.Todo_16());
            // Console.WriteLine(todos.Todo_17());
            // Console.WriteLine(todos.Todo_18());
        }
    }
}
