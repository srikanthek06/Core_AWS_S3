using SEK.LifeBackup.Core.Communication.Bucket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEK.LifeBackup.Core.Interface
{
   public interface IBucketRepository
    {
        Task<bool> DoesS3BucketExist(string bucketName);
        Task<CreateBucketResponse> CreateBucket(string bucketName);
    }
}
