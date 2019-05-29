using System;
using NUnit.Framework;

namespace EventEmitting.Tests
{
    [TestFixture]
    public class EventEmitterTests
    {
        [Test]
        public void IntEvent_SubUnsub_Test()
        {
            IEventEmitter emitter = new EventEmitter();
            var eventReceiver = new TestClass { Value = 0 };

            emitter.Subscribe<int>(eventReceiver.OnIntEmitted);

            emitter.Emit(5);

            Assert.AreEqual(5, eventReceiver.Value);

            emitter.Unsubscribe<int>(eventReceiver.OnIntEmitted);

            emitter.Emit(99);

            Assert.AreEqual(5, eventReceiver.Value);
        }

        [Test]
        public void IntEvent_SubUnsub_Anomym_Test()
        {
            IEventEmitter emitter = new EventEmitter();

            var value = 0;

            Action<int> action = x => value = x;

            emitter.Subscribe(action);

            emitter.Emit(5);

            Assert.AreEqual(5, value);

            emitter.Unsubscribe(action);

            emitter.Emit(99);

            Assert.AreEqual(5, value);
        }

        [Test]
        public void SeveralIntEventSubscribers_Test()
        {
            var sub1 = new TestClass();
            var sub2 = new TestClass();
            var sub3 = new TestClass();

            var emitter = new EventEmitter();

            emitter.Subscribe<int>(sub1.OnIntEmitted);
            emitter.Subscribe<int>(sub2.OnIntEmitted);
            emitter.Subscribe<int>(sub3.OnIntEmitted);

            emitter.Emit(5);

            Assert.AreEqual(5, sub1.Value);
            Assert.AreEqual(5, sub2.Value);
            Assert.AreEqual(5, sub3.Value);

            emitter.Unsubscribe<int>(sub1.OnIntEmitted);

            emitter.Emit(10);

            Assert.AreEqual(5, sub1.Value);
            Assert.AreEqual(10, sub2.Value);
            Assert.AreEqual(10, sub3.Value);

            emitter.Unsubscribe<int>(sub2.OnIntEmitted);

            emitter.Emit(99);

            Assert.AreEqual(5, sub1.Value);
            Assert.AreEqual(10, sub2.Value);
            Assert.AreEqual(99, sub3.Value);
        }

        public class TestClass
        {
            public int Value;

            public void OnIntEmitted(int value)
            {
                this.Value = value;
            }
        }

    }
}