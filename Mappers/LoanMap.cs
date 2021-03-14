using CsvUpdater.Models;
using CsvHelper.Configuration;

namespace CsvUpdater.Mappers
{
    public sealed class LoanMap : ClassMap<LoanModel>
    {
        public LoanMap()
        {
            Map(m => m.BorrowerName).Name(Constants.CsvHeaders.BorrowerName);
            Map(m => m.City).Name(Constants.CsvHeaders.City);
            Map(m => m.State).Name(Constants.CsvHeaders.State);
            Map(m => m.LoanNumber).Name(Constants.CsvHeaders.LoanNumber);
            Map(m => m.LoanAmount).Name(Constants.CsvHeaders.LoanAmount);
        }
    }
}
