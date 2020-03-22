using System.Collections.ObjectModel;
using Northwoods.GoXam.Model;

namespace GoXam
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var startNode = new MyNodeData {Key = "Start"};
            var endNode = new MyNodeData {Key = "End"};

            var startToEndLink = new MyLinkData {From = startNode.Key, To = endNode.Key};

            var model = new GraphLinksModel<MyNodeData, string, string, MyLinkData>
            {
                NodesSource = new ObservableCollection<MyNodeData> {startNode, endNode},
                LinksSource = new ObservableCollection<MyLinkData> {startToEndLink}
            };

            MyDiagram.Model = model;
        }
    }
}