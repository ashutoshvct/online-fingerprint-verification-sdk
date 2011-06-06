using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FingerAppNet
{
    class CMain
    {
        //Application.Run(new Form1());
        [STAThread]
        static void Main()
        {
            try
            {
                Form1 form = new Form1();
                form.Show();
                Application.Run(form);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message ); 
            }
        }
    }

    
}
