using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace cSharpExtensionMethods
{
    public partial class FrmExtension : Form
    {
        public FrmExtension()
        {
            InitializeComponent();
        }

        private void FrmExtension_Load(object sender, EventArgs e)
        {
        }

        private void BtnExtensions_Click(object sender, EventArgs e)
        {
            //TxtTitleCase.Text = TxtTitleCaseInput.Text.ToTitleCase();
            TxtTitleCase.Text = "hello".AppendRandomString(5, true);
            //TxtTitleCase.Text = TxtTitleCaseInput.Text.RandomString(10, false);
            //MessageBox.Show("joe".IsBool().ToString());
        }



    }

    public static class ExtensionMethods
    {
        public static string ToTitleCase(this string str)
        {
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(str);
        }

        public static bool IsBool(this string str)
        {
            if (str.ToUpper() == "TRUE" || str.ToUpper() == "FALSE")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Hello");
                return false;
            }
        }

        // Generate and append a random string of a given size    
        public enum Case
        {
            Upper,
            Lower,
            Mixed
        }
        public static string AppendRandomString(this string str, int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return str + builder.ToString().ToLower();
            return str + builder.ToString();
        }

    }
}
