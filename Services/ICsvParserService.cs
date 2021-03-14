using CsvUpdater.Models;
using System.Collections.Generic;

namespace CsvUpdater.Services
{
    public interface ICsvParserService
    {
        List<LoanModel> ReadCsvFileToLoanModel(string path);
        void WriteNewCsvFile(string path, List<LoanModel> loanModels);
    }
}
