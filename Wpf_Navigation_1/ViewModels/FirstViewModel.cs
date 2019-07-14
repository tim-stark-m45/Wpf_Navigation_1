using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Messages;

namespace Wpf_Navigation_1.ViewModels
{
    class FirstViewModel : ViewModelBase
    {
        private string message;
        public string Message { get => message; set => Set(ref message, value); }

        public FirstViewModel()
        {
            Messenger.Default.Register<FirstMessage>(this, param => Message = param.Message);
        }
    }
}
