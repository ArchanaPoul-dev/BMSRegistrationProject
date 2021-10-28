using BMSLoanService_Loan.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService_Loan.Interfaces
{
    public interface ILoanRepository
    {
        Loan Add(Loan _reg);
    }
}
