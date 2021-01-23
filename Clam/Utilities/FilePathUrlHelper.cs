using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clam.Utilities
{
    public class FilePathUrlHelper
    {

        /// <summary>
        /// Get a path and return it's substring path using a restricted index position, using an index count for the character '\'
        /// </summary>
        /// <param name="path">Path Route</param>
        /// <param name="restriction">Index Count Restriction</param>
        /// <returns></returns>
        public static string DataFilePathFilter(string path, int restriction)
        {

            int count = 0;
            int startPathIndex = 0;
            char getIndex = '\\';

            string filteredPath = string.Empty;

            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == getIndex)
                {
                    count++;
                    if (count == restriction)
                    {
                        startPathIndex = i + 1;
                    }
                }
            }

            filteredPath = path.Substring(startPathIndex, path.Length - startPathIndex);
            return filteredPath;
        }

        /// <summary>
        /// Get a path and return the index of a directory using an index count for the character '\'
        /// </summary>
        /// <param name="path">Path Route</param>
        /// <param name="restriction">Index Count Restriction</param>
        /// <returns></returns>
        public static int DataFilePathFilterIndex(string path, int restriction)
        {

            int count = 0;
            int startPathIndex = 0;
            char getIndex = '\\';

            string filteredPath = string.Empty;

            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == getIndex)
                {
                    count++;
                    if (count == restriction)
                    {
                        startPathIndex = i;
                    }
                }
            }
            return startPathIndex;
        }

        /// <summary>
        /// Get a path and return its absolute file path in system
        /// </summary>
        /// <param name="path">Path stored in database</param>
        /// <param name="key">Stored Folder Name</param>
        /// <param name="rootDirectory">Stored Root Directory</param>
        /// <returns></returns>
        public static string DirectoryFilter(string path, string key, string rootDirectory)
        {

            string filteredPath = path.Substring(path.IndexOf(key));
            string pathToReturn = Path.Combine(rootDirectory, filteredPath);
            string pathToImageFiltered = pathToReturn.Replace("\\", "/");
            return (pathToImageFiltered);
        }

        /// <summary>
        /// Get path and removes the last index of path containing '\' for windows. Can be used for deleting files or folders
        /// </summary>
        /// <param name="path">Chosen Path</param>
        /// <returns></returns>
        public static string GetFileDirectoryPath(string path)
        {
            string filteredDirectoryName = path.Substring(0, path.LastIndexOf(@"\"));
            return filteredDirectoryName;
        }

        /// <summary>
        /// Get file name containing an extension (Example: File.txt) and removing the extension so the file contains only the title
        /// </summary>
        /// <param name="path">File Title</param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            //string filteredPathFileName = path.Substring(path.LastIndexOf(@"\"), path.Length - path.LastIndexOf(@"\"));
            string filteredPathFileName = path;
            return filteredPathFileName.Substring(0, filteredPathFileName.LastIndexOf(@"."));
        }


        /// <summary>
        /// Get File Name at the end of a path string: c:/some/path/string/[filename.extension]
        /// </summary>
        /// <param name="path">Path String</param>
        /// <returns></returns>
        public static string GetFileAtEndOfPath(string path)
        {
            int pathIndex = path.LastIndexOf(@"\") + 1;
            string fileName = path.Substring(pathIndex, path.Length - pathIndex);
            return fileName;
        }

        /// <summary>
        /// Convert String input into Url format, with lowercase and replacing spaces with '-'
        /// </summary>
        /// <param name="path">Route Path</param>
        /// <returns></returns>
        public static string UrlString(string path)
        {
            string filteredUrl = path.ToLower().Replace(" ", "-");
            return filteredUrl;
        }

        /// <summary>
        /// Generate a custom string path from a Guid and returns as string
        /// </summary>
        /// <param name="id">Guid required as a parameter</param>
        /// <returns></returns>
        public static string GenerateKeyPath(Guid id)
        {

            var restriction = "-";
            var firstConvert = id.ToString().IndexOf(restriction);
            var lastConvert = id.ToString().LastIndexOf(restriction) + 1;

            var firstExtract = id.ToString().Substring(0, firstConvert);
            var lastExtract = id.ToString().Substring(lastConvert, id.ToString().Length - lastConvert);

            int length = 10;

            // creating a StringBuilder object()
            StringBuilder buildPathString = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt + firstConvert));
                letter = Convert.ToChar(shift + 65 + lastConvert);
                buildPathString.Append(letter);
            }

            var complete = Path.GetRandomFileName() + lastExtract + Path.GetRandomFileName() + firstExtract + buildPathString.ToString();
            return complete;
        }

        /// <summary>
        /// Retrieves the last portion from a Guid 'xxxxx-xx-xx-xx-[Here]' and returns as string
        /// </summary>
        /// <param name="id">Guid required as a parameter</param>
        /// <returns></returns>
        public static string LastIndexGuidPath(Guid id)
        {
            var restriction = "-";
            var convert = id.ToString().LastIndexOf(restriction) + 1;
            var complete = id.ToString().Substring(convert, id.ToString().Length - convert);
            return complete;
        }

        /// <summary>
        /// Retrieves the first portion from a Guid '[Here]-xx-xx-xx-xxxxx' and returns as string
        /// </summary>
        /// <param name="id">Guid required as a parameter</param>
        /// <returns></returns>
        public static string FirstIndexGuidPath(Guid id)
        {
            var restriction = "-";
            var convert = id.ToString().IndexOf(restriction);
            var complete = id.ToString().Substring(0, convert);
            return complete;
        }

        /// <summary>
        /// Takes a Youtube Url (String) and converts it into an embedded Url that can be used in site
        /// </summary>
        /// <param name="url">Youtube Url</param>
        /// <returns></returns>
        public static string YoutubePathFilter(string url)
        {
            string key = "/embed/";
            if (url.Contains(key))
            {
                return url;
            }
            int indexKey = url.LastIndexOf(@"=") + 1;
            string urlFirst = url.Substring(0, url.LastIndexOf(@"/"));
            string urlSecond = url.Substring(indexKey, url.Length - indexKey);
            string embbededUrl = urlFirst + key + urlSecond;
            return embbededUrl;
        }
    }
}
