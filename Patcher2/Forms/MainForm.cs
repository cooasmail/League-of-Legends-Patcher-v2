using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Patcher2.Features;
using SimpleLogger;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Patcher2.Forms
{
    public partial class MainForm : Form
    {
        private class Particle
        {
            public float X, Y;
            public float Size;
        }

        private const int InitialParticles = 400;
        private const int RotationLength = 80000;
        private const int ParticlesPerFrame = 1;
        private const float MoveSpeed = 0.4f;
        private const float MinSize = 1f;
        private const float MaxSize = 3f;

        private readonly Random rng = new Random();
        private readonly List<Particle> particles = new List<Particle>();
        private readonly Rectangle displayRect;

        private readonly Brush bgBrush = new SolidBrush(Color.FromArgb(0xff, 0x0d, 0x1f, 0x22));
        private readonly Brush fgBrush = new SolidBrush(Color.FromArgb(0xff, 0x26, 0x40, 0x27));
        
        private string exePath;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.leaguepatcher;
            this.Text = "Patcher v2 :: Created by Zaczero";
            SetDoubleBuffered(this.animationPanel);
            SetDoubleBuffered(this.groupBox1);

            this.displayRect = new Rectangle(0, 0, this.animationPanel.Width, this.animationPanel.Height);

            for (var i = 0; i < InitialParticles; i++)
            {
                var particle = new Particle
                {
                    X = this.rng.Next(0, this.displayRect.Width + 1),
                    Y = this.rng.Next(0, this.displayRect.Height + 1)
                };

                var sizeScale = (float)this.rng.NextDouble();
                particle.Size = MinSize * sizeScale + MaxSize * (1 - sizeScale);
                this.particles.Add(particle);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            while (true)
            {
                var rads = PathScanner.GetRADS();
                if (rads == null)
                {
                    var result = MessageBox.Show("Failed to locate League of Legends directory\r\nIncorrect path?", "Patcher", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        continue;
                    }
                    else
                    {
                        Environment.Exit(0);
                        return;
                    }
                }
                else
                {
                    var exe = PathScanner.GetEXE(rads);
                    if (exe == null)
                    {
                        var result = MessageBox.Show("Failed to locate League of Legends.exe file\r\nIncorrect path?", "Patcher", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (result == DialogResult.Retry)
                        {
                            continue;
                        }
                        else
                        {
                            Environment.Exit(0);
                            return;
                        }
                    }
                    else
                    {
                        this.exePath = exe;
                        break;
                    }
                }
            }

            if (File.Exists(this.exePath + ".bak"))
            {
                this.backupBtn.Visible = true;
            }
            else
            {
                this.backupBtn.Visible = false;
            }
        }

        private void SetDoubleBuffered(Control c)
        {
            //https://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form
            var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            prop?.SetValue(c, true, null);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            this.animationPanel.Refresh();
        }

        private void animationPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.None;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.High;

            Particles(g);
            PostProcess(g);
        }

        private void Particles(Graphics g)
        {
            var time = Environment.TickCount;

            // Calc
            var xScale = (Math.Abs((time % RotationLength) - (RotationLength / 2f)) - (RotationLength / 4f)) / (RotationLength / 4f);
            var yScale = (Math.Abs(((time + (RotationLength / 4)) % RotationLength) - (RotationLength / 2f)) - (RotationLength / 4f)) / (RotationLength / 4f);
            var xMove = MoveSpeed * xScale;
            var yMove = MoveSpeed * yScale;
            var rngLength = this.displayRect.Width * Math.Abs(yScale) + this.displayRect.Height * Math.Abs(xScale);

            // Generate
            for (var i = 0; i < this.rng.Next(0, ParticlesPerFrame + 1); i++)
            {
                var particle = new Particle();

                var ox = this.rng.Next(0, (int)rngLength + 1) < this.displayRect.Height * Math.Abs(xScale);

                if (xScale > 0 && yScale > 0)
                {
                    // right, bottom
                    if (ox)
                    {
                        particle.X = 0;
                        particle.Y = this.rng.Next(0, this.displayRect.Height);
                    }
                    else
                    {
                        particle.X = this.rng.Next(0, this.displayRect.Width);
                        particle.Y = 0;
                    }
                }
                else if (xScale < 0 && yScale > 0)
                {
                    // left, bottom
                    if (ox)
                    {
                        particle.X = this.displayRect.Width;
                        particle.Y = this.rng.Next(0, this.displayRect.Height);
                    }
                    else
                    {
                        particle.X = this.rng.Next(0, this.displayRect.Width);
                        particle.Y = 0;
                    }
                }
                else if (xScale > 0 && yScale < 0)
                {
                    // right, top
                    if (ox)
                    {
                        particle.X = 0;
                        particle.Y = this.rng.Next(0, this.displayRect.Height);
                    }
                    else
                    {
                        particle.X = this.rng.Next(0, this.displayRect.Width);
                        particle.Y = this.displayRect.Height;
                    }
                }
                else if (xScale < 0 && yScale < 0)
                {
                    // left, top
                    if (ox)
                    {
                        particle.X = this.displayRect.Width;
                        particle.Y = this.rng.Next(0, this.displayRect.Height);
                    }
                    else
                    {
                        particle.X = this.rng.Next(0, this.displayRect.Width);
                        particle.Y = this.displayRect.Height;
                    }
                }

                var sizeScale = (float)this.rng.NextDouble();
                particle.Size = MinSize * sizeScale + MaxSize * (1 - sizeScale);
                this.particles.Add(particle);
            }

            // Animate
            foreach (var particle in this.particles)
            {
                particle.X += xMove;
                particle.Y += yMove;
            }

            // Clean
            for (var i = this.particles.Count - 1; i >= 0; i--)
            {
                var particle = this.particles[i];
                if (particle.X < 0 || particle.X > this.displayRect.Width ||
                    particle.Y < 0 || particle.Y > this.displayRect.Height)
                {
                    this.particles.RemoveAt(i);
                }
            }

            // Render
            g.FillRectangle(this.bgBrush, this.displayRect);

            foreach (var particle in this.particles)
            {
                g.FillEllipse(this.fgBrush, particle.X, particle.Y, particle.Size, particle.Size);
            }
        }

        private void PostProcess(Graphics g)
        {
            g.DrawImage(Properties.Resources.leaguepatcher1, new Rectangle(30, 30, 32, 32));
        }

        private void patchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(this.exePath + ".bak"))
                {
                    File.Copy(this.exePath, this.exePath + ".bak");
                    this.backupBtn.Visible = true;
                }

                var resultSb = new StringBuilder("Patcher v2 :: Created by Zaczero\r\n\r\nPatch results:\r\n");
                var buffer = File.ReadAllBytes(this.exePath);

                if (this.zoomOutCbox.Checked)
                {
                    if (ZoomOut.Process(ref buffer))
                    {
                        resultSb.AppendLine("ZoomHack (max) --> Success");
                    }
                    else
                    {
                        resultSb.AppendLine("ZoomHack (max) --> Fail");
                    }
                }

                if (this.zoomInCbox.Checked)
                {
                    if (ZoomIn.Process(ref buffer))
                    {
                        resultSb.AppendLine("ZoomHack (min) --> Success");
                    }
                    else
                    {
                        resultSb.AppendLine("ZoomHack (min) --> Fail");
                    }
                }

                if (this.oomCbox.Checked)
                {
                    if (OOM.Process(ref buffer))
                    {
                        resultSb.AppendLine("OOM --> Success");
                    }
                    else
                    {
                        resultSb.AppendLine("OOM --> Fail");
                    }
                }

                if (this.fovCbox.Checked)
                {
                    if (FOV.Process(ref buffer))
                    {
                        resultSb.AppendLine("FOV Changer --> Success");
                    }
                    else
                    {
                        resultSb.AppendLine("FOV Changer --> Fail");
                    }
                }

                resultSb.Append("\r\nIf any of these failed, here are the possible reasons:\r\n* Already patched\r\n* Patcher is outdated");

                File.WriteAllBytes(this.exePath, buffer);
                MessageBox.Show(resultSb.ToString(), "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // MsgBox
                MessageBox.Show("Patch failed!\r\n" + ex.Message + "\r\n\r\nPossible solutions:\r\n* Run as administrator\r\n* Pause anti-virus\r\n* Exit all LoL processes", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backupBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.exePath + ".bak"))
            {
                MessageBox.Show("Failed to locate .bak file", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm
            var result = MessageBox.Show("Do you want to restore a backup?", "Patcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Proceed
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Overwritte file
                    File.Copy(this.exePath + ".bak", this.exePath, true);

                    // MsgBox
                    MessageBox.Show("Backup restore completed!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // MsgBox
                    MessageBox.Show("Backup restore failed!\r\n" + ex.Message + "\r\n\r\nPossible solutions:\r\n* Run as administrator\r\n* Pause anti-virus", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
