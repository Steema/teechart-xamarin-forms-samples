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
using AndroidX.Core.Content.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.CustomRenders;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomSwitchCell), typeof(CustomSwitchCellRenderer))]
namespace XamControls.Droid.Renderer
{

    public class CustomSwitchCellRenderer : SwitchCellRenderer
    {

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {

            var cell = base.GetCellCore(item, convertView, parent, context);

            var child1 = ((LinearLayout)cell).GetChildAt(1);

            var label = (TextView)((LinearLayout)child1).GetChildAt(0);
            label.SetTextColor(new Android.Graphics.Color(ResourcesCompat.GetColor(context.Resources, Resource.Color.black_color, null)));

            return cell;

        }

    }
}