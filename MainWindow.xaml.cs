using System.Collections.ObjectModel;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;
using Northwoods.GoXam.Layout;
using Formatting = Newtonsoft.Json.Formatting;

namespace GoXam
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MyDiagram.Model = new MyModel
            {
                NodesSource = new ObservableCollection<MyNode>(),
                LinksSource = new ObservableCollection<MyLink>(),
                Modifiable = true,
                NodeIsGroupPath = "IsSubGraph",
                GroupNodePath = "SubGraphKey"
            };
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var model = MyDiagram.Model as MyModel ?? new MyModel();
            var modelAsXml = model.Save<MyNode, MyLink>(nameof(MainWindow), nameof(MyNode), nameof(MyLink));
            var document = new XmlDocument();
            document.LoadXml(modelAsXml.ToString());
            var modelAsJson = JsonConvert.SerializeXmlNode(document, Formatting.Indented);
            MessageBox.Show(modelAsJson);
        }
    }
}