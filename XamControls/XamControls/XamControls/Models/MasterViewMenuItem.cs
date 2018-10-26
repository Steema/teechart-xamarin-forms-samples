using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamControls.Models
{
    public class MasterViewMenuItem
    {

		private int a_id;
		private string a_title;
		private Color a_backgroundColor;
		private Type a_targetType;
		private ImageSource a_imageSource;

        public MasterViewMenuItem(int Id, string Title, Type TargetType, Color BackgroundColor, ImageSource ImageSource)
        {

				this.a_id = Id;
				this.a_title = Title;
				this.a_targetType = TargetType;
				this.a_imageSource = ImageSource;
				this.a_backgroundColor = BackgroundColor;

        }
				
        public int Id { get { return a_id; } }
        public string Title { get { return a_title; } }
		public Color BackgroundColor { get { return a_backgroundColor; } set { a_backgroundColor = value; } }
		public Type TargetType { get { return a_targetType; } }
		public ImageSource ImageSource { get { return a_imageSource; } }


	}
}