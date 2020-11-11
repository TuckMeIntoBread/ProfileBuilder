using ff14bot.AClasses;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ProfileDevelopment
{
    public class ProfileBuilder : BotPlugin
    {
        public override string Author => "Mastahg, modified by Sodimm, further modified by TuckMeIntoBread";

        public override Version Version => new Version(1, 1, 0);

        public override string Name => "Profile Builder";

        internal Thread _guiThread;
        internal Gui _guiForm;
        public void ToggleGui()
        {
            if (_guiThread == null || !_guiThread.IsAlive)
            {
                _guiThread = new Thread(() =>
                {
                    _guiForm = new Gui();
                    _guiForm.ShowDialog();
                })
                {
                    IsBackground = true
                };

                _guiThread.SetApartmentState(ApartmentState.STA);
                _guiThread.Start();
            }
            else
            {
                CloseForm();
            }
        }

        public override void OnButtonPress()
        {
            ToggleGui();
        }

        public override bool WantButton => true;

        public override string ButtonText => "Toggle GUI";

        private void CloseForm()
        {
            if (_guiForm != null && _guiForm.Visible)
            {
                _guiForm.Invoke((MethodInvoker)delegate { _guiForm.Close(); });
            }
        }

        public override void OnShutdown()
        {
            CloseForm();
        }

        public override void OnDisabled()
        {
            CloseForm();
        }

        public override void OnEnabled()
        {
            ToggleGui();
        }
    }
}
