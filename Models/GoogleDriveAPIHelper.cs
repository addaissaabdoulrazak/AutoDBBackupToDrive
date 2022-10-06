using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static Google.Apis.Drive.v3.DriveService;

namespace Automate_Backup.Models
{
    public class GoogleDriveAPIHelper
    {
        private IWebHostEnvironment _hostingEnvironment;


        public GoogleDriveAPIHelper(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        //add scope
        public string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };


        [Obsolete]
        public DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "code_secret_client_9.json"), FileMode.Open, FileAccess.Read))
            {
               string FolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "~/");
               string FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveMVCUpload",
            });
            return service;
        }



        //file Upload to the Google Drive root folder.
        [Obsolete]
        ///<summary>
        /// if you used IformeFile,for access a file name you have a property fileName(file.Filename) but with a string type 
        /// you have directly access a file name.
        /// => with a Iformefile type you have direct access to a set of property easily 
        /// </summary>
        public void UplaodFileOnDrive(string file)
        {
            if (file != null && file.Length > 0)
            {
                //create service
                DriveService service = GetService();

                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file);
                //FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);
                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, file), FileMode.Create))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }



            }
        }


      
    }
}
