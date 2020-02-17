﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.MagicalComponents
{
    public class Syntax
    {
        public List<HiWord> HighlightedWords;

        public struct HiWord
        {
            public string Text;
            public Color ForeColor;
            public Color BackColor;
            public bool Bold, Italic;

            public HiWord(string text, Color foreColor, bool bold, bool italic) : this(text, foreColor, Color.Transparent, bold, italic) { }

            public HiWord(string text, Color foreColor) : this(text, foreColor, Color.Transparent, false, false) { }

            public HiWord(string text, Color foreColor, Color backColor) : this(text, foreColor, backColor, false, false) { }

            public HiWord(string text, Color foreColor, Color backColor, bool bold, bool italic)
            {
                this.Text = text;
                this.ForeColor = foreColor;
                this.BackColor = backColor;
                this.Bold = bold;
                this.Italic = italic;
            }
        };

        public Syntax()
        {
            this.HighlightedWords = new List<HiWord>();
        }

        public void AddWord(string text, Color foreColor) =>
            this.AddWord(new HiWord(text, foreColor));

        public void AddWord(string text, Color foreColor, Color backColor) =>
            this.AddWord(new HiWord(text, foreColor, backColor));

        public void AddWord(HiWord word) =>
            this.HighlightedWords.Add(word);

        public Color GetForeColorByText(string text)
        {
            foreach (var word in this.HighlightedWords)
                if (word.Text == text)
                    return word.ForeColor;
            return Color.Transparent;
        }

        public Color GetBackColorByText(string text)
        {
            foreach (var word in this.HighlightedWords)
                if (word.Text == text)
                    return word.BackColor;
            return Color.Transparent;
        }
    }
}
