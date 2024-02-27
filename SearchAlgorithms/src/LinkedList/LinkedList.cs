namespace linkedlist
{
    /// <summary>
    /// Class <c>LinkedList</c> represents a linked list data structure.
    /// </summary>
    class LinkedList
    {
        /// <summary>
        /// <value>Represents the entry node of the linked list.</value>
        /// </summary>
        public Node? FirstNode { get; private set; }
        /// <summary>
        /// <value>Represents the final node of the linked list.</value>
        /// </summary>
        public Node? LastNode { get; private set; }

        /// <summary>
        /// <value>Represents the length of the linked list.</value>
        /// </summary>
        public int Length { get; private set; } = 0;

        /// <summary>
        /// Create an empty linked list.
        /// </summary>
        public LinkedList() {}

        /// <summary>
        /// Initialise a new linked list with a single node.
        /// </summary>
        /// <param name="firstNode">The first node of the linked list.</param>
        public LinkedList(Node firstNode)
        {
            FirstNode = firstNode;
            LastNode = firstNode;
            Length++;
        }

        /// <summary>
        /// Initialise a new linked list containing the passed nodes.
        /// <example>
        /// For example:
        /// <code>
        /// LinkedList newList = new(new Node(7), new Node(14), new Node(42));
        /// </code>
        /// creates a linked list containing the values [7, 14, 42].
        /// </example>
        /// </summary>
        /// <param name="nodes">A set of nodes to include in this linked list.</param>
        public LinkedList(params Node[] nodes)
        {
            foreach (Node node in nodes)
            {
                Append(node);
            }
        }

        /// <summary>
        /// Initialise a linked list containing the given values.
        /// <example>
        /// For example:
        /// <code>
        /// LinkedList newList = new(7, 14, 42);
        /// </code>
        /// creates a linked list containing the values [7, 14, 42].
        /// </example>
        /// </summary>
        /// <param name="values">A set of values to store in the linked list.</param>
        public LinkedList(params int[] values)
        {
            foreach (int value in values)
            {
                Append(value);
            }
        }

        /// <summary>
        /// Accessor to retrieve the value stored at a given index in the linked list.
        /// </summary>
        /// <param name="index">Index to access.</param>
        /// <returns>The value stored at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="index"/> is greater than or equal to the length of the linked list.
        /// </exception>
        public int this[int index] => At(index).Value;

        /// <summary>
        /// Accessor to retrieve the <c>Node</c> stored at a given index in the linked list.
        /// </summary>
        /// <param name="index">Index to access.</param>
        /// <returns>The <c>Node</c> stored at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="index"/> is greater than or equal to the length of the linked list.
        /// </exception>
        private Node At(int index)
        {
            if (index >= Length)
            {
                throw(new IndexOutOfRangeException($"Index {index} is out of range {Length}"));
            }
            int i = index;
            if (index < 0)
            {
                i = Length - index;
            }
            Node activeNode = FirstNode;
            for (int x = 1; x <= i; x++) {
                activeNode = activeNode.Next;
            }
            return activeNode;
        }

        /// <summary>
        /// Append the given <c>Node</c> to the end of the linked list.
        /// </summary>
        /// <param name="node">The <c>Node</c> to append.</param>
        public void Append(Node node)
        {
            Length++;
            if (FirstNode == null)
            {
                FirstNode = node;
                LastNode = node;
                return;
            }
            LastNode.Next = node;
            LastNode = node;
        }

        /// <summary>
        /// Append a value to the linked list as a <c>Node</c>.
        /// </summary>
        /// <param name="value">Value to append.</param>
        public void Append(int value)
        {
            Append(new Node(value));
        }

        /// <summary>
        /// Insert a value in the linked list at a specific index.
        /// </summary>
        /// <param name="value">Value to insert.</param>
        /// <param name="index">Index to insert <paramref name="index"/> at.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown if <paramref name="index"/> is greater than or equal to the length of the linked list.
        /// </exception>
        public void Insert(int value, int index) {
            if (index >= Length)
            {
                throw(new IndexOutOfRangeException($"Whoops! Index {index} is outside of range {Length}"));
            }

            if (Length == 0)
            {
                Append(new Node(value));
                return;
            }

            Node activeNode = At(index);
            Node newNode = new(value);
            if (index == 0) {
                newNode.Next = FirstNode;
                FirstNode = newNode;
                Length++;
                return;
            }
            
            Node previousNode = At(index - 1);
            newNode.Next = activeNode;
            previousNode.Next = newNode;
            Length++;
        }

        /// <summary>
        /// Removes a value from the linked list.
        /// </summary>
        /// <param name="value">Value to attempt to remove.</param>
        /// <returns><c>bool</c> representing whether the value was removed.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the length of the linked list is 0.
        /// </exception>
        public bool Remove(int value) {
            if (Length == 0)
            {
                throw(new IndexOutOfRangeException("There are no values here!"));
            }

            if (FirstNode.Value == value) {
                FirstNode = FirstNode.Next;
                if (FirstNode == null)
                {
                    LastNode = null;
                }
                Length--;
                return true;
            }

            for (int i = 1; i < Length; i++)
            {
                Node activeNode = At(i);
                if (activeNode.Value == value) {
                    Node previousNode = At(i-1);
                    if (activeNode.Next == null)
                    {
                        LastNode = previousNode;
                    }
                    previousNode.Next = activeNode.Next;
                    Length--;
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string outStr = "[";

            for (int i = 0; i < Length; i++)
            {
                string separator = i != Length - 1 ? "," : "";
                outStr += $"{this[i]}{separator}";
            }

            return outStr + "]";
        }
    }

    /// <summary>
    /// A node containing data to be stored in a linked list.
    /// </summary>
    class Node {
        /// <summary>
        /// <value>The integer value stored in this <c>Node</c>.</value>
        /// </summary>
        public int Value { get; }
        /// <summary>
        /// <value>The next <c>Node</c> stored in the linked list. Null if this is the end of the list.</value>
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Initialise a new <c>Node</c> containing a single <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value for this <c>Node</c> to hold.</param>
        public Node(int value)
        {
            Value = value;
        }
    }
}