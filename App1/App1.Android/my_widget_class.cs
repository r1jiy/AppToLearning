using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace App1.Droid
{
    [BroadcastReceiver(Label = "Widget Button Click")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [IntentFilter(new string[] { "com.companyname.App1.ACTION_WIDGET_TURNON" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/my_widget_provider")]

    public class my_widget_class : AppWidgetProvider
    {
        public static String ACTION_WIDGET_TURNON = "Button 1 click";
        public static String update = "android.appwidget.action.APPWIDGET_UPDATE";
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            //Update Widget layout
            //Run when create widget or meet update time

            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(my_widget_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
        }

        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {
            //Build widget layout
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.my_widget);

            //Change text of element on Widget
            SetTextViewText(widgetView);

            //Handle click event of button on Widget
            RegisterClicks(context, appWidgetIds, widgetView);

            return widgetView;
        }

        private void SetTextViewText(RemoteViews widgetView)
        {
            widgetView.SetTextViewText(Resource.Id.widgetSmall, Convert.ToString(DateTime.Now));
        }

        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        {
            var intent = new Intent(context, typeof(my_widget_class));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

            //Button
            widgetView.SetOnClickPendingIntent(Resource.Id.butonWid, GetPendingSelfIntent(context, ACTION_WIDGET_TURNON));
        }

        private PendingIntent GetPendingSelfIntent(Context context, string action)
        {
            var intent = new Intent(context, typeof(my_widget_class));
            intent.SetAction(action);
            return PendingIntent.GetBroadcast(context, 0, intent, 0);
        }

        public override void OnReceive(Context context, Intent intent)
        {
            base.OnReceive(context, intent);
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.my_widget);

            // Check if the click is from the "ACTION_WIDGET_TURNOFF or ACTION_WIDGET_TURNON" button
            if (ACTION_WIDGET_TURNON.Equals(intent.Action))
            {
                Toast.MakeText(context, "god god gooood", ToastLength.Short).Show();
                SetTextViewText(widgetView);
                UpdateAppWidget(context);
            }
        }

        static public void UpdateAppWidget(Context context)
        {
            Intent intent = new Intent(context, typeof(my_widget_class));
            intent.SetAction(update);
            int[] ids = AppWidgetManager.GetInstance(context).GetAppWidgetIds(new ComponentName(context, Java.Lang.Class.FromType(typeof(my_widget_class))));
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, ids);
            context.SendBroadcast(intent);
        }

    }
}