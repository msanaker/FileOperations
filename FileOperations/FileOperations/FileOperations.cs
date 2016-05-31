using System;
using System.Reflection;

namespace FileOperations
{
    public class FileOperations
    {
        /// <summary>
        /// Checks for the existence of the provided file path, if the path exists it attempts to find an alternate file name to use by appending a digit in parenthesis to the file name.  If the path does not yet exist it is returned, otherwise the alternate path is returned.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private static String checkFilePath(string filepath)
        {
            try
            {
                String path = filepath;
                if (System.IO.File.Exists(path))
                {
                    int j = 1;
                    string fileType = string.Empty;
                    for (int i = 0; i < j; i++)
                    {
                        fileType = path.Substring(path.Length - j, j);
                        if (fileType.Contains("."))
                        {
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                    char[] toTrim = fileType.ToCharArray();
                    string basePath = path.Trim(toTrim);
                    int c = 1;
                    for (int i = 0; i < c; i++)
                    {
                        string fileToCheck = basePath + "(" + c.ToString() + ")" + fileType;
                        if (System.IO.File.Exists(fileToCheck))
                        {
                            c++;
                        }
                        else
                        {
                            path = fileToCheck;
                            break;
                        }
                    }
                }
                return path;
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

    }
}
/*
    Copyright 2016 Matthew Sanaker, matthew@sanaker.com, @msanaker on GitHub
    
    This file is part of 'FileOperations'.

    'FileOperations' is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    'FileOperations' is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FileOperations.  If not, see <http://www.gnu.org/licenses/>.
*/
