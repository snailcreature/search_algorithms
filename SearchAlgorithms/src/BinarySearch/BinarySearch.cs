using linkedlist;

namespace binarysearch
{
    /// <summary>
    /// Represents the error thrown when a given linked list is not sorted.
    /// </summary>
   public class LinkedListNotSortedException : Exception
    {
        public LinkedListNotSortedException()
        {
        }

        public LinkedListNotSortedException(string message)
            : base(message)
        {
        }

        public LinkedListNotSortedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Struct containing an implementation of a binary search algorithm.
    /// </summary>
    struct BinarySearch : ISearchAlgorithm
    {
        public static int? Search(LinkedList linkedList, int value)
        {
            if (!IsSorted(linkedList))
            {
                throw(new LinkedListNotSortedException("Oh dear, this LinkedList is not sorted!"));
            }
            int startI = 0;
            int endI = linkedList.Length;
            int index = (int)Math.Floor(linkedList.Length/2.0);
            do 
            {
                if (linkedList[index] == value)
                {
                    return value;
                }

                if (value < linkedList[index])
                {
                    endI = index;
                }
                else
                {
                    startI = index;
                }
                index = (int)Math.Floor((endI - startI)/2.0);
            } while (endI - startI != 0);
            return null;
        }

        /// <summary>
        /// Checks whether the given linked list is sorted in ascending order.
        /// </summary>
        /// <param name="linkedList">Linked list to check.</param>
        /// <returns><c>true</c> if <paramref name="linkedList"/> is correctly sorted. <c>false</c> otherwise.</returns>
        private static bool IsSorted(LinkedList linkedList)
        {
            for (int i = 0; i < linkedList.Length-1; i++)
            {
                if (linkedList[i] > linkedList[i+1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}