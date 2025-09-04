using Microsoft.AspNetCore.Mvc;

namespace Prog7312_MunicipalityApp_ST10299399.Models
{
    // Node class for linked list implementation of issues
    // Each node contains an issue and a reference to the next node
    public class IssueNode
    {
        // The issue data contained in this node
        public Issue Data { get; set; }

        // Reference to the next node in the linked list
        //Links to the next issue node
        public IssueNode Next { get; set; }

        // Constructor to initialize the node with issue data
        public IssueNode(Issue data)
        {
            Data = data;
            Next = null;
        }
    }
}
