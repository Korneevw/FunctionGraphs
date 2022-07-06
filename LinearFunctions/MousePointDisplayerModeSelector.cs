using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal class MousePointDisplayerModeSelector
    {
        public GroupBox GroupBox { get; set; }
        public RadioButton XInput { get; set; }
        public bool X { get { return XInput.Checked; } }
        public RadioButton YInput { get; set; }
        public bool Y { get { return YInput.Checked; } }
        public RadioButton XYInput { get; set; }
        public bool XY { get { return XYInput.Checked; } }
        public RadioButton NoneInput { get; set; }
        public bool None { get { return NoneInput.Checked; } }
        public event Action? AnyCheckedChanged;
        public MousePointDisplayerModeSelector(Point location, Control.ControlCollection controls)
        {
            GroupBox = new GroupBox()
            {
                Location = location,
                Text = "Отображение точки",
            };

            XInput = new RadioButton()
            {
                Text = "По Y",
                Location = new Point(10, 20)
            };
            XInput.Size = XInput.PreferredSize;
            XInput.CheckedChanged += (s, e) => AnyCheckedChanged?.Invoke();
            GroupBox.Controls.Add(XInput);

            YInput = new RadioButton()
            {
                Text = "По X",
                Location = new Point(XInput.Right, XInput.Top)
            };
            YInput.Size = YInput.PreferredSize;
            YInput.CheckedChanged += (s, e) => AnyCheckedChanged?.Invoke();
            GroupBox.Controls.Add(YInput);

            XYInput = new RadioButton()
            {
                Text = "По X и Y",
                Location = new Point(YInput.Right, XInput.Top),
                Checked = true
            };
            XYInput.Size = XYInput.PreferredSize;
            XYInput.CheckedChanged += (s, e) => AnyCheckedChanged?.Invoke();
            GroupBox.Controls.Add(XYInput);

            NoneInput = new RadioButton()
            {
                Text = "Не отображать",
                Location = new Point(10, XInput.Bottom),
            };
            NoneInput.Size = NoneInput.PreferredSize;
            NoneInput.CheckedChanged += (s, e) => AnyCheckedChanged?.Invoke();
            GroupBox.Controls.Add(NoneInput);

            GroupBox.Width = 244;
            GroupBox.Height = 10 + XInput.Height + 10 + NoneInput.Height + 10;
            controls.Add(GroupBox);
        }
    }
}
