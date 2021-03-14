using CsvHelper;
using System.Globalization;
using System.IO;

namespace CsvUpdater.Utility
{
    public class NameHelper
    {
        private int _index;
        private string[] _lastNames;

        public NameHelper()
        {

            _lastNames = File.ReadAllLines(@"c:\temp\csvFiles\LastNames.txt");


        }



        public string PerformGetLastName(int index)
        {

            _index = index;

            var lastName = _lastNames[_index];

            //var lastName = "MyLastName-" + index;

            return lastName;
        }


    }
}
