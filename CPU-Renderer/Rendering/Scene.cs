using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Scene
    {
        private LockBitmap lockmap;
        private PictureBox pictureBox;

        public Scene(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = bitmap;
            this.lockmap = new LockBitmap(bitmap);
            this.pictureBox = pictureBox;
        }
    }
}
