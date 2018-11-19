using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Commerce
{
    public class Custom_List_Item
    {
        public String ImageSource { get; set; }
        public String TextValue { get; set; }
        public Custom_List_Item(String ImageSource,String TextValue)
        {
            this.ImageSource = ImageSource;
            this.TextValue = TextValue;

        }
    }
}
