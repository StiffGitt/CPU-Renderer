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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            shadingComboBox = new ComboBox();
            gridModeCheckBox = new CheckBox();
            backFaceCheckBox = new CheckBox();
            changeCameraButton = new Button();
            animationCheckBox = new CheckBox();
            fpsTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            fpsLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fpsLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(shadingComboBox);
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
            // shadingComboBox
            // 
            shadingComboBox.FormattingEnabled = true;
            shadingComboBox.Location = new Point(6, 134);
            shadingComboBox.Name = "shadingComboBox";
            shadingComboBox.Size = new Size(126, 23);
            shadingComboBox.TabIndex = 4;
            shadingComboBox.SelectedIndexChanged += shadingComboBox_SelectedIndexChanged;
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
            changeCameraButton.Location = new Point(6, 88);
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
            // fpsTimer
            // 
            fpsTimer.Enabled = true;
            fpsTimer.Interval = 1000;
            fpsTimer.Tick += fpsTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 112);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 5;
            label1.Text = "Shading:";
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            fpsLabel.Location = new Point(6, 338);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(30, 19);
            fpsLabel.TabIndex = 6;
            fpsLabel.Text = "fps:";
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
        private ComboBox shadingComboBox;
        private System.Windows.Forms.Timer fpsTimer;
        private Label fpsLabel;
        private Label label1;
    }
}