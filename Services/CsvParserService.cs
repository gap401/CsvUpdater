using CsvHelper;
using CsvHelper.Configuration;
using CsvUpdater.Mappers;
using CsvUpdater.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvUpdater.Services
{
    public class CsvParserService : ICsvParserService
    {
        public List<LoanModel> ReadCsvFileToLoanModel(string path)
        {
            try
            {
                using (var reader = new StreamReader(path, Encoding.Default))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        TrimOptions = TrimOptions.Trim,
                        Comment = '@',
                        HasHeaderRecord = true,
                    };

                    csv.Context.RegisterClassMap<LoanMap>();

                    var records = csv.GetRecords<LoanModel>().ToList();
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void WriteNewCsvFile(string path, List<LoanModel> loanModels)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<LoanModel>();
                cw.NextRecord();

                foreach (LoanModel loan in loanModels)
                {
                    cw.WriteRecord(loan);
                    cw.NextRecord();
                }

            }
        }
    }
}
