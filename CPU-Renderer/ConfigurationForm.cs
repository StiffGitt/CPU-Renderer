using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.PixelOperations;
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
        public static int FrameCount = 0;
        public ConfigurationForm(Form form)
        {
            InitializeComponent();
            mainForm = form;
            shadingComboBox.Items.Add("Constant");
            shadingComboBox.Items.Add("Gouraud");
            shadingComboBox.Items.Add("Phong");
            shadingComboBox.SelectedIndex = 2;
        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.ToggleAnimation();
        }

        private void changeCameraButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeCamera();
        }

        private void backFaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.BackFaceCulling = backFaceCheckBox.Checked;
            mainForm.Draw();
        }

        private void gridModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.GridMode = gridModeCheckBox.Checked;
            mainForm.Draw();
        }

        private void shadingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (shadingComboBox.SelectedIndex)
            {
                case 0:
                    Config.ShadingType = ShadingTypes.Constant;
                    break;
                case 1:
                    Config.ShadingType = ShadingTypes.Gouraud;
                    break;
                case 2:
                    Config.ShadingType = ShadingTypes.Phong;
                    break;
            }
            mainForm.Draw();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fpsLabel.Text = $"fps: {FrameCount}";
            FrameCount = 0;
        }

        private void fogTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Config.FogIntensity = (100 - (float)fogTrackBar.Value) / 100.0f;
            mainForm.Draw();
        }
    }
}
