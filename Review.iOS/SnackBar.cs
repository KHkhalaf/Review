using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Review.Controls;
using TTGSnackBar;
using UIKit;

namespace Review.iOS
{
    class IOS_SnackBar : ISnackBar
    {
        public void ShowSnackBar(string Message)
        {
            var snackbar = new TTGSnackbar(Message);
            snackbar.Duration = TimeSpan.FromSeconds(2);
            snackbar.Show();
        }
    }
}