using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions;

var scopes = new[] { "User.Read",
      "Calendars.Read",
      "calendars.ReadBasic",
      "Calendars.ReadWrite" };

// Values from app registration
var clientId = "08e27f03-8249-4676-bd8c-7173245ca194";
var tenantId = "3735cf0d-e668-43cb-9cb5-6147c1650cb3";
//var clientSecret = "oEh8Q~b8cGKUjMR5gtJMdlXtJOZnRYnvIfZ1tbDm";

var options = new InteractiveBrowserCredentialOptions
{
    TenantId = tenantId,
    ClientId = clientId,
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
    // MUST be http://localhost or http://localhost:PORT
    // See https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/System-Browser-on-.Net-Core
    RedirectUri = new Uri("http://localhost"),
};

// https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential
var interactiveCredential = new InteractiveBrowserCredential(options);

var graphClient = new GraphServiceClient(interactiveCredential, scopes);

var result = await graphClient.Me.Events.GetAsync((requestConfiguration) =>
{
    requestConfiguration.QueryParameters.Select = new string[] { "subject", "body", "bodyPreview", "organizer", "attendees", "start", "end", "location" };
});

Console.WriteLine();