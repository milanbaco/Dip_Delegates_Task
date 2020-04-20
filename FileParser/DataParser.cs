using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            char[] charsToTrim = { ' ' };
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Trim(charsToTrim);
                }
            }
            return data; //-- return result here
        }
    

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            char[] charsToTrim = { '"' };

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].TrimStart(charsToTrim);
                    data[i][j] = data[i][j].TrimEnd(charsToTrim);
                }
            }

            

           

            return data; //-- return result here
        }

    }
}