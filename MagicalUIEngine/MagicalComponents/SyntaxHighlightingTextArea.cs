using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalUIEngine.MagicalComponents
{
    class SyntaxHighlightingTextArea : RichTextBox
    {
        public SyntaxHighlightingTextArea()
        {
            this.AcceptsTab = true;
            this.Multiline = true;
        }
    }
}
