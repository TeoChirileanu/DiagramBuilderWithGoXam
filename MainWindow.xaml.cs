using System.Collections.ObjectModel;

namespace GoXam
{
    public partial class MainWindow
    {
        private static readonly MyNode StartNode = new MyNode {Key = "Start"};
        private static readonly MyNode EndNode = new MyNode {Key = "End"};
        private readonly ObservableCollection<MyNode> _initialNodes = new ObservableCollection<MyNode> {StartNode, EndNode};

        public MainWindow()
        {
            InitializeComponent();

            MyDiagram.Model = new MyModel
            {
                NodesSource = new ObservableCollection<MyNode>(),
                LinksSource = new ObservableCollection<MyLink>(),
                Modifiable = true
            };

            MyPalette.Model = new MyModel
            {
                NodesSource = _initialNodes
            };
        }
    }
}