using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wrc.Web.Domain;
using Wrc.Web.Dtos;
using Wrc.Web.Models;
using Wrc.Web.Services.Replays;

namespace Wrc.Web.Controllers.Replays
{
    public class ReplaysController : Controller
    {
        private readonly IReplayService _replayService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ReplaysController(
            IUnitOfWorkFactory unitOfWorkFactory,
            IReplayService replayService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _replayService = replayService;
        }

        //
        // GET: /Replays/List
        public IActionResult Details(int replayId)
        {
            throw new NotImplementedException();
            /*if (replayId <= 0)
                return NotFound();

            var dto = _replayRepository.GetReplayAsync(replayId);

            if (dto == null)
                return NotFound();

            dto;*/
        }

        [HttpGet]
        public async Task<ReplayListModel> ListAsync(int startIndex, int pageSize, string searchText)
        {
            var pagingInfo = new PagingInfo(startIndex, pageSize);

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var replays = await unitOfWork.ReplayRepository
                    .ListAsync(pagingInfo, searchText)
                    .ConfigureAwait(false);

                return new ReplayListModel(replays);
            }
        }

        [HttpGet]
        public async Task<ReplayListModel> GetByPlayerUserAsync(int playerId, int startIndex, int pageSize)
        {
            var pagingInfo = new PagingInfo(startIndex, pageSize);

            using (var uow = _unitOfWorkFactory.Create())
            {
                var replays = await uow.ReplayRepository
                    .GetByAccountAsync(playerId, pagingInfo)
                    .ConfigureAwait(false);

                return new ReplayListModel(replays);
            }
        }

        [HttpGet]
        public async Task<int> GetCount(string searchText)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return await uow.ReplayRepository.GetTotalCountAsync(searchText);
            }
        }

        //
        // POST: /Replays/Upload
        [HttpPost]
        public JsonResult Upload( /*HttpPostedFileBase file*/)
        {
            throw new NotImplementedException();
            /*try
            {
                var filename = Path.GetFileName(file.FileName);

                if (filename == null) throw new NotSupportedException();

                var randomFilename = Path.GetRandomFileName();
                string title;
                if (_replayService.IsAlreadyUploadedAsync(file.InputStream, out title))
                    return Json(new
                    {
                        success = false,
                        message = string.Format("Replay is already uploaded with title - '{0}'.", title)
                    });

                var replay = _replayService.SaveReplayAsync(file.InputStream, randomFilename);

                var path = Path.Combine(Server.MapPath("~/App_Data/replays"), randomFilename);
                file.SaveAs(path);

                var replayToken = string.Empty;

                if (HttpContext.Session != null)
                {
                    var hashedReplaySeed = PasswordHasher<>.Hash(replay.Seed);
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
            }*/
        }

        [HttpPost]
        public JsonResult SetTitle(int replayId, string token, string newTitle)
        {
            throw new NotImplementedException();
            /*if (HttpContext.Session == null) return Json(new { });

            var replayToken = HttpContext.Session["replay" + replayId];
            var tokenString = replayToken as string;
            if (replayToken == null || tokenString != token)
                return Json(new { });

            var replay = _replayRepository.GetById(replayId);
            if (replay == null) throw new NotSupportedException();

            replay.Title = newTitle;
            _replayRepository.Save(replay);

            return Json(new {success = true});*/
        }

        public FileResult GetReplayFile(int replayId)
        {
            throw new NotImplementedException();
            /*var replay = _replayRepository.GetById(replayId);
            var path = Path.Combine(Server.MapPath("~/App_Data/replays"), replay.DownloadLink);

            var fileBytes = System.IO.File.ReadAllBytes(path);

            replay.DownloadsCounter++;
            _replayRepository.Save(replay);

            using (var zipStream = new MemoryStream())
            {
                using (var zip = new ZipFile())
                {
                    zip.AddEntry(replay.Title + ".wargamerpl2", fileBytes);
                    zip.Save(zipStream);
                }

                return File(zipStream.ToArray(), MediaTypeNames.Application.Zip, replay.Title + ".zip");
            }*/
        }
    }
}