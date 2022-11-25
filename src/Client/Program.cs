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
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String username = String.Empty;
            String token = String.Empty;
            String character = String.Empty;

            var lf = new LoginForm();
            Application.Run(lf);
            username = lf._username;
            token = lf._token;
            if (!lf._done) return;

            var ccf = new CharacterChooseForm(username);
            Application.Run(ccf);
            character = ccf._character;
            if (!ccf._done) return;

            var mgf = new MainGameForm(username, token, character);
            Application.Run(mgf);

            Debug.WriteLine(username);
            Debug.WriteLine(token);
            Debug.WriteLine(character);
        }
    }
}
