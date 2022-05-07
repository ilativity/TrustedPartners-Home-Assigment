# TrustedPartners-Home-Assignment
Web API interface

Create the "trustedpartners" Database and populate it by running attached trustedPertners_homeAssignmentt.sql file

clone "https://github.com/ilativity/TrustedPartners-Home-Assignment" git repository  "master" branch to local machine

open a solution in Visual Studio 2019 or recent one

update a connection string in appsettings.json file

Load requered packages

You can run the project from within the VisualStudio or deploy it IIS

There will be a test page will all api to test or use FIDDLER run the tests

Note:
The stored procedures scaffolding was created with this tool:
	https://github.com/DarioN1/SPToCore
	
By running this command:
	SPToCore.exe scan -cnn "Server=MM\MSSQLSERVER2014;Database=trustedpartners;Trusted_Connection=True;" -sch * -nsp TrustedPartnersHomeAssignment -ctx CoreDbContext -sf Models -pf C:\Users\VitVit\source\repos\TrustedPartnersHomeAssignment\TrustedPartnersHomeAssignment\Models\ -f SPToCoreContext.cs
