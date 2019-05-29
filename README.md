# EventEmitter
Simple .NET event emitter for multiply emitters - multiply subscribers model.

Example of use
--------------

In this example, we have class that represents the event type that we will emit.
Firstly, we create an EventEmitter.
Than we subscribe on event and pass the callback method for this event.
Finally, we test it by emitting a new event of MyEvent type.

```csharp
public class Program
{
    public static void Main()
    {
        IEventEmitter eventEmitter = new EventEmitter();

        eventEmitter.Subscribe<MyEvent>(OnMyEvent);

        eventEmitter.Emit("Hello, World!");
    }

    public static void OnMyEvent(MyEvent myEvent)
    {
        Console.WriteLine(myEvent.value);
    }

    public class MyEvent
    {
        public string value;
    }
}
