using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//using Android.OS;
using PCL;
using System.Diagnostics;
using System.Net;

namespace HttpClientTestAndroid
{
    [Activity(Label = "HttpClientTestAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            Debug.WriteLine("Limit:" + ServicePointManager.DefaultConnectionLimit);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button oneGet = FindViewById<Button>(Resource.Id.oneGet);
            oneGet.Click += delegate
            {
                GetAsync();
            };
            Button twoGets = FindViewById<Button>(Resource.Id.twoGets);
            twoGets.Click += delegate
            {
                for (int i = 0; i < 2; i++)
                {
                    GetAsync();
                }
            };
            Button twentyGets = FindViewById<Button>(Resource.Id.twentyGets);
            twentyGets.Click += delegate
            {
                for (int i = 0; i < 20; i++)
                {
                    GetAsync();
                }
            };
            Button onePost = FindViewById<Button>(Resource.Id.onePost);
            onePost.Click += delegate
            {
                PostAsync();
            };
            Button twoPosts = FindViewById<Button>(Resource.Id.twoPosts);
            twoPosts.Click += delegate
            {
                for (int i = 0; i < 2; i++)
                {
                    PostAsync();
                }
            };
            Button twentyPosts = FindViewById<Button>(Resource.Id.twentyPosts);
            twentyPosts.Click += delegate
            {
                for (int i = 0; i < 20; i++)
                {
                    PostAsync();
                }
            };

        }

        async private void GetAsync()
        {
            Debug.WriteLine("BEFORE GETASYNC");
            ViewModel viewModel = await MyClass.Instance.GetAsync();
            if (viewModel != null)
            {
                Debug.WriteLine("AFTER GETASYNC: " + viewModel.user);
            }
            else
            {
                Debug.WriteLine("GETASYNC FAILED");
            }
        }

        async private void PostAsync()
        {
            Debug.WriteLine("BEFORE POSTASYNC");
            ViewModel viewModel = await MyClass.Instance.PostAsync(new Request(){ Name = "My name" });
            if (viewModel != null)
            {
                Debug.WriteLine("AFTER POSTASYNC: " + viewModel.user);
            }
            else
            {
                Debug.WriteLine("POSTASYNC FAILED");
            }
        }

    }
}


