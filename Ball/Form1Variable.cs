using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Ball
{
    public partial class Form1 : Form
    {
        Configure FormConfigure = new Configure();
        Ball ball = new Ball();
        int RunTimes = 0;
        Log logs = new Log();

    }
}
