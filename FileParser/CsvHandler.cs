using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FileParser;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            FileHandler _fh = new FileHandler();
            DataParser _dp = new DataParser();

            List<string> dataFile = _fh.ReadFile(readFile);

            List<List<string>> csvFile = _fh.ParseCsv(dataFile);

            dataHandler += _dp.StripQuotes;
            dataHandler += _dp.StripWhiteSpace;
            List<List<string>> result = dataHandler.Invoke(csvFile);

            _fh.WriteFile(writeFile, ',', result);

        }
        
    }
}