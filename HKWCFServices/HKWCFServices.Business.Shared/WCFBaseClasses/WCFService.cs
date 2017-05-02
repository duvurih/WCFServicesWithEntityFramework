using System;
using System.ServiceModel;

namespace HKWCFServices.Business.Shared.WCFBaseClasses
{
    public abstract class WCFService : IDisposable
    {
        private bool m_disposed = false;

        protected WCFService()
        {
            InitializeService();
            //CheckCredentials();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources, if any
                }
                m_disposed = true;
            }
        }
        protected abstract void InitializeService();

        public void CheckCredentials()
        {

        }
    }
}
