using CPU_Renderer.Rendering;

namespace CPU_Renderer
{
    public partial class Form : System.Windows.Forms.Form
    {
        Scene scene;
        public Form()
        {
            InitializeComponent();
            this.scene = new Scene(pictureBox);
        }

    }
}