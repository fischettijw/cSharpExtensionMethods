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

            TxtTitleCase.Text = TxtTitleCaseInput.Text.AppendRandomString(15, ExtensionMethods.Case.Mixed);
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
        public static string AppendRandomString(this string str, int size, Case whatCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));

                if (whatCase == Case.Mixed)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        ch = Convert.ToChar(Convert.ToString(ch).ToLower());
                    }
                    else
                    {
                        ch = Convert.ToChar(Convert.ToString(ch).ToUpper());
                    }
                }

                builder.Append(ch);
            }
            switch (whatCase)
            {
                case Case.Lower:
                    return str + builder.ToString().ToLower();
                case Case.Upper:
                    return str + builder.ToString().ToUpper();
                case Case.Mixed:
                    return str + builder.ToString();
            }
            return str + builder.ToString();
        }

    }
}
