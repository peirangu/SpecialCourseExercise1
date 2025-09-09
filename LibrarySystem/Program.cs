using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================== Library Management System ===================\n");


            var library = new LibraryManager();
            
            Console.WriteLine("【1a: Add Library Items】");
            library.AddItem(new Novel(id: 1, title: "The Three-Body Problem", author: "Liu Cixin"));
            library.AddItem(new Magazine(id: 2, title: "Scientific American", issueNumber: 202509));
            library.AddItem(new TextBook(id: 3, title: "C# Programming Guide", publisher: "Tsinghua"));
            library.AddItem(new Novel(id: 4, title: "To Live", author: "Yu Hua"));
            
            Console.WriteLine("\n【2,3,4: Register Members】");
            var alice = new Member(name: "Alice");
            var bob = new Member(name: "Bob");
            library.RegisterMember(alice);
            library.RegisterMember(bob);
            
            Console.WriteLine("\n \n【5: Show Catalog】");
            library.ShowCatalog();
            
            Console.WriteLine("\n【6, 6a, 6b: Alice Borrows Items】");
            BorrowItemByMember(library, alice, itemId: 1);
            BorrowItemByMember(library, alice, itemId: 2);
            BorrowItemByMember(library, alice, itemId: 3);
            alice.ShowBorrowedItems();
            
            Console.WriteLine("\n【7, 7a, 7b: Verify Borrow Limit (Max 3 Items)】");
            BorrowItemByMember(library, alice, itemId: 4);
            alice.ShowBorrowedItems();

            Console.WriteLine("\n=================== System Operation Completed ===================");
        }

        private static void BorrowItemByMember(LibraryManager library, Member member, int itemId)
        {
            var item = library.FindItemById(itemId);
            if (item == null)
            {
                Console.WriteLine($"  Item with ID {itemId} not found. {member.Name} failed to borrow!");
                return;
            }

            var result = member.BorrowItem(item);
            Console.WriteLine($"  {result}");
        }

        private static void ReturnItemByMember(LibraryManager library, Member member, int itemId)
        {
            var item = library.FindItemById(itemId);
            if (item == null)
            {
                Console.WriteLine($"  Item with ID {itemId} not found. {member.Name} failed to return!");
                return;
            }

            var result = member.ReturnItem(item);
            Console.WriteLine($"  {result}");
        }
    }
}
