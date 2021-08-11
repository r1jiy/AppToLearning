using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Format;
using Android.Views;
using Android.Widget;

namespace App1.Droid
{
    [BroadcastReceiver(Label = "Widget")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [IntentFilter(new string[] { "com.companyname.App1.APPWIDGET_BUTTON" })]
    // The "Resource" file has to be all in lower caps
    [MetaData("android.appwidget.provider", Resource = "@xml/appwidgetprovider")]


    class Widget : AppWidgetProvider
    {

        public static String APPWIDGET_BUTTON = "Button click";
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(Widget)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
        }

        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.widget2);
            SetTextWiewText(widgetView);

            RegisterClicks(context, appWidgetIds, widgetView);

            return widgetView;
        }

        private void SetTextWiewText(RemoteViews widgetView)
        {
            widgetView.SetTextViewText(Resource.Id.widgetSmall, Convert.ToString(DateTime.Now));
        }

        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        {
            var intent = new Intent(context, typeof(Widget));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

            //Button 1
            widgetView.SetOnClickPendingIntent(Resource.Id.butonWidg, GetPendingSelfIntent(context, APPWIDGET_BUTTON));
        }

        private PendingIntent GetPendingSelfIntent(Context context, string action)
        {
            var intent = new Intent(context, typeof(Widget));
            intent.SetAction(action);
            return PendingIntent.GetBroadcast(context, 0, intent, 0);
        }

        public override void OnReceive(Context context, Intent intent)
        {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.widget2);

            // Check if the click is from the "ACTION_WIDGET_TURNOFF or ACTION_WIDGET_TURNON" button
            if (APPWIDGET_BUTTON.Equals(intent.Action))
            {
                Toast.MakeText(context, Convert.ToString(DateTime.Now), ToastLength.Short).Show();
            }
        }


    }
}