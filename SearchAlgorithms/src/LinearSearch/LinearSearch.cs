using linkedlist;

namespace linearsearch
{
    /// <summary>
    /// Struct <c>LinearSearch</c> contains a function for linearly searching a linked list.
    /// </summary>
    struct LinearSearch : ISearchAlgorithm
    {
        public static int? Search(LinkedList linkedList, int value)
        {
            for (int i = 0; i < linkedList.Length; i++)
            {
                if (linkedList[i] == value)
                {
                    return value;
                }
            }
            return null;
        }
    }
}