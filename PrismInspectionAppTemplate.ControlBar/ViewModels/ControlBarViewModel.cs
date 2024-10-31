using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismInspectionAppTemplate.Core.Enums;
using PrismInspectionAppTemplate.Core.Names;


namespace PrismInspectionAppTemplate.ControlBar.ViewModels
{
    public class ControlBarViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        private ViewType _mainRegionContent;
        public ViewType MainRegionContent { get => _mainRegionContent; set => SetProperty(ref _mainRegionContent, value); }

        public ICommand MainRegionChangeClickCommand => new DelegateCommand<object>(OnMainRegionChangeClick);

        public ControlBarViewModel(IContainerProvider containerProvider)
        {

        }

        private void OnMainRegionChangeClick(object parameter)
        {
            ViewType newContent = (ViewType)Enum.Parse(typeof(ViewType), parameter.ToString());
            if (MainRegionContent == newContent) return;

            MainRegionContent = newContent;
            _regionManager.RequestNavigate(RegionNames.MAIN, newContent.ToString());
        }
    }
}
