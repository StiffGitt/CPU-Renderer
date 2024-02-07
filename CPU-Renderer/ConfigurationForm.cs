using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Renderer
{
    public partial class ConfigurationForm : System.Windows.Forms.Form
    {
        private Form mainForm;
        public ConfigurationForm(Form form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.ToggleAnimation();
        }

        private void changeCameraButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeCamera();
        }
    }
}
