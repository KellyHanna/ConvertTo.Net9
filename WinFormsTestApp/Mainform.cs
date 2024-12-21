namespace WinFormsTestApp
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void CallWcfService_Click(object sender, EventArgs e)
        {

            var client = new SampleService.SampleServiceClient();

            var result = client.GetData(1);

            MessageBox.Show(result);

        }

        private void CallWcfGetComposite_Click(object sender, EventArgs e)
        {

            var client = new SampleService.SampleServiceClient();

            var request = new SampleService.CompositeType { BoolValue = true, StringValue = "Test Value " };
            var result = client.GetDataUsingDataContract(request);

            string msg = $" result.BoolValue:{result.BoolValue} {Environment.NewLine} result.StringValue:{result.StringValue}";

            MessageBox.Show(msg);

        }

        private void CallApiGetData_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();

            string url = "https://localhost:7170";
            string methodname = "GetDataUsingDataContract";

            var request = new SampleService.CompositeType { BoolValue = true, StringValue = "Test Value " };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            SampleService.CompositeType result = client.CallWebApi<SampleService.CompositeType>(url, methodname, json);

            string msg = $" result.BoolValue:{result.BoolValue} {Environment.NewLine} result.StringValue:{result.StringValue}";

            MessageBox.Show(msg);

        }
    }


}
