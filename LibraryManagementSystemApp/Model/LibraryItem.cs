using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime AddedDate {get ; set ;}

        public abstract string GetInfo();
    }
}
