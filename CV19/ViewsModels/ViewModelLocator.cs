using Microsoft.Extensions.DependencyInjection;

namespace CV19.ViewsModels
{
    //класс с набором свойств чтобы пикать вьюмодели
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public StudentsManagementViewModel StudentsManagement => App.Host.Services.GetRequiredService<StudentsManagementViewModel>();
    }
}
