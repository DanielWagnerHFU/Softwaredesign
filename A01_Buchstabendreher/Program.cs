using System;

namespace A01_Buchstabendreher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte einen kleinen Satz eingeben");
            Console.Write("> ");
            var text = Console.ReadLine();
            string letters = reverseLetters(text);
            string words = reverseWords(text);
            string sentence = reverseSentence(text);
            Console.WriteLine(sentence + "\n" + words + "\n" + letters);
        }
        //reverses the Letters of a String (shortest possible Implementation)
        public static String reverseLetters(String text)
        {
            return (text.Length == 0)? "" : text[text.Length - 1] + reverseLetters(text.Substring(0, text.Length - 1));
        }
        public static String reverseWords(String text){
            return (text.Length == 0)? "" : text.Split(' ')[text.Split(' ').Length - 1] + " " + reverseWords(String.Join(" ", SubArray(text.Split(' '), 0, text.Split(' ').Length - 1)));
        }
        public static String reverseSentence(String text)
        {
            return text;
        }
        public static String[] SubArray(String[] data, int index, int length)
        {
            String[] result = new String[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
