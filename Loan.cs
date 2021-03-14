using System;
using System.Collections.Generic;
using System.Text;

namespace CsvUpdater
{
    public class Loan
    {

		public string BorrowerName { get; }
		public string City { get; }
		public string State { get; }
		public string LoanNumber { get; }
		public decimal LoanAmount { get; }

		public Loan(string borrowerName, string city, string state, string loanNumber, decimal loanAmount)
		{
			this.BorrowerName = borrowerName;
			this.City = city;
			this.State = state;
			this.LoanNumber = loanNumber;
			this.LoanAmount = loanAmount;
		}

    }
}
