using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using WorkerService1.Services;

namespace WorkerService1;

class SyslogListener
{
    public async Task ListenToSyslog(CancellationToken stoppingToken)
    {
        UdpClient listener = new UdpClient(514);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 514);
        Regex rx = new Regex(@"<134>\s+\s+id=(?<id>\S+)\s+sn=(?<sn>\S+)\s+time=(?<date>\d+-\d+-\d+\s+\d+:\d+:\d+)\s+fw=(?<fw>\d+.\d+.\d+.\d+)\s+pri=(?<pri>\d+)\s+c=(?<c>\d+)\s+m=(?<m>\d+)\s+msg=(?<msg>.*)\s+app=(?<app>\d+)\s+n=(?<n>\d+)\s+src=(?<src>\d+.\d+.\d+.\d+:\d+:\S+)\s+dst=", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Waiting for broadcast.");
                byte[] bytes = listener.Receive(ref groupEP);
                Console.WriteLine($"Received broadcast from {groupEP}: ");
                Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");

                Log log = new Log();
                LogService logService = new LogService();
                string text = $" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}";
                text = text.Replace("\"", "");
                MatchCollection matches = rx.Matches(text);

                foreach (Match match in matches)
                {
                    log.logid = match.Groups[1].ToString();
                    log.sn = match.Groups[2].ToString();
                    log.time = match.Groups[3].ToString();
                    log.fw = match.Groups[4].ToString();
                    log.pri = match.Groups[5].ToString();
                    log.c = match.Groups[6].ToString();
                    log.m = match.Groups[7].ToString();
                    log.msg = match.Groups[8].ToString();
                    log.app = match.Groups[9].ToString();
                    log.n = match.Groups[10].ToString();
                    log.src = match.Groups[11].ToString();
                    logService.Create(log);
                }
                logService.Dispose();
                log.Dispose();

                await Task.Delay(10, stoppingToken);
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }
}
