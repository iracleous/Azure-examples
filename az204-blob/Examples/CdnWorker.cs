using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace az204_blob.Examples;


// Microsoft.Azure.Management.Cdn.Fluent
// -> obsolete

//Azure.ResourceManager.Cdn

/*
 * 
  In the Package Manager Console, execute the following command to install the Active Directory Authentication Library (ADAL):

Install-Package Microsoft.IdentityModel.Clients.ActiveDirectory

Execute the following to install the Azure CDN Management Library:

Install-Package Microsoft.Azure.Management.Cdn



 * 
 * 
 */





public class CdnWorker
{
    //Tenant app constants
    private const string clientID = "<YOUR CLIENT ID>";
    private const string clientSecret = "<YOUR CLIENT AUTHENTICATION KEY>"; //Only for service principals
    private const string authority = "https://login.microsoftonline.com/<YOUR TENANT ID>/<YOUR TENANT DOMAIN NAME>";

    //Application constants
    private const string subscriptionId = "<YOUR SUBSCRIPTION ID>";
    private const string profileName = "CdnConsoleApp";
    private const string endpointName = "<A UNIQUE NAME FOR YOUR CDN ENDPOINT>";
    private const string resourceGroupName = "CdnConsoleTutorial";
    private const string resourceLocation = "<YOUR PREFERRED AZURE LOCATION, SUCH AS Central US>";


    static bool profileAlreadyExists = false;
    static bool endpointAlreadyExists = false;



    public void DoWork()
    {

    }

}
