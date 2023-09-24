using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        UserCredential credential;

        public Form2()
        {
            InitializeComponent();

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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private static CalendarService GoogleAPIService(UserCredential credential)
        {
            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event()
            {
                Summary = txtTitle.Text,
                Description = "Etkinlik Açıklaması",
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse(dateTimeStart.Text),
                    TimeZone = "Europe/Istanbul",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(dateTimeEnd.Text),
                    TimeZone = "Europe/Istanbul"
                },
                Attendees = new EventAttendee[]
            {
                new EventAttendee()
                {
                    Email = "masendgj7@gmail.com"
                },
            },
                //Reminders = new Event.RemindersData()
                //{
                //    UseDefault = false,
                //    Overrides = new EventReminder[]
                //    {
                //        new EventReminder() {Method = "email", Minutes = 24 * 60},
                //        new EventReminder() {Method = "popup", Minutes = 10},
                //    }
                //}
            };

            String calendarId = "primary";
            CalendarService service = GoogleAPIService(credential);
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event createdEvent = request.Execute();
            MessageBox.Show("Etkinlik başarıyla oluşturuldu");
        }
    }
}
