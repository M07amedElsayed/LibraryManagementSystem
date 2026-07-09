using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem.Models
{
    public class Member : ISearchable
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime JoinDate { get; set; }
        public virtual int LoanDays { get; } = 14;
        public Book[] BorrowedBooks { get; set; }

        public bool MatchesQuery(string query)
        {
            query = query.ToLower();

            return Name.ToLower().Contains(query) ||
                   Email.ToLower().Contains(query);

        }
    }

     
}
