﻿using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using TrendyolApp.Message;
using TrendyolApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrendyolApp.Services.Classes
{
    internal class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;
        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>(ParameterMessage? message) where T : ViewModelBase
        {
            _messenger.Send(message);
            _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T) });
        }
    }
}