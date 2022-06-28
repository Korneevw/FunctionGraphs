using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal class FunctionSelector
    {
        public ComboBox Selector;
        public Label FunctionFormula;
        public event Action? SelectedItemChanged;
        public FunctionSelector(Point location, Control.ControlCollection controls)
        {
            Selector = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = location,
                Width = 200,
            };
            Selector.Items.Add("Линейная функция");
            Selector.SelectedIndex = 0;
            Selector.SelectedValueChanged += (s, e) => SelectedItemChanged?.Invoke();
            FunctionFormula = new Label()
            {
                Location = new Point(location.X, Selector.Bottom),
                Text = "y(x) = kx + b",
                Font = new Font(Form.DefaultFont.FontFamily, 18)
            };
            FunctionFormula.Size = FunctionFormula.PreferredSize;
            controls.AddRange(new Control[] { Selector, FunctionFormula });
        }
    }
}
