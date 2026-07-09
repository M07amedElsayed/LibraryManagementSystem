using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book : LibraryItem, ISearchable
    {
        public int Year { get; set; }
        public string Author { get; set; }

        public string Genre { get; set; }

        public bool IsAvailable { get; set; }

        public bool MatchesQuery(string query)
        {
            query = query.ToLower();

            return Title.ToLower().Contains(query);
        }




        public override string GetInfo()
        {
            return $"Id: {Id}, Title: {Title}, Author: {Author}, Year: {Year}, Genre: {Genre}, Available: {IsAvailable}";
        }
    }
}
