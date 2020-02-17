using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalUIEngine.MagicalComponents
{
    public class SyntaxHighlightingTextArea : RichTextBox
    {
        private Syntax syntax;

        public SyntaxHighlightingTextArea(Syntax syntax)
        {
            this.syntax = syntax;
            this.AcceptsTab = true;
            this.Multiline = true;
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            string key = new KeysConverter().ConvertToString(e.KeyValue);
            //MessageBox.Show(key + "");

            foreach (var hiword in this.syntax.HighlightedWords)
            {
                if (this.Text.Contains(hiword.Text))
                {
                    int index = -1;
                    int selectStart = this.SelectionStart;

                    while ((index = this.Text.IndexOf(hiword.Text, (index + 1))) != -1)
                    {
                        this.Select((index), hiword.Text.Length);
                        this.SelectionColor = hiword.ForeColor;
                        this.Select(selectStart, 0);
                        this.SelectionColor = Color.Black;
                    }
                }
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            
            base.OnTextChanged(e);
        }
    }
}
