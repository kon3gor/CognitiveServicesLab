Cognitive Services with Xamarin lab
------

**Cognitive Services** is a tool, that gives ability to use Machine Learning algorithms without any expirence in creating and training models. Today we’ll create a simple **Xamarin app**, which will use it.

Objectives
------
During the lab you'll learn:

* How to create simple Xamarin Android app.
* How to create Cognitive Service in Azure Cloud.
* How to make request to Azure server.
* How to get response from Azure server.


Prerequisites
------
During the lab you'll need:

* [Visual Studio Community](https://visualstudio.microsoft.com/ru) or higher with [Xamarin installed](https://docs.microsoft.com/en-us/xamarin/get-started/installation/windows)
* At least Android Emulator should be installed
* Active Azure subscription. If you don't have it see all options [here (Rus)](https://habr.com/ru/company/microsoft/blog/352786/)



Overview
-------
1. Loading basic **Xamarin app** from zip.
2. Addong some settings to the app.
3. Creating **Computer Vision** service in **Azure cloud**.
4. Adding requset method to the app.
5. Handling response from Azure server.

Estimated time to finish this lab: 60 minutes


Loading basic Xamarin app from zip:
-------
* Load [zip archive](https://1drv.ms/u/s!Ao4BAFKEH4-gcOiRhobqfXRN5QI?e=9mag4H) 
* Unzip project
* Open project in Visual Studio(follow screenshots bellow)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/1.png)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/2.jpg)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/3.png)
* Now you can deploy your app
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/4.jpg)
* Explore the resoult  
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/5.png)

Adding some settings to the app:
-------
* Now we need to add permissions to read and write external storge. Also we need to add click action to the button.
* Double left click on properties. Go to the **Android Manifest** in opened window.
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/7.png)
* Scroll down and find field **Required permissions**. 
* You should type **storage** in the search string and pick both found options.
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/6.png)
* Now you can go to the **MainActivity.cs** and do folowing steps:
* Add **permission request** to the OnCreate method.
```C#
ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 1);
```
* Add action to the button.
```C#
btn.Click += delegate {

                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
```
* Add **OnActivityResult** method to the activity. 
```C#

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
            }
        }
```
* If you did everything right, you'll see something like this after deploying app.  
*home screen*  
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/8.png)  
*after click the button*  
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/9.png)

Creating Computer Vision service in Azure cloud.
-------
* Go to the [cloud](https://azure.microsoft.com/), than follow screenshots bellow.  
*click **portal***
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/10.jpg)
*click **create a resource***
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/11.jpg)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/12.jpg)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/13.png)
* Now click **create** button and fill all fields. No matter which location you'll use, it affects only on the result url
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/14.png)
* After a while you'll see somthing like this. Click **go to the resource**.
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/15.png)
* Now you on yours computer vision service page.
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/16.png)

Adding request method to the app.
-------
* First of all, you need to return to this page and click **Keys**.
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/16.png)  
*After click you'll see something like this*  
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/16.png)
* Now copy first key and put it in variable before **OnCreate** method
```C#
private const string key = "8cb6b523ef3c4ece877682e826561853";
```



