using CsvHelper.Configuration.Attributes;

namespace CsvUpdater.Models
{
    public class LoanModel
    {
        [Name(Constants.CsvHeaders.BorrowerName)]
        public string BorrowerName { get; set; }

        [Name(Constants.CsvHeaders.City)]
        public string City { get; set; }

        [Name(Constants.CsvHeaders.State)]
        public string State { get; set; }

        [Name(Constants.CsvHeaders.LoanNumber)]
        public string LoanNumber { get; set; }

        [Name(Constants.CsvHeaders.LoanAmount)]
        public string LoanAmount { get; set; }

    }


}
