using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] words = new string[]
{
"abstract" ,"add" ,"alias" ,"as" ,"ascending" ,"async" ,"await" ,"base" ,"bool" ,"break" ,"by" ,"byte" ,"case" ,"catch" ,"char" ,"checked","class" ,"const" ,"continue" ,"decimal" ,"default" ,"delegate" ,"descending" ,"do" ,"double" ,"dynamic" ,"else" ,"enum",
"equals" ,"event" ,"explicit" ,"extern" ,"false" ,"finally" ,"fixed" ,"float" ,"for" ,"foreach" ,"from" ,"get" ,"global" ,"goto" ,"group" ,"if","implicit" ,"in" ,"int" ,"interface" ,"internal" ,"into" ,"is" ,"join" ,"let" ,"lock" ,"long" ,"nameof" ,"namespace" ,"new" ,"null" ,"object",
"on" ,"operator" ,"orderby" ,"out" ,"override" ,"params" ,"partial" ,"private" ,"protected" ,"public" ,"readonly","ref","remove" ,"return" ,"sbyte" ,"sealed" ,"select" ,"set" ,"short" ,"sizeof" ,"stackalloc" ,"static" ,"string" ,"struct" ,"switch" ,"this",
"throw" ,"true" ,"try" ,"typeof" ,"uint" ,"ulong" ,"unchecked" ,"unsafe" ,"ushort" ,"using" ,"value" ,"var" ,"virtual","void","volatile" ,"when" ,"where" ,"while" ,"yield"
};
        StringBuilder word = new StringBuilder();
        private static int Compare(string key, string word)
        {
            int z = 0;
            if (word == key)
            {
                return 0;
            }
            while (true)
            {
                if (word[z] == key[z])
                {
                    z++;
                };
                if (key.Length == z)
                {
                    return -1;
                };
                if (word.Length == z)
                {
                    return 1;
                };
                if (word[z] > key[z])
                {
                    return -1;
                };
                if (word[z] < key[z])
                {
                    return 1;
                };
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {

                if (richTextBox1.Text[i] >= 'a' && richTextBox1.Text[i] <= 'z')
                {
                    word.Append(richTextBox1.Text[i]);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        int r = words.Length;
                        int l = 0;
                        do
                        {
                            int mid = l + (r - l) / 2;
                            if (Compare(Convert.ToString(word), words[mid]) == 0)
                            {
                                richTextBox1.Select(i - word.Length, word.Length);
                                richTextBox1.SelectionColor = Color.Blue;
                                break;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == -1)
                            { r = mid; };
                            if (Compare(Convert.ToString(word), words[mid]) == 1)
                            { l = mid + 1; };

                        } while (l < r);
                    };
                    word.Clear();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] >= 'a' && richTextBox1.Text[i] <= 'z')
                {
                    word.Append(richTextBox1.Text[i]);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        int r = words.Length - 1;
                        int l = 0;
                        char[] bukL = words[l].ToCharArray();
                        char[] bukR = words[r].ToCharArray();
                        while (l < r)
                        {

                            int mid = l + (word[0] - bukL[0]) * (r - l) / (bukR[0] - bukL[0]);
                            if (word.Length == 1)
                            {
                                break;
                            }
                            if (Compare(Convert.ToString(word), words[mid]) == 0 || Convert.ToString(word) == words[l] || Convert.ToString(word) == words[r])
                            {
                                richTextBox1.Select(i - word.Length, word.Length);
                                richTextBox1.SelectionColor = Color.Blue;
                                break;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == -1)
                            {
                                r = mid - 1;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == 1)
                            {
                                l = mid + 1;
                            };
                        };
                    };
                    word.Clear();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder previous = null;
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] >= 'a' && richTextBox1.Text[i] <= 'z')
                {
                    word.Append(richTextBox1.Text[i]);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        int r = words.Length - 1;
                        int l = 0;
                        char[] bukL = words[l].ToCharArray();
                        char[] bukR = words[r].ToCharArray();
                        int mid = l + (word[0] - bukL[0]) * (r - l) / (bukR[0] - bukL[0]);
                        if (previous != null && previous.Length > 1)
                        {
                            if (Compare(Convert.ToString(word), Convert.ToString(previous)) == 1)
                            {
                                l = mid + 1;
                            };
                            if (Compare(Convert.ToString(word), Convert.ToString(previous)) == -1)
                            {
                                r = mid - 1;
                            };
                        }
                        while (l < r)
                        {
                            if (word.Length == 1)
                            {
                                break;
                            }
                            if (Compare(Convert.ToString(word), words[mid]) == 0 || Convert.ToString(word) == words[l] || Convert.ToString(word) == words[r])
                            {
                                richTextBox1.Select(i - word.Length, word.Length);
                                richTextBox1.SelectionColor = Color.Blue;
                                break;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == -1)
                            {
                                r = mid - 1;
                            };
                            if (Compare(Convert.ToString(word), words[mid]) == 1)
                            {
                                l = mid + 1;
                            };
                            mid = l + (word[0] - bukL[0]) * (r - l) / (bukR[0] - bukL[0]);
                            previous = word;
                        };
                    };
                    word.Clear();
                }
            }
        }
    }
}









