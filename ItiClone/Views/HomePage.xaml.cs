﻿using ItiClone.Utils;
using ItiClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        readonly uint _duration = 200;
        double? _height = null;

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SetFooterInitialState();
            await FooterAnimation(200);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (_height == null)
            {
                _height = height;

                if (_height.HasValue)
                {
                    stkPrimary.HeightRequest = _height.Value;
                    stkSecundary.HeightRequest = _height.Value;

                    stkSecundary.Margin = new Thickness(0, _height.Value, 0, _height.Value * -1);
                }
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            var item = (e.CurrentSelection.FirstOrDefault() as Models.Action);

            if (item != null)
                (BindingContext as HomePageViewModel).ActionCommand.Execute(item as Models.Action);

            cvActions.SelectedItem = null;
        }

        private void Eye_Tapped(object sender, EventArgs e)
        {
            lblBalance.IsVisible = !lblBalance.IsVisible;
            bvBalance.IsVisible = !bvBalance.IsVisible;
            lblEye.Text = lblBalance.IsVisible ? IconFont.EyeOff : IconFont.Eye;
        }

        private async void Footer_Tapped(object sender, EventArgs e)
        {
            Task translateStkPrincipal = stkPrimary.TranslateTo(0, stkPrimary.HeightRequest * -1, _duration);
            Task translateStkSecundario = stkSecundary.TranslateTo(0, stkPrimary.HeightRequest * -1, _duration);

            await Task.WhenAll(new List<Task> { translateStkPrincipal, translateStkSecundario });
            await SetFooterInitialState();
        }

        private async void Header_Tapped(object sender, EventArgs e)
        {
            await ShowPrimary();
        }

        private async Task FooterAnimation(int delayDuration)
        {
            await Task.Delay(delayDuration);

            var task1 = flFooter.FadeTo(1, 500, Easing.SinInOut);
            var task2 = flFooter.TranslateTo(0, -10, 500, Easing.SpringOut);

            await Task.WhenAll(new List<Task> { task1, task2 });

            frameArrowUp.IsVisible = true;
            arrowUpIcon.TextColor = Color.FromHex("#2A3548");

            await gridArrowUp.TranslateTo(0, -5, 700, Easing.SpringOut);
        }

        private async Task SetFooterInitialState()
        {
            var task1 = flFooter.FadeTo(0, 0);
            var task2 = flFooter.TranslateTo(0, 50, 0);
            var task3 = gridArrowUp.TranslateTo(0, 0);

            await Task.WhenAll(new List<Task> { task1, task2, task3 });
        }

        private async Task ShowPrimary()
        {
            Task translateStkPrincipal = stkPrimary.TranslateTo(0, 0, _duration);
            Task translateStkSecundario = stkSecundary.TranslateTo(0, 0, _duration);

            await Task.WhenAll(new List<Task> { translateStkPrincipal, translateStkSecundario })
                .ContinueWith((t) => FooterAnimation(200), TaskContinuationOptions.RunContinuationsAsynchronously);
        } 
    }
}