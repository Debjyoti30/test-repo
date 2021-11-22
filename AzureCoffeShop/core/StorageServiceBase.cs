using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace core
{
    public abstract class StorageServiceBase
    {
        private CloudStorageAccount _storageAccount;

        protected StorageServiceBase()
        {
            var credentials = new StorageCredentials("mkstorageazure", "YczBlDkuIWYIHvisw+OZ1kzo8dww9dOPRJyJ+Mt9gLw6y8BmBlys1gPGijKYtrxolYcterymd23THhjVy0T09g==");

            _storageAccount = new CloudStorageAccount(credentials, true);
        }

        protected CloudStorageAccount StorageAccount
        {
            get { return _storageAccount; }
        }
    }
}
