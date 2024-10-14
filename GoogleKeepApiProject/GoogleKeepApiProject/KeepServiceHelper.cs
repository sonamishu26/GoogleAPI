using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

public class KeepServiceHelper
{
    private KeepService _keepService;
    private object GoogleWebAuthorizationBroker;

    public KeepServiceHelper(string clientId, string clientSecret)
    {
        InitializeKeepService(clientId, clientSecret);
    }

    private void InitializeKeepService(string clientId, string clientSecret)
    {
        UserCredential credential;

        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            var credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
                [KeepService.Scope.Keep],
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        _keepService = new KeepService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Keep API Sample",
        });
    }

    public void ListNotes()
    {
        var notes = _keepService.Notes.List().Execute();
        foreach (var note in notes.Notes)
        {
            Console.WriteLine($"{note.Title}: {note.TextContent}");
        }
    }
}

internal class UserCredential
{
}