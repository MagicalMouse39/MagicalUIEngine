﻿using System;
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
        public Syntax Syntax;

        public SyntaxHighlightingTextArea(Syntax syntax)
        {
            this.Syntax = syntax;
            this.AcceptsTab = true;
            this.Multiline = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            int caret = this.SelectionStart;
            this.Select(0, this.Text.Length);
            this.SelectionColor = this.ForeColor;
            this.SelectionFont = this.Font;
            this.SelectionBackColor = this.BackColor;
            this.Select(caret, 0);
            foreach (var hiword in this.Syntax.HighlightedWords)
            {
                if (this.Text.Contains(hiword.Text))
                {
                    int index = -1;
                    int selectStart = this.SelectionStart;

                    while ((index = this.Text.IndexOf(hiword.Text, (index + 1))) != -1)
                    {
                        this.Select((index), hiword.Text.Length);
                        this.SelectionColor = hiword.ForeColor;
                        this.SelectionBackColor = hiword.BackColor == Color.Transparent ? Syntax.DefaultBack : hiword.BackColor;
                        this.SelectionFont = new Font(this.SelectionFont, (hiword.Bold ? FontStyle.Bold : 0) | (hiword.Italic ? FontStyle.Italic : 0));
                        this.Select(selectStart, 0);
                        this.SelectionFont = this.Font;
                        this.SelectionBackColor = this.BackColor;
                        this.SelectionColor = this.ForeColor;
                    }
                }
            }
            
            base.OnTextChanged(e);
        }
    }
}
