using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Xamarin.Controls;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace rosary
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 0;
        int all = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btn = FindViewById<Button>(Resource.Id.btnClick);
            Button btnReset = FindViewById<Button>(Resource.Id.btnClear);
            TextView txtresul = FindViewById<TextView>(Resource.Id.etxt_result);
            TextView txtall = FindViewById<TextView>(Resource.Id.etxt_all);
            Button btnclear_all = FindViewById<Button>(Resource.Id.btnclear_all);
            Button button = FindViewById<Button>(Resource.Id.button1);
            // Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            //data
            //List<string> datalist = new List<string>();
            //datalist.Add("Developer");
            //datalist.Add("item ");
            //datalist.Add("l");


            /* Notification ---- button click --------- */
            button.Click += delegate {
                // Set up an intent so that tapping the notifications returns to this app:
                Intent intent = new Intent(this, typeof(MainActivity));
                
                // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
                const int pendingIntentId = 0;
                PendingIntent pendingIntent =
                    PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

                Notification.Builder builder = new Notification.Builder(this);
                builder.SetContentTitle("new news");
                builder.SetContentText("about the football sport");
                builder.SetSmallIcon(Resource.Drawable.Icon2);
                // Build the notification:
                Notification notification = builder.Build();
                // Get the notification manager:
                NotificationManager notificationManager =
    GetSystemService(Context.NotificationService) as NotificationManager;
                // Publish the notification:
                //const int notificationId = 0;

                notificationManager.Notify(12, notification);
                notificationManager.Notify(133, notification);
                notificationManager.Notify(122  , notification);
               


            };

            btn.Click += delegate
            {
                count++;
                all++;
                txtresul.Text = string.Format("{0} ", count);
                txtall.Text = string.Format("{0}", all);
                btn.Text = string.Format("{0}", count);
                
            };
            //button reset 
            btnReset.Click += delegate {
                count = 0;
                txtresul.Text = string.Format("{0} ", count);
                
            };
            //button clear all
            btnclear_all.Click += delegate
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Notify");
                alert.SetMessage("Sure?");
                alert.SetPositiveButton("Yes", delegate
                 {
                     all = 0;
                     txtall.Text = string.Format("{0}", all);
                      

                     AlertCenter.Default.Init(Application);

                     AlertCenter.Default.PostMessage("CLeared", "All cleared !", Resource.Drawable.Icon);
                 });
                alert.SetNegativeButton("No", delegate {
                    //do something ..
                });
                alert.SetNeutralButton("cancle", delegate {
                    AlertCenter.Default.Init(Application);

                    AlertCenter.Default.PostMessage("Done", "calnced !", Resource.Drawable.Icon);

                });
                alert.Show();

            };
        }


        //create menu 
        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        //select from menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            TextView txtall = FindViewById<TextView>(Resource.Id.etxt_all);
            TextView txtresul = FindViewById<TextView>(Resource.Id.etxt_result);
            switch (item.ItemId)
              {
                  case Resource.Id.clear_all:
                      //do something
                      all = 0;
                      txtall.Text = string.Format("{0}", all);
                      all++;
                      return true;

                  case Resource.Id.add:
                    txtresul.Text = string.Format("{0} ", count);
                    txtall.Text = string.Format("{0}", all);
                    count++;
                    all++;
                    return true;
              }
              return base.OnOptionsItemSelected(item);

            }
        protected override void OnResume()
        {
            base.OnResume();
            
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
             
        }
        protected override void OnStart()
        {
            base.OnStart();
            
        }



    }
}

