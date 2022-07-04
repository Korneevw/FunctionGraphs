using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal class CameraLocationInput
    {
        public double X { get { return (double)XInput.Value; } }
        public double Y { get { return (double)YInput.Value; } }
        public Camera Camera;
        public GroupBox GroupBox;
        public Label XInputLabel;
        public NumericUpDown XInput;
        public Label YInputLabel;
        public NumericUpDown YInput;
        public Button MoveButton;
        public event Action? OnMove;
        public CameraLocationInput(Point location, Camera camera, Control.ControlCollection controls)
        {
            Camera = camera;
            GroupBox = new GroupBox()
            {
                Location = location,
                Text = "Перемещение"
            };

            XInputLabel = new Label()
            {
                Location = new Point(10, 20),
                Text = "X:",
            };
            XInputLabel.Width = XInputLabel.PreferredWidth;
            XInput = new NumericUpDown()
            {
                Minimum = -1000000,
                Maximum = 1000000,
                Location = new Point(XInputLabel.Location.X + XInputLabel.PreferredWidth, XInputLabel.Top - 2),
            };

            YInputLabel = new Label()
            {
                Location = new Point(10, XInputLabel.Bottom + 10),
                Text = "Y:",
            };
            YInputLabel.Width = YInputLabel.PreferredWidth;
            YInput = new NumericUpDown()
            {
                Minimum = -1000000,
                Maximum = 1000000,
                Location = new Point(YInputLabel.Location.X + YInputLabel.PreferredWidth, YInputLabel.Top - 2),
            };

            MoveButton = new Button()
            {
                Width = 140,
                Location = new Point(10, YInput.Bottom + 10),
                Text = "Переместиться"
            };
            MoveButton.Click += OnMoveAction;

            GroupBox.Size = new Size(220, 20 + XInput.Height + YInput.Height + 10 + MoveButton.Height + 20);

            GroupBox.Controls.AddRange(new Control[] { XInputLabel, XInput, YInputLabel, YInput, MoveButton });
            controls.Add(GroupBox);
        }
        private void OnMoveAction(object? sender, EventArgs e)
        {
            Camera.GridLocation = new PointF((float)CoordinateConverter.CameraXToGridX(Camera, CoordinateConverter.GridXToCameraX(Camera, (double)XInput.Value) - Camera.Width / 2), (float)CoordinateConverter.CameraYToGridY(Camera, CoordinateConverter.GridYToCameraY(Camera, (double)YInput.Value) - Camera.Height / 2));
            OnMove?.Invoke();
        }
    }
}
