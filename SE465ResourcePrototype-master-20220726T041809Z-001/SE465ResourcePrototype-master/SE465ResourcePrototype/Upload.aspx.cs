using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE465ResourcePrototype
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FileSubmit_Click(object sender, EventArgs e)
        {

            String saveData = "";

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUpload1.FileName;
                Double fileSizeDoub = FileUpload1.PostedFile.ContentLength;
                String fileTime = DateTime.Now.ToString();
                String dataSize = "Bytes";

                while (fileSizeDoub > 1024)
                {
                    fileSizeDoub = fileSizeDoub / 1024;

                    switch (dataSize)
                    {
                        case "Bytes":
                            dataSize = "KB";
                            break;
                        case "KB":
                            dataSize = "MB";
                            break;
                        case "MB":
                            dataSize = "GB";
                            break;
                        default:
                            break;
                    }
                }

                fileSizeDoub = Math.Round(fileSizeDoub, 1);
                String fileSize = fileSizeDoub.ToString();

                // Append the name of the file to upload to the path.
                saveData += fileName + "|" + fileSize + " " + dataSize + "|" + fileTime;

                // Write to file
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Server.MapPath(@"~/AppData/resources.txt"), true))
                {
                    file.WriteLine(saveData);
                }

                //Monitor Resource Creation
                String monitorData = "";
                String userName = "Admin";
                String actionTaken = "File '" + fileName + "' Uploaded";

                monitorData = userName + "|" + actionTaken + "|" + fileTime;

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Server.MapPath(@"~/AppData/monitor.txt"), true))
                {
                    file.WriteLine(monitorData);
                }

                //Who has Access to Files
                String ownerData = userName + "|" + fileName + "|" + "Owner";

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Server.MapPath(@"~/AppData/ownership.txt"), true))
                {
                    file.WriteLine(ownerData);
                }

                // Notify the user of the name of the file
                // was saved under.
                FileLabel.Text = "Your file was saved as " + saveData;
                FileUpload1.Visible = false;
                FileSubmit.Visible = false;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                FileLabel.Text = "Please select a file to upload.";
            }

        }

    }
}