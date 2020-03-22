using System.Collections.ObjectModel;

namespace GoXam
{
    public partial class MainWindow
    {
        private static readonly MyNode StartNode = new MyNode {Key = "Start"};
        private static readonly MyNode EndNode = new MyNode {Key = "End"};
        private static readonly MyLink StartToEndLink = new MyLink {From = StartNode.Key, To = EndNode.Key};

        private readonly ObservableCollection<MyNode> _nodes = new ObservableCollection<MyNode>{StartNode, EndNode};
        private readonly ObservableCollection<MyLink> _links = new ObservableCollection<MyLink> {StartToEndLink};

        public MainWindow()
        {
            InitializeComponent();

            MyDiagram.Model = new MyModel
            {
                NodesSource = _nodes,
                LinksSource = _links,
                Modifiable = true
            };

            MyPalette.Model = new MyModel
            {
                NodesSource = _nodes
            };
        }
    }
}