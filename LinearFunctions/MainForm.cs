namespace LinearFunctions
{
    public partial class MainForm : Form
    {
        private Camera _camera;
        private LinearFunction _linearFunction;
        private GraphInput _graphInput;
        private FunctionSelector _functionSelector;

        private Point? _mouseLocation;
        private PointF? _cameraLocation;

        private bool _ignoreAnyValueChanged = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            GridDisplayer.Display(_camera, e.Graphics);
            LinearFunctionDisplayer.Display(_camera, _linearFunction, e.Graphics);
            CoordinateDisplayer.Display(_camera, e.Graphics);
            e.Graphics.DrawLine(Pens.Black, new Point(_graphInput.KInput.Right + 10, 0), new Point(_graphInput.KInput.Right + 10, ClientSize.Height));
            base.OnPaint(e);
        }
        public MainForm()
        {
            InitializeComponent();
            _functionSelector = new FunctionSelector(new Point(10, 10), Controls);
            _graphInput = new GraphInput(new Point(10, _functionSelector.FunctionFormula.Bottom + 10), Controls);
            _camera = new Camera(1, new Size(ClientSize.Width, ClientSize.Height), new Point(_graphInput.KInput.Right + 10, 0));
            _linearFunction = new LinearFunction(_graphInput.K, _graphInput.B);
            _graphInput.AnyValueChanged += GraphInputValueChangedHandler;
            this.ClientSize = new Size(_camera.Location.X + _camera.Width, _camera.Height);
            this.MouseWheel += ResizeHandler;
            this.MouseUp += DragMovementUpHandler;
            this.MouseDown += DragMovementDownHandler;
            this.MouseMove += DragMovementMoveHandler;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Графики функций";
        }
        private void ResizeHandler(object? sender, MouseEventArgs e)
        {
            _camera.Scale += e.Delta / 120 * 0.1;
            if (_camera.Scale < 0.5) _camera.Scale = 0.5;
            this.Refresh();
        }
        private void DragMovementUpHandler(object? sender, MouseEventArgs e)
        {
            _mouseLocation = null;
            _cameraLocation = null;
        }
        private void DragMovementDownHandler(object? sender, MouseEventArgs e)
        {
            
            _mouseLocation = e.Location;
            _cameraLocation = _camera.GridLocation;
        }
        private void DragMovementMoveHandler(object? sender, MouseEventArgs e)
        {
            if (_mouseLocation.HasValue && _cameraLocation.HasValue)
            {
                _camera.GridLocation = new PointF(
                    _cameraLocation.Value.X + (float)((_mouseLocation.Value.X - e.Location.X) / (50 * _camera.Scale)),
                    _cameraLocation.Value.Y - (float)((_mouseLocation.Value.Y - e.Location.Y) / (50 * _camera.Scale)));
                this.Refresh();
            }
        }
        private void WindowResizeHandler(object? sender, EventArgs e)
        {
            _camera.Size = new Size(ClientSize.Width, ClientSize.Height);
            this.Refresh();
        }
        private void GraphInputValueChangedHandler()
        {
            if (_ignoreAnyValueChanged) return;
            _linearFunction.K = _graphInput.K;
            _linearFunction.B = _graphInput.B;
            this.Refresh();
        }
    }
}