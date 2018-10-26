using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Services.Share
{
    public class ShareImage
    {
			public Command Share { get; set; }
			public ImageSource Source { get; set; }

			public ShareImage()
			{
				this.Share = new Command(ShareCommand);
			}

			void ShareCommand()
			{

					MessagingCenter.Send<ImageSource>(this.Source, "Share");

			}

	}
}
