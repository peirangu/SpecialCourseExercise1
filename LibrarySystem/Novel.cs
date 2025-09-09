using System;

namespace LibrarySystem
{
    public class Novel : LibraryItem
    {
        private string author;
        public string Author => author;
        
        public Novel(int id, string title, string author) 
            : base(id, title, ItemType.Novels) 
        {
            if (author == null)
            {
                Console.WriteLine("Author can not be null");
                return;
            }
            
            this.author = author;
        }
        
        public override string GetDetails()
        {
            return $"[Novel] ID: {Id}, Title: {Title}, Author: {Author}";
        }
    }
}