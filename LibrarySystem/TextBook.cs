using System;

namespace LibrarySystem
{
    public class TextBook : LibraryItem
    {
        private string publisher;
        
        public string Publisher => publisher;
        
        public TextBook(int id, string title, string publisher)
            : base(id, title, ItemType.TextBook)
        {
            if (publisher == null)
            {
                Console.WriteLine("Publisher cannot be null");
                return;
            }
            this.publisher = publisher;
        }
        
        public override string GetDetails()
        {
            return $"[TextBook] ID: {Id}, Title: {Title}, Publisher: {Publisher}";
        }
    }
}