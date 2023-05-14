using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Search.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessageBox(string caption, string message, MessageBoxButton button, MessageBoxImage image)
        {
            MessageBox.Show(message, caption, button, image);
        }
    }
}
