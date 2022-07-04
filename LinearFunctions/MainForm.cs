namespace LinearFunctions
{
    public partial class MainForm : Form
    {
        private Camera _camera;
        private LinearFunction _linearFunction;
        private LinearFunctionInput _graphInput;
        private FunctionSelector _functionSelector;
        private CameraLocationInput _cameraLocationInput;

        private Point _mouseLocation;
        private Point? _dragMouseLocation;
        private PointF? _dragCameraLocation;

        private bool _ignoreAnyValueChanged = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            GridDisplayer.Display(_camera, e.Graphics);
            LinearFunctionDisplayer.Display(_camera, _linearFunction, e.Graphics);
            CoordinateDisplayer.Display(_camera, e.Graphics);
            //MousePointDisplayer.DisplayByX(_camera, _linearFunction, _mouseLocation.Y, e.Graphics);
            e.Graphics.DrawLine(Pens.Black, new Point(_functionSelector.GroupBox.Right + 10, 0), new Point(_functionSelector.GroupBox.Right + 10, ClientSize.Height));
            base.OnPaint(e);
        }
        public MainForm()
        {
            InitializeComponent();
            _functionSelector = new FunctionSelector(new Point(10, 10), Controls);
            _graphInput = new LinearFunctionInput(new Point(10, _functionSelector.GroupBox.Bottom + 10), Controls);
            _camera = new Camera(1, new Size(ClientSize.Width, ClientSize.Height), new Point(_functionSelector.GroupBox.Right + 10, 0));
            _linearFunction = new LinearFunction(_graphInput.K, _graphInput.B);
            _cameraLocationInput = new CameraLocationInput(new Point(10, _graphInput.BInput.Bottom), _camera, Controls);
            _cameraLocationInput.GroupBox.Location = new Point(10, this.ClientSize.Height - _cameraLocationInput.GroupBox.ClientSize.Height - 10);
            _cameraLocationInput.OnMove += () => this.Refresh();
            _graphInput.AnyValueChanged += GraphInputValueChangedHandler;
            this.ClientSize = new Size(_camera.Location.X + _camera.Width, _camera.Height);
            this.MouseWheel += ResizeHandler;
            this.MouseUp += DragMovementUpHandler;
            this.MouseDown += DragMovementDownHandler;
            this.MouseMove += DragMovementMoveHandler;
            this.MouseMove += CursorPointDisplayerData;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Графики функций";
        }

        private void CursorPointDisplayerData(object? sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
            this.Refresh();
        }

        private void ResizeHandler(object? sender, MouseEventArgs e)
        {
            _camera.Scale += e.Delta / 120 * 0.1;
            if (_camera.Scale < 0.5) _camera.Scale = 0.5;
            this.Refresh();
        }
        private void DragMovementUpHandler(object? sender, MouseEventArgs e)
        {
            _dragMouseLocation = null;
            _dragCameraLocation = null;
        }
        private void DragMovementDownHandler(object? sender, MouseEventArgs e)
        {
            _dragMouseLocation = e.Location;
            _dragCameraLocation = _camera.GridLocation;
        }
        private void DragMovementMoveHandler(object? sender, MouseEventArgs e)
        {
            if (_dragMouseLocation.HasValue && _dragCameraLocation.HasValue)
            {
                _camera.GridLocation = new PointF(
                    _dragCameraLocation.Value.X + (float)((_dragMouseLocation.Value.X - e.Location.X) / (50 * _camera.Scale)),
                    _dragCameraLocation.Value.Y - (float)((_dragMouseLocation.Value.Y - e.Location.Y) / (50 * _camera.Scale)));
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