using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamControls.Droid.Renderer.Gesture
{
		public class GestureListener : GestureDetector.SimpleOnGestureListener
		{

			private float startX;
			private float lastX;

			/*
			public override void OnLongPress(MotionEvent e)
			{
					Console.WriteLine("OnLongPress");
					base.OnLongPress(e);
			}

			public override bool OnDoubleTap(MotionEvent e)
			{
					Console.WriteLine("OnDoubleTap");
					return base.OnDoubleTap(e);
			}

			public override bool OnDoubleTapEvent(MotionEvent e)
			{
					Console.WriteLine("OnDoubleTapEvent");
					return base.OnDoubleTapEvent(e);
			}

			public override bool OnSingleTapUp(MotionEvent e)
			{
					Console.WriteLine("OnSingleTapUp");
					return base.OnSingleTapUp(e);
			}
			

			public override bool OnDown(MotionEvent e)
			{
					var f = e.Action;
					return base.OnDown(e);
			}
			*/
			

			public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
			{
					startX = e1.GetX();
					lastX = e2.GetX();

					if (Math.Abs(lastX - startX) > 200) { return true; }
					else { return false; }

			}
			
		/*
			public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
			{

				return base.OnScroll(e1, e2, e2.GetX() - e1.GetX(), e2.GetY() - e1.GetY());
				// return base.OnScroll(e1, e2, distanceX, distanceY);

			}
				
		*/
			/*
			public override void OnShowPress(MotionEvent e)
			{
					Console.WriteLine("OnShowPress");
					base.OnShowPress(e);
			}

			public override bool OnSingleTapConfirmed(MotionEvent e)
			{
					Console.WriteLine("OnSingleTapConfirmed");
					return base.OnSingleTapConfirmed(e);
			}
			*/

			public float StartX { get { return startX; } }
			public float LastX { get { return lastX; } }

		}
}