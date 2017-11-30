using System;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wrc.Web.Domain;
using Wrc.Web.Dtos;
using Wrc.Web.Filters;
using Wrc.Web.Models;
using Wrc.Web.Models.Api;
using Wrc.Web.Services.Replays;

namespace Wrc.Web.Controllers
{
    [Route("api/replays")]
    public class ReplayController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IReplayService _replayService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ReplayController(
            IUnitOfWorkFactory unitOfWorkFactory,
            IReplayService replayService,
            IHostingEnvironment env)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _replayService = replayService;
            _env = env;
        }

        [HttpGet("{replayId}")]
        public async Task<IActionResult> DetailsAsync(int replayId)
        {
            if (replayId <= 0)
            {
                return NotFound();
            }

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var replay = await unitOfWork.ReplayRepository.GetReplayAsync(replayId);

                if (replay == null)
                {
                    return NotFound();
                }

                return Ok(new ApiOkResponse(new ReplayCardModel(replay)));
            }
        }

        [HttpGet("")]
        [ApiValidationFilter]
        public async Task<IActionResult> GetReplayListAsync(GetReplayListRequest request)
        {
            var pagingInfo = request.ToPagingInfo();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var replays = await unitOfWork.ReplayRepository
                    .ListAsync(pagingInfo, request.SearchText)
                    .ConfigureAwait(false);

                return Ok(new ApiOkResponse(new ReplayListModel(replays)));
            }
        }

        [HttpGet("getByAccount/{playerId}")]
        public async Task<IActionResult> GetByPlayerUserAsync(
            int playerId,
            int start,
            int limit)
        {
            var pagingInfo = new PagingInfo(start, limit);

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var replays = await unitOfWork.ReplayRepository
                    .GetByAccountAsync(playerId, pagingInfo)
                    .ConfigureAwait(false);

                return Ok(new ReplayListModel(replays));
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCountAsync(string searchText)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return Ok(
                    await unitOfWork.ReplayRepository
                        .GetTotalCountAsync(searchText)
                        .ConfigureAwait(false));
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync(IFormFile formFile)
        {
            if (formFile.Length == 0)
            {
                return BadRequest(new ApiResponse(400, "File is empty."));
            }

            var randomFileName = Path.GetRandomFileName();

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream)
                    .ConfigureAwait(false);
                var replay = await _replayService.GetByFileHashAsync(memoryStream)
                    .ConfigureAwait(false);

                if (replay != null)
                {
                    throw new Exception($"Replay is already uploaded with title - '{replay.Title}'.");
                }

                replay = await _replayService
                    .SaveReplayAsync(memoryStream, randomFileName)
                    .ConfigureAwait(false);

                var filePath = GetReplayFilePath(randomFileName);

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream).ConfigureAwait(false);
                    }
                }

                var replayToken = string.Empty;

                /*if (HttpContext.Session != null)
                {
                    var hashedReplaySeed = PasswordHasher<>.Hash(replay.GameInfo.Seed);
                    HttpContext.Session["replay" + replay.Id] = replayToken = hashedReplaySeed.Hash;
                }*/

                return Ok(
                    new
                    {
                        replayId = replay.Id,
                        success = true,
                        token = replayToken
                    });
            }
        }

        private string GetReplayFilePath(string fileName)
        {
            return _env.WebRootPath + Path.DirectorySeparatorChar + fileName;
        }

        [HttpPost("{replayId}/setTitle")]
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

        [HttpGet("{replayId}/download")]
        public async Task<IActionResult> GetReplayFileAsync(int replayId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var replay = await unitOfWork.ReplayRepository.GetReplayAsync(replayId);
                var path = GetReplayFilePath(replay.UploadedFile.FileName);

                await unitOfWork.ReplayRepository.IncrementDownloadCountAsync(replay.Id);

                using (var fileStream = System.IO.File.OpenRead(path))
                {
                    using (var zipArchiveStream = new MemoryStream())
                    {
                        using (var zipArchive = new ZipArchive(zipArchiveStream))
                        {
                            var zipEntry = zipArchive.CreateEntry(replay.Title + ".wargamerpl2");
                            using (var zipStream = zipEntry.Open())
                            {
                                await fileStream.CopyToAsync(zipStream);
                            }

                            await unitOfWork.SaveChangesAsync();

                            return File(
                                zipArchiveStream,
                                MediaTypeNames.Application.Zip,
                                replay.Title + ".zip");
                        }
                    }
                }
            }
        }
    }
}