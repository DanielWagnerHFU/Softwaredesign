using System;

namespace L02_C_
{
    class L02
    {
        static void Main(string[] args)
        {
            PrintAllTodos();
        }

        public static void PrintAllTodos(){
           Todos todos = new Todos();
           Console.WriteLine(todos.Todo_1());
           Console.WriteLine(todos.Todo_2());
           Console.WriteLine(todos.Todo_3());
           Console.WriteLine(todos.Todo_4());

        }
    }
}
