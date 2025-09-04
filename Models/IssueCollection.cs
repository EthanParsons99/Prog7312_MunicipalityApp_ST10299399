using System.Collections;

namespace Prog7312_MunicipalityApp_ST10299399.Models
{
    public class IssueCollection : IEnumerable<Issue>
    {
        private IssueNode head; // Head of the linked list

        public int Count { get; private set; } // Number of issues in the collection

        public IssueCollection()
        {
            head = null;
            Count = 0;
        }

        public void Add(Issue issue)
        {
            var newNode = new IssueNode(issue);
            newNode.Next = head;
            head = newNode;
            Count++;
        }

        public Issue Get(int index)
        {
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

        public Issue GetById(int id)
        {
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

        public IEnumerator<Issue> GetEnumerator()
        {
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
