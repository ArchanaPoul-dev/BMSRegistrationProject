using BMSLoanService_Loan.Interfaces;
using BMSLoanService_Loan.Data;
using BMSLoanService_Loan.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService_Loan.Services
{
    public class LoanRepository:ILoanRepository
    {
        private readonly ApplicationDBContext _context;
        public LoanRepository(ApplicationDBContext context)
        {
            _context = context;

        }
        public Loan Add(Loan _loan)
        {
            try
            {
                _context.Add(_loan);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _loan;
        }
    }
}
