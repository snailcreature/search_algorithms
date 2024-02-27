namespace linkedlist
{
    /// <summary>
    /// An interface for search algorithms.
    /// </summary>
    interface ISearchAlgorithm {
        /// <summary>
        /// Search the given linked list for the value.
        /// </summary>
        /// <param name="linkedList">Linked list to search.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns>
        /// If value is found, returns the value. Otherwise, returns <c>null</c>.
        /// </returns>
        public static abstract int? Search(LinkedList linkedList, int value);
    }
}