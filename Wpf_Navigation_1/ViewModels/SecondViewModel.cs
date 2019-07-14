using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Messages;
using Wpf_Navigation_1.Services;

namespace Wpf_Navigation_1.ViewModels
{
    class SecondViewModel : ViewModelBase
    {
        private string text;
        public string Text { get => text; set => Set(ref text, value); }

        private readonly INavigationService navigation;
        private readonly IMessageService messageService;

        public SecondViewModel(INavigationService navigation, IMessageService messageService)
        {
            this.navigation = navigation;
            this.messageService = messageService;
        }

        private RelayCommand<string> sendCommand;
        public RelayCommand<string> SendCommand
        {
            get => sendCommand ?? (sendCommand = new RelayCommand<string>(
              param =>
              {
                  if (string.IsNullOrWhiteSpace(Text))
                  {
                      messageService.ShowError("Text can't be empty!");
                  }
                  else
                  {
                      if (param == "First")
                      {
                          Messenger.Default.Send(new FirstMessage { Message = Text });
                          navigation.Navigate<FirstViewModel>();
                      }
                      else if (param == "Third")
                      {
                          Messenger.Default.Send(new ThirdMessage { Message = Text });
                          navigation.Navigate<ThirdViewModel>();
                      }
                      Text = "";
                  }
              }
              ));
        }
    }
}
