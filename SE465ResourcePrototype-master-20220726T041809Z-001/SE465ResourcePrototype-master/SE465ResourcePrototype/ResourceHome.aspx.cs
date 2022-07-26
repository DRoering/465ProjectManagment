using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE465ResourcePrototype
{
    public partial class ResourceHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string line;
            string fileContents = "";
            string header = "<tr>" +
                                "<td colspan ='100%'> <hr style = 'border-bottom: 2px solid gray' /> </td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td style = 'border: 2px outset'> File Name </td>" +
                                "<td style = 'border: 2px outset'> File Size </td>" +
                                "<td style = 'border: 2px outset'> Last Modified </td>" +
                                "<td style = 'border: 2px outset'></td>" +
                            "</tr>";

            System.IO.StreamReader file =
                new System.IO.StreamReader(Server.MapPath(@"~/AppData/resources.txt"));
            while ((line = file.ReadLine()) != null)
            {
                string[] pieces = line.Split('|');

                fileContents += "<tr>";

                foreach (var piece in pieces)
                {
                    fileContents += "<td>" + piece + "</td>";
                }
                fileContents += "<td align='center'><input type='checkbox' value='" + line + "' name='checked''></td>" +
                                "</tr>";
            }
            file.Close();
            testTable.InnerHtml = "<table style='width: 80%'>" +
                                        header +
                                        fileContents +
                                    "<tr>" +
                                        "<td colspan = '100%'> <hr style = 'border-bottom: 2px solid gray'/> </td>" +
                                    "</tr>" +
                                  "</table>";
        }

        protected void FileDelete_Click(object sender, EventArgs e)
        {
            string checkedCheckBoxes = Request.Form["checked"];
            if (!string.IsNullOrEmpty(checkedCheckBoxes))
            {
                IList<string> linesToDelete = checkedCheckBoxes.Split(',').ToList();

                String filename = Server.MapPath(@"~/AppData/resources.txt");
                String tempFilename = Server.MapPath(@"~/AppData/resourcesTemp.txt");
                int lineNumber = 0;
                int linesRemoved = 0;

                String fileStr = "";


                // Read file
                using (var sr = new StreamReader(filename))
                {
                    // Write new file
                    using (var sw = new StreamWriter(tempFilename))
                    {
                        // Read lines
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lineNumber++;
                            // Look for text to remove
                            if (!ContainsString(line, linesToDelete))
                            {
                                // Keep lines that does not match
                                sw.WriteLine(line);
                            }
                            else
                            {
                                // Ignore lines that DO match
                                linesRemoved++;

                                //Deletion Record
                                fileStr = line.Split('|')[0];
                                MonitorAndCleanup(Server.MapPath(@"~/AppData/monitor.txt"), Server.MapPath(@"~/AppData/ownership.txt"), Server.MapPath(@"~/AppData/ownershipTemp.txt"), fileStr);
                            }
                        }
                    }
                }
                // Delete original file
                File.Delete(filename);

                // ... and put the temp file in its place.
                File.Move(tempFilename, filename);

                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('" + linesRemoved + " Files Deleted'); window.location.href = window.location.href;", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('Please select a file.')", true);
            }
        }

        private static bool ContainsString(string line, IEnumerable<string> linesToDelete)
        {
            foreach (var delLine in linesToDelete)
            {
                if (line.Contains(delLine)) 
                    return true;  
            }
            return false;
        }

        private void MonitorAndCleanup(string monFile, string ownFile, string ownTempFile, string fileName)
        {
            //Deletion Record
            String userName = "Admin";
            String actionTaken = "File '" + fileName + "' Deleted";
            String monitorData = userName + "|" + actionTaken + "|" + DateTime.Now.ToString();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(monFile, true))
            {
                file.WriteLine(monitorData);
            }

            // Read file
            using (var sr = new StreamReader(ownFile))
            {
                // Write new file
                using (var sw = new StreamWriter(ownTempFile))
                {
                    // Read lines
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Look for text to remove
                        if (!line.Split('|')[1].Equals(fileName))
                        {
                            // Keep lines that does not match
                            sw.WriteLine(line);
                        }
                        else
                        {
                            
                        }
                    }
                }
            }

            // Delete original file
            File.Delete(ownFile);

            // ... and put the temp file in its place.
            File.Move(ownTempFile, ownFile);
        }
    }
}