using System;
using Microsoft.Practices.Prism.ViewModel;

namespace Zebo.Presentation.Common
{
    public abstract class ObservableObject : NotificationObject
    {
        ~ObservableObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            //
        }
    }
}
