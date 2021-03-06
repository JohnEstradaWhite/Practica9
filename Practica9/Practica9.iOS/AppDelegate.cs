﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using System.Threading.Tasks;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;

namespace Practica9.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,SQLAzure
    {
        private MobileServiceUser usuario;

        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                usuario = await MainPage.cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("Usuario Autenticado {0}", usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            UIAlertViewDelegate Alert = null;
            UIAlertView Aalert = new UIAlertView("resultado de autenyocacion", message, Alert, "ok", null);
            Aalert.Show();
            return usuario;
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init(this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
