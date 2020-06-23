using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMDIWinDoorsCS.Class
{
    class csFunctions
    {
        public IEnumerable<Control> GetAll(Control control, Type type, string name)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type, name))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .Where(c => c.Name.Contains(name));
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public IEnumerable<Control> GetAll(Control control, string name)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, name))
                                      .Concat(controls)
                                      .Where(c => c.Name.Contains(name));
        }
        public void LogToFile(string errormsg, string stacktrace)
        {
            using (StreamWriter logfile = new StreamWriter(Application.StartupPath + @"\Error_Logs.txt", true))
            {
                logfile.WriteLine("Dated: " + DateTime.Now.ToString("dddd, MMMM dd, yyyy HH:mm:ss tt") +
                                 "\nError: " + errormsg +
                                 "\nStacktrace: " + stacktrace +
                                 "\n");
            }
        }
    }
}