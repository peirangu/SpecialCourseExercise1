using System;

namespace LibrarySystem
{
    public enum ItemType
    {
        Novels,
        Magazine,
        TextBook
    }
    
    public abstract class LibraryItem
    {
        private int id;
        private string title;
        private ItemType itemType;
        
        public int Id => id;
        public string Title => title;
        public ItemType ItemType => itemType;
        
        public LibraryItem(int id, string title, ItemType itemType)
        {
            if (title == null)
            {
                Console.WriteLine("Title cannot be null");
                return;
            }
            
            this.id = id;
            this.title = title;
            this.itemType = itemType;
        }
        
        public abstract string GetDetails();
    }
}