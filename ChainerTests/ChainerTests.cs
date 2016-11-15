using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Program.Tests
{
    [TestClass()]
    public class ChainerTests
    {
        [TestMethod()]
        public void FairData_ChainTest()
        {
            List<Item> Data = new List<Item>();
            Data.Add(new Item() { Src = "BB", Dest = "CC" });
            Data.Add(new Item() { Src = "AA", Dest = "BB" });
            Data.Add(new Item() { Src = "DD", Dest = "EE" });
            Data.Add(new Item() { Src = "CC", Dest = "DD" });
            Data.ForEach(c => { Console.WriteLine(c.Src + "=>" + c.Dest); });
            Item[] sorted;
            var chainer = new Chainer();
            
            Assert.IsFalse( chainer.MakeChain(Data, out sorted) == Data.Count-1);
        }

        [TestMethod()]
        public void LoopData_ChainTest()
        {
            List<Item> Data = new List<Item>();
            Data.Add(new Item() { Src = "BB", Dest = "CC" });
            Data.Add(new Item() { Src = "AA", Dest = "BB" });
            Data.Add(new Item() { Src = "DD", Dest = "EE" });
            Data.Add(new Item() { Src = "CC", Dest = "DD" });
            Data.Add(new Item() { Src = "EE", Dest = "AA" });
            Data.ForEach(c => { Console.WriteLine(c.Src + "=>" + c.Dest); });
            Item[] sorted;
            var chainer = new Chainer();
            int l = chainer.MakeChain(Data, out sorted);
            Assert.IsFalse(l != 0);
        }

    }
}