using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Member
    {
        private string name;
        private List<LibraryItem> borrowedItems;
        
        public string Name => name;
        
        public Member(string name)
        {
            if (name == null)
            {
                Console.WriteLine("Member name cannot be null");
                return;
            }
            this.name = name;
            this.borrowedItems = new List<LibraryItem>();
        }
        
        public string BorrowItem(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Borrowed item cannot be null");
                return string.Empty;
            }
            
            if (borrowedItems.Count >= 3)
            {
                return $"{name}, you cannot borrow more than 3 items!";
            }
            
            if (borrowedItems.Contains(item))
            {
                return $"{name}, you have already borrowed 《{item.Title}》. No need to borrow it again!";
            }

            borrowedItems.Add(item);
            return $"{name} successfully borrowed: 《{item.Title}》";
        }
        
        public string ReturnItem(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Returned item cannot be null");
                return string.Empty;
            }

            if (borrowedItems.Contains(item))
            {
                borrowedItems.Remove(item);
                return $"{name} successfully returned: 《{item.Title}》";
            }

            return $"{name}, you did not borrow 《{item.Title}》, so you cannot return it!";
        }
        
        public List<LibraryItem> GetBorrowedItems()
        {
            return borrowedItems != null ? new List<LibraryItem>(borrowedItems) : new List<LibraryItem>();
        }
        
        public void ShowBorrowedItems()
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Member name is not valid");
                return;
            }
            
            Console.WriteLine($"\n{name}'s Current Borrowed Items List:");
            if (borrowedItems == null || borrowedItems.Count == 0)
            {
                Console.WriteLine("No borrowed items yet");
                return;
            }

            foreach (var item in borrowedItems)
            {
                Console.WriteLine($"  - {item.GetDetails()}");
            }
        }
    }
}