This a Sample solution showing how to convert a WCF app to .NET API.

Step Taken
1) Create a new .NET API project.
2) Copy the Intefrace.cs file and the svc.cs file for the WCF project to the API project.
3) Remove the  using statements for using System.ServiceModel.Web
4) In Program.cs add the Services 
5) then Map the Routes.

The  solution also has a WinForm call the show the calls to the wcf and the APi.
