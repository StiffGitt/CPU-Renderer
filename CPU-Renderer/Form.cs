using CPU_Renderer.Rendering;
using CPU_Renderer.Rendering.PixelOperations;

namespace CPU_Renderer
{
    public partial class Form : System.Windows.Forms.Form
    {
        Scene scene;
        public Form()
        {
            InitializeComponent();
            this.scene = new Scene(pictureBox);
            ConfigurationForm configurationForm = new ConfigurationForm(this);
            configurationForm.Show();
            Draw();
        }

        public void Draw()
        {
            if (scene != null)
                scene.Draw();
            pictureBox.Refresh();
        }

        public void ToggleAnimation()
        {
            animationTimer.Enabled = !animationTimer.Enabled;
        }
        public void ChangeCamera()
        {
            scene.ChangeCamera();
            Draw();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.DoTick();
            Draw();
        }
    }
}