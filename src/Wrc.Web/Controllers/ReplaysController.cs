using System;
using Microsoft.AspNet.Mvc;
using Wrc.Domain.Services;
using Wrc.Domain.Dal.Repositories;

namespace Wrc.Web.Controllers
{
    public class ReplaysController : Controller
    {
        private readonly IReplayService _replayService;
        private readonly IReplayRepository _replayRepository;

        public ReplaysController(
            IReplayService replayService,
            IReplayRepository replayRepository
            )
        {
            _replayService = replayService;
            _replayRepository = replayRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Replays/List
        public JsonResult Details(int replayId)
        {
            throw new NotImplementedException();
            /*if (replayId <= 0)
            {
                return NotFound();
            }

            var dto = _replayRepository.GetReplayCard(replayId);

            if (dto == null)
            {
                return NotFound();
            }

            dto;*/
        }

        private JsonResult NotFound()
        {
            throw new NotImplementedException();
            /*return Json(new {success = false}, JsonRequestBehavior.AllowGet);*/
        }

        //
        // GET: /Replays/List
        public JsonResult List(int startIndex, int pageSize, string searchText)
        {
            throw new NotImplementedException();

            /*var pagingInfo = new PagingInfo(startIndex, pageSize);

            var dtos = _replayService.GetReplays(pagingInfo, searchText);
            return Json(dtos, JsonRequestBehavior.AllowGet);*/
        }

        //
        // GET: /Replays/List
        public JsonResult GetByPlayerUser(int playerId, int startIndex, int pageSize)
        {
            throw new NotImplementedException();

            /*var pagingInfo = new PagingInfo(startIndex, pageSize);

            var dtos = _replayService.GetReplaysByPlayerUser(playerId, pagingInfo);
            return Json(dtos, JsonRequestBehavior.AllowGet);*/
        }

        //
        // GET: /Replays/GetCount
        public JsonResult GetCount(string searchText)
        {
            throw new NotImplementedException();

            /*return Json(_replayService.GetReplaysCount(searchText), JsonRequestBehavior.AllowGet);*/
        }

        //
        // POST: /Replays/Upload
        [HttpPost]
        public JsonResult Upload(/*HttpPostedFileBase file*/)
        {
            throw new NotImplementedException();

            /*try
            {
                var filename = Path.GetFileName(file.FileName);

                if (filename == null) throw new NotSupportedException();

                var randomFilename = Path.GetRandomFileName();
                string title;
                if (_replayService.IsAlreadyUploaded(file.InputStream, out title))
                {
                    return Json(new
                    {
                        success = false,
                        message = string.Format("Replay is already uploaded with title - '{0}'.", title)
                    });
                }

                var replay = _replayService.SaveReplay(file.InputStream, randomFilename);

                var path = Path.Combine(Server.MapPath("~/App_Data/replays"), randomFilename);
                file.SaveAs(path);

                string replayToken = string.Empty;

                if (HttpContext.Session != null)
                {
                    var hashedReplaySeed = PasswordHasher.Hash(replay.Seed);
                    HttpContext.Session["replay" + replay.Id] = replayToken = hashedReplaySeed.Hash;
                }

                return new JsonResult
                {
                    Data = new
                    {
                        replayId = replay.Id,
                        success = true,
                        token = replayToken
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult
                {
                    Data = new
                    {
                        success = false,
                        message = string.Format("Could not upload the replay - {0}", ex.Message)
                    }
                };
            }
            */
        }

        [HttpPost]
        public JsonResult SetTitle(int replayId, string token, string newTitle)
        {
            throw new NotImplementedException();

            /*if (HttpContext.Session == null) return Json(new {});

            var replayToken = HttpContext.Session["replay" + replayId];
            var tokenString = replayToken as string;
            if (replayToken == null || tokenString != token)
            {
                return Json(new {});
            }

            var replay = _replayRepository.GetById(replayId);
            if(replay == null) throw new NotSupportedException();

            replay.Title = newTitle;
            _replayRepository.Save(replay);

            return Json(new {success = true});*/
        }

        public FileResult GetReplayFile(int replayId)
        {
            throw new NotImplementedException();

            /*var replay = _replayRepository.GetById(replayId);
            var path = Path.Combine(Server.MapPath("~/App_Data/replays"), replay.Link);

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            replay.DownloadsCounter++;
            _replayRepository.Save(replay);

            using (var zipStream = new MemoryStream())
            {
                using (var zip = new ZipFile())
                {
                    zip.AddEntry(replay.Title + ".wargamerpl2", fileBytes);
                    zip.Save(zipStream);
                }
                
                return File(zipStream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Zip, replay.Title + ".zip");
            }*/
        }
    }
}
