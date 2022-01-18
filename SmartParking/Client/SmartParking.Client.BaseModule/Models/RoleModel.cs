using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;

namespace SmartParking.Client.BaseModule.Models
{
    public class RoleModel:BindableBase
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int State { get; set; }
        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }
        public ICommand DeleteCommand { get; set; }
        public ICommand ItemSelectedCommad { get; set; }
    }
}
