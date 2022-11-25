using Client.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainGameForm());

            String username = String.Empty;
            String token = String.Empty;
            String character = String.Empty;

            var lf = new LoginForm();
            Application.Run(lf);
            username = lf._username;
            token = lf._token;

            var ccf = new CharacterChooseForm();
            Application.Run(ccf);
            character = ccf._character;

            Debug.WriteLine(username);
            Debug.WriteLine(token);
            Debug.WriteLine(character);
        }
    }
}
