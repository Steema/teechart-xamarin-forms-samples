using System;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GestureRecognizers;
using GestureRecognizers.Droid;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.Droid.Renderer.Gesture;
using XamControls.Services.Gesture.Swipe.Views;
using XamControls.Variables;
using XamControls.ViewModels.Base;
using XamControls.Views;

[assembly: ExportRenderer(typeof(LabelSwipe), typeof(SwipeViewRenderer))]
namespace GestureRecognizers.Droid
{

	public class SwipeViewRenderer : LabelRenderer
		{
				private readonly GestureListener _listener;
				private readonly GestureDetector _detector;
				private Label lastElement;

				public SwipeViewRenderer(Context context) : base(context)
				{
					_listener = new GestureListener();
					_detector = new GestureDetector(_listener);

				}

				protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
				{
					base.OnElementChanged(e);
					lastElement = e.OldElement;

					if (e.NewElement == null)
					{

						this.GenericMotion -= HandleGenericMotion;
						this.Touch -= HandleTouch;

					}

					if (e.OldElement == null)
					{
						this.GenericMotion += HandleGenericMotion;
						this.Touch += HandleTouch;
					}
				}

				void HandleTouch(object sender, TouchEventArgs e)
				{
		
						var label = sender as LabelRenderer;

						if (_detector.OnTouchEvent(e.Event))
						{

							var startX = _listener.StartX;
							var lastX = _listener.LastX;

							if (lastX - startX < 200) { ((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).NextMonth(); }
							else { ((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).PreviousMonth(); }

							if ((label.Element as LabelSwipe).GetChart.Header.Text == "BasicCalendar") { label.Element.Text = MyConvert.NumericMonthToString(((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).Date.Month) + ", " + ((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).Date.Year.ToString(); }
							else if ((label.Element as LabelSwipe).GetChart.Header.Text == "SpecialCalendar" || (label.Element as LabelSwipe).GetChart.Header.Text == "EventCalendar")
							{ label.Element.Text = ((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).Date.ToShortDateString(); }


						}


						//label.Element.Text = Convert.ToString(e.Event.GetX() - e.Event.GetY());
						/*
						if (Convert.ToDouble(label.Element.Text) > 250) {

								((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).NextMonth();

						}
						else if(Convert.ToDouble(label.Element.Text) < -250) {

								((label.Element as LabelSwipe).GetChart.Series[0] as Calendar).PreviousMonth();

						}
						*/					

				}

				public override bool OnTouchEvent(MotionEvent e)
				{

						var se = e.Action;
						return false;

				}

				void HandleGenericMotion(object sender, GenericMotionEventArgs e)
				{
					_detector.OnTouchEvent(e.Event);
				}

		}
}