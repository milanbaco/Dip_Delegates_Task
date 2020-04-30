using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FileParser {

    public class FileHandler {
       public FileHandler() {

            

        }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// 
        public List<string> ReadFile(string filePath) {
            _ = new List<string>();

            List<string> lines = File.ReadLines(filePath).ToList();

            return lines; //-- return result here
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {

            StringBuilder sb = new StringBuilder();

            foreach (List<string> line in rows)
                {
                    sb.AppendLine(String.Join(delimeter.ToString(), line));
                }
            File.WriteAllText(filePath, sb.ToString());

        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) {
            List<List<string>> result = new List<List<string>>();

            foreach (string line in data)
            {
                result.Add(line.Split(delimiter).ToList());
            }

            return result; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> result = new List<List<string>>();

            foreach (string line in data)
            {
                result.Add(line.Split(',').ToList());
            }
            return result;  //-- return result here
        }
    }
}