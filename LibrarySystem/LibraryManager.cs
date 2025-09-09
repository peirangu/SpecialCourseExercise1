using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class LibraryManager
    {
        private List<LibraryItem> catalog;
        private List<Member> members;
        
        public LibraryManager()
        {
            this.catalog = new List<LibraryItem>();
            this.members = new List<Member>();
        }
        
        public void AddItem(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("The item to add cannot be null");
                return;
            }
            
            if (catalog.Any(i => i.Id == item.Id))
            {
                Console.WriteLine($"Warning: An item with ID {item.Id} already exists and was not added again!");
                return;
            }

            catalog.Add(item);
            Console.WriteLine($"Successfully added item: {item.GetDetails()}");
        }
        
        public void RegisterMember(Member member)
        {
            if (member == null)
            {
                Console.WriteLine("The member to register cannot be null");
                return;
            }
            
            if (members.Any(m => m.Name.Equals(member.Name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Warning: A member named {member.Name} is already registered and was not added again!");
                return;
            }

            members.Add(member);
            Console.WriteLine($"Successfully registered member: {member.Name}");
        }
        
        public void ShowCatalog()
        {
            Console.WriteLine("\n=================== Library Item Catalog ===================");
            if (catalog.Count == 0)
            {
                Console.WriteLine("  The catalog is empty; no items available yet");
                return;
            }

            foreach (var item in catalog)
            {
                Console.WriteLine($"  {item.GetDetails()}");
            }
            Console.WriteLine("============================================================");
        }
        
        public LibraryItem? FindItemById(int id)
        {
            return catalog.Find(item => item.Id == id);
        }
        
        public Member? FindMemberByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be null or whitespace when searching for a member");
                return null;
            }
            return members.Find(member => 
                member.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}