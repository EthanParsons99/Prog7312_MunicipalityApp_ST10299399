using System.Collections;

namespace Prog7312_MunicipalityApp_ST10299399.Models
{
    // Node class for linked list
    public class IssueCollection : IEnumerable<Issue>
    {
        private IssueNode head; // Head of the linked list

        public int Count { get; private set; } // Number of issues in the collection


        public IssueCollection()
        {
            // Initialize an empty collection
            head = null;
            Count = 0;
        }

       
        public void Add(Issue issue)
        {
            // Add new issue to the front of the list
            var newNode = new IssueNode(issue);
            newNode.Next = head;
            head = newNode;
            Count++;
        }

        public Issue Get(int index)
        {
            // Get issue by index
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            IssueNode current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        // Get issue by ID
        public Issue GetById(int id)
        {
            // Traverse the list to find the issue with the specified ID
            IssueNode current = head;
            while (current != null)
            {
                if (current.Data.Id == id)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null; // Not found
        }
        // Enumerator to allow foreach iteration
        public IEnumerator<Issue> GetEnumerator()
        {
            // Traverse the linked list
            IssueNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
