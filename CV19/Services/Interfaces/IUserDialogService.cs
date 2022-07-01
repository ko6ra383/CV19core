using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Services.Interfaces
{
    public interface IUserDialogService
    {
        bool Edit(object item);
        void ShowInformation(string Info, string Caption);
        void ShowWarning(string Message, string Caption);
        void ShowError(string Message, string Caption);
        bool Confirme(string Message, string Caption, bool Exlamation = false);
    }
}
