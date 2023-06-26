using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob.Examples
{
    internal class AzVault
    {

        public readonly string yourUniqueKeyVaultName = "myvaultmetro";
        public readonly string mySecretName = "mySecretName";

        public readonly string tenantId = "b1732512-60e5-48fb-92e8-8d6902ac1349";
        public readonly string clientId = "efd45afb-12c9-43f0-ace8-a5c654c39085"; //SimpleWebApi 
        public readonly string clientSecret = "zdq8Q~RM~FdNua2olnPofx.jRLlRZxutwSSa0b_b";  // 


        public void DoWork()
        {

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);


            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
            };
            var client = new SecretClient(new Uri("https://"+ yourUniqueKeyVaultName + ".vault.azure.net/"),
                credential, options);


            client.SetSecret(new KeyVaultSecret(mySecretName,"xxxx"));

            KeyVaultSecret secret = client.GetSecret(mySecretName);

            string secretValue = secret.Value;
            Console.WriteLine(secretValue);
        }
    }
}
