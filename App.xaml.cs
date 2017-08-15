using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace fuzzy_chainsaw
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }

                #region BUG
                //
                // BUG: PreferredLaunchViewSize must be 500x320 or higher at first launch (assuming 100% scale size)
                // Subsequent launches can be user-defined as long as size is >= SetPreferredMinSize
                //

                // Steps:
                // 1. Uncomment out below code
                // 2. Run app
                // 3. Note window doesn't open up to correct size
                // 4. Clean up persisted application frame settings before continuing! (see below commands)

                //ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 500));
                //ApplicationView.PreferredLaunchViewSize = new Size(499, 320); // Window should open up to 499 x 500
                //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
                //Window.Current.Activate();
                #endregion

                #region BUG
                //
                // BUG: Setting PreferredLaunchWindowingMode before PreferredLaunchViewSize is set results in undefined behavior
                //

                // Steps:
                // 1. Uncomment out below code
                // 2. Run app
                // 3. Note window doesn't open up to correct size
                // 4. Clean up persisted application frame settings before continuing! (see below commands)

                //ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 500));
                //ApplicationView.PreferredLaunchViewSize = new Size(500, 320); // Window should open up to 500 x 500
                //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
                //Window.Current.Activate();
                #endregion

                /*
                 Clean up scripts for PowerShell:
                 
                 Remove-Item HKCU:\Software\Microsoft\Windows\CurrentVersion\ApplicationFrame\Positions\8E4C835C-CCAD-4A60-9156-15B00FE2809D_v2s4gq4vpbf78!App
                 Remove-Item HKCU:\Software\Microsoft\Windows\CurrentVersion\ApplicationFrame\TitleBar\8E4C835C-CCAD-4A60-9156-15B00FE2809D_v2s4gq4vpbf78!App
                 Remove-Item HKCU:\Software\Microsoft\Windows\CurrentVersion\ApplicationFrame\WindowSizing\8E4C835C-CCAD-4A60-9156-15B00FE2809D_v2s4gq4vpbf78!App
                */
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }
    }
}
