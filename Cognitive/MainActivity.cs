using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Cognitive
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        /// <summary>
        /// Necessary variables
        /// </summary>
        private Button btn;
        //Key for conection to the service
        private const string key = "8cb6b523ef3c4ece877682e826561853";
        //Base url for Computer Vision services 
        private const string urlBase = "https://eastus.api.cognitive.microsoft.com/vision/v2.0/analyze/";
        //HttpClient for requests
        private static readonly HttpClient client = new HttpClient
        {
            DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", key } }
        };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            btn = (Button)FindViewById(Resource.Id.btn);
            //Adding action to the button 
            btn.Click += delegate {

                var imageIntent = new Intent();
                //Images with any format
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                //Starting activity to get any result
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
            //Request for necessary permissions
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 1);
        }
            
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok) {
                //Getting actual path from URI
                string path = ActualPath.GetActualPathFromFile(data.Data, this);
                //Starting async http request
                Analyze(path);
            }
        }
        /// <summary>
        /// Async task for http requests
        /// </summary>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        async Task Analyze(string imagepath) {
            //Object, which will contain response from server
            HttpResponseMessage response;
            //Features, which we wont to get from service
            string parametrs = "visualFeatures=Description";
            //Request string
            string url = urlBase + "?" + parametrs;
            byte[] byteImage = GetBytesFromImage(imagepath);
            using (ByteArrayContent content = new ByteArrayContent(byteImage)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            //JSON  representation of response
            JToken resp = JToken.Parse(responseContent);
            string tmp = resp["Description"]["captions"][0]["text"].ToString();
            TextView text =(TextView) FindViewById(Resource.Id.text);
            text.Text = tmp;
        }
        /// <summary>
        /// Getting bytes from image
        /// </summary>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        private byte[] GetBytesFromImage(string imagepath)
        {
            using (FileStream stream = new FileStream(imagepath, FileMode.Open, FileAccess.Read)) {
                BinaryReader bytes = new BinaryReader(stream);
                return bytes.ReadBytes((int)stream.Length);
            }
        }
    }


}