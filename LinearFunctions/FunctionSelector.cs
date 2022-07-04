using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal class FunctionSelector
    {
        public GroupBox GroupBox { get; set; }
        public ComboBox Selector { get; set; }
        public Label FunctionFormula { get; set; }
        public event Action? SelectedItemChanged;
        public FunctionSelector(Point location, Control.ControlCollection controls)
        {
            Selector = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(10, 20),
                Width = 200,  
            };
            Selector.Items.Add("Линейная функция");
            Selector.SelectedIndex = 0;
            Selector.SelectedValueChanged += (s, e) => SelectedItemChanged?.Invoke();

            FunctionFormula = new Label()
            {
                Location = new Point(10, Selector.Bottom + 10),
                Font = new Font(Form.DefaultFont.FontFamily, 18),
                BorderStyle = BorderStyle.FixedSingle,
                Text = "y(x) = kx + b"
            };
            FunctionFormula.AutoSize = true;

            GroupBox = new GroupBox()
            {
                Text = "Выбор функции",
                Size = new Size(10 + Selector.Width + 10, 10 + Selector.Height + 10 + FunctionFormula.PreferredHeight + 10 + 10),
                Location = location
            };


            GroupBox.Controls.AddRange(new Control[] { Selector, FunctionFormula });
            controls.AddRange(new Control[] { GroupBox });
        }
    }
}
