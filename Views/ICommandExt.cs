using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RCTool_Server.Views
{
    public class ICommandExt : ICommand
    {
        private Action _exec;
        private Func<bool> _canExec;

        public ICommandExt(Action Exec, Func<bool> CanExec)
        {
            _exec = Exec;
            _canExec = CanExec;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExec.Invoke();
        }

        public void Execute(object parameter)
        {
            _exec.Invoke();
        }

        public void NotifyStateChange()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
