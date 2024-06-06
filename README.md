# AutoDBBackupToDrive

## Overview
**AutoDBBackupToDrive** is an ASP.NET Core MVC application designed to automate the process of backing up SQL Server databases and uploading the backups to Google Drive. It simplifies the backup process, ensuring that database backups are performed regularly and securely stored off-site.

## Features
- **Automated Backups:** Automatically backs up all non-system SQL Server databases.
- **Cloud Storage:** Uploads backups directly to Google Drive for safe, remote storage.
- **Easy Trigger:** Backups can be triggered from a simple web interface.
- **Notification System:** Provides real-time feedback on the success or failure of backup operations.

## Technologies
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Google Drive API
- JavaScript (jQuery)
- Bootstrap

## Getting Started

### Prerequisites
Before you begin, ensure you have the following installed:
- .NET 5.0 or higher
- SQL Server (Developer or Express Edition)
- Google Drive API access with `credentials.json`

### Installation

1. **Clone the repository**
   ```sh
   https://github.com/addaissaabdoulrazak/AutoDBBackupToDrive.git
   cd AutoDBBackupToDrive

2. Configure Google Drive API
     -Go to the Google Developers Console.
   
     -Create a project and enable the Google Drive API for it.
   
     -Generate your credentials.json and place it in the project root directory.

4. Install dependencies
   ```sh
   dotnet restore

5. Update your SQL Server connection string
   
   -Edit the appsettings.json to include your SQL Server connection details.

7. Run the application
   ```sh
   dotnet run

## Configuration
   -Database settings: Adjust the SQL query in HomeController.cs to exclude any specific databases from being backed up.
   
   -Google Drive settings: Set up the target folder in Google Drive in GoogleDriveAPIHelper.cs if necessary.

## Usage
   -Navigate to the web interface at http://localhost:port/ and click on the "Take Backup" button to manually start the backup process.
  
   -The backups will automatically be uploaded to the configured Google Drive folder.

## Contributing
   -Contributions are welcome. Please fork the repository and submit a pull request with your changes.
