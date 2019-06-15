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
1. Load basic **Xamarin app** from zip.
2. Add some settings to the app.
3. Creating **Computer Vision** service in **Azure cloud**.
4. Adding requset method to the app.
5. Handling response from Azure server.

Estimated time to finish this lab: 60 minutes


Load basic Xamarin app from zip:
-------
* Load [zip archive](https://1drv.ms/u/s!Ao4BAFKEH4-gcOiRhobqfXRN5QI?e=9mag4H) 
* Unzip project
* Open project in Visual Studio(follow screenshote bellow)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/1.png)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/2.jpg)
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/3.png)
* Now you can deploy your app
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/4.jpg)
* Explore the resoult  
![](https://github.com/kon3gor/CognitiveServicesLab/blob/master/MK/5.png)

Add some settings to the app:
-------
* Now we need to add permissions to read and write external storge. Also we need to add click action to the button.
* Double left click on properties.
![]()
* Scroll down and find field *Required permissions*. 
* You should type *storage* in the search string and pick both found options.
![]()
* Now you can go to the *MainActivity.cs* and do folowing steps:
* Add new action to the button.
```C#
btn.Click += delegate {

    var imageIntent = new Intent();
    imageIntent.SetType("image/*");
    imageIntent.SetAction(Intent.ActionGetContent);
    StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
};
```





