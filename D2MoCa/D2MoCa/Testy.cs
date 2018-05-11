using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa
{
    class Testy
    {
        public List<string> d2paths { get; private set; }

        public Testy()
        {
            if (d2paths == null)
                d2paths = new List<string>();

            d2paths.Add(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe");
            d2paths.Add(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe");
            d2paths.Add(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet3\Game.exe");
            d2paths.Add(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet4\Game.exe");
        }


        // eksempel på 'gem List<object> som string i settings'
        void SaveTuples(List<tuple> tuples)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, tuples);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.tuples = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }

        List<tuple> LoadTuples()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.tuples)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<tuple>)bf.Deserialize(ms);
            }
        }

        private void kk()
        {
            List<tuple> list = new List<tuple>();
            list.Add(new tuple());
            list.Add(new tuple());
            list.Add(new tuple());
            list.Add(new tuple());
            list.Add(new tuple());

            // save list
            SaveTuples(list);

            // load list
            list = LoadTuples();
        }

        internal class tuple
        {
            // have info
        }
    }
}
