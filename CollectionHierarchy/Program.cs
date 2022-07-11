using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var addCollectionResult = new List<int>();
            var addremoveCollectionResult = new List<int>();
            var myListResult = new List<int>();

            var remAddCollectionResult = new List<string>();
            var remMyListResult = new List<string>();


            string[] addOperations = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int removeOperations = int.Parse(Console.ReadLine());

            foreach (string operation in addOperations)
            {
                int resultOne = addCollection.Add(operation);
                addCollectionResult.Add(resultOne);

                int resultTwo = addRemoveCollection.Add(operation);
                addremoveCollectionResult.Add(resultTwo);

                int resultThree = myList.Add(operation);
                myListResult.Add(resultThree);
            }

            for (int i = 0; i < removeOperations; i++)
            {
                string resultOne  = addRemoveCollection.Remove();
                string resultTwo = myList.Remove();

                remAddCollectionResult.Add(resultOne);
                remMyListResult.Add(resultTwo);
            }

            Console.WriteLine(string.Join(' ', addCollectionResult));
            Console.WriteLine(string.Join(' ', addremoveCollectionResult));
            Console.WriteLine(string.Join(' ', myListResult));
            Console.WriteLine(string.Join(' ', remAddCollectionResult));
            Console.WriteLine(string.Join(' ', remMyListResult));
            
        }
    }
}
