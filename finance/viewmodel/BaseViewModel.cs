using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finance.viewmodel
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool check;
    }
}
