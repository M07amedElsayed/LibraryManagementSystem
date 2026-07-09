using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class PremiumMember : Member
    {
        public override int LoanDays { get; } = 30;
    }
}
