using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using MusicLab.Backend.Services.Interfaces;

namespace MusicLab.Backend.Services
{
    public class AWSS3Service : IAWSS3Service
    {
        private readonly IConfiguration _configuration;

        public AWSS3Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetURLAsync(string songName)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_configuration["AWSS3:AccessKey"], _configuration["AWSS3:SecretKey"]);
                var config = new AmazonS3Config();
                config.ServiceURL = _configuration["AWSS3:ServiceURL"];
                using var client = new AmazonS3Client(credentials, config);
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _configuration["AWSS3:BucketName"],
                    Key = songName,
                    Expires = DateTime.Now.AddYears(1)
                };
                var response = client.GetPreSignedURL(request);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }          
        }
        
        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            var credentials = new BasicAWSCredentials(_configuration["AWSS3:AccessKey"], _configuration["AWSS3:SecretKey"]);
            var config = new AmazonS3Config();
            config.ServiceURL = _configuration["AWSS3:ServiceURL"];
            using var client = new AmazonS3Client(credentials, config);

            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = memoryStream,
                    Key = file.FileName,
                    BucketName = _configuration["AWSS3:BucketName"],
                    CannedACL = S3CannedACL.NoACL
                };

                // initialise the transfer/upload tools
                var transferUtility = new TransferUtility(client);

                // initiate the file upload
                await transferUtility.UploadAsync(uploadRequest);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }    
        }
    }
}
