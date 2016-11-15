using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Item
    {
        public string Src { get; set; }
        public string Dest { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> Data = new List<Item>();
            Data.Add(new Item() { Src = "BB", Dest = "CC" });
            Data.Add(new Item() { Src = "AA", Dest = "BB" });
            Data.Add(new Item() { Src = "DD", Dest = "EE" });
            Data.Add(new Item() { Src = "CC", Dest = "DD" });
            Data.ForEach(c => { Console.WriteLine(c.Src + "=>" + c.Dest); });
            Item[] sorted;
            var chainer = new Chainer();
            Console.WriteLine(chainer.MakeChain(Data, out sorted));
            foreach (var c in sorted)
            {
                Console.WriteLine(c.Src + "=>" + c.Dest);
            }

        }
    }

        public class Chainer
        {
            public int MakeChain(List<Item> data, out Item[] sorted)
            {
                sorted = data.ToArray();
                return MakeChain(ref sorted);
            }

            public int MakeChain(ref Item[] sorted)
            {
                int maxChain = 0;
                // looking for first link

                for (int i = 0; i < sorted.Length; i++)
                {
                    var s = sorted[i];
                    int keyIndex = Array.FindIndex(sorted, w => w.Dest == s.Src);
                    if (keyIndex == -1) // start link 
                    {
                        if (keyIndex == 0)
                            break;
                        var f = sorted[0];
                        sorted[0] = sorted[i];  // start form zero index now
                        sorted[i] = f;
                        maxChain = 1;
                        break;
                    }
                }

                for (int i = 0; i < sorted.Length - 1 && maxChain > 0; i++)
                {
                    var c = sorted[i];
                    int keyIndex = Array.FindIndex(sorted, i+1, w => w.Src == c.Dest);
                    if (keyIndex > -1)
                    { // swap elements
                        c = sorted[i + 1];
                        sorted[i + 1] = sorted[keyIndex];
                        sorted[keyIndex] = c;
                        maxChain++;
                    }
                }
                return maxChain;
            }
        }
    
}
