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
            //string letters = reverseLetters(text);
            string words = reverseWords(text);
            //string sentence = reverseSentence(text);
            Console.WriteLine(sentence + "\n" + words + "\n" + letters);
        }
        //reverses the Letters of a String (shortest possible Implementation)
        public static String reverseLetters(String text)
        {
            return (text.Length == 0)? "" : text[text.Length - 1] + reverseLetters(text.Substring(0, text.Length - 1));
        }
        public static String reverseWords(String text)
        {
            if (text.Length == 0){
                return "";
            } else {
                String [] words = text.Split(' ');
                String [] restStrings = SubArray(words, 0, words.Length - 1);
                String lastString = words[words.Length - 1];
                String newText = String.Join(" ", restStrings);
                newText = lastString + newText;
                return newText;
            }
        }
        public static String reverseWordsHelper(String[] words){
            return null;
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
