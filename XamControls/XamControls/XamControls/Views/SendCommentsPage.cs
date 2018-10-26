using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace XamControls.Views
{
    public class SendCommentsPage : ContentPage
    {

        ScrollView scrollView = new ScrollView();
        StackLayout layout = new StackLayout();
        StackLayout nameLayout = new StackLayout();
        Label subjectLabel = new Label();
        Entry subjectEntry = new Entry();
        StackLayout commentLayout = new StackLayout();
        Label commentLabel = new Label();
        Editor commentEntry = new Editor();
        Button sendButton = new Button();

        public SendCommentsPage()
        {

            this.Title = "Give us your opinion";

            scrollView.Content = layout;
            scrollView.HorizontalScrollBarVisibility = ScrollBarVisibility.Never;
            scrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Default;
            scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
            scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;

            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.Children.Add(nameLayout);
            layout.Children.Add(commentLayout);
            layout.Children.Add(sendButton);

            nameLayout.HorizontalOptions = LayoutOptions.Fill;
            nameLayout.VerticalOptions = LayoutOptions.Start;
            nameLayout.Orientation = StackOrientation.Vertical;
            nameLayout.Margin = new Thickness(10, 10, 10, 10);
            nameLayout.Children.Add(subjectLabel);
            nameLayout.Children.Add(subjectEntry);

            subjectLabel.Text = "Subject:";
            subjectLabel.TextColor = Color.FromHex("#0B8DF9");
            subjectLabel.FontSize += 2;

            subjectEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
            subjectEntry.VerticalOptions = LayoutOptions.FillAndExpand;
            subjectEntry.Focused += SubjectEntry_Focused;
            subjectEntry.Unfocused += SubjectEntry_Unfocused;
            subjectEntry.Text = "Write your title";
            subjectEntry.TextColor = Color.FromRgb(140, 140, 140);

            commentLayout.Orientation = StackOrientation.Vertical;
            commentLayout.HorizontalOptions = LayoutOptions.Fill;
            commentLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            commentLayout.Children.Add(commentLabel);
            commentLayout.Children.Add(commentEntry);
            commentLayout.Margin = new Thickness(10, 0, 10, 10);

            commentLabel.Text = "Review:";
            commentLabel.TextColor = Color.FromHex("#0B8DF9");
            commentLabel.FontSize += 2;

            commentEntry.Text = "Write your review";
            commentEntry.TextColor = Color.FromRgb(140, 140, 140);
            commentEntry.VerticalOptions = LayoutOptions.Fill;
            commentEntry.Focused += CommentEntry_Focused;
            commentEntry.Unfocused += CommentEntry_Unfocused;
            commentEntry.AutoSize = EditorAutoSizeOption.TextChanges;

            sendButton.HorizontalOptions = LayoutOptions.Fill;
            sendButton.Text = "SEND";
            sendButton.Clicked += SendButton_Clicked;
                
            this.Content = scrollView;

        }

        private void SubjectEntry_Unfocused(object sender, FocusEventArgs e)
        {

            if (subjectEntry.Text == "") { subjectEntry.Text = "Write your title"; subjectEntry.TextColor = Color.FromRgb(140, 140, 140); }

        }

        private void SubjectEntry_Focused(object sender, FocusEventArgs e)
        {

            if (subjectEntry.Text == "Write your title") { subjectEntry.Text = ""; subjectEntry.TextColor = Color.Black; }

        }

        private void CommentEntry_Unfocused(object sender, FocusEventArgs e)
        {

            if (commentEntry.Text == "") { commentEntry.Text = "Write your review"; commentEntry.TextColor = Color.FromRgb(140, 140, 140); }

        }

        private void CommentEntry_Focused(object sender, FocusEventArgs e)
        {

            if (commentEntry.Text == "Write your review") { commentEntry.Text = ""; commentEntry.TextColor = Color.Black; }

        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            
            if(ValidReview()) { SendReview(); }
            else { ShowError(); }

        }

        // Mira si la review es válida
        private bool ValidReview()
        {

            bool isValid = false;

            if(subjectEntry.Text != null && commentEntry.Text != null && subjectEntry.Text.Length > 2 && commentEntry.Text.Length > 10 && subjectEntry.Text != "Write your title" && commentEntry.Text != "Write your review") { isValid = true; }
            else { isValid = false; }

            return isValid;

        }

        // Si la review no cumple los requisitos
        private void ShowError()
        {

            string message = "";

            if (subjectEntry.Text == null || commentEntry.Text == null || subjectEntry.Text == "Write your title" || commentEntry.Text == "Write your review")
            {

                message += "Fill all fields";

            }
            else
            {
                if (subjectEntry.Text.Length <= 2) { message += "The from text entry is more small than 3. "; }
                if (commentEntry.Text.Length <= 10) { message += "Your review is more small than 11. "; }

            }

            DisplayAlert("Short Review", message, "OK");

        }

        public async Task SendReview()
        {

            EmailMessage message = new EmailMessage();

            try
            {

                message.Subject = subjectEntry.Text;
                message.Body = commentEntry.Text;
                message.To = new List<string> { "info@steema.com" };
                await Email.ComposeAsync(message);

            }
            catch(FeatureNotSupportedException fnsException)
            {

                await DisplayAlert("Not supported", "Email is not supported on this device", "OK");

            }
            catch(Exception exception)
            {


                await DisplayAlert("Error", "Unknown error", "OK");
            }

        }

    }
}
