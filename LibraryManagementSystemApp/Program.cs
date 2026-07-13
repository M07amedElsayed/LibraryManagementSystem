using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System;
using System.Reflection;



namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        { 

            Library library = new Library();

            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome To The Library System.");
                    Console.WriteLine("_________________________________");
                    Console.WriteLine("1- Add Book");
                    Console.WriteLine("2- Register Member");
                    Console.WriteLine("3- Borrow Book");
                    Console.WriteLine("4- Return Book");
                    Console.WriteLine("5- Search the Catalog");
                    Console.WriteLine("6- View Available Books");
                    Console.WriteLine("7- Member Borrowing History");
                    Console.WriteLine("8- Late Return Report");
                    Console.WriteLine("9- exit");
                    Console.WriteLine("_________________________________");
                    Console.WriteLine("Please enter a Numbera from 1 To 8  :");

                    var result = int.Parse(Console.ReadLine());



                    switch (result)
                    {



                        case 1:
                            Console.WriteLine("Please Enter The Title :");
                            var titel = Console.ReadLine();
                            Console.WriteLine("Please Enter The Author :");
                            var author = Console.ReadLine();
                            Console.WriteLine("Please Enter The Year  :");
                            var year = int.Parse(Console.ReadLine());

                            Book book = new Book()
                            {
                                Title = titel,
                                Author = author,
                                Year = year

                            };
                            library.AddBook(book);
                            break;

                        case 2:

                            Console.WriteLine("Please enter your Name :");
                            var name = Console.ReadLine();
                            Console.WriteLine("Please enter your Email :");
                            var email = Console.ReadLine();

                            Console.WriteLine("Chose The Number type :");
                            Console.WriteLine("1- Regular Member");
                            Console.WriteLine("2- Premium Member");

                            int check = int.Parse(Console.ReadLine());
                            Member member = null;
                            if (check == 1)
                            {

                                member = new Member()
                                {
                                    Name = name,
                                    Email = email
                                };

                            }
                            else if (check == 2)
                            {

                                member = new PremiumMember()
                                {
                                    Name = name,
                                    Email = email
                                };

                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }

                            library.RegisterMember(member);

                            break;

                        case 3:
                            Console.WriteLine("Please Enter The BookId :");
                            var bookid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please Enter The MemberId :");
                            var memberid = int.Parse(Console.ReadLine());

                            library.BorrowBook(bookid, memberid);
                            break;

                        case 4:
                            Console.WriteLine("Please Enter The BookId That You Want to Return : ");
                            var bookid2 = int.Parse(Console.ReadLine());
                            library.ReturnBook(bookid2);
                            break;

                        case 5:
                            Console.WriteLine("Please Enter The Query you want to Search Book(Title) ,Member(Name or Email) : ");
                            var query = Console.ReadLine();
                            library.SearchCatalog(query);
                            break;

                        case 6:
                            Console.WriteLine("The Available Book :");
                            library.ViewAvailableBooks();
                            break;

                        case 7:
                            Console.WriteLine("Please Enter MemberId : ");
                            var memberid2 = int.Parse(Console.ReadLine());

                            library.MemberBorrowingHistory(memberid2);
                            break;


                        case 8:
                            Console.WriteLine();
                            library.LateReturnReport();
                            break;


                        case 9:
                            Environment.Exit(0);
                            break;




                    }
                }
                catch
               
                (Exception ex) 
                { Console.WriteLine(ex.Message); 
                }
            }




 




        }
    }
}
