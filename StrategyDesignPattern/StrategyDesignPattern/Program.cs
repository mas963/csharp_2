Serializer srz = new Serializer(new XmlSerializer());

srz.Serialize("Stragey");
srz.Deserialize("Stragey");

srz = new Serializer(new BinarySerializer());

srz.Serialize("");
srz.Deserialize("");

// base interface
interface ISerializable
{
    void Serialize(string str);
    void Deserialize(string str);
}

// concrete tip 1
class XmlSerializer : ISerializable
{
    public void Deserialize(string str)
    {
        Console.WriteLine("xml ters serileştirme");
    }

    public void Serialize(string str)
    {
        Console.WriteLine("xml serileştirme");
    }
}

// concrete tip 2
class BinarySerializer : ISerializable
{
    public void Deserialize(string str)
    {
        Console.WriteLine("binary ters serileştirme");
    }

    public void Serialize(string str)
    {
        Console.WriteLine("binary serileştirme");
    }
}

// context tip
class Serializer
{
    ISerializable _serializer;

    public Serializer(ISerializable serializer)
    {
        _serializer = serializer;
    }

    public void Serialize(string str)
    {
        _serializer.Serialize(str);
    }

    public void Deserialize(string str)
    {
        _serializer.Deserialize(str);
    }
}