using System;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos;
using Wrc.Web.Models;
using Wrc.Web.Services.Replays;
using System.Collections.Generic;
using Wrc.Web.Dtos.Replays;

namespace Wrc.Web.Controllers.Replays
{
    [Route("api/replays")]
    public class ReplaysController : Controller
    {
        private readonly IReplayService _replayService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public ReplaysController(
            IUnitOfWorkFactory uowFactory,
            IReplayService replayService)
        {
            _uowFactory = uowFactory;
            _replayService = replayService;
        }

        //
        // GET: /Replays/List
        public IActionResult Details(int replayId)
        {
            throw new NotImplementedException();
            /*if (replayId <= 0)
                return NotFound();

            var dto = _replayRepository.GetReplayCard(replayId);

            if (dto == null)
                return NotFound();

            dto;*/
        }

        [HttpGet]
        [Route("/replays/list")]
        public async Task<ReplayListModel> ListAsync(int startIndex, int pageSize, string searchText)
        {
            return new ReplayListModel(new List<ReplayRowDto>());
            var pagingInfo = new PagingInfo(startIndex, pageSize);

            using (var uow = _uowFactory.Create())
            {
                var replays = await uow.ReplayRepository.ListAsync(pagingInfo, searchText);

                return new ReplayListModel(replays);
            }
        }

        //
        // GET: /Replays/List
        public ReplayListModel GetByPlayerUser(int playerId, int startIndex, int pageSize)
        {
            var pagingInfo = new PagingInfo(startIndex, pageSize);

            using (var uow = _uowFactory.Create())
            {
                var dtos = uow.ReplayRepository.GetByPlayerUser(playerId, pagingInfo);
                return new ReplayListModel(dtos);
            }
        }

        [HttpGet]
        public int GetCount(string searchText)
        {
            using (var uow = _uowFactory.Create())
            {
                return uow.ReplayRepository.GetTotalCount(searchText);
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
                if (_replayService.IsAlreadyUploaded(file.InputStream, out title))
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
            var path = Path.Combine(Server.MapPath("~/App_Data/replays"), replay.Link);

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