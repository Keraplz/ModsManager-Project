using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public class ControlTweak
    {
        int[] FadeRGB = new int[3];

        public void Fade_ForeColor(Control C, Color Color)
        {
            FadeRGB[0] = C.ForeColor.R;
            FadeRGB[1] = C.ForeColor.G;
            FadeRGB[2] = C.ForeColor.B;

            if (FadeRGB[0] > Color.R)
                FadeRGB[0]--;
            else if (FadeRGB[0] < Color.R)
                FadeRGB[0]++;

            if (FadeRGB[1] > Color.G)
                FadeRGB[1]--;
            else if (FadeRGB[1] < Color.G)
                FadeRGB[1]++;

            if (FadeRGB[2] > Color.B)
                FadeRGB[2]--;
            else if (FadeRGB[2] < Color.B)
                FadeRGB[2]++;

            C.ForeColor = Color.FromArgb(FadeRGB[0], FadeRGB[1], FadeRGB[2]);
        }

        public async Task FadeAsync_ForeColor(Control C, Color Color)
        {
            await Task.Run(() =>
                {
                    FadeRGB[0] = C.ForeColor.R;
                    FadeRGB[1] = C.ForeColor.G;
                    FadeRGB[2] = C.ForeColor.B;

                    if (FadeRGB[0] > Color.R)
                        FadeRGB[0]--;
                    else if (FadeRGB[0] < Color.R)
                        FadeRGB[0]++;

                    if (FadeRGB[1] > Color.G)
                        FadeRGB[1]--;
                    else if (FadeRGB[1] < Color.G)
                        FadeRGB[1]++;

                    if (FadeRGB[2] > Color.B)
                        FadeRGB[2]--;
                    else if (FadeRGB[2] < Color.B)
                        FadeRGB[2]++;

                    C.ForeColor = Color.FromArgb(FadeRGB[0], FadeRGB[1], FadeRGB[2]);
                });
        }

        public bool Fade_BackColor(Control C, Color Color)
        {
        LOOP:
            FadeRGB[0] = C.BackColor.R;
            FadeRGB[1] = C.BackColor.G;
            FadeRGB[2] = C.BackColor.B;

            if (FadeRGB[0] > Color.R)
                FadeRGB[0]--;
            else if (FadeRGB[0] < Color.R)
                FadeRGB[0]++;

            if (FadeRGB[1] > Color.G)
                FadeRGB[1]--;
            else if (FadeRGB[1] < Color.G)
                FadeRGB[1]++;

            if (FadeRGB[2] > Color.B)
                FadeRGB[2]--;
            else if (FadeRGB[2] < Color.B)
                FadeRGB[2]++;

            C.BackColor = Color.FromArgb(FadeRGB[0], FadeRGB[1], FadeRGB[2]);

            if (C.BackColor == Color)
                return true;
            else goto LOOP;
        }

        public async Task FadeAsync_BackColor(Control C, Color Color)
        {
            await Task.Run(() =>
                {
                    FadeRGB[0] = C.BackColor.R;
                    FadeRGB[1] = C.BackColor.G;
                    FadeRGB[2] = C.BackColor.B;

                    if (FadeRGB[0] > Color.R)
                        FadeRGB[0]--;
                    else if (FadeRGB[0] < Color.R)
                        FadeRGB[0]++;

                    if (FadeRGB[1] > Color.G)
                        FadeRGB[1]--;
                    else if (FadeRGB[1] < Color.G)
                        FadeRGB[1]++;

                    if (FadeRGB[2] > Color.B)
                        FadeRGB[2]--;
                    else if (FadeRGB[2] < Color.B)
                        FadeRGB[2]++;

                    C.BackColor = Color.FromArgb(FadeRGB[0], FadeRGB[1], FadeRGB[2]);
                });
        }

        private void CentralizeH(Control c, int Width)
        {
            c.Location = new Point(Width / 2 - c.Width / 2, c.Location.Y);
        }
        private void CentralizeV(Control c, int Height)
        {
            c.Location = new Point(c.Location.X, Height / 2 - c.Height / 2);
        }
    }
}