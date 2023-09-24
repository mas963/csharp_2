using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Services;

class Log : IDisposable
{
    private bool disposedValue;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string logid { get; set; }
    public string sn { get; set; }
    public string time { get; set; }
    public string fw { get; set; }
    public string pri { get; set; }
    public string c { get; set; }
    public string m { get; set; }
    public string msg { get; set; }
    public string app { get; set; }
    public string n { get; set; }
    public string src { get; set; }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
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
