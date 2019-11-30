using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DZ1_Цветовая_схема
{
    [Serializable]
    public class User
    {
        public string login { get; set; }
        public string pass { get; set; }
        public Color color { get; set; }
    }
}
