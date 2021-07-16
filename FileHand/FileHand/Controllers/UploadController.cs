using FileHand.DataBase;
using FileHand.Model;
using FileHand.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FileHand.Controllers
{

    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly DetailServices _detailServices;
        private MongoDatabase database;

        public UploadController(DetailServices detailServices)
        {
            _detailServices = detailServices;
        }

        public class FileUpload
        {
            public byte[] fileStream;
            internal byte[] id;

            //byte[] fileStream = Files.ReadAllBytes();

            public IFormFile Files
            {
                get; set;
            }
        }
        IGridFSBucket bucket;
        Stream source;
        //public class MongoGridFs
        //{
        //    private readonly MongoDatabase _db;
        //    private readonly MongoGridFS _gridFs;
        //    public MongoGridFs(MongoDatabase db)
        //    {
        //        _db = db;
        //        _gridFs = _db.GridFS;
        //    }
        //    public ObjectId Addfile(Stream fileStream, String FileName)
        //    {
        //        var fileInfo = _gridFs.Upload(fileStream, FileName);
        //        return (ObjectId)fileInfo.Id;
        //    }
        //    public Stream GetFile(ObjectId id)
        //    {
        //        var file = _gridFs.FindOneById(id);
        //        return file.OpenRead();
        //    }
        //}

        [Route("GetFile")]
        [HttpGet]
        public async Task<IEnumerable<FileEntity>> GetAllDetails()
        {
            return await _detailServices.GetAllDeatils();
        }
        [HttpPost]
        /*public string SaveFile([FromForm] FileUpload fileObj)
        {
            FileEntity file = JsonConvert.DeserializeObject<FileEntity>(fileObj.FileEntity);
            if (fileObj.File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    file = _detailServices.InsertOne(file);
                    file.File = fileBytes;
                    file = _detailServices.Save(file);
                    return "Saved";
                }
            }
            return "Failed";
        }*/
        [Route("UploadFile")]
        [HttpPost]
        public Task<string> Post([FromForm] FileUpload image)
        {

            var fileName = "clip_image071.jpg";

            var client = new MongoClient();
            var server = client.GetServer();
            var database = server.GetDatabase("testdb");
            var gridFs = new MongoGridFs(database);

            var id = ObjectId.Empty;
            using (var file = File.OpenRead(fileName))
            {
                id = gridFs.AddFile(file, fileName);
            }

            using (var file = gridFs.GetFile(id))
            {
                var buffer = new byte[file.Length];
                // note - you'll probably want to read in
                // small blocks or stream to avoid 
                // allocating large byte arrays like this
                file.Read(buffer, 0, (int)file.Length);
            }
        }
    }
}







            //DBContext db = new DBContext();
            //var server = db._database; //MongoServer.Create("mongodb://localhost:27020");
            //var database = server.GetDatabase("tesdb");

            //var fileName = "D:\\Untitled.png";
            //var newFileName = "D:\\new_Untitled.png";
            //using (var fs = new FileStream(fileName, FileMode.Open))
            //{
            //    var gridFsInfo = database.GridFS.Upload(fs, fileName);
            //    var fileId = gridFsInfo.Id;

            //    ObjectId oid = new ObjectId(fileId);
            //    var file = database.GridFS.FindOne(Query.EQ("_id", oid));

            //    using (var stream = file.OpenRead())
            //    {
            //        var bytes = new byte[stream.Length];
            //        stream.Read(bytes, 0, (int)stream.Length);
            //        using (var newFs = new FileStream(newFileName, FileMode.Create))
            //        {
            //            newFs.Write(bytes, 0, bytes.Length);
            //        }
            //    }
            //}
            //    if (image.Files.FileName.ToString() != "" )
            //    {
            //        using (FileStream fileStream = System.IO.File.Create( image.Files.FileName))
            //        {

            //            image.Files.CopyTo(fileStream);
            //            var id = await bucket.UploadFromStreamAsync(image.Files.FileName, fileStream);
            //            var gridFs = new MongoGridFs(database);
            //            var id = ObjectId.Empty;
            //            using (var file = fileStream.OpenRead(Files))
            //            {
            //                id = gridFs.Addfile(file, fileName);
            //            }
            //            /*_ = _detailServices.Addfile(new FileEntity
            //            {
            //                //image.File.CopyTo(fileStream);
            //                name = "FileUpload",
            //                File = image.id
            //            })
            //            ;*/
            //        }
            //            return image.Files.FileName;
            //            /*if (Files.FileName.ToString() != "")
            //            {
            //                image.ImageLocation = Files.FileName.ToString();
            //            }*/
            //            //fileStream = image.Files.FileName.ToString();
            //            //public bytes[] 


       //}
            //}
            //}
        //}
//var task = Convert.ToBase64String(File);
/*_ = _detailServices.Addfile(new FileEntity
    //image.File.CopyTo(fileStream);
    File = image.File
});
&& ContentType != "applicatio/zip"
 */