/*
    Authors: Gage Glenn and Nate Harper

    This work is our own and not copied from another source. We referred to DnDbeyond's rules for 5e when generating the code.
    We do not claim owner of any material owned by Wizards of the Coast including, but not limited to, the 5th edition tabletop
    game Dungeons and Dragons.

    This program was built entirely for our statistics course.
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonSim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DungeonSimBox());
            
        }
    }
}
