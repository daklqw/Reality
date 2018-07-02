using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Ball
{
    class Log
    {
        public Log()
        {
            try
            {
                if (!Directory.Exists(Configures.LogPath))
                    Directory.CreateDirectory(Configures.LogPath);
                OutputFile = new FileStream(Utils.GetLogFullName(), FileMode.Create);
                Writer = new StreamWriter(OutputFile);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Flush()
        {
            try
            {
                Writer.Flush();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Close()
        {
            try
            {
                Writer.Close();
                OutputFile.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Write(string buf)
        {
            try
            {
                Writer.Write("[" + Utils.GetTime_Normal() + "]\r\n" + buf + "\r\n");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        private FileStream OutputFile;
        private StreamWriter Writer;
    }
}
