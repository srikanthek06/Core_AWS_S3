using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEK.LifeBackup.Core.Communication.Bucket;
using SEK.LifeBackup.Core.Interface;

namespace SEK.LifeBackup.Service.Controllers
{
    [Route("api/bucket")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketRepository _bucketRepository;
        public BucketController(IBucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }

        [HttpPost]
        [Route("create/{bucketName}")]
        public async Task<ActionResult<CreateBucketResponse>> CreateS3Bucket([FromRoute] string bucketName)
        {
            // validation to check if the bucket already exists
            var bucketExists = await _bucketRepository.DoesS3BucketExist(bucketName);
            if (bucketExists)
            {
                return BadRequest("S3 bucket already exists");
            }

            // logic to create S3 bucket.
            var result = await _bucketRepository.CreateBucket(bucketName);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}