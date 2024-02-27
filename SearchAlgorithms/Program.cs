// See https://aka.ms/new-console-template for more information
using linearsearch;
using binarysearch;

Console.WriteLine("Hello, World!");

linkedlist.LinkedList linkedList = new(1, 2, 3, 4, 5, 6, 7, 8, 9);

Console.WriteLine(LinearSearch.Search(linkedList, 5));

Console.WriteLine(LinearSearch.Search(linkedList, 10));

Console.WriteLine(BinarySearch.Search(linkedList, 3));

Console.WriteLine(BinarySearch.Search(linkedList, 10));