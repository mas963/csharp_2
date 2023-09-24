using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    static string[] Scopes = {
        CalendarService.Scope.Calendar,
        CalendarService.Scope.CalendarEvents,
        CalendarService.Scope.CalendarEventsReadonly
    };
    static string ApplicationName = "Google Calendar API.NET Quicstart";
    UserCredential credential;

    public Form1()
    {
        InitializeComponent();
        GoogleAPI();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    public void GoogleAPI()
    {
        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        CalendarService service = GoogleAPIService(credential);

        EventsResource.ListRequest request = service.Events.List("primary");
        request.TimeMin = DateTime.Now;
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.MaxResults = 10;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        Events events = request.Execute();

        if (events.Items != null && events.Items.Count > 0)
        {
            txtCalendarEvents.Text = "";
            foreach (var eventItem in events.Items)
            {
                txtCalendarEvents.Text += eventItem.Summary + " / " + eventItem.Location + " / " + eventItem.Start.DateTime + " - " + eventItem.End.DateTime + Environment.NewLine;
            }
        }
        else
        {
            txtCalendarEvents.Text = "No Upcoming Events";
        }
    }

    private static CalendarService GoogleAPIService(UserCredential credential)
    {
        return new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });
    }

    private void GetEvents_Tick(object sender, EventArgs e)
    {
        GoogleAPI();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Form2 form2 = new();
        form2.Show();
    }
}