namespace CPU_Renderer
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            backFaceCheckBox = new CheckBox();
            changeCameraButton = new Button();
            animationCheckBox = new CheckBox();
            gridModeCheckBox = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gridModeCheckBox);
            groupBox1.Controls.Add(backFaceCheckBox);
            groupBox1.Controls.Add(changeCameraButton);
            groupBox1.Controls.Add(animationCheckBox);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(184, 361);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // backFaceCheckBox
            // 
            backFaceCheckBox.AutoSize = true;
            backFaceCheckBox.Location = new Point(12, 38);
            backFaceCheckBox.Name = "backFaceCheckBox";
            backFaceCheckBox.Size = new Size(119, 19);
            backFaceCheckBox.TabIndex = 2;
            backFaceCheckBox.Text = "Back Face Culling";
            backFaceCheckBox.UseVisualStyleBackColor = true;
            backFaceCheckBox.CheckedChanged += backFaceCheckBox_CheckedChanged;
            // 
            // changeCameraButton
            // 
            changeCameraButton.Location = new Point(12, 88);
            changeCameraButton.Name = "changeCameraButton";
            changeCameraButton.Size = new Size(126, 23);
            changeCameraButton.TabIndex = 1;
            changeCameraButton.Text = "Change Camera";
            changeCameraButton.UseVisualStyleBackColor = true;
            changeCameraButton.Click += changeCameraButton_Click;
            // 
            // animationCheckBox
            // 
            animationCheckBox.AutoSize = true;
            animationCheckBox.Location = new Point(12, 20);
            animationCheckBox.Name = "animationCheckBox";
            animationCheckBox.Size = new Size(82, 19);
            animationCheckBox.TabIndex = 0;
            animationCheckBox.Text = "Animation";
            animationCheckBox.UseVisualStyleBackColor = true;
            animationCheckBox.CheckedChanged += animationCheckBox_CheckedChanged;
            // 
            // gridModeCheckBox
            // 
            gridModeCheckBox.AutoSize = true;
            gridModeCheckBox.Location = new Point(12, 63);
            gridModeCheckBox.Name = "gridModeCheckBox";
            gridModeCheckBox.Size = new Size(82, 19);
            gridModeCheckBox.TabIndex = 3;
            gridModeCheckBox.Text = "Grid Mode";
            gridModeCheckBox.UseVisualStyleBackColor = true;
            gridModeCheckBox.CheckedChanged += gridModeCheckBox_CheckedChanged;
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 361);
            ControlBox = false;
            Controls.Add(groupBox1);
            Name = "ConfigurationForm";
            ShowIcon = false;
            Text = "Configuration";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox animationCheckBox;
        private Button changeCameraButton;
        private CheckBox backFaceCheckBox;
        private CheckBox gridModeCheckBox;
    }
}