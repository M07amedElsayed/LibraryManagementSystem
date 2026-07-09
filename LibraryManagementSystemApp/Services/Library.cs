using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryManagementSystem.Services
{
    public class Library
    {
        Book[] books = new Book[100];
        
        int currenbookcount = 0;

        Member[] members = new Member[100];

        int currentmembercount = 0;

        
        BorrowRecord[] Borrowrecords = new BorrowRecord[25];
        int currentborrowscount = 0;



        public void AddBook(Book book)
        {

            if(currenbookcount<books.Length)
            {
                books [currenbookcount] = book;
                currenbookcount++;
                book.Id = currenbookcount;

                Console.WriteLine("The Book Added Sucsessfuly.");
            }
            else
            {
                Console.WriteLine("Library is full, canot add books");
            }


        }

        public void RegisterMember(Member member)
        {
            if (currentmembercount >= members.Length)
            {
                Console.WriteLine("Library members are full.");
                return;
            }
            member.Id = currentmembercount + 1;
            members [currentmembercount] = member;

            member.JoinDate = DateTime.Now;
            
            currentmembercount++;

        }

        public Book FindBookById(int id)
        {
            
            for (int i = 0; i <currenbookcount ; i++)
            {
                if (books[i].Id == id)
                {
                    return books[i];
                }
            }
            return null;
        }
        public Member FindMemberById(int memberid)
        {
            for (int i = 0; i < currentmembercount; i++)
            {
                if (members[i].Id == memberid)
                {
                    return members[i];
                }
            }
            return null;
        }
        public void BorrowBook(int bookid , int memberid)
        {
            Book  book1 = FindBookById(bookid);
            if(book1 == null)
            {
                Console.WriteLine("The Book is not exist.");
                return;
            }

            Member member = FindMemberById(memberid);
            if (member == null)
            {
                Console.WriteLine("The member is not exist");
                return;

            }

            if (!book1.IsAvailable)
            {
                Console.WriteLine("Book is already borrowed.");
                return;
            }

            if (currentborrowscount >= Borrowrecords.Length)
            {
                Console.WriteLine("Borrow records are full.");
                return;
            }

            BorrowRecord record = new BorrowRecord();

            record.Id = currentborrowscount + 1;
            record.Book = book1;
            record.Member = member;
            record.BorrowDate = DateTime.Now;
            record.DueDate = DateTime.Now.AddDays(member.LoanDays);
            record.ReturnDate = null;

            Borrowrecords[currentborrowscount] = record;
            currentborrowscount++;

            Console.WriteLine("Book borrowed successfully.");
            book1.IsAvailable = false;
        }
        
        public void ReturnBook(int bookid)
        {
            Book book = FindBookById(bookid);


            if(book == null )
            {
                Console.WriteLine("The is not exist.");
                return;
            }

            for (int i = 0; i < currentborrowscount; i++)
            {
                if (Borrowrecords[i].Book.Id== bookid && Borrowrecords[i].ReturnDate == null)
                {
                    Borrowrecords[i].Book.IsAvailable = true;

                    Borrowrecords[i].ReturnDate= DateTime.Now;
                    Console.WriteLine("Book returned successfully.");
                    return;
                }                
            }
            Console.WriteLine("The Book is not currently borrowed");
        }


        public void SearchCatalog(string query)
        {
           bool found = false;

            for (int i = 0; i < currenbookcount; i++)
            {
                if (books[i].MatchesQuery(query))
                {

                    Console.WriteLine(books[i].GetInfo());
                    found = true; 
                }
            }

            for (int i = 0; i < currentmembercount; i++)
            {
                if (members[i].MatchesQuery(query))
                {
                    Console.WriteLine($"Id :{members[i].Id},Name : {members[i].Name}, Email : {members[i].Email} ");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No results found.");
            }
        }

      
        public void ViewAvailableBooks()
        {
            bool found = false;

            for (int i = 0; i < currenbookcount; i++)
            {
                if(books[i].IsAvailable) 
                {
                
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(books[i].GetInfo());
               
                    found = true;
                }
                
                
            }

            if (found ==false)
            {
                Console.WriteLine("No available books.");
            }

        }

        public void MemberBorrowingHistory(int memberid)
        {

            Member member = FindMemberById(memberid);

            if(member == null)
            {
                Console.WriteLine("The Member is not exist");
                return;
            }
            bool found = false;

            for (int i = 0; i < currentborrowscount; i++)
            {
                if (Borrowrecords[i].Member.Id == memberid)
                {
                    Console.WriteLine("-----------------------------------------");

                    Console.WriteLine($"Title        : {Borrowrecords[i].Book.Title}");
                    Console.WriteLine($"Borrow Date  : {Borrowrecords[i].BorrowDate}");
                    if (Borrowrecords[i].ReturnDate== null)
                    {
                        Console.WriteLine("Returned  : No");
                    }
                    else
                    {
                        Console.WriteLine("Returned  : Yes");

                        Console.WriteLine($"Returned Date: {Borrowrecords[i].ReturnDate}");
                    }
                    Console.WriteLine("-----------------------------------------");

                    found = true;
                }
                
            }
            if (found == false)
            {

                Console.WriteLine("The membeer has not borrow yet");
            }

        }

        public void LateReturnReport()
        {

            bool found = false;
            for (int i = 0; i < currentborrowscount; i++)
            {
                if (Borrowrecords[i].IsLate())
                {
                    int result = (DateTime.Now - Borrowrecords[i].DueDate).Days;


                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"Name       : {Borrowrecords[i].Member.Name}");
                    Console.WriteLine($"Book title : {Borrowrecords[i].Book.Title}");
                    Console.WriteLine($"BorrowDate : {Borrowrecords[i].BorrowDate}");
                    Console.WriteLine($"Due Date   : {Borrowrecords[i].DueDate:d}");
                    Console.WriteLine($"OverDue    : {result}");
                    Console.WriteLine("-----------------------------------------");

                    found = true;
                }


            }
            if(!found)
            {
                Console.WriteLine("The Days didn't finish yet.");
            }
        }
    }
}
