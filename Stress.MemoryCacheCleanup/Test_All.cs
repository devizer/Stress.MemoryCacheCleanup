namespace H3Control.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;

    using NUnit.Framework;

    using Stress.MemoryCacheCleanup;

    using Universe;

    [TestFixture]
    public class Test_All : BaseTest
    {
        AcquiredUdpPacketsHistory history = new AcquiredUdpPacketsHistory();

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {

        }

        [Test]
        public void T01()
        {
            Console.WriteLine("Process: '" + Process.GetCurrentProcess().ProcessName + "'");
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed <= TimeSpan.FromSeconds(111))
            {
                for (int i = 0; i < 100000; i++)
                {
                    history.Acquire(Guid.NewGuid());
                }

                Trace.WriteLine("Working Set: " + Process.GetCurrentProcess().WorkingSet64 / 1024m / 1024m);
            }



        }
    }
}