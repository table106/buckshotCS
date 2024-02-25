using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Shotgun
    {
        public List<string> content = new List<string>();
        public int dmg;
        public Shotgun() { 
            content = new List<string>();
            dmg = 1;
        }
        public override string ToString()
        {
            return string.Join(", ", content);
        }
        public void insertShells(int lives, int blanks)
        {
            for (int i = 0; i <= lives; i++)
            {
                content.Add("live");
            }
            for (int i = 0;i <= blanks; i++)
            {
                content.Add("blank");
            }
            Random rnd = new Random();
            content = content.OrderBy(x=> rnd.Next()).ToList();
        }
        public void shoot()
        {
            content.Remove(content[0]);
        }
        public void empty()
        {
            content.Clear();
        }
    }
}
