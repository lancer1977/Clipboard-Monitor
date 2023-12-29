using EmbedIO;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ClipboardMonitor.Listener;

public class Listener : IListener
    {
        private ISubject<string> Subject { get; }
        public IObservable<string> OnMessageReceived { get; }
        public string Port { get; set; }

        public Listener()
        {
            Subject = new Subject<string>();
            OnMessageReceived = Subject.AsObservable();
        }
    public void Start(bool runWeb = true)
        {
            
            //EndPointManager.UseIpv6 = false; 
            var universalUrl = $"http://*:{Port}";
            var server = new WebServer(o => o.WithUrlPrefix(universalUrl).WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager();

            //if (runWeb)
            //{
            //    server.WithModule(new CombatManagerHTMLServer("/www/", state, RunActionCallback));
            //}

            server.WithWebApi("/", m => m.RegisterController(() => new ClipboardController(this)));
                //.WithModule(new CombatManagerNotificationServer("/api/notification/"))
                //.WithWebApi("/api", m => m.RegisterController(() => new LocalCombatManagerServiceController(null)));
            server.RunAsync();

        }

        public void MessageReceived(string message)
        {
            Subject.OnNext(message);
        }
    }