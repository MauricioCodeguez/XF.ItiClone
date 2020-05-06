using PanCardView.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItiClone.ViewModels
{
    public class ChargeSomeoneQrCodePageViewModel : BaseViewModel
    {
        public ChargeSomeoneQrCodePageViewModel()
        {

        }

        public override Task InitializeAsync(object[] args)
        {
            decimal? value = null;

            if (args.Count() > 0)
                value = (decimal)args[0];

            return Task.CompletedTask;
        }
    }
}