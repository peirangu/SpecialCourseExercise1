using System;

namespace LibrarySystem
{
    public class Magazine : LibraryItem
    {
        private int issueNumber;
        public int IssueNumber => issueNumber;
        
        public Magazine(int id, string title, int issueNumber)
            : base(id, title, ItemType.Magazine)
        {
            if (issueNumber <= 0)
            {
                Console.WriteLine("Issue number must be a positive integer");
                return;
            }
            this.issueNumber = issueNumber;
        }
        
        public override string GetDetails()
        {
            return $"[Magazine] ID: {Id}, Title: {Title}, Issue Number: Issue {IssueNumber}";
        }
    }
}