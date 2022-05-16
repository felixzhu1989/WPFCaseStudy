using Prism.Events;
namespace ModuleA.Event;
public class MessageEvent:PubSubEvent<string>
{
}
public class TestObjectEvent : PubSubEvent<TestObject>
{
}
public class TestObject
{
    public string Id { get; set; }
    public string Name { get; set; }
}