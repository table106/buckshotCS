using System;
using System.Collections.Generic;
using System.Linq;

namespace buckshot
{
    internal class Shotgun
    {
        private List<string> _content = new List<string>();
        public List<string> Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public int dmg;
        public Shotgun() { 
            _content = new List<string>();
            dmg = 1;
        }
        public override string ToString()
        {
            return string.Join(", ", _content);
        }
        public void InsertShells(int lives, int blanks)
        {
            for (int i = 0; i <= lives; i++)
            {
                _content.Add("live");
            }
            for (int i = 0;i <= blanks; i++)
            {
                _content.Add("blank");
            }
            Random rnd = new Random();
            _content = _content.OrderBy(x=> rnd.Next()).ToList();
        }
        public void Shoot()
        {
            _content.Remove(_content[0]);
            dmg = 1;
        }
        public void Empty()
        {
            _content.Clear();
        }
    }
}
