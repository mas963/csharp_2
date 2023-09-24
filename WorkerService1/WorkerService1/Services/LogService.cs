using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Services;

class LogService : IDisposable
{
    private readonly IMongoCollection<Log> _logs;
    private bool disposedValue;

    public LogService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("worker");
        _logs = database.GetCollection<Log>("Logs");
    }

    public List<Log> Get() => _logs.Find(log => true).ToList();

    public Log Get(string id) => _logs.Find<Log>(log => log.Id == id).FirstOrDefault();

    public Log Create(Log log)
    {
        _logs.InsertOneAsync(log);
        return log;
    }

    public void Update(string id, Log login) => _logs.ReplaceOne(log => log.Id == id, login);

    public void Remove(Log login) => _logs.DeleteOne(log => log.Id == login.Id);

    public void Remove(string id) => _logs.DeleteOne(log => log.Id == id);

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if(disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
