using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
            }

            Member member = FindMemberById(memberid);
            if (member == null)
            {
                Console.WriteLine("The member is not exist");
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

        
    }
}
