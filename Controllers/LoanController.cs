using BMSLoanService_Loan.Interfaces;
using BMSLoanService_Loan.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService_Loan.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanapp;
        public LoanController(ILoanRepository loan)
        {
            _loanapp = loan;
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Add(Loan _loan)
        {
            try
            {
                if (_loan == null) return BadRequest();
                var result = _loanapp.Add(_loan);
                 if (result!=null)
                    return Ok(_loan);
                 else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                string filePath = @"D:\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }                
                return BadRequest(ex.Message);
            }

        }
    }
}

