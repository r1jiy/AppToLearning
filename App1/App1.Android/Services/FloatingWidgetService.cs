using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Droid.Services
{
    public class FloatingWidgetService : Service
    {
        private IWindowManager _windowManager;
        private WindowManagerLayoutParams _layoutParams;
        private View _floatingView;

        public override void OnCreate()
        {
            base.OnCreate();

            _floatingView = LayoutInflater.From(this).Inflate(Resource.Layout.layout_floating_widget, null);

            _layoutParams = new WindowManagerLayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent,
                WindowManagerTypes.Phone,
                WindowManagerFlags.NotFocusable,
                Format.Translucent)
            {
                Gravity = GravityFlags.Left | GravityFlags.Top
            };

            _windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();
            _windowManager.AddView(_floatingView, _layoutParams);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (_floatingView != null)
            {
                _windowManager.RemoveView(_floatingView);
            }
        }
    }
}