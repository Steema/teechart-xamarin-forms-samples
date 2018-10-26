using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XamControls.Services;

namespace XamControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomNavigationPage : Xamarin.Forms.NavigationPage
    {
		public bool IgnoreLayoutChange { get; set; } = false;


		protected override void OnSizeAllocated(double width, double height)
		{

			if (!IgnoreLayoutChange)
				base.OnSizeAllocated(width, height);
			
		}

		public CustomNavigationPage() : base()
		{
			InitializeComponent();

		}

		public CustomNavigationPage(Xamarin.Forms.Page root, TransitionType type) : base(root)
		{

			TransitionType = type;
            InitializeComponent();
			
		}

		public static readonly BindableProperty TransitionTypeProperty =
		BindableProperty.Create("TransitionType", typeof(TransitionType), typeof(CustomNavigationPage), TransitionType.Fade);

        /// <summary>
        /// Modifica el tipo de transicion (animación) entre páginas
        /// </summary>
		public TransitionType TransitionType
		{
			get { return (TransitionType)GetValue(TransitionTypeProperty); }
			set { SetValue(TransitionTypeProperty, value); }
		}

        public static readonly BindableProperty ElevationProperty =
        BindableProperty.Create("Elevation", typeof(int), typeof(CustomNavigationPage), 8);

        /// <summary>
        /// Establece el elevation del NavigationBar
        /// </summary>
        public int Elevation
        {

            get { return (int)GetValue(ElevationProperty); }
            set { SetValue(ElevationProperty, value); }

        }

        public static readonly BindableProperty BarVisibilityProperty =
       BindableProperty.Create("BarVisibility", typeof(bool), typeof(CustomNavigationPage), true);

        /// <summary>
        /// Establece el visibility del NavigationBar
        /// </summary>
        public bool BarVisivility
        {

            get { return (bool)GetValue(BarVisibilityProperty); }
            set { SetValue(BarVisibilityProperty, value); }

        }

    }

}
