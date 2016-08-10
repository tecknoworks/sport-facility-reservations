//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Xamarin.Forms;
//using Client.Droid.Resources;
//using static Java.Util.ResourceBundle;
//using System.Reflection;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(Xamarin.Forms.TimePicker), typeof(CustomTimePickerRender))]
//namespace Client.Droid.Resources
//{
//    public class MyTimePickerRenderer : ViewRenderer<Xamarin.Forms.TimePicker, Android.Widget.EditText>, TimePickerDialog.IOnTimeSetListener, IJavaObject, IDisposable
//    {
//        private TimePickerDialog dialog = null;

//        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
//        {
//            base.OnElementChanged(e);
//            this.SetNativeControl(new Android.Widget.EditText(Forms.Context));
//            this.Control.Click += Control_Click;
//            this.Control.Text = DateTime.Now.ToString("HH:mm");
//            this.Control.KeyListener = null;
//            this.Control.FocusChange += Control_FocusChange;
//        }

//        void Control_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
//        {
//            if (e.HasFocus)
//                ShowTimePicker();
//        }

//        void Control_Click(object sender, EventArgs e)
//        {
//            ShowTimePicker();
//        }

//        private void ShowTimePicker()
//        {
//            if (dialog == null)
//            {
//                dialog = new TimePickerDialog(Forms.Context, this, DateTime.Now.Hour, DateTime.Now.Minute, true);
//            }

//            dialog.Show();
//        }

//        public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
//        {
//            var time = new TimeSpan(hourOfDay, minute, 0);
//            this.Element.SetValue(TimePicker.TimeProperty, time);

//            this.Control.Text = time.ToString(@"hh\:mm");
//        }
//    }

//}